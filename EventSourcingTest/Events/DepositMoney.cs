namespace EventSourcingTest.Events
{
    public class DepositMoney : IEvent
    {
        public DepositMoney(int amount)
        {
            Amount = amount;
        }
        public int Amount { get; private set; }
    }
}