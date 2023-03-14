using Itenet.Models;
using System.Collections;
using System.Diagnostics;

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
        if (string.IsNullOrEmpty(Noticia.titulo))
        {
            await DisplayAlert("Requerido", "Debes colocar un titulo.", "OK");
            txtTitulo.Focus();
            return;
        }

        if (string.IsNullOrEmpty(Noticia.mensaje))
        {
            await DisplayAlert("Requerido", "Debes colocar un mensaje.", "OK");
            txtMensaje.Focus();
            return;
        }

        Noticia.fecha = DateTime.Now;

        if (Noticia.imagen != null)
        {
            Noticia.imagen = ImageSource.FromUri(new Uri(await StorageManager.Upload(Noticia.imagen.ToStream())));
        }

        await FireBaseManager.Post("noticias", Noticia);
        await this.Navigation.PopModalAsync();
    }

    async void onImage(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }

        var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "image/jpeg", "image/webp", "image/gif", "image/png" } },
                    { DevicePlatform.Android, new[] { "image/jpeg", "image/webp", "image/gif", "image/png" } }
                });

        PickOptions options = new()
        {
            PickerTitle = "Selecciona una imagen",
            FileTypes = customFileType,
        };

        var result = await FilePicker.Default.PickAsync(options);

        if (result != null)
        {
            Stream file = await result.OpenReadAsync();
            Noticia.imagen = ImageSource.FromStream(() => file);
            Debug.WriteLine($"[IMAGEN] {Noticia.imagen}");

            if (Noticia.imagen == null)
            {
                await DisplayAlert("Error", "No se pudo subir la imagen", "OK");
                return;
            }
        }
    }


    async void onTexto(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
    }

    async void onLink(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
    }

    async void onVideo(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
    }
}