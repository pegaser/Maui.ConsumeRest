using Microsoft.Maui.Networking;
namespace Maui.ConsumeRest;

public partial class MainPage : ContentPage
{
	int count = 0;
	bool _stillConnected = false;
	public MainPage()
	{
		InitializeComponent();
        Connectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
	}

    private async void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        _stillConnected = e.NetworkAccess == NetworkAccess.Internet ? true : false;
		if(_stillConnected)
			await DisplayAlert("Alert", "Estamos conectados :)", "Ok");
		else
            await DisplayAlert("Alert", "No tiene internet :(", "Ok");
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
		if(Connectivity.Current.NetworkAccess == NetworkAccess.None)
		{
			await DisplayAlert("Alert", "No tiene internet", "Ok");
			return;
		}
        count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

