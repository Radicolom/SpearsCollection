using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClRecursosL
    {

        public static string MtdEncrip(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enco = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enco.GetBytes(texto));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        public bool MtdVerificar(string correo)
        {
            bool resultado = false;
            ClUsuarioD objUsuario = new ClUsuarioD();
            List<ClUsuarioE> datos = objUsuario.MtdListar();
            if (datos.Count > 0)
            {
                resultado = MtdEnvioEmail(correo, datos[0].correoUsuario);

            }
            return resultado;
        }

        //Configurar credenciales
        private bool MtdEnvioEmail(string destino, string contrasena)
        {
            try
            {
                // Dirección de correo electrónico del remitente y sus credenciales
                string remitenteEmail = "diegog480@gmail.com";
                string remitenteContraseña = "yaxheilxpytjcbkq";

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(remitenteEmail, remitenteContraseña);
                    smtpClient.EnableSsl = true;

                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(remitenteEmail);
                        //mensaje.To.Add("diegog480@gmail.com");
                        mensaje.To.Add(destino);
                        mensaje.Subject = "Recuperación de contraseña";

                        // Cuerpo del mensaje
                        mensaje.Body = "Tu contraseña es: " + contrasena;

                        // Envía el correo
                        smtpClient.Send(mensaje);

                        return true; // El correo se envió con éxito
                    }
                }
            }
            catch (Exception ex)
            {
                return false; // Hubo un error al enviar el correo
            }
        }

    }
}
