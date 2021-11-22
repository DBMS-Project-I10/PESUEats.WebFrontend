using System.Text.Json.Serialization;

namespace PESUEatsBlazorServer.JSONBodyFormats.signup
{
    public class CustomerJSONRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("addr")]
        public string? Address { get; set; }

        public CustomerJSONRequest(string Name, string Email, string Password, string Phone, string? Address)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Phone = Phone;
            this.Address = Address;
        }
    }

    public class CustomerJSONResponse200
    {
        [JsonPropertyName("custname")]
        public string Name { get; set; }

        [JsonPropertyName("custemail")]
        public string Email { get; set; }

        [JsonPropertyName("custphone")]
        public string Phone { get; set; }

        [JsonPropertyName("custaddr")]
        public string? Address { get; set; }

        public CustomerJSONResponse200(string Name, string Email, string Phone, string? Address)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
        }
    }




    public class DaJSONRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }


        public DaJSONRequest(string Name, string Email, string Password)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }
    }

    public class DaJSONResponse200
    {
        [JsonPropertyName("daname")]
        public string Name { get; set; }

        [JsonPropertyName("daemail")]
        public string Email { get; set; }


        public DaJSONResponse200(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }
    }






    public class RestaurantJSONRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("cuisine")]
        public string Cuisine { get; set; }

        public RestaurantJSONRequest(string Name, string Email, string Password, string Location, string Cuisine)
        {
            this.Name = Name;
            this.Email = Email;
            this.Location = Location;
            this.Password = Password;
            this.Cuisine = Cuisine;
        }
    }

    public class RestaurantJSONResponse200
    {
        [JsonPropertyName("rname")]
        public string Name { get; set; }

        [JsonPropertyName("remail")]
        public string Email { get; set; }

        [JsonPropertyName("rlocation")]
        public string Location { get; set; }

        [JsonPropertyName("rcuisine")]
        public string Cuisine { get; set; }

        public RestaurantJSONResponse200(string Name, string Email, string Location, string Cuisine)
        {
            this.Name = Name;
            this.Email = Email;
            this.Location = Location;
            this.Cuisine = Cuisine;
        }
    }
}
