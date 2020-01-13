using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WA.Common.ApiClient;
using WA.Common.WeatherGrabber;

namespace WA.Client
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IApiClient _apiClient;

        public MainVM(IApiClient apiClient)
        {
            _apiClient = apiClient;
            CitiesList = new ObservableCollection<string>(_apiClient.GetAvailableCitiesForTomorrow());
        }

        public WeatherInfo Search()
        {
            return _apiClient.GetWeatherInfo(SearchText, SearchDate);
        }

        #region string SearchText
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));
                }
            }
        }

        private string _searchText;
        #endregion

        #region DateTime SearchDate
        public DateTime SearchDate
        {
            get { return _searchDate; }
            set
            {
                if (_searchDate != value)
                {
                    _searchDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchDate)));
                }
            }
        }

        private DateTime _searchDate;
        #endregion

        #region ObservableCollection<string> CitiesList
        public ObservableCollection<string> CitiesList
        {
            get { return _citiesList; }
            set
            {
                if (_citiesList != value)
                {
                    _citiesList = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CitiesList)));
                }
            }
        }

        private ObservableCollection<string> _citiesList;
        #endregion
    }
}
