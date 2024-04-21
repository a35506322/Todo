namespace Todo.API.Domain.Request.Post;

public record PostSignInRequest([Required] string Account, [Required] string Password);

