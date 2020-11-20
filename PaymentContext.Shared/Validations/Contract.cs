using System;
using System.Linq.Expressions;
using PaymentContext.Shared.Notify;

namespace PaymentContext.Shared.Validations
{
    public partial class Contract : Notifiable
    {
        public Contract Requires()
        {
            return this;
        }

        public Contract IfNotNull(object parameterType, Expression<Func<Contract, Contract>> contractExpression)
        {
            if (parameterType != null)
            {
                contractExpression.Compile().Invoke(this);
            }

            return this;
        }
    }
}