using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WeAppEip.Web.Extensions;

namespace WeAppEip.Web.ViewModels
{

    [Serializable]
    public class ReturnResult<TKey>
    {
        #region 编码

        private ReturnCode code;

        /// <summary>
        /// 编码
        /// </summary>
        public ReturnCode Code
        {
            get => code;

            set
            {
                code = value;
                message = code.GetDescription();
            }
        }

        #endregion

        #region 消息

        private string message;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message
        {
            get => message;

            set => message = value;
        }

        #endregion

        #region 内容

        private TKey data;

        /// <summary>
        /// 内容
        /// </summary>
        public TKey Data
        {
            get => data;

            set => data = value;
        }

        #endregion
    }

    public enum ReturnCode
    {
        [Description("操作成功.")]
        Success = 200,

        [Description("操作失败.请稍后重试.")]
        Fail = 201,

        [Description("系统异常.")]
        SystemException = 204,

        [Description("请求参数无效")]
        RequestPramsInvalid = 205
    }
}
