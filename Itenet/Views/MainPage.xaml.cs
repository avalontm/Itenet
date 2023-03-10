using Firebase.Database;
using Firebase.Database.Query;
using Itenet.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Itenet.Views;

public partial class MainPage : ContentPage
{
    ObservableCollection<Noticia> _noticias;
    public ObservableCollection<Noticia> Noticias
    {
        get { return _noticias; }
        set
        {
            _noticias = value;
            OnPropertyChanged("Noticias");
        }
    }

    bool _isRefreshing;
    public bool IsRefreshing
    {
        get { return _isRefreshing; }
        set
        {
            _isRefreshing = value;
            OnPropertyChanged("IsRefreshing");
        }
    }

    ICommand _refreshCommand;
    public ICommand RefreshCommand
    {
        get { return _refreshCommand; }
        set
        {
            _refreshCommand = value;
            OnPropertyChanged("RefreshCommand");
        }
    }


    public MainPage()
	{
		InitializeComponent();
        RefreshCommand = new Command(onRefreshCommand);
        BindingContext = this;
    }

    async void onRefreshCommand(object obj)
    {
        await onGetTrabajos();
        IsRefreshing = false;   
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		onGetTrabajos();
    }

    async Task onGetTrabajos()
    {
        Noticias = await FireBaseManager.Get<ObservableCollection<Noticia>>("noticias");
    }


    async void onNoticiaTapped(object sender, TappedEventArgs e)
    {
        Border borde = sender as Border;

        if (borde != null)
        {
            Noticia noticia = borde.BindingContext as Noticia;

            if (noticia != null)
            {
                if (!noticia.tapped)
                {
                    noticia.tapped = true;
                    await borde.ScaleTo(0.98, 50);
                    await borde.ScaleTo(1, 50);
                    noticia.tapped = false;
                }
            }
        }
    }


    async void onInicio(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
        Debug.WriteLine($"[onInicio]");
    }


    async void onCrear(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }

        //Mostramos la ventana de crear publicacion
        if (CrearPage.Instance == null)
        {
            await this.Navigation.PushModalAsync(new CrearPage());
        }
    }


    async void onPerfil(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {
            await button.ScaleTo(0.95, 50);
            await button.ScaleTo(1, 50);
        }
        Debug.WriteLine($"[onPerfil]");
    }
}

