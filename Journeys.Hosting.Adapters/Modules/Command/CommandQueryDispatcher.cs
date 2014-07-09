﻿using Journeys.Application.Command;
using Journeys.Data.Queries;
using Journeys.Hosting.Adapters.Dispatching;
using Journeys.Support.Dispatching;

namespace Journeys.Hosting.Adapters.Modules.Command
{
    public class CommandQueryDispatcher : IQueryDispatcher
    {
        private readonly HandlerDispatcher _handlerDispatcher;

        public CommandQueryDispatcher(HandlerDispatcher handlerDispatcher)
        {
            _handlerDispatcher = handlerDispatcher;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            var queryAdapter = new QueryAdapter<TResult>(query);
            return queryAdapter.Execute(_handlerDispatcher);
        }
    }
}