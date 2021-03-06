﻿using System.Web.Mvc;

namespace InputValidation.Filters
{ 
    public class AjaxFilterAttribute : FilterAttribute
    {
        /// <summary>
        /// 是否將錯誤用 partial view 的方式傳回前端
        /// </summary>
        public bool ReturnPartialView { get; set; }
    }
}