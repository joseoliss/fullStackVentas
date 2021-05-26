using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades.Models.Response
{
    public class Respuesta
    {
        //Respuesta de la solicitud a la api
        public int _Exito { get; set; }
        public string _Mensaje { get; set; }
        public object _Data { get; set; }
    }
}
