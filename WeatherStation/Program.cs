using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData waetherStation = new WeatherData();
            CurrentConditionsReport conditionsReport = new CurrentConditionsReport();
            StatisticReport statisticReport = new StatisticReport();

            waetherStation.Register(conditionsReport);
            waetherStation.Register(statisticReport);
            waetherStation.Unregister(statisticReport);
           
            waetherStation.StartNotify();
        }
    }
}
