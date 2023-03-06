using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet.Models
{
    public class Noticia
    {
        public int id { set; get; }
        public string titulo { set; get; }
        public string mensaje { set; get; }  
        public string imagen { set; get; }

        [JsonIgnore]
        public bool tapped { set; get; }
    }
}
