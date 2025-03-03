namespace GLOB.Domain.Auth;
public class RegisterDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RefreshTokenDto
{
    public string RefreshToken { get; set; }
}

public class VerifyEmailDto
{
    public string Email { get; set; }
    public string Token { get; set; }
}

public class ForgotPasswordDto
{
    public string Email { get; set; }
}

public class ResetPasswordDto
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}

public class ChangePasswordDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
public class TwoFactorDto
{
    public string Email { get; set; }
    public string Code { get; set; }
}
// Role-Based Access Control (RBAC)
public class ExternalAuthDto
{
    public string Provider { get; set; } // Google, Facebook, Apple
    public string IdToken { get; set; }  // Token from external provider
}

public class AssignRoleDto
{
    public string UserId { get; set; }
    public string Role { get; set; }
}

public class RemoveRoleDto
{
    public string UserId { get; set; }
    public string Role { get; set; }
}
