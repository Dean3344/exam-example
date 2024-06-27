namespace ExamApiNet7.WebApi.Models
{
    public class UserCreateRequest
    {

        public string AccountName { get; set; } = null!;

        public string GivenName { get; set; } = null!;

        public string FamilyName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime Birthday { get; set; }

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

    }
}
