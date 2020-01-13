using System;
using System.Collections.Generic;
using WA.Common.WeatherGrabber;

namespace WA.Common.DataLayer
{
    public interface IStorage
    {
        void SetCityWeather(CityInfo city, DateTime date, WeatherInfo weather);
        
        WeatherInfo GetWeatherForTomorowByCityName(string cityName, DateTime today);
        
        List<CityInfo> GetCitiesForTomorrow(DateTime today);
    }
}
