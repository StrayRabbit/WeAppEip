using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAppEip.Web.ViewModels.Banner
{
    public class BannerViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
    }
}
