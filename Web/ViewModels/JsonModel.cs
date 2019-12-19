using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAppEip.Web.ViewModels
{
    public class JsonModel
    {
        /// <summary>
        /// 数据码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据包
        /// </summary>
        public object Data { get; set; }
    }
}
