﻿using Mors.AppPlatform.Common.Transactions;
using Mors.AppPlatform.Support.Repositories;

namespace Mors.AppPlatform.Adapters.Modules.EventSourcing
{
    internal sealed class EventSourcingTransactedRepositories : IRepositories, ITransactional<IRepositories>
    {
        private readonly ITransactional<IRepositories> _repositories;

        public EventSourcingTransactedRepositories(Mors.AppPlatform.Support.Repositories.IRepositories repositories)
        {
            _repositories = repositories.Lift();
        }

        public TEntity Get<TEntity>(object id) where TEntity : IHasId
        {
            return _repositories.Object.Get<TEntity>(id);
        }

        public void Store<TEntity>(TEntity entity) where TEntity : IHasId
        {
            _repositories.Object.Store(entity.Id, entity);
        }

        public ITransactional<IRepositories> Lift()
        {
            return this;
        }

        public IRepositories Object
        {
            get { return this; }
        }

        public void Abort()
        {
            _repositories.Abort();
        }

        public void Commit()
        {
            _repositories.Commit();
        }
    }
}