﻿using System.Text.Json.Serialization;

namespace Pizzerie.Domain.Models.Product
{
    public class ProductResponse
    {
        [JsonPropertyName("id")] 
        public string ProductId { get; set; } = string.Empty;

        [JsonPropertyName("description")] 
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("category")] 
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}