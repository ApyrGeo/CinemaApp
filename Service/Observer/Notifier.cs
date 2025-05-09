using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service.Observer
{
    public interface IObserver<T>
    {
        void Update(T data);
    }
    public class Notifier
    {
        private readonly Dictionary<Type, List<object>> _observers = new();
        private readonly object _lock = new();

        public void Subscribe<T>(IObserver<T> observer)
        {
            var type = typeof(T);
            lock (_lock)
            {
                if (!_observers.ContainsKey(type))
                    _observers[type] = new List<object>();

                if (!_observers[type].Contains(observer))
                    _observers[type].Add(observer);
            }
        }

        public void Notify<T>(T data)
        {
            var type = typeof(T);
            lock (_lock) 
            {
                if (_observers.TryGetValue(type, out var list))
                {
                    foreach (var obs in list.Cast<IObserver<T>>())
                    {
                        obs.Update(data);
                    }
                }
            }
        }

        public void Unsubscribe<T>(IObserver<T> observer)
        {
            var type = typeof(T);
            lock (_lock) 
            {
                if (_observers.TryGetValue(type, out var list))
                {
                    list.Remove(observer);
                    if (list.Count == 0)
                    {
                        _observers.Remove(type);
                    }
                }
            }
        }

    }
}
