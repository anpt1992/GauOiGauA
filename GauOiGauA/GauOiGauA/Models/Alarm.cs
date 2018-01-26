using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace GauOiGauA.Models
{
    public class Alarm : BindableBase
    {
        private DelegateCommand _command;
        private string _fullname;
        private string _time;
        private bool _enabled;

        public DelegateCommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value);
        }

        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }
        
    }
}
