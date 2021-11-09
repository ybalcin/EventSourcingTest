using System.Collections.Generic;
using EventSourcingTest.Events;

namespace EventSourcingTest.Account
{
    public partial class Account
    {
        public List<IEvent> Changes { get; set; } = new();

        private Account(int amount)
        {
            Balance = amount;
        }

        public static Account CreateNewCustomer(int balance)
        {
            balance = balance < 0 ? 0 : balance;
            return new Account(balance);
        }

        public Account(IEnumerable<IEvent> events)
        {
            foreach (var @event in events) Mutate(@event);
        }

        private int Balance { get; set; } = 100; // for test purposes only

        private void Mutate(IEvent @event)
        {
            When((dynamic) @event);
        }

        private void When(WithdrawMoney e)
        {
            Balance -= e.Amount;
        }

        private void When(DepositMoney e)
        {
            Balance += e.Amount;
        }
    }
}