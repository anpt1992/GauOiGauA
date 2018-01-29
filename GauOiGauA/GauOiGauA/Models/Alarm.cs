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
        private TimeSpan _time;
        private bool _mon, _tue, _wen, _thu, _fri, _sat, _sun;
        private bool _enabled;
        private int _interval;
        private int _volume; //1 to 15
        private int _buttonPressesNumber;
        private int _shakesNumber;

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

        public TimeSpan Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        public bool Mon
        {
            get => _mon;
            set => SetProperty(ref _mon, value);
        }
        public bool Tue
        {
            get => _tue;
            set => SetProperty(ref _tue, value);
        }
        public bool Wen
        {
            get => _wen;
            set => SetProperty(ref _wen, value);
        }
        public bool Thu
        {
            get => _thu;
            set => SetProperty(ref _thu, value);
        }
        public bool Fri
        {
            get => _fri;
            set => SetProperty(ref _fri, value);
        }
        public bool Sat
        {
            get => _sat;
            set => SetProperty(ref _sat, value);
        }
        public bool Sun
        {
            get => _sun;
            set => SetProperty(ref _sun, value);
        }
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }
        public int Interval
        {
            get => _interval;
            set => SetProperty(ref _interval, value);
        }

        public int Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public int ButtonPresses
        {
            get => _buttonPressesNumber;
            set => SetProperty(ref _buttonPressesNumber, value);
        }

        public int Shakes
        {
            get => _shakesNumber;
            set => SetProperty(ref _shakesNumber, value);
        }

        public int Id
        {
            get
            { 
                string _id = FullName + Time.ToString(@"hh\:mm");
                return _id.GetHashCode();
            }
        }
    }
}
