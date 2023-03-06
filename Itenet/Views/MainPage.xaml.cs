using Android.Database.Sqlite;
using Firebase.Database;
using Firebase.Database.Query;
using Itenet.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

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

	public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		onGetTrabajos();
    }

    async void onGetTrabajos()
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

}

