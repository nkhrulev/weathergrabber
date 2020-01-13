using System;
using System.Collections.Generic;
using WA.Common.WeatherGrabber;

namespace WA.Common.ApiClient
{
    public interface IApiClient : IDisposable
    {
        void Open(string host, int port);

        List<string> GetAvailableCitiesForTomorrow();
        
        WeatherInfo GetWeatherInfo(string cityName, DateTime date);
    }
}
