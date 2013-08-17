﻿using System;
using System.Collections.Generic;

namespace Journeys.Query.Infrastructure.Views
{
    internal class Set<TKey, TValue>
    {
        private readonly Func<TValue, TKey> _keyGenerator;
        private readonly Dictionary<TKey, TValue> _values;

        public Set(Func<TValue, TKey> keyGenerator)
        {
            _keyGenerator = keyGenerator;
            _values = new Dictionary<TKey, TValue>();
        }

        public void Add(TValue value)
        {
            var key = _keyGenerator(value);
            _values.Add(key, value);
        }

        public void Update(TKey key, Func<TValue, TValue> updater)
        {
            var value = _values[key];
            var newKey = _keyGenerator(value);
            _values.Remove(key);
            _values[newKey] = updater(value);
        }

        public TValue Get(TKey key)
        {
            return _values[key];
        }

        public TValue Remove(TKey key)
        {
            var value = _values[key];
            _values.Remove(key);
            return value;
        }

        public IEnumerable<TValue> Retrieve()
        {
            return _values.Values;
        }
    }
}
