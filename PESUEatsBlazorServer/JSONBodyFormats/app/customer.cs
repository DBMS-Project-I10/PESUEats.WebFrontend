using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.app.customer
{
	public class AddToCartJSONRequest
	{
		[JsonPropertyName("itemid")]
		public int ItemId { get; set; }

		[JsonPropertyName("cartid")]
		public int CartId { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		public AddToCartJSONRequest(int itemId, int cartId, int quantity)
		{
			this.ItemId = itemId;
			this.CartId = cartId;
			this.Quantity = quantity;
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

	public class RemoveFromCartJSONRequest
	{
		[JsonPropertyName("itemid")]
		public int ItemId { get; set; }

		[JsonPropertyName("cartid")]
		public int CartId { get; set; }

		public RemoveFromCartJSONRequest(int itemId, int cartId)
		{
			this.ItemId = itemId;
			this.CartId = cartId;
		}
	}


	public class RemoveFromCartJSONResponse200
	{
		[JsonPropertyName("message")]
		public string Message { get; set; }

		public RemoveFromCartJSONResponse200(string message)
		{
			this.Message = message;
		}
	}

	public class ShowCartJSONResponse200
	{
		[JsonPropertyName("iid")]
		public int id { get; set; }

		[JsonPropertyName("iname")]
		public string Name { get; set; }

		[JsonPropertyName("iprice")]
		public float Price { get; set; }

		[JsonPropertyName("miquantity")]
		public int Quantity { get; set; }

		public ShowCartJSONResponse200(int id, string name, float price, int quantity)
		{
			this.id = id;
			this.Name = name;
			this.Price = price;
			this.Quantity = quantity;
		}
	}

}
