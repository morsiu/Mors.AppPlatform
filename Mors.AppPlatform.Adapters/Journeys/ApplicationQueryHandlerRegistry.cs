﻿using System;
using Mors.AppPlatform.Adapters.Dispatching;
using Mors.AppPlatform.Support.Dispatching;
using Mors.Journeys.Data;

namespace Mors.AppPlatform.Adapters.Journeys
{
    internal sealed class ApplicationQueryHandlerRegistry : Mors.Journeys.Application.IQueryHandlerRegistry
    {
        private readonly IHandlerRegistry _handlerRegistry;

        public ApplicationQueryHandlerRegistry(IHandlerRegistry handlerRegistry)
        {
            _handlerRegistry = handlerRegistry;
        }

        public void SetHandler<TQuery, TResult>(Func<TQuery, TResult> handler)
            where TQuery : IQuery<TResult>
        {
            var queryKey = new QueryKey(typeof(TQuery));
            Func<object, object> adaptedHandler = query => handler((TQuery)query);
            _handlerRegistry.Set(queryKey, adaptedHandler);
        }
    }
}
