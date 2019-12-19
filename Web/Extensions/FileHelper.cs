using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Options;
using WeAppEip.Web.ViewModels.Configuration;
using Encoder = System.Drawing.Imaging.Encoder;

namespace WeAppEip.Web.Extensions
{
    public class FileHelper
    {
        //private static Logger logger = Logger.CreateLogger();

        #region 将文件流转成图片

        /// <summary>
        /// 将文件流转成图片
        /// </summary>
        /// <param name="stream">字节流</param>
        /// <param name="fileName">文件路径</param>
        /// <param name="IsCompress">是否压缩</param>
        /// <returns>返回相对路径</returns>
        public static string StreamToFile(Stream stream, string fileName, bool IsCompress = true, long quality = 50L)
        {
            if (stream == null || string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException();
            }

            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                //文件相对路径
                string relativePath = fileName.Replace("\\", "/").ToLower();
                relativePath = relativePath.Substring(relativePath.IndexOf("upload") - 1, relativePath.Length - relativePath.IndexOf("upload") + 1);

                // 把 Stream 转换成 byte[]
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                // 设置当前流的位置为流的开始
                stream.Seek(0, SeekOrigin.Begin);

                if (IsCompress && IsImage(fileName))
                {
                    // 不超过1M不进行压缩
                    if (stream.Length > 512 * 1024)
                    {
                        bytes = CompressionImage(stream, quality, 1.5);
                    }
                }

                // 把 byte[] 写入文件
                fs = new FileStream(fileName, FileMode.Create);
                bw = new BinaryWriter(fs);
                bw.Write(bytes);


                return relativePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bw?.Close();
                fs?.Close();
            }
        }
        #endregion

        #region 获取文件扩展名
        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFilePostfix(string fileName)
        {
            string result = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentNullException();
                }

                result = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region 获取文件名
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileNameByPath(string filePath)
        {
            string result = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException();
                }

                if (filePath.Contains("\\"))
                {
                    result = filePath.Substring(filePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        #endregion

        #region 根据key获取上传的物理路径
        /// <summary>
        /// 根据key获取上传的物理路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetFolderPathByKey(string key)
        {
            string path = Environment.CurrentDirectory + "/wwwroot/upload/";

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }

            try
            {
                switch (key.ToLower())
                {
                    case "banner":
                        path += "banner/";
                        break;
                    case "news":
                        path += "news/"; 
                        break;
                    case "richtext":
                        path += "richtext/"; 
                        break;
                    default:
                        path += "" + key + "/";
                        break;
                }

#if !DEBUG
                    path = path.Replace("\\", "/");
#endif

                //判断路径是否存在，不存在添加
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                //logger.Error($"获取文件夹路径失败[GetFolderPath（key：{key})]!");
            }

            return path;
        }
        #endregion

        #region 获取文件完整路径
        /// <summary>
        /// 获取文件完整路径（文件名自动生成）
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="fileName">文件名称（包含扩展名）</param>
        /// <returns></returns>
        public static string GetFileFullPathByKey(string key, string fileName)
        {
            return GetFolderPathByKey(key) + Guid.NewGuid().ToString().Replace("-", "") + GetFilePostfix(fileName);
        }
        #endregion

        #region 压缩图片
        /// <summary>
        /// 壓縮圖片 /// </summary>
        /// <param name="fileStream">圖片流</param>
        /// <param name="quality">壓縮質量0-100之間 數值越大質量越高</param>
        /// <returns></returns>
        private static byte[] CompressionImage(Stream fileStream, long quality)
        {
            using (Image img = Image.FromStream(fileStream))
            using (Bitmap bitmap = new Bitmap(img))
            {
                ImageCodecInfo[] array = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo CodecInfo = array.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));

                //ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, CodecInfo, myEncoderParameters);
                    myEncoderParameters.Dispose();
                    myEncoderParameter.Dispose();
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// 壓縮圖片 /// </summary>
        /// <param name="fileStream">圖片流</param>
        /// <param name="quality">壓縮質量0-100之間 數值越大質量越高</param>
        /// <param name="multiple">收缩倍数</param>
        /// <returns></returns>
        private static byte[] CompressionImage(Stream fileStream, long quality, double multiple)
        {
            using (Image img = Image.FromStream(fileStream))
            {
                float xWidth = img.Width;
                float yWidth = img.Height;

                using (Bitmap bitmap = new Bitmap(img, (int)(xWidth / multiple), (int)(yWidth / multiple)))
                {
                    ImageCodecInfo[] array = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo CodecInfo = array.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));

                    //ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
                    Encoder myEncoder = Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    //质量压缩
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    //尺寸压缩
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(bitmap, 0, 0, (int)(xWidth / multiple), (int)(yWidth / multiple));
                    g.Dispose();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, CodecInfo, myEncoderParameters);
                        myEncoderParameters.Dispose();
                        myEncoderParameter.Dispose();
                        return ms.ToArray();
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                { return codec; }
            }
            return null;
        }
        #endregion

        #region 根据图片路径返回图片的字节流byte[]
        /// <summary>
        /// 根据图片路径返回图片的字节流byte[]
        /// </summary>
        /// <returns>返回的字节流</returns>
        //private static byte[] GetImageByte(MediaTypeNames.Image img)
        //{
        //    try
        //    {
        //        ImageConverter imgconv = new ImageConverter();
        //        byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));

        //        return b;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region 字节流转Stram
        /// <summary>
        /// 字节流转Stram
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static Stream BytesToStream(byte[] bytes)
        {
            try
            {
                Stream stream = new MemoryStream(bytes);
                return stream;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 根据图片路径获取Stram
        /// <summary>
        /// 根据图片路径获取Stram
        /// </summary>
        /// <returns></returns>
        //public static Stream GetStreamByImage(MediaTypeNames.Image img)
        //{
        //    return BytesToStream(GetImageByte(img));
        //}
        #endregion

        #region 根据文件名判断是否为图片
        /// <summary>
        /// 根据文件名判断是否为图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool IsImage(string fileName)
        {
            bool isJPG = false;

            try
            {
                //Image img = Image.FromFile(fileName);
                //if (img.RawFormat.Equals(ImageFormat.Jpeg))
                //{
                //    isJPG = true;
                //}

                string fix = GetFilePostfix(fileName).ToUpper();
                if (fix == ".BMP" || fix == ".JPG" || fix == ".JPEG" || fix == ".PNG" || fix == ".GIF")
                {
                    isJPG = true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return isJPG;
        }
        #endregion
    }
}
