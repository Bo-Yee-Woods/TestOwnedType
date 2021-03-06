﻿using Newtonsoft.Json;
using TestOwnedType.Cases.Three;

namespace TestOwnedType.Models.DTOs
{
    public class ComputedStampDutyDTO
    {
        [JsonProperty("propertyType")]
        public PropertyType PropertyType { get; set; }

        [JsonProperty("buyersStampDuty")]
        public double BuyersStampDuty { get; set; }

        [JsonProperty("additionalBuyersStampDuty")]
        public double AdditionalBuyersStampDuty { get; set; }
    }
}
