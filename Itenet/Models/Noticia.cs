using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet.Models
{
    public class Noticia : BaseViewModel
    {
        ImageSource _imagen;
        public string id { set; get; }
        public DateTime fecha { set; get; }
        public string titulo { set; get; }
        public string mensaje { set; get; }
        public ImageSource imagen
        {
            get { return _imagen; }
            set { _imagen = value;
                OnPropertyChanged("imagen");
            }
        }

        [JsonIgnore]
        public bool tapped { set; get; }

    }
}
