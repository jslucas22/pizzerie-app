﻿using Pizzerie.Domain.Models.Product;
using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.GuestCheckPad
{
    public class EmployeeCheckPadGetResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("employee_name")]
        public string EmployeeName { get; set; } = string.Empty;

        [JsonPropertyName("clients")]
        public List<string>? Clients { get; set; }

        [JsonPropertyName("products")]
        public List<ProductResponse>? Products { get; set; }

        [JsonPropertyName("creation_date")]
        public DateTime Creation { get; set; }

        [JsonPropertyName("last_change_date")]
        public DateTime LastChangeDate { get; set; }
    }
}
