namespace MariyaCompany.Application.Abstractions.Responses
{
    public class BaseResponce
    {
        public bool IsSuccess { get; set; } = true;

        public string ErrorMessage { get; set; }
    }
}
