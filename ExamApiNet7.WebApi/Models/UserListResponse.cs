namespace ExamApiNet7.WebApi.Models
{
	public class UserListResponse
	{
		public Guid Id { get; set; }
		public string AccountName { get; set; } = string.Empty;
		public string FullName { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public string PhoneNo { get; set; } = string.Empty;

		public DateTime Birthday { get; set; }

		public DateTime CreateTime { get; set; }
	}
}
