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

	public class MenuItemsJSONResponse200
	{
		[JsonPropertyName("iid")]
		public int Id { get; set; }

		[JsonPropertyName("iinmenurid")]
		public int InMenuRid { get; set; }

		[JsonPropertyName("iname")]
		public string Name { get; set; }

		[JsonPropertyName("iprice")]
		public float Price { get; set; }

		[JsonPropertyName("idescription")]
		public string? Description { get; set; }

		[JsonPropertyName("icategory")]
		public string? Category { get; set; }

		public MenuItemsJSONResponse200(int id, int inMenuRid, string name, float price, string? description, string? category)
		{
			this.Id = id;
			this.InMenuRid = inMenuRid;
			this.Name = name;
			this.Price = price;
			this.Description = description;
			this.Category = category;
		}
	}

	public class AddMenuItemJSONRequest
	{
		[JsonPropertyName("itemname")]
		public string Name { get; set; }

		[JsonPropertyName("price")]
		public float Price { get; set; }

		[JsonPropertyName("desc")]
		public string Description { get; set; }

		[JsonPropertyName("category")]
		public string Category { get; set; }

		public AddMenuItemJSONRequest(string name, float price, string description, string category)
		{
			this.Name = name;
			this.Price = price;
			this.Description = description;
			this.Category = category;
		}
	}

	public class ChangeStatusJSONRequest
	{
		[JsonPropertyName("oid")]
		public int OId { get; set; }

		public ChangeStatusJSONRequest(int id)
		{
			this.OId = id;
		}
	}
}
