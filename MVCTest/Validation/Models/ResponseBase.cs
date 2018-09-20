namespace Validation.Models
{
    public class ResponseBase<T>
    {
        public bool Status { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}