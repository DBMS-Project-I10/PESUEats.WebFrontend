using PESUEatsBlazorServer.JSONBodyFormats.app.customer;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public partial class PESUEatsWebAPIService
    {
        public async Task<(bool, AddToCartJSONResponse200?, string?)> AddToCart(string token, AddToCartJSONRequest addToCartJSONRequest)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.PostAsJsonAsync("addtocart", addToCartJSONRequest);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    AddToCartJSONResponse200? jsonResponse =
                        await JsonSerializer.DeserializeAsync<AddToCartJSONResponse200>(responseContent);
                    if (jsonResponse != null)
                    {
                        return (true, jsonResponse, null);
                    }
                    else
                    {
                        return (false, null, "devError: error serializing JSON");
                    }
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, null, error.Message);
                }
                else
                    return (false, null, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, null, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
            finally
            {
                client.DefaultRequestHeaders.Clear();
            }
        }
    }
}
