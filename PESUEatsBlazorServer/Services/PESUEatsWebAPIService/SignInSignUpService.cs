using PESUEatsBlazorServer.JSONBodyFormats.Signin;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using PESUEatsBlazorServer.JSONBodyFormats.signup;
using PESUEatsBlazorServer.JSONBodyFormats.app.restaurant;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public partial class PESUEatsWebAPIService
    {
        private readonly HttpClient client;

        public PESUEatsWebAPIService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<(bool, string)> SignupCustomerAsync(CustomerJSONRequest customer)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("/signup/customer", customer);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    CustomerJSONResponse200? custRes200 = await JsonSerializer.DeserializeAsync<CustomerJSONResponse200>(responseContent);
                    if (custRes200 != null)
                    {
                        return (true, $"Hey {custRes200.Name}! You successfully Signed up.\n Click close to go and sign in.");
                    }
                    else
                    {
                        return (false, "devError: error serializing JSON");
                    }
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, $"Error in signing up: {error.Message}");
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
        }


        public async Task<(bool, string)> SignupRestaurantAsync(RestaurantJSONRequest customer)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("/signup/restaurant", customer);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    RestaurantJSONResponse200? custRes200 = await JsonSerializer.DeserializeAsync<RestaurantJSONResponse200>(responseContent);
                    if (custRes200 != null)
                    {
                        return (true, $"Hey {custRes200.Name}! You successfully Signed up.\n Click close to go and sign in.");
                    }
                    else
                    {
                        return (false, "devError: error serializing JSON");
                    }
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, $"Error in signing up: {error.Message}");
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
        }


        public async Task<(bool, string)> SignupDaAsync(DaJSONRequest customer)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("/signup/da", customer);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    DaJSONResponse200? custRes200 = await JsonSerializer.DeserializeAsync<DaJSONResponse200>(responseContent);
                    if (custRes200 != null)
                    {
                        return (true, $"Hey {custRes200.Name}! You successfully Signed up.\n Click close to go and sign in.");
                    }
                    else
                    {
                        return (false, "devError: error serializing JSON");
                    }
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, $"Error in signing up: {error.Message}");
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
        }


        public async Task<(bool, string, PESUEatsRoles?)> SignInUserAsync(UserJSONRequest user)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("/signin", user);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    UserJSONResponse200? res200 = await JsonSerializer.DeserializeAsync<UserJSONResponse200>(responseContent);
                    if (res200 != null)
                    {
                        return (true, res200.Token, res200.GetRole());
                    }
                    else
                    {
                        return (false, "devError: error serializing JSON", null);
                    }
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, $"Error in signing up: {error.Message}", null);
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message, null);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message, null);
            }
        }
    }
}
