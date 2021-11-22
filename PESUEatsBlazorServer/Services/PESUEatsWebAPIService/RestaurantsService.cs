using PESUEatsBlazorServer.JSONBodyFormats.Signin;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using PESUEatsBlazorServer.JSONBodyFormats.signup;
using PESUEatsBlazorServer.JSONBodyFormats.app.restaurant;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public partial class PESUEatsWebAPIService
    {        
        public async Task<(bool, List<RestaurantsJSONResponse200>?, string?)> GetRestaurantsAsync(string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("restaurants");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    List<RestaurantsJSONResponse200>? restaurants = await JsonSerializer.DeserializeAsync<List<RestaurantsJSONResponse200>>(responseContent);
                    if (restaurants != null)
                    {
                        return (true, restaurants, null);
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
                    return (false, null, $"{error.Message}");
                }
                else
                    return (false, null, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, null, new ErrorMessage("Fatal error").Message);
            }
        }

        public async Task<(bool, List<RestaurantsJSONResponse200>?, string?)> GetMenuItemsAsync(string token, int rid)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync($"menuitems?rid={rid}");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    List<RestaurantsJSONResponse200>? restaurants = await JsonSerializer.DeserializeAsync<List<RestaurantsJSONResponse200>>(responseContent);
                    if (restaurants != null)
                    {
                        return (true, restaurants, null);
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
                    return (false, null, $"{error.Message}");
                }
                else
                    return (false, null, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, null, new ErrorMessage("Fatal error").Message);
            }
        }

    }
}
