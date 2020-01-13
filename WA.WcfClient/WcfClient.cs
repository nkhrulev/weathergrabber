using System;
using System.ServiceModel;
using System.Collections.Generic;
using WA.Common.ApiClient;
using WA.Common.WeatherGrabber;
using WA.WcfClient.WcfServiceReference;

namespace WA.WcfClient
{
    public class WcfClient : IApiClient
    {
        private WcfServiceClient client;

        public void Open(string host, int port)
        {
            var tmt = TimeSpan.FromSeconds(1);
            client = new WcfServiceClient(
                new BasicHttpBinding() { 
                    ReceiveTimeout = tmt, 
                    SendTimeout = tmt, 
                    OpenTimeout = tmt 
                },
                new EndpointAddress($"http://{host}:{port}"));
            
            client.Open();
        }

        public List<string> GetAvailableCitiesForTomorrow()
        {
            return client.GetAvailableCitiesForTomorrow(DateTime.Today);
        }

        public WeatherInfo GetWeatherInfo(string cityName, DateTime date)
        {
            return client.GetWeatherInfo(cityName, date);
        }

        public void Dispose()
        {
            client?.Close();
        }
    }
}
