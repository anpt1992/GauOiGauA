﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GauOiGauA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

	    private void OnCancelClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnOKClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }
	}
}