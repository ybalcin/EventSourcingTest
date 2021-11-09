using EventSourcingTest.Persistance;

namespace EventSourcingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventStore store = new EventStore();
            var stream = store.LoadStreams(1);
            var account = new Account.Account(stream.Events);
            // 80
            account.DepositMoney(10);
            account.DepositMoney(50);
            account.WithdrawMoney(100);

            store.AppendToStream(1, stream.Version, account.Changes);

            var stream2 = store.LoadStreams(1);
            var account2 = new Account.Account(stream2.Events);
            
            account2.DepositMoney(5);
            account2.DepositMoney(3);
            account2.DepositMoney(9);
            
            store.AppendToStream(1, stream2.Version, account2.Changes);
            
            var stream3 = store.LoadStreams(1);
            var account3 = new Account.Account(stream2.Events);
        }
    }
}