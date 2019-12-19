using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeAppEip.Web.ViewModels.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 类型 1新闻 2活动
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        public int? Order { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
