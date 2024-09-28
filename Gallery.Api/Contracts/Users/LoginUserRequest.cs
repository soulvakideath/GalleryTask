using System.ComponentModel.DataAnnotations;

namespace Gallery.Contracts.Users;

public record LoginUserRequest(
	[Required] string Email,
	[Required] string Password);