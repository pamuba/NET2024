using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Commands;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    internal class WeatherVM : INotifyPropertyChanged
    {
        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };
                CurrrentConditions = new CurrrentConditions()
                {
                    WeatherText = "Partly Clody",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = "25"
                        }
                    }
                };
            }
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }


        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChnaged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrrentConditions currrentConditions;

        public CurrrentConditions CurrrentConditions
        {
            get { return currrentConditions; }
            set { 
                currrentConditions = value;
                OnPropertyChnaged("CurrrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { 
                selectedCity = value;
                GetCurrentConditions();
                OnPropertyChnaged("SelectedCity");
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public async void GetCurrentConditions() {
            Query = string.Empty;
            Cities.Clear();
            CurrrentConditions = await AccuWeatherHelper.GetCurrrentConditions(selectedCity.Key);
        }
        public async void MakeQuery() {

            var cities = await AccuWeatherHelper.GetCities(Query);

            //Cities = new ObservableCollection<City>();
            Cities.Clear();
            foreach (City city in cities)
            {
                Cities.Add(city);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        //method to trigger the event
        private void OnPropertyChnaged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

    }
}
