﻿using Journeys.Queries;

namespace Journeys.Client.Wpf
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TResult>(IQuery<TResult> query);
    }
}
