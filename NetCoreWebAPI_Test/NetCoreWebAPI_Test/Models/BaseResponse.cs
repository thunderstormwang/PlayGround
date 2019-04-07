namespace NetCoreWebAPI_Test.Models
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}