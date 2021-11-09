using EventSourcingTest.Events;

namespace EventSourcingTest.Account
{
    public partial class Account
    {
        public void DepositMoney(int amount)
        {
            if (amount > 0)
            {
                Apply(new DepositMoney(amount));
            }
        }

        public void WithdrawMoney(int amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Apply(new WithdrawMoney(amount));
            }
        }

        private void Apply(IEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }
    }
}