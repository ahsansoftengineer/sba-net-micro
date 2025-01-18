
namespace SBA.Auth.Model;
public class RegisterModel
{
  public string Email { get; set; }
  public string Password { get; set; }
  public string ConfirmPassword { get; set; }
}

public class LoginModel
{
  public string Email { get; set; }
  public string Password { get; set; }
  public bool RememberMe { get; set; }
}

public class ForgotPasswordModel
{
  public string Email { get; set; }
}

public class ResetPasswordModel
{
  public string Email { get; set; }
  public string Token { get; set; }
  public string NewPassword { get; set; }
}

public class ChangePasswordModel
{
  public string CurrentPassword { get; set; }
  public string NewPassword { get; set; }
  public string ConfirmPassword { get; set; }
}

public class ResendEmailConfirmationModel
{
  public string Email { get; set; }
}
