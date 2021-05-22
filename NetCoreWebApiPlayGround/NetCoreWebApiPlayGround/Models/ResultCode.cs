using System.ComponentModel;

namespace NetCoreWebApiPlayGround.Models
{
    public enum ResultCode
    {
        /// <summary>
        /// 執行成功
        /// </summary>
        [Description("1.0")]
        Success = 1,

        /// <summary>
        /// 未知的錯誤
        /// </summary>
        [Description("-1.0")]
        OtherException = -1,

        /// <summary>
        /// Model 無效
        /// </summary>
        [Description("-2")]
        ModelInvalid = -2,
    }
}