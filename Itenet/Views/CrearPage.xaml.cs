namespace Itenet.Views;

public partial class CrearPage : ContentPage
{
	public CrearPage()
	{
		InitializeComponent();
		BindingContext= this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    async void onCerrar(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
        await this.Navigation.PopModalAsync();	
    }

    async void onPublicar(object sender, EventArgs e)
    {

    }

   
}