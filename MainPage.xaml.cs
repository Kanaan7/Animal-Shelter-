namespace Assignment2._1;

public partial class MainPage : ContentPage
{		

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnGoToDashboardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardPage());
    }
}

