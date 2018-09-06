using Newtonsoft.Json;

namespace TestOwnedType.Models.DTOs
{
    public class PaymentRecordDTO
    {
        //[JsonProperty("documentRefNo")]
        public string DocumentRefNo { get; set; }

        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }

        [JsonProperty("computedStampDuty")]
        public ComputedStampDutyDTO ComputedStampDuty { get; set; }
    }
}
