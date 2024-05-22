using Newtonsoft.Json;
using SnipeSharp.Common;
using System.Collections.Generic;

namespace SnipeSharp.Endpoints.Models
{
    public class User : CommonEndpointModel
    {

        [JsonProperty("name")]
        [RequestHeader("name")]
        public new string Name { get; set; }

        [JsonProperty("accessories_count")]
        public long? AccessoriesCount { get; set; }

        [JsonProperty("activated")]
        [RequestHeader("activated")]
        public bool Activated { get; set; }

        [JsonProperty("address")]
        [RequestHeader("address")]
        public string Address { get; set; }

        [JsonProperty("assets_count")]
        public long? AssetsCount { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("city")]
        [RequestHeader("city")]
        public string City { get; set; }

        [JsonProperty("company")]
        [RequestHeader("company_id")]
        public Company Company { get; set; }

        [JsonProperty("consumables_count")]
        public long ConsumablesCount { get; set; }

        [JsonProperty("country")]
        [RequestHeader("country")]
        public string Country { get; set; }

        [JsonProperty("email")]
        [RequestHeader("email")]
        public string Email { get; set; }

        [JsonProperty("employee_num")]
        [RequestHeader("employee_num")]
        public string EmployeeNum { get; set; }

        [JsonProperty("firstname")]
        [RequestHeader("first_name", true)]
        public string Firstname { get; set; }

        [JsonProperty("jobtitle")]
        [RequestHeader("jobtitle")]
        public string Jobtitle { get; set; }

        [JsonProperty("last_login")]
        public ResponseDate LastLogin { get; set; }

        [JsonProperty("lastname")]
        [RequestHeader("last_name")]
        public string Lastname { get; set; }

        [JsonProperty("licenses_count")]
        public long? LicensesCount { get; set; }

        [JsonProperty("location")]
        [RequestHeader("location_id")]
        public Location Location { get; set; }

        [JsonProperty("manager")]
        [RequestHeader("manager_id")]
        public User Manager { get; set; }

        [JsonProperty("notes")]
        [RequestHeader("notes")]
        public string Notes { get; set; }

        [JsonProperty("permissions")]
        public Dictionary<string, string> Permissions { get; set; }

        [JsonProperty("phone")]
        [RequestHeader("phone")]
        public string Phone { get; set; }

        [JsonProperty("state")]
        [RequestHeader("state")]
        public string State { get; set; }

        [JsonProperty("two_factor_activated")]
        public bool TwoFactorActivated { get; set; }

        [JsonProperty("username")]
        [RequestHeader("username", true)]
        public string Username { get; set; }

        [JsonProperty("zip")]
        [RequestHeader("zip")]
        public object Zip { get; set; }

        [RequestHeader("password", true)]
        public string Password { get; set; }

        [JsonProperty("department")]
        [RequestHeader("department_id")]
        public Department Department { get; set; }
    }
}
