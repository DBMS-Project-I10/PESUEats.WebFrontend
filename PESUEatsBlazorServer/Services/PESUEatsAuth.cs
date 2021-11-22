using Microsoft.AspNetCore.Components.Authorization;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using PESUEatsBlazorServer.JSONBodyFormats.signup;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.Services
{
    public class User
    {
        [JsonPropertyName("token")]
        public string Token { get; private set; }

        [JsonPropertyName("username")]
        public string Email { get; set; }

        [JsonPropertyName("role")]
        public PESUEatsRoles Role { get; set; }

        public User(string token, string username, PESUEatsRoles roles)
        {
            this.Token = token;
            this.Email = username;
            this.Role = roles;
        }
    }


    public class PESUEatsAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            /*var usernameClaim = new Claim(ClaimTypes.Name, Username);*/
            var identity = new ClaimsIdentity(/*new[] { usernameClaim }, "PESUEatsPostgresAuth"*/);
            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        /*
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "noauth"));
            var identity = new ClaimsIdentity(claims, "LocalAuth");
            var user = new ClaimsPrincipal(identity);

            /// THis means that a user authorized with "noauth" is actually unauthorized even though they may show up as Authed
            /// This means that auth has to be used at all costs

            return Task.FromResult(new AuthenticationState(user));
        }
        */

        public string GetAuthToken(ClaimsPrincipal AuthenticationStateUser)
        {
            Claim? tokenClaim = AuthenticationStateUser.Claims.Where(i => i.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber").FirstOrDefault();
            return tokenClaim == null ? "" : tokenClaim.Value;
        }

        public void SigninUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString("G")));
            claims.Add(new Claim(ClaimTypes.SerialNumber, user.Token));
            var identity = new ClaimsIdentity(claims, "PESUEatsPostgresAuth");
            var principal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public bool SignoutUser()
        {
            try
            {
                /*var usernameClaim = new Claim(ClaimTypes.Name, Username);*/
                var identity = new ClaimsIdentity(/*new[] { usernameClaim }, "PESUEatsPostgresAuth"*/);
                var user = new ClaimsPrincipal(identity);
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
