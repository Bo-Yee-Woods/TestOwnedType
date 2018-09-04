using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestOwnedType.Cases
{
    public class MyEntityConfiguration
        : IEntityTypeConfiguration<MyEntity>
    {
        public void Configure(EntityTypeBuilder<MyEntity> builder)
        {
            builder.OwnsOne(
                    entity => entity.ValueObject,
                    valueObj =>
                    {
                        valueObj.Property(x => x.Name);
                    }
                );
        }
    }

    public class MyEntity : BaseEntity
    {
        public MyEntity() { }

        public MyEntity(ValueObject valueObject)
        {
            ValueObject = valueObject;
        }

        public ValueObject ValueObject { get; private set; }
    }

    public class ValueObject
    {        
        public ValueObject(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
