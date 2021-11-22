using PESUEatsBlazorServer.JSONBodyFormats.general;
using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.Signin
{
    public class UserJSONRequest
    {
        [JsonPropertyName("username")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        public UserJSONRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }

    public record UserJSONResponse200
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
        
        public UserJSONResponse200(string token, string role)
        {
            this.Token = token;
            this.Role = role;
        }

        public PESUEatsRoles GetRole()
        {
            return (PESUEatsRoles)Enum.Parse(typeof(PESUEatsRoles), Role, true);
        }

        /*
        [JsonPropertyName("role")]
        public string _role_DO_NOT_USE;

        [JsonIgnore]
        public PESUEatsRoles Role { 
            get => (PESUEatsRoles)Enum.Parse(typeof(PESUEatsRoles), _role_DO_NOT_USE, true);
            set
            {
                _role_DO_NOT_USE = value.ToString("G");
            }
        }

        public UserJSONResponse200(string token, PESUEatsRoles role)
        {
            this.Token = token;
            this.Role = role;
            this._role_DO_NOT_USE = role.ToString("G");
        }

        public UserJSONResponse200(string token, string role)
        {
            this.Token = token;
            this._role_DO_NOT_USE = role;
        }*/
    }
}
