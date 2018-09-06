using Newtonsoft.Json;

namespace TestOwnedType.Models.DTOs
{
    public class ComputedStampDutyDTO
    {
        [JsonProperty("propertyType")]
        public string PropertyType { get; set; }

        [JsonProperty("buyersStampDuty")]
        public double BuyersStampDuty { get; set; }

        [JsonProperty("additionalBuyersStampDuty")]
        public double AdditionalBuyersStampDuty { get; set; }
    }
}
