using Gallery.Core.Models;

namespace Gallery.Application.Auth;
public interface IJwtProvider
{
    string Generate(User user);
}