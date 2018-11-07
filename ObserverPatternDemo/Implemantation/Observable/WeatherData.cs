using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers = new List<IObserver<WeatherInfo>>();

        /// <summary>
        /// Start broadcasting.
        /// </summary>
        public void StartNotify()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            Random rnd = new Random();

            while (keyInfo.Key != ConsoleKey.Escape)
            {
                WeatherInfo weather = new WeatherInfo()
                {
                    Temperature = rnd.Next(-30, 35),
                    Humidity = rnd.Next(0, 99),
                    Pressure = rnd.Next(0, 999),
                };

                Console.Clear();
                this.Notify(weather);

                Thread.Sleep(500);
                if (Console.KeyAvailable)
                    keyInfo = Console.ReadKey();
            }
        }

        void IObservable<WeatherInfo>.Notify(WeatherInfo info)
            => this.Notify(info);

        /// <summary>
        /// Notify observer about change of info.
        /// </summary>
        /// <param name="sender">Reference to sender.</param>
        /// <param name="info">Information.</param>
        private void Notify(WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
                return;

            foreach (var observer in observers)
            {
                observer.Update(this, info);
            }
        }

        /// <summary>
        /// Add observer to the observers list.
        /// </summary>
        /// <param name="observer">Observer.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
                return;

            observers.Add(observer);
        }

        /// <summary>
        /// Remove observer from the observers list.
        /// </summary>
        /// <param name="observer">Observer.</param>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
                return;

            observers.Remove(observer);
        }
    }
}
