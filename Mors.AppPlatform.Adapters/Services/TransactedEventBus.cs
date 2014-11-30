﻿using System;
using Mors.AppPlatform.Common.Transactions;
using Mors.AppPlatform.Support.Events;

namespace Mors.AppPlatform.Adapters.Services
{
    internal sealed class TransactedEventBus : Common.Services.IEventBus, ITransactional<Common.Services.IEventBus>
    {
        private readonly ITransactional<IEventBus> _eventBus;

        public TransactedEventBus(IEventBus eventBus)
        {
            _eventBus = eventBus.Lift();
        }

        public ITransactional<Common.Services.IEventBus> Lift()
        {
            return this;
        }

        public Common.Services.IEventBus Object
        {
            get { return this; }
        }

        public void Abort()
        {
            _eventBus.Abort();
        }

        public void Commit()
        {
            _eventBus.Commit();
        }

        public void Publish<TEvent>(TEvent @event)
        {
            _eventBus.Object.Publish(@event);
        }

        public void RegisterListener<TEvent>(Action<TEvent> handler)
        {
            _eventBus.Object.RegisterListener(new EventListener<TEvent>(handler));
        }
    }
}