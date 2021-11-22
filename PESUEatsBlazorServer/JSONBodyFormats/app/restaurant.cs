using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.app.restaurant
{
	public class RestaurantsJSONResponse200
	{
		[JsonPropertyName("rid")]
		public int id { get; set; }

		[JsonPropertyName("rhaswid")]
		public int walletid { get; set; }

		/*
		[JsonPropertyName("Remail")]
		public string email { get; set; }
		*/

		[JsonPropertyName("rname")]
		public string name { get; set; }

		[JsonPropertyName("rlocation")]
		public string location { get; set; }

		[JsonPropertyName("rrating")]
		public float? rating { get; set; }

		[JsonPropertyName("rcuisine")]
		public string? cuisine { get; set; }

		public RestaurantsJSONResponse200(int id, int walletid, /*string email,*/ string name, string location, float? rating, string? cuisine)
		{
			this.id = id;
			this.walletid = walletid;
			this.name = name;
			//this.email = email;
			this.location = location;
			this.rating = rating;
			this.cuisine = cuisine;
		}
	}
}
