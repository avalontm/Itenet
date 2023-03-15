using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet.Models
{
    public class Noticia : BaseViewModel
    {

        public string id { set; get; }
        public DateTime fecha { set; get; }
        public string titulo { set; get; }
        public string mensaje { set; get; }
        public List<ImageSource> imagenes { set; get; }

        [JsonIgnore]
        public bool tapped { set; get; }

        public Noticia()
        {
            imagenes = new List<ImageSource>();
        }
    }
}
