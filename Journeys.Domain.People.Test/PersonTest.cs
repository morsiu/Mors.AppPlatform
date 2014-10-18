﻿using Journeys.Data.Events;
using Journeys.Domain.Infrastructure.Exceptions;
using Journeys.Domain.Test.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Journeys.Domain.People.Test
{
    [TestClass]
    public sealed class PersonTest
    {
        private static readonly string PersonName = "PersonName";
        private static readonly object PersonId = new Id(0);
        private EventBusMock _eventBus;

        [TestInitialize]
        public void TestInitialize()
        {
            _eventBus = new EventBusMock();
        }

        [TestMethod]
        public void ShouldPublishEventWhenCreatingPerson()
        {
            var eventMatcher = _eventBus.Listen(() =>
            {
                new Person(PersonId, PersonName, _eventBus.Object);
            });

            eventMatcher.AssertReceivedOneEvent<PersonCreatedEvent>(
                evt => evt.PersonId.Equals(PersonId) &&
                       evt.PersonName == PersonName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvariantViolationException))]
        public void ShouldReportInvariantViolationWhenCreatingPersonWithEmptyName()
        {
            new Person(PersonId, string.Empty, _eventBus.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(InvariantViolationException))]
        public void ShouldReportInvariantViolationWhenCreatingPersonWithNullName()
        {
            new Person(PersonId, null, _eventBus.Object);
        }
    }
}
