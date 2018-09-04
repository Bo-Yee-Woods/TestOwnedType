using System;

namespace TestOwnedType.Cases
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedTime { get; protected set; }

        public DateTime UpdatedTime { get; protected set; }

        protected BaseEntity()
        {
            CreatedTime = UpdatedTime = DateTime.UtcNow;
        }
    }
}
