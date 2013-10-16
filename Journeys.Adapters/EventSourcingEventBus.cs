﻿using System;
using Journeys.EventSourcing;
using Journeys.Transactions;

namespace Journeys.Adapters
{
    public class EventSourcingEventBus : IEventBus
    {
        private readonly Event.IEventBus _eventBus;

        public EventSourcingEventBus(Event.IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void RegisterListener<TEvent>(Action<TEvent> handler)
        {
            _eventBus.RegisterListener(new Event.EventListener<TEvent>(handler));
        }

        public ITransactional<IEventBus> Lift()
        {
            return new EventSourcingTransactedEventBus(_eventBus);
        }
    }
}
