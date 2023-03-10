using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet.Models
{
    public class RootNoticia
    {
        public Noticia NQCL7y8KacH5tMydZra { get; set; }
    }

    public class Noticia
    {
        public string id { set; get; }
        public DateTime fecha { set; get; }
        public string titulo { set; get; }
        public string mensaje { set; get; }
        public string imagen { set; get; }

        [JsonIgnore]
        public bool tapped { set; get; }

    }
}
