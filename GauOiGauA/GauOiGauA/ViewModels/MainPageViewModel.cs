using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GauOiGauA.Models;
using Plugin.Notifications;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace GauOiGauA.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Alarm> _alarms;
        public DelegateCommand<Alarm> SelectedCommand { get; }
        public DelegateCommand<Alarm> DeleteCommand { get; }
        public ObservableCollection<Alarm> Alarms
        {
            get => _alarms;
            set => SetProperty(ref _alarms, value);
        }
        private DateTime _datetimenow;
        public DelegateCommand AddCommand { get; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            AddCommand = new DelegateCommand(AddAction);
            SelectedCommand = new DelegateCommand<Alarm>(Selected);
            DeleteCommand = new DelegateCommand<Alarm>(Delete);
            DateTimeNow = DateTime.Now;
        }
        private async void AddAction()
        {
            await CrossNotifications.Current.CancelAll();
            var notify = new Notification
            {
                Id = 2,
                Title = "XXX",
                Message = "yyy",
                When = TimeSpan.FromHours(3),
                Vibrate = true
            };

            await CrossNotifications.Current.Send(notify);
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
            NavigationService.NavigateAsync("AlarmPage", parameter);
        }
        private void Delete(Alarm obj)
        {
            Alarms.RemoveAt(Alarms.IndexOf(obj));
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await GetAlarms();
        }

        private async Task GetAlarms()
        {
            var list = await CrossNotifications.Current.GetScheduledNotifications();
            var notifications = new ObservableCollection<Notification>(list);
            ObservableCollection<Alarm> alm_lts = new ObservableCollection<Alarm>();
            foreach (var noti in notifications)
            {
                DateTime time =  (DateTime) noti.Date;
                var alm = new Alarm
                {
                    Time = DateTimeNow.TimeOfDay,
                    FullName = noti.Title,
                    Enabled = noti.IsScheduled
                };
                alm_lts.Add(alm);
            }

            Alarms = alm_lts;

        }
    }
}
