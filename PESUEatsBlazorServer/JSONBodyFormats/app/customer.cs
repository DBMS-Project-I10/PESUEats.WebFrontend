using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.app.customer
{
	public class AddToCartJSONRequest
	{
		[JsonPropertyName("itemid")]
		public int ItemId { get; set; }

		public AddToCartJSONRequest(int id)
		{
			this.ItemId = id;
		}
	}

	public class AddToCartJSONResponse200
	{
		[JsonPropertyName("cartid")]
		public int CartId { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; }

		public AddToCartJSONResponse200(int cartId, string message)
		{
			this.CartId = cartId;
			this.Message = message;
		}
	}
}
