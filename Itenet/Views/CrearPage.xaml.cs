using Itenet.Models;

namespace Itenet.Views;

public partial class CrearPage : ContentPage
{
    Noticia _noticia;
    public Noticia Noticia
    {
        get { return _noticia; }
        set
        {
            _noticia = value;
            OnPropertyChanged(nameof(Noticia));
        }
    }

    public static CrearPage Instance { get; private set; }
    public CrearPage()
	{
		InitializeComponent();
        Instance = this;
        Noticia = new Noticia();
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
        string imagen = await StorageManager.Upload();

        if(string.IsNullOrEmpty(imagen))
        {
            await DisplayAlert("Error", "No se pudo subir la imagen", "OK");
            return;
        }

        Noticia.fecha = DateTime.Now;
        Noticia.imagen = imagen;

        await FireBaseManager.Post("noticias", Noticia);
        await this.Navigation.PopModalAsync();
    }

   
}