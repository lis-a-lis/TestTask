using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Infrastructure.Services
{
    public class ServicesContainer : IServicesContainer
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public void Register<TService>(TService service)
        {
            if (_services.ContainsKey(typeof(TService)))
                throw new Exception($"Service {typeof(TService)} is already registered");

            _services[typeof(TService)] = service;

            Debug.Log($"Service {typeof(TService)} was successfully registered;\nTotal count: {_services.Keys.Count}");
        }

        public TService Get<TService>()
        {
            if (!_services.ContainsKey(typeof(TService)))
                throw new Exception($"Service {typeof(TService)} dont registered");

            return (TService)_services[typeof(TService)];
        }
    }
}