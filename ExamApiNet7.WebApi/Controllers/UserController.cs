using ExamApiNet7.Domain.Models.UserAggregate;
using ExamApiNet7.Infrastructure.Repositories;
using ExamApiNet7.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApiNet7.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserRepository _repository;

		public UserController(ILogger<UserController> logger, IUserRepository repository)
		{
			_logger = logger;
			_repository = repository;

		}

		[HttpGet("")]
		public async Task<IActionResult> GetAsync([FromQuery] Guid id)
		{
			var user = await _repository.Users.Include(x => x.ContactInfo).Where(x => x.Id == id).FirstOrDefaultAsync();


			return Ok(user == null ? new UserResponse() : new UserResponse()
			{
				Id = id,
				AccountName = user.AccountName,
				FamilyName = user.FamilyName,
				GivenName = user.GivenName,
				Gender = user.Gender,
				Birthday = user.Birthday,
				Email = user.ContactInfo.Email,
				Phone = user.ContactInfo.Email
			});
		}


		[HttpGet("list")]
		public async Task<IEnumerable<UserListResponse>> ListAsync()
		{
			var users = await _repository.Users.Include(x => x.ContactInfo).ToListAsync();

			return users.Select(x => new UserListResponse()
			{
				AccountName = x.AccountName,
				FullName = $"{x.GivenName}, {x.FamilyName}",
				Gender = x.Gender,
				Birthday = x.Birthday,
				CreateTime = x.CreateTime,
				Email = x.ContactInfo.Email,
				PhoneNo = x.ContactInfo.PhoneNo,
				Id = x.Id
			}).ToList();
		}


		[HttpPost("")]
		public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequest request)
		{
			var user = new User(request.AccountName, request.GivenName, request.FamilyName, request.Gender,
				request.Birthday, request.Email, request.Phone);

			await _repository.Users.AddAsync(user);
			await _repository.SaveChangesAsync();


			return Ok();
		}

		[HttpPut("")]
		public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateRequest request)
		{
			var user = await _repository.Users.Include(x => x.ContactInfo).Where(x => x.Id == request.Id).FirstOrDefaultAsync();

			user!.Update(request.GivenName, request.FamilyName, request.Gender, request.Birthday, request.Email, request.Phone);
			await _repository.SaveChangesAsync();


			return Ok();
		}

		[HttpDelete("")]
		public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
		{
			var user = await _repository.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

			if (user == null) return BadRequest("no item");

			_repository.Users.Remove(user);
			await _repository.SaveChangesAsync();

			return Ok();
		}
	}
}
