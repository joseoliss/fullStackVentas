using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.DB;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Services.Contracts
{
    public class ClienteService : IClienteService
    {         
        public List<ClienteEntidad> LstClientes()
        {
            List<ClienteEntidad> lstCliente = new List<ClienteEntidad>();
            ClienteEntidad oCliente;
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var clientes = (from d in db.Clientes
                               select d).ToList();
                    foreach (var cliente in clientes)
                    {
                        oCliente = new ClienteEntidad();
                        oCliente.Id = cliente.Id;
                        oCliente.Nombre = cliente.Nombre;
                        oCliente.Apellidos = cliente.Apellidos;
                        oCliente.Email = cliente.Email;
                        lstCliente.Add(oCliente);
                    }
                }
                return lstCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes: " + ex.Message);
            }
        }

        public List<ClienteEntidad> FillClientes(string nombre)
        {
            List<ClienteEntidad> lstCliente = new List<ClienteEntidad>();
            ClienteEntidad oCliente;
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var clientes = (from d in db.Clientes
                                    where d.Nombre.Contains(nombre)
                                    select d).ToList();
                    foreach (var cliente in clientes)
                    {
                        oCliente = new ClienteEntidad();
                        oCliente.Id = cliente.Id;
                        oCliente.Nombre = cliente.Nombre;
                        oCliente.Apellidos = cliente.Apellidos;
                        oCliente.Email = cliente.Email;
                        lstCliente.Add(oCliente);
                    }
                }
                return lstCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los clientes: " + ex.Message);
            }
        }

        public void AddCliente(ClienteEntidad oCliente)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente newCliente = new Cliente();
                    newCliente.Nombre = oCliente.Nombre;
                    newCliente.Apellidos = oCliente.Apellidos;
                    newCliente.Email = oCliente.Email;
                    db.Add(newCliente);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar un cliente: " + ex.Message);
            }
        }

        public void UpdCliente(ClienteEntidad oCliente)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente newCliente = db.Clientes.Find(oCliente.Id);
                    if (newCliente == null) throw new Exception("No se pudo encontrar el cliente");
                    newCliente.Nombre = oCliente.Nombre;
                    newCliente.Apellidos = oCliente.Apellidos;
                    newCliente.Email = oCliente.Email;
                    db.Entry(newCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente: " + ex.Message);
            }
        }

        public void DelCliente(int id)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Cliente oCliente = db.Clientes.Find(id);
                    if (oCliente == null) throw new Exception("No se pudo encontrar el cliente");
                    db.Remove(oCliente);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar un cliente: " + ex.Message);
            }
        }

    }
}
