using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                    // 1. must explicitly declare property the fields are readonly
                    // otherwise, EF core will ignore them by default
                    computedStampDuty.Property(csd => csd.PropertyType);
                    computedStampDuty.Property(csd => csd.BuyersStampDuty);
                    computedStampDuty.Property(csd => csd.SubmitedAt);
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

        // 2. property of complex type cannot be readonly, not supported yet
        public ComputedStampDuty ComputedStampDuty { get; private set; }
    }


    public class ComputedStampDuty
    {
        // 3. constructor will be used when the fields are readonly,
        // constructor must have parameters mapping all readonly properties

        // 4. empty constructor override the constructor with parameters,
        // which is necessary for EF core to configure readonly property
        // therefore, must not have empty constructor when configure readonly property
        // private ComputedStampDuty() { }

        public ComputedStampDuty(
            PropertyType propertyType,
            DateTime submitedAt,
            double buyersStampDuty,
            double additionalBuyersStampDuty)
        {
            PropertyType = propertyType;
            BuyersStampDuty = buyersStampDuty;
            AdditionalBuyersStampDuty = additionalBuyersStampDuty;
        }

        // 5. only scalar property can be readonly
        public PropertyType PropertyType { get; }

        public DateTime SubmitedAt { get; }

        public double BuyersStampDuty { get; }

        public double AdditionalBuyersStampDuty { get; }

        public double TotalAmountPayable => BuyersStampDuty + AdditionalBuyersStampDuty;
    }

    public enum PropertyType
    {
        Resident,
        NonResident,
    }
}
