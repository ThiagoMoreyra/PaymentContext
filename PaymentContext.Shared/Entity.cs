using System;
using PaymentContext.Shared.Notify;

namespace PaymentContext.Shared
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}