
namespace ExamApiNet7.Domain.Models.UserAggregate
{
	public class User
	{
		public Guid Id { get; private set; }

		public string AccountName { get; private set; }

		public string GivenName { get; private set; }

		public string FamilyName { get; private set; }

		public string Gender { get; private set; }


		public DateTime Birthday { get; private set; }

		public DateTime CreateTime { get; init; }

		public DateTime? UpdateTime { get; private set; }

		public ContactInfo ContactInfo { get; private set; }

		internal User()
		{

		}
		public User(string accountName, string givenName, string familyName, string gender, DateTime birthday, string email, string phoneNo)
		{
			Id = Guid.NewGuid();
			AccountName = accountName;
			GivenName = givenName;
			FamilyName = familyName;
			Gender = gender;
			Birthday = birthday;
			ContactInfo = new ContactInfo(email, phoneNo);
		}

		public void Update(string givenName, string familyName, string gender, DateTime birthday, string email, string phoneNo)
		{
			GivenName = givenName;
			FamilyName = familyName;
			Gender = gender;
			Birthday = birthday;
			ContactInfo.Update(email, phoneNo);
			UpdateTime = DateTime.Now;

		}
	}
}
