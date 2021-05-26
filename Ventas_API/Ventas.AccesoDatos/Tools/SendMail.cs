using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Tools
{
    public class SendMail
    {
        public static void PasswordRecovery(string EmailDestino, string token)
        {
            string EmailOrigen = "prograAvanzadaPayPal@gmail.com";
            string Contraseña = "paypal123";
            string url = "http://localhost:64514/PasswordRecovery/NuevaContraseña/?token=" + token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Contraseña recuperada",
                "<p></p>" + "<a href='" + url + "'>Abra este enlace para cambiar la contraseña</a>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;

            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

        }
    }
}
