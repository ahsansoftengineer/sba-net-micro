using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GLOB.Domain.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.Infra.Helper;
public static class HelperAuth
{
  public static string GenerateJwtToken(UserInfra user, IConfiguration config)
  {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Email),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim("UserId", user.Id)
    };

    var token = new JwtSecurityToken(
      issuer: config["Jwt:Issuer"],
      audience: config["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddHours(1),
      signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}