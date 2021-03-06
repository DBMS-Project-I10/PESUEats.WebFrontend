using PESUEatsBlazorServer.JSONBodyFormats.app.customer;
using PESUEatsBlazorServer.JSONBodyFormats.app.restaurant;
using PESUEatsBlazorServer.JSONBodyFormats.app.shared;
using PESUEatsBlazorServer.JSONBodyFormats.general;
using System.Text.Json;

namespace PESUEatsBlazorServer.Services
{
    public partial class PESUEatsWebAPIService
    {

        public async Task<(bool, OrdersCurrentJSONResponse200?, string?)>
            GetDACurrentOrder(string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                response = await client.GetAsync("/daorder");

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

        public async Task<(bool, string?)>
            ChangeStatusToDelivered(string token)
        {
            try
            {
                HttpResponseMessage response;
                client.DefaultRequestHeaders.Add("token", token);
                //TODO
                response = await client.GetAsync("/changestatus/delivered");

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
