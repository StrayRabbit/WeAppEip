using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeAppEip.Web.Extensions;
using WeAppEip.Web.ViewModels;
using WeAppEip.Web.ViewModels.Configuration;

namespace Web.Areas.System.Controllers
{
    public class UploadFileController : BaseController
    {
        private readonly ConfigurationFile _configuration;
        public UploadFileController(IOptions<ConfigurationFile> configuration)
        {
            _configuration = configuration.Value;
        }

        #region 上传文件

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="name">上传控件name</param>
        /// <param name="folderName">文件夹名字</param>
        public JsonResult UploadFile(string name, string folderName)
        {
            var json = new JsonModel { Code = 200, Msg = "上传成功!" };
            try
            {
                var files = Request.Form.Files[name];

                if (files != null)
                {
                    json.Data = FileHelper.StreamToFile(files.OpenReadStream(), FileHelper.GetFileFullPathByKey(folderName, files.FileName));
                }
            }
            catch (Exception)
            {
                json.Code = 500;
                json.Msg = "上传失败!";
            }

            return Json(json);
        }

        /// <summary>
        /// 上传多张图片
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        //public JsonResult UploadMultipleFile(string folderName)
        //{
        //    JsonResult result = new JsonResult
        //    {
        //        ContentEncoding = Encoding.UTF8,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //    HttpFileCollectionBase files = Request.Files;
        //    List<string> urls = new List<string>();
        //    for (int i = 0; i < files.Count; i++)
        //    {
        //        HttpPostedFileBase file = files[i];
        //        if (file == null || file.ContentLength <= 0) continue;
        //        string fileName = FileHelper.GetFileFullPathByKey(folderName, file.FileName);
        //        string filePath = FileHelper.StreamToFile(file.InputStream, fileName);
        //        urls.Add("/" + filePath.Replace(@"\", "/"));
        //    }
        //    result.Data = new { Code = HttpStatusCode.OK, Message = string.Join(",", urls) };
        //    return result;
        //}
        #endregion

        #region 删除上传图片

        /// <summary>
        /// 
        /// </summary>
        public JsonResult DelePic(string key)
        {
            return Json("");
        }

        #endregion

        #region 获取图片列表
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<string> GetPicUrls(int id, int type)
        //{
        //    try
        //    {
        //        List<string> list = await _pictureService.GetPictures(id, type);
        //        string result = Newtonsoft.Json.JsonConvert.SerializeObject(list);

        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region 添加图片
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="urls">连接串</param>
        /// <param name="targetId"></param>
        /// <param name="type"></param>
        //public void InsertPicByUrls(string urls, int targetId, int type)
        //{
        //    //删除附件内容
        //    _pictureService.Delete(targetId, type);

        //    if (!string.IsNullOrEmpty(urls) && targetId > 0)
        //    {
        //        List<Picture> list = new List<Picture>();

        //        foreach (string url in urls.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            Picture pic = new Picture
        //            {
        //                ImageUrl = url,
        //                Type = type,
        //                TargetId = targetId
        //            };

        //            list.Add(pic);
        //        }

        //        if (list.Count > 0)
        //            _pictureService.Insert(list);
        //    }
        //}
        #endregion

        #region 富文本控件上传图片
        /// <summary>
        /// 富文本控件上传图片
        /// </summary>
        public IActionResult RichTextControlUpload(IFormFile upload, string CKEditorFuncNum)
        {
            Response.ContentType = "text/html";

            if (upload == null)
            {
                return Content($"<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum},'','没有要上传的图片！');</script>");
            }
            FileInfo info = new FileInfo(upload.FileName);
            string extention = info.Extension;

            string[] allowUploadImageType = { ".jpg", ".png", ".bmp", ".doc", ".docx", ".xls", ".xlsx" };
            if (!allowUploadImageType.Any(t => t.Equals(extention, StringComparison.CurrentCultureIgnoreCase)))
            {
                return Content($"<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum},'','上传图片的格式不合法！目前仅支持jpg,png,bmp 格式的图片！');</script>");
            }

            string fileName = FileHelper.GetFileFullPathByKey("richtext", upload.FileName);
            string filePath = FileHelper.StreamToFile(upload.OpenReadStream(), fileName);
            filePath = @"/" + filePath.Replace(@"\", "/");
            filePath = Request.Scheme + "://" + Request.Host + filePath;
            string message = $"<script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum},'{filePath}');</script>";

            return Content(message);
        }
        #endregion
    }
}