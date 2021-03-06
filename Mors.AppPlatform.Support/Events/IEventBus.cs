﻿using Mors.AppPlatform.Support.Transactions;

namespace Mors.AppPlatform.Support.Events
{
    public interface IEventBus : IProvideTransactional<IEventBus>
    {
        void RegisterListener<TEvent>(EventListener<TEvent> listener);

        void Publish<TEvent>(TEvent @event);
    }
}
