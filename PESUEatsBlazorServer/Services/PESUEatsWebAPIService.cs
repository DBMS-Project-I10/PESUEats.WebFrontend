using PESUEatsBlazorServer.JSONBodyFormats.Signin;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using PESUEatsBlazorServer.JSONBodyFormats.signup;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public class PESUEatsWebAPIService
    {
        private readonly HttpClient client;

        public PESUEatsWebAPIService(HttpClient client)
        {
            this.client = client;
        }

        /*
        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            var response = await client.GetAsync("restaurants");
            //response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<Restaurant>>(responseContent);
        }

        public async Task<List<User>>? GetUsersAsync(string? username)
        {
            User admin = new User("Admin", "1234", new[] { "" });
            HttpResponseMessage response;
            if (username == null)
                response = await client.PostAsJsonAsync("users", admin);
            else
                response = await client.PostAsJsonAsync($"users/{username.ToLower()}", admin);

            if (response.IsSuccessStatusCode)
            {
                using var responseContent = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<User>>(responseContent);
            }
            else
            {
                return null;
            }
        }
        */

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
                        return (true, $"Hey {custRes200.Email}! You successfully Signed up.\n Click close to go and sign in.");
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
                    CustomerJSONResponse200? custRes200 = await JsonSerializer.DeserializeAsync<CustomerJSONResponse200>(responseContent);
                    if (custRes200 != null)
                    {
                        return (true, $"Hey {custRes200.Email}! You successfully Signed up.\n Click close to go and sign in.");
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
                    CustomerJSONResponse200? custRes200 = await JsonSerializer.DeserializeAsync<CustomerJSONResponse200>(responseContent);
                    if (custRes200 != null)
                    {
                        return (true, $"Hey {custRes200.Email}! You successfully Signed up.\n Click close to go and sign in.");
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
