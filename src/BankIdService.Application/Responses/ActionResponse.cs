namespace BankIdService.Application.Responses
{
    public class ActionResponse<T>
    {
        public ActionResponse(bool isSuccessful = false)
        {
            IsSuccessful = isSuccessful;
        }

        public bool IsSuccessful { get; private set; }
        public T Payload { get; set; }
    }
}
