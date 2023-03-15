using Itenet.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Android.Provider.MediaStore;

namespace Itenet.Views;

public partial class CrearPage : ContentPage
{
    ObservableCollection<ImageSource> _imagenes;
    public ObservableCollection<ImageSource> Imagenes
    {
        get { return _imagenes; }
        set
        {
            _imagenes = value;
            OnPropertyChanged("Imagenes");
        }
    }

    ObservableCollection<byte[]> _data;
    public ObservableCollection<byte[]> Data
    {
        get { return _data; }
        set
        {
            _data = value;
            OnPropertyChanged("Data");
        }
    }

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
        Imagenes =new ObservableCollection<ImageSource>();
        Data = new ObservableCollection<byte[]>();
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

        foreach (var data in Data)
        {
            try
            {
                Noticia.imagenes.Add(ImageSource.FromUri(new Uri(await StorageManager.Upload(data))));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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

            if (file == null)
            {
                await DisplayAlert("Error", "No se pudo cargar la imagen", "OK");
                return;
            }

            byte[] data = file.ToArray();
            Data.Add(data);
            Imagenes.Add(data.FromArray());

            Debug.WriteLine($"[IMAGENES] {Imagenes.Count}");
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

    void onImagenBorrar(object sender, EventArgs e)
    {
        try
        {
            ImageButton button = sender as ImageButton;

            if (button != null)
            {
                if (button.BindingContext is ImageSource)
                {
                    ImageSource imagen = button.BindingContext as ImageSource;

                    if (imagen != null)
                    {
                        int Index = Imagenes.IndexOf(imagen);
                        Imagenes.RemoveAt(Index);
                        Data.RemoveAt(Index);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

}