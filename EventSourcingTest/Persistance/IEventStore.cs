using System.Collections.Generic;
using EventSourcingTest.Events;

namespace EventSourcingTest.Persistance
{
    public interface IEventStore
    {
        EventStream LoadStreams(int aggregateId);
        void AppendToStream(int aggregateId, int streamVersion, IEnumerable<IEvent> events);
    }
}