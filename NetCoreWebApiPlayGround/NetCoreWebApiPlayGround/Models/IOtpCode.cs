using System.ComponentModel.DataAnnotations;

namespace NetCoreWebApiPlayGround.Models
{
    public interface IOtpCode
    {
        public string OtpCode { get; set; }
    }
}