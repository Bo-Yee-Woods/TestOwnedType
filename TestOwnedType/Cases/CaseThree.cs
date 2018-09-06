using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestOwnedType.Cases.Three
{

    public class PaymentRecordEntityConfiguration
        : IEntityTypeConfiguration<PaymentRecordEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentRecordEntity> builder)
        {
            builder.Property(x => x.DocumentRefNo).IsRequired();

            builder.Property<double>("TotalAmount").IsRequired();

            builder.OwnsOne(
                paymentRecordEntity => paymentRecordEntity.ComputedStampDuty,
                computedStampDuty =>
                {
                    // 1. must explicitly declare all property here
                    computedStampDuty.Property(csd => csd.PropertyType);
                    computedStampDuty.Property(csd => csd.BuyersStampDuty);
                    computedStampDuty.Property(csd => csd.AdditionalBuyersStampDuty);
                    computedStampDuty.Ignore(csd => csd.TotalAmountPayable);
                }
            );
        }
    }

    public class PaymentRecordEntity : BaseEntity
    {
        private string _documentRefNo;
        private double _totalAmount;

        private PaymentRecordEntity() { }

        public PaymentRecordEntity(
            string documentRefNo,
            double totalAmount,
            ComputedStampDuty computedStampDuty)
        {
            _documentRefNo = documentRefNo;
            _totalAmount = totalAmount;
            ComputedStampDuty = computedStampDuty;
        }

        public string DocumentRefNo => _documentRefNo;

        // 2. the backing field must be read-writable
        public ComputedStampDuty ComputedStampDuty { get; private set; }
    }


    public class ComputedStampDuty
    {
        // 3. cannot have empty constructor in owned type
        // 4.  constructor must have parameters mapping all property type
        // private ComputedStampDuty() { }

        public ComputedStampDuty(string propertyType, double buyersStampDuty, double additionalBuyersStampDuty)
        {
            PropertyType = propertyType;
            BuyersStampDuty = buyersStampDuty;
            AdditionalBuyersStampDuty = additionalBuyersStampDuty;
        }

        public string PropertyType { get; }

        public double BuyersStampDuty { get; }

        public double AdditionalBuyersStampDuty { get; }

        public double TotalAmountPayable => BuyersStampDuty + AdditionalBuyersStampDuty;
    }


}
