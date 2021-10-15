using AbiHub.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbiHub.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand UebermichCommand { get; set; }

        public RelayCommand WeiteresCommand { get; set; }

        public WeiteresViewModel WeiteresVM { get; set; }
        public HomeViewModel HomeVM { get; set; }

        public UebermichViewModel UeberVM { get; set; }

        private object _currentview;

        public object CurrentView
        {
            get { return _currentview; }
            set {
                    _currentview = value;
                     OnPropertyChanged();
                }
        }

        public MainViewModel()
        {

            HomeVM = new HomeViewModel();
            UeberVM = new UebermichViewModel();
            WeiteresVM = new WeiteresViewModel();

            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            UebermichCommand = new RelayCommand(o =>
            {
                CurrentView = UeberVM;
            });

            WeiteresCommand = new RelayCommand(o =>
            {
                CurrentView = WeiteresVM;
            });
        }
    }
}
