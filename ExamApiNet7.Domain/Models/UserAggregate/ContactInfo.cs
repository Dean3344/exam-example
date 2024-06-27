namespace ExamApiNet7.Domain.Models.UserAggregate
{
    public class ContactInfo
    {
        public Guid UserId { get; init; }

        public string Email { get; private set; }

        public string PhoneNo { get; private set; }

        internal ContactInfo(string email, string phoneNo)
        {
            Email = email;
            PhoneNo = phoneNo;
        }

        internal void Update(string email, string phoneNo)
        {
            Email = email;
            PhoneNo = phoneNo;
        }
    }
}
