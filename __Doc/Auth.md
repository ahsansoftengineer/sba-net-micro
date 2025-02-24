Here’s a breakdown of **Auth-related endpoints** with their purpose and expected behavior:  

### **1. Authentication (Login/Signup)**  
- **`POST /auth/register`** → Register a new user.  
- **`POST /auth/login`** → Authenticate user and return token.  
- **`POST /auth/logout`** → Invalidate token and logout.  
- **`POST /auth/refresh`** → Refresh access token using refresh token.  
- **`POST /auth/verify-email`** → Verify email after registration (OTP/Token-based).  

### **2. Password Management**  
- **`POST /auth/forgot-password`** → Send password reset link/OTP.  
- **`POST /auth/reset-password`** → Reset password using token/OTP.  
- **`POST /auth/change-password`** → Change password (requires old password).  

### **3. User & Session Management**  
- **`GET /auth/me`** → Get logged-in user details.  
- **`GET /auth/sessions`** → Get active sessions/devices.  
- **`DELETE /auth/sessions/:id`** → Logout from a specific session.  

### **4. Two-Factor Authentication (2FA)**  
- **`POST /auth/enable-2fa`** → Enable 2FA (Google Authenticator, OTP).  
- **`POST /auth/verify-2fa`** → Verify 2FA code during login.  
- **`POST /auth/disable-2fa`** → Disable 2FA.  

### **5. Social Authentication**  
- **`POST /auth/google`** → Login/Register via Google.  
- **`POST /auth/facebook`** → Login/Register via Facebook.  
- **`POST /auth/apple`** → Login/Register via Apple.  

### **6. Role-Based Access Control (RBAC)**  
- **`GET /auth/roles`** → Fetch all roles.  
- **`POST /auth/assign-role`** → Assign role to user.  
- **`DELETE /auth/remove-role`** → Remove role from user.  

Let me know if you need more details! 🚀