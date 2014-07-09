﻿using Journeys.Data.Queries;

namespace Journeys.Application.Client.Wpf
{
    public interface IQueryHandlerRegistry
    {
        void SetHandler<TQuery, TResult>(QueryHandler<TQuery, TResult> handler)
            where TQuery : IQuery<TResult>;
    }
}