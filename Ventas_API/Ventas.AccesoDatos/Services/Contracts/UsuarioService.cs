using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.DB;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.AccesoDatos.Tools;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Request;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.Services.Contracts
{
    public class UsuarioService : IUsuarioService
    {
        #region METODOS PRIVADOS
            /// <summary>
            /// Metodo para generar el JWT
            /// </summary>
            /// <param name="usuario">Modelo del usuario de la db</param>
            /// <param name="secreto">El secreto desde el appSettings del API</param>
            /// <returns>RETORNA EL TOKEN</returns>
            private string GetToken(Usuario usuario, string secreto)
            {
                var tokenHndler = new JwtSecurityTokenHandler();

                var llave = Encoding.ASCII.GetBytes(secreto);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                       new Claim[]
                       {
                           new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                           new Claim(ClaimTypes.Email, usuario.Email)
                       }
                       ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHndler.CreateToken(tokenDescriptor);
                return tokenHndler.WriteToken(token);
            }
        #endregion

        #region MÉTODOS PÚBLICOS  
        /// <summary>
        /// Metodo que verifica si el usuario existe en la base de datos y hacer autenticación con json web token
        /// </summary>
        /// <param name="model">Recive el correo y la contraseña</param>
        /// <param name="secreto">El secreto que le pasamos al metodo GetToken para generar el token</param>
        /// <returns>Retorna null si no existe, y el email + token si existe</returns>
        public AuthResponse Login(AuthRequest model, string secreto)
        {
            try
            {
                AuthResponse userResponse = new AuthResponse();
                using (var db = new VentasContext())
                {
                    string password = EncryptPass.GetSHA256(model.Password);
                    var usuario = db.Usuarios.Where(d => d.Password == password &&
                                                    d.Email == model.Email).FirstOrDefault();
                    if (usuario == null) return null;
                    userResponse.Email = usuario.Email;
                    userResponse.Token = GetToken(usuario, secreto);
                }
                return userResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsuarioEntidad> LstUsuario()
        {
            List<UsuarioEntidad> lstUsuario = new List<UsuarioEntidad>();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var usuarios = (from d in db.Usuarios
                                         select d).ToList();
                    foreach (var usuario in usuarios)
                    {
                        UsuarioEntidad oUsuario = new UsuarioEntidad();
                        oUsuario.Id = usuario.Id;
                        oUsuario.Email = usuario.Email;
                        oUsuario.Password = usuario.Password;
                        oUsuario.Nombre = usuario.Nombre;
                        lstUsuario.Add(oUsuario);
                    }
                }
                return lstUsuario;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar los usuarios: "+ex.Message);
            }
        }

        public List<UsuarioEntidad> FillUsuario(string nombre)
        {
            List<UsuarioEntidad> lstUsuario = new List<UsuarioEntidad>();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var usuarios = (from d in db.Usuarios
                                    where d.Nombre.Contains(nombre)
                                    select d).ToList();
                    foreach (var usuario in usuarios)
                    {
                        UsuarioEntidad oUsuario = new UsuarioEntidad();
                        oUsuario.Id = usuario.Id;
                        oUsuario.Email = usuario.Email;
                        oUsuario.Password = usuario.Password;
                        oUsuario.Nombre = usuario.Nombre;
                        lstUsuario.Add(oUsuario);
                    }
                }
                return lstUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el usuario: " + ex.Message);
            }
        }

        public void AddUsuario(UsuarioEntidad oUsuario)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Usuario newUsuario = new Usuario();
                    newUsuario.Nombre = oUsuario.Nombre;
                    newUsuario.Email = oUsuario.Email;
                    newUsuario.Password = EncryptPass.GetSHA256(oUsuario.Password);
                    db.Usuarios.Add(newUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar el usuario: " + ex.Message);
            }
        }

        public void UpdUsuario(UsuarioEntidad oUsuario)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Usuario newUsuario = db.Usuarios.Find(oUsuario.Id);
                    if (newUsuario == null) throw new Exception("No se pudo encontrar el usuario");
                    newUsuario.Nombre = oUsuario.Nombre;
                    newUsuario.Email = oUsuario.Email;
                    newUsuario.Password = EncryptPass.GetSHA256(oUsuario.Password);
                    db.Entry(newUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar el usuario: " + ex.Message);
            }
        }

        public void DelUsuario(int id)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Usuario newUsuario = db.Usuarios.Find(id);
                    if (newUsuario == null) throw new Exception("No se pudo encontrar el usuario");
                    db.Remove(newUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar el usuario: " + ex.Message);
            }
        }
        #endregion

    }
}
