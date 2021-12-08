using PESUEatsBlazorServer.JSONBodyFormats.app.customer;
using PESUEatsBlazorServer.JSONBodyFormats.app.shared;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public partial class PESUEatsWebAPIService
    {

        public async Task<(bool, GetCartIdJSONResponse200?, string?)>
            GetActiveCartID (string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("getcartid");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    GetCartIdJSONResponse200? jsonResponse =
                        await JsonSerializer.DeserializeAsync<GetCartIdJSONResponse200>(responseContent);
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

        public async Task<(bool, CreateNewCartJSONResponse200?, string?)>
            CreateNewCart (string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.PostAsJsonAsync("createnewcart", "");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    CreateNewCartJSONResponse200? jsonResponse =
                        await JsonSerializer.DeserializeAsync<CreateNewCartJSONResponse200>(responseContent);
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

        public async Task<(bool, PlaceOrderJSONResponse200?, string?)>
            PlaceOrder(string token, PlaceOrderJSONRequest placeOrder)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.PostAsJsonAsync("placeorder", placeOrder);

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    PlaceOrderJSONResponse200? jsonResponse =
                        await JsonSerializer.DeserializeAsync<PlaceOrderJSONResponse200>(responseContent);
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

        public async Task<(bool, OrdersCurrentJSONResponse200?, string?)>
            GetMyCurrentOrder (string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("/orders/current");

                if ((int)response.StatusCode == 200)
                {
                    using var responseContent = await response.Content.ReadAsStreamAsync();
                    OrdersCurrentJSONResponse200? jsonResponse =
                        await JsonSerializer.DeserializeAsync<OrdersCurrentJSONResponse200>(responseContent);
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

        public async Task<(bool, List<OrdersCurrentJSONResponse200>?, string?)>
            GetOrderHistory(string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("/orders/history");

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
    }
}
