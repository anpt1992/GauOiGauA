using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace GauOiGauA.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public DelegateCommand CancelCommand { get; }
        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Settings Page";
            CancelCommand = new DelegateCommand(CancelAction);
        }
        private async void CancelAction()
        {
            await NavigationService.GoBackAsync();
        }
    }
}
