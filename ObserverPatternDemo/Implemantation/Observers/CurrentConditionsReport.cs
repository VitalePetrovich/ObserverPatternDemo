using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Class observer. Displays weather information to console in this case.
    /// Also can store or process this information.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        /// <summary>
        /// Update information from observable.
        /// </summary>
        /// <param name="sender">Sender (observable).</param>
        /// <param name="info">Weather information.</param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
                return;

            Console.WriteLine($"Temperature: {info.Temperature, 3}| Humidity: {info.Humidity, 3}| Pressure: {info.Pressure, 3}");
        }
    }
}