using Android.Database.Sqlite;
using Firebase.Database;
using Firebase.Database.Query;

namespace Itenet.Views;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		onGetTrabajos();
    }

    async void onGetTrabajos()
    {
        var items = await FireBaseManager.Get<object>("trabajos");

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key} is {item.Object}.");
        }

    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

