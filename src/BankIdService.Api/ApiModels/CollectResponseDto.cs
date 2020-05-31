namespace BankIdService.Api.ApiModels
{
    public class CollectResponseDto
    {
        public string OrderRef { get; set; }
        public string Status { get; set; }

        public string PersonalNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string IpAddress { get; set; }
    }
}
