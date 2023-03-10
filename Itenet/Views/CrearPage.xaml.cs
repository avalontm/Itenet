namespace Itenet.Views;

public partial class CrearPage : ContentPage
{
    string _titulo;
    public string Titutlo
    {
        get { return _titulo; }
        set
        {
            _titulo = value;
            OnPropertyChanged(nameof(Titutlo));
        }
    }

    string _mensaje;
    public string Mensaje
    {
        get { return _mensaje; }
        set
        {
            _mensaje = value;
            OnPropertyChanged(nameof(Mensaje));
        }
    }
    
    public static CrearPage Instance { get; private set; }
    public CrearPage()
	{
		InitializeComponent();
        Instance = this;
        BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Instance = this;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Instance = null;
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