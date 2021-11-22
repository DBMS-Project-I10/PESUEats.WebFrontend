using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.app.shared
{
	/*public class OrdersCurrentJSONResponse200
	{
		[JsonPropertyName("Oid")]
		public int id { get; set; }

		[JsonPropertyName("OfromRid")]
		public int fromRid { get; set; }

		[JsonPropertyName("ODAid")]
		public int? DAid { get; set; }

		[JsonPropertyName("OtoCartId")]
		public int OtoCartId { get; set; }

		[JsonPropertyName("OtoCartCustId")]
		public int OtoCartCustId { get; set; }

		[JsonPropertyName("OETA")]
		public NpgsqlDateTime? ETA { get; set; }

		[JsonPropertyName("OStatus")]
		public string status { get; set; }

		[JsonPropertyName("OPlacedDateTime")]
		public NpgsqlDateTime? placedDateTime { get; set; }

		public OrdersCurrentJSONResponse200(int id, int fromRid, int? DAid, int OtoCartId, int OtoCartCustId, NpgsqlDateTime? ETA, string status, NpgsqlDateTime? placedDateTime)
		{
			this.id = id;
			this.fromRid = fromRid;
			this.DAid = DAid;
			this.OtoCartId = OtoCartId;
			this.OtoCartCustId = OtoCartCustId;
			this.ETA = ETA;
			this.status = status;
			this.placedDateTime = placedDateTime;
		}
	}*/

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
