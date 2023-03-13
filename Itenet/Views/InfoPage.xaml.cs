using Itenet.Models;

namespace Itenet.Views;

public partial class InfoPage : ContentPage
{
    Noticia _noticia;
    public Noticia Noticia
    {
        get { return _noticia; }
        set
        {
            _noticia = value;
            OnPropertyChanged("Noticia");
        }
    }

    public static InfoPage Instance { private set; get; }

    public InfoPage()
    {
        InitializeComponent();
        Instance = this;
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Instance = this;
        onLoadNoticia();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Instance = null;
    }

    async void onLoadNoticia()
    {
        Title = Noticia.titulo;
    }

}