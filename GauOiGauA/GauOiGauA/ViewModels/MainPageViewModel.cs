using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GauOiGauA.Models;
using Xamarin.Forms;

namespace GauOiGauA.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private List<Alarm> _alarms;
        public DelegateCommand<Alarm> SelectedCommand { get; }
        public List<Alarm> Alarms
        {
            get
            {
                if (_alarms == null)
                {
                    _alarms = new List<Alarm>
                    {
                        new Alarm
                        {
                            Time = "Test1",
                            FullName = "home_faq.png",
                            Command = new DelegateCommand(() => NavigationService.NavigateAsync("AlarmPage")),
                            Enabled = false
                        },
                        new Alarm
                        {
                            Time = "Test2",
                            FullName = "home_emergency.png",
                            Command = new DelegateCommand(() => NavigationService.NavigateAsync("AlarmPage")),
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
    }
}
