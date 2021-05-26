using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Services.Interfaces
{
    public interface IClienteService
    {
        public List<ClienteEntidad> LstClientes();
        public List<ClienteEntidad> FillClientes(string nombre);
        public void AddCliente(ClienteEntidad oCliente);
        public void UpdCliente(ClienteEntidad oCliente);
        public void DelCliente(int id);
    }
}
