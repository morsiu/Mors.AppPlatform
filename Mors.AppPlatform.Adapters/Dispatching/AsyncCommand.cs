﻿using System;
using System.Threading.Tasks;
using Mors.AppPlatform.Support.Dispatching;
using Mors.AppPlatform.Support.Dispatching.Exceptions;
using Mors.AppPlatform.Adapters.Messages;

namespace Mors.AppPlatform.Adapters.Dispatching
{
    public sealed class AsyncCommand
    {
        private readonly object _commandSpecification;

        public AsyncCommand(object commandSpecification)
        {
            _commandSpecification = commandSpecification;
        }

        public Task Execute(AsyncHandlerDispatcher dispatcher)
        {
            var commandKey = CommandKey.From(_commandSpecification);
            try
            {
                return dispatcher.Dispatch(commandKey, _commandSpecification);
            }
            catch (HandlerNotFoundException)
            {
                throw new InvalidOperationException(string.Format(FailureMessages.NoHandlerRegisteredForCommandOfType, commandKey));
            }
        }
    }
}