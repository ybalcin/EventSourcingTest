using System;
using System.Collections.Generic;
using System.Linq;
using EventSourcingTest.Events;

namespace EventSourcingTest.Persistance
{
    public class EventStore : IEventStore
    {
        private static EventStream _cache;

        private static EventStream Cache
        {
            get
            {
                _cache ??= new EventStream();

                if (_cache.Events.Any()) return _cache;

                // for test purposes only
                _cache.Events.Add(new WithdrawMoney(50));
                _cache.Events.Add(new DepositMoney(20));
                _cache.Events.Add(new DepositMoney(10));

                return _cache;
            }
        }

        public EventStream LoadStreams(int aggregateId)
        {
            // some find operations from event store via aggregateId
            return Cache;
        }

        public void AppendToStream(int aggregateId, int streamVersion, IEnumerable<IEvent> events)
        {
            // some find operations from event store via aggregateId
            if (_cache.Version != streamVersion)
            {
                throw new InvalidOperationException(
                    $"Stream version different from last version of aggregate: {aggregateId}");
            }

            _cache.Version++;
            _cache.Events.AddRange(events);
        }
    }

    public class EventStream
    {
        public int Version { get; set; } = 1; // for test purposes only
        public List<IEvent> Events { get; set; } = new();
    }
}