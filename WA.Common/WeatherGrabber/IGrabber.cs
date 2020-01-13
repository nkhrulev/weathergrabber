using System.Collections.Generic;

namespace WA.Common.WeatherGrabber
{
    public interface IGrabber
    {
        List<WeatherInfo> GetWeatherInfoList(CityInfo city);

        List<CityInfo> GetFavoriteCities();
    }
}
