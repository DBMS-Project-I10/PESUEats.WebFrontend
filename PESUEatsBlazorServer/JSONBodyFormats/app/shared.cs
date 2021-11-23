using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.app.shared
{
	public class OrdersCurrentJSONResponse200
	{
		[JsonPropertyName("oid")]
		public int id { get; set; }

		[JsonPropertyName("ofromrid")]
		public int fromRid { get; set; }

		[JsonPropertyName("odaid")]
		public int DAid { get; set; }

		[JsonPropertyName("otocartid")]
		public int OtoCartId { get; set; }

		[JsonPropertyName("otocartcustid")]
		public int OtoCartCustId { get; set; }

		[JsonPropertyName("oeta")]
		public string? ETA { get; set; }

		[JsonPropertyName("ostatus")]
		public string status { get; set; }

		[JsonPropertyName("oplaceddatetime")]
		public string? placedDateTime { get; set; }

		public OrdersCurrentJSONResponse200(int id, int fromRid, int daid, int OtoCartId, int OtoCartCustId, string? ETA, string status, string? placedDateTime)
		{
			this.id = id;
			this.fromRid = fromRid;
			this.DAid = daid;
			this.OtoCartId = OtoCartId;
			this.OtoCartCustId = OtoCartCustId;
			this.ETA = ETA;
			this.status = status;
			this.placedDateTime = placedDateTime;
		}
	}

	public class GetCartIdJSONResponse200
	{
		[JsonPropertyName("cartid")]
		public int Cartid { get; set; }

		public GetCartIdJSONResponse200(int cartid)
		{
			Cartid = cartid;
		}
	}

	public class CreateNewCartJSONResponse200
	{
		[JsonPropertyName("cartid")]
		public int Cartid { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; }


		public CreateNewCartJSONResponse200(int cartid, string message)
		{
			Cartid = cartid;
			Message = message;
		}
	}

	public class PlaceOrderJSONRequest
	{
		[JsonPropertyName("cartid")]
		public int CartId { get; set; }

		public PlaceOrderJSONRequest(int cartId)
		{
			this.CartId = cartId;
		}
	}

	public class PlaceOrderJSONResponse200
	{
		[JsonPropertyName("message")]
		public string Message { get; set; }

		public PlaceOrderJSONResponse200(string message)
		{
			this.Message = message;
		}
	}
}
