using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades.Models.Response
{
    public class AuthResponse
    {
        //Para json web token
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
