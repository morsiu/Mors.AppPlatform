﻿using Journeys.Common;
using System.Runtime.Serialization;

namespace Journeys.Queries.Dtos
{
    [DataContract]
    public class PersonName
    {
        public PersonName(object ownerId, string name)
        {
            OwnerId = ownerId;
            Name = name;
        }

        [DataMember]
        public object OwnerId { get; private set; }

        [DataMember]
        public string Name { get; private set; }
    }
}
