using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GauOiGauA.Models;
using Xamarin.Forms;

namespace GauOiGauA.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Alarm> _alarms;
        public DelegateCommand<Alarm> SelectedCommand { get; }
        public DelegateCommand<Alarm> DeleteCommand { get; }
        public ObservableCollection<Alarm> Alarms
        {
            get
            {
                if (_alarms == null)
                {
                    _alarms = new ObservableCollection<Alarm>
                    {
                        new Alarm
                        {
                            Time = DateTime.Now.TimeOfDay,
                            FullName = "home_faq.png",
                            Enabled = false
                        },
                        new Alarm
                        {
                            Time = DateTime.Now.TimeOfDay,
                            FullName = "home_emergency.png",
                            Enabled = true
                        }
                    };
                }

                return _alarms;
            }
        }
        private DateTime _datetimenow;
        public DelegateCommand AddCommand { get; }
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            AddCommand = new DelegateCommand(AddAction);
            SelectedCommand = new DelegateCommand<Alarm>(Selected);
            DeleteCommand = new DelegateCommand<Alarm>(Delete);
            DateTimeNow = DateTime.Now;
        }
        private async void AddAction()
        {
            await NavigationService.NavigateAsync("SettingsPage");
        }
        public DateTime DateTimeNow
        {
            get => _datetimenow;
            set { SetProperty(ref _datetimenow, value, () => RaisePropertyChanged(nameof(DateTimeNow))); }
        }
        private void Selected(Alarm obj)
        {
            var parameter = new NavigationParameters
            {
                { "Id", obj }
            };
            NavigationService.NavigateAsync("AlarmPage",parameter);
        }
        private void Delete(Alarm obj)
        {
           Alarms.RemoveAt(Alarms.IndexOf(obj)); 
        }
    }
}
