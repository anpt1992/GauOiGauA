using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace GauOiGauA.ViewModels
{
    public class AlarmPageViewModel : ViewModelBase
    {
        public AlarmPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
