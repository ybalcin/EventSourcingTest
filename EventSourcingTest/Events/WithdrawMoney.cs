namespace EventSourcingTest.Events
{
    public class WithdrawMoney : IEvent
    {
        public WithdrawMoney(int amount)
        {
            Amount = amount;
        }
        public int Amount { get; private set; }
    }
}