using PESUEatsBlazorServer.JSONBodyFormats.Signin;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using PESUEatsBlazorServer.JSONBodyFormats.signup;
using PESUEatsBlazorServer.JSONBodyFormats.app.shared;
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
            finally
            {
                client.DefaultRequestHeaders.Clear();
            }
        }

        public async Task<(bool, List<MenuItemsJSONResponse200>?, string?)> GetMenuItemsAsync(string token, int rid)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync($"menuitems?rid={rid}");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    List<MenuItemsJSONResponse200>? menuItems = await JsonSerializer.DeserializeAsync<List<MenuItemsJSONResponse200>>(responseContent);
                    if (menuItems != null)
                    {
                        return (true, menuItems, null);
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
            finally
            {
                client.DefaultRequestHeaders.Clear();
            }
        }


        public async Task<(bool, List<OrdersCurrentJSONResponse200>?, string?)>
                GetCurrentOrdersForRestaurant (string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("/orders/current");
                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    List<OrdersCurrentJSONResponse200>? jsonResponse =
                        await JsonSerializer.DeserializeAsync<List<OrdersCurrentJSONResponse200>>(responseContent);
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

        public async Task<(bool, string?)>
            ChangeStatusToPrep (string token, ChangeStatusJSONRequest statusJSONRequest)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                //TODO
                response = await client.PostAsJsonAsync("/changestatus/preparing", statusJSONRequest);

                if ((int)response.StatusCode == 200)
                {
                    return (true, null);
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, error.Message);
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
            finally
            {
                client.DefaultRequestHeaders.Clear();
            }
        }

        public async Task<(bool, string?)>
            ChangeStatusToPickedUp (string token, ChangeStatusJSONRequest statusJSONRequest)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                //TODO
                response = await client.PostAsJsonAsync("/changestatus/pickedup", statusJSONRequest);

                if ((int)response.StatusCode == 200)
                {
                    return (true, null);
                }
                else if ((int)response.StatusCode == 400)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    ErrorMessage error = (await JsonSerializer.DeserializeAsync<ErrorMessage>(responseContent) ??
                        new ErrorMessage("No error message/JSON serialize fail"));
                    return (false, error.Message);
                }
                else
                    return (false, new ErrorMessage("Unknown Error").Message);
            }
            catch (Exception e)
            {
                return (false, new ErrorMessage($"Fatal error: {e.Message}").Message);
            }
            finally
            {
                client.DefaultRequestHeaders.Clear();
            }
        }
    }
}
