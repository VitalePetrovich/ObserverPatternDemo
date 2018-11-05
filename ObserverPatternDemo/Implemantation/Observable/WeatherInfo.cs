namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Class container for weather conditions.
    /// </summary>
    public class WeatherInfo : EventInfo
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}