using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.general
{
    public enum PESUEatsRoles
    {
        admin,
        customer,
        restaurant,
        da
    }

    public class ErrorMessage
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = "No error message";

        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
