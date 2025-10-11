using System;
using System.Text.Json.Serialization;

namespace WebhookHandler.Data.Dtos
{
    public class RazorpayWebhook
    {
        [JsonPropertyName("entity")]
        public string Entity { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("contains")]
        public string[] Contains { get; set; }

        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("payment")]
        public PaymentWrapper Payment { get; set; }
    }

    public class PaymentWrapper
    {
        [JsonPropertyName("entity")]
        public PaymentEntity Entity { get; set; }
    }

    public class PaymentEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("status")]
        public PaymentStatus Status { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("contact")]
        public string Contact { get; set; }

        [JsonPropertyName("notes")]
        public Notes Notes { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("card_id")]
        public string card_id { get; set; }

        [JsonPropertyName("card")]
        public Card Card { get; set; }

    }
    public class Notes
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("product_id")]
        public string productID { get; set; }
    }

    public class Card
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("entity")]
        public string Entity { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last4")]
        public string Last4 { get; set; }

        [JsonPropertyName("network")]
        public string Network { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("international")]
        public bool International { get; set; }

        [JsonPropertyName("emi")]
        public bool Emi { get; set; }

        [JsonPropertyName("sub_type")]
        public string SubType { get; set; }

        [JsonPropertyName("token_iin")]
        public string TokenIin { get; set; }
    }

    public enum PaymentStatus
    {
        Created,
        Authorized,
        Captured,
        Failed,
        Refunded,
        Disputed
    }

}
