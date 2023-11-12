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
using static CapaEntidad.ClDatos;

namespace CapaNegocio
{
    public class ClRecursosL
    {
        public string MtdPassGene(out string passGener)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            string password = MtdEncrip(sb.ToString());
            passGener = sb.ToString();

            return password;
        }

        private static string MtdEncrip(string texto)
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

        //Configurar credenciales
        public static void MtdEnvioEmail(string destino, string contrasena)
        {
            try
            {
                // Dirección de correo electrónico del remitente y sus credenciales
                string remitenteEmail = "speearscollectionbbc@gmail.com";
                string remitenteContraseña = "dpzlxdotndzhalkj";

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(remitenteEmail, remitenteContraseña);
                    smtpClient.EnableSsl = true;

                    using (MailMessage mensaje = new MailMessage())
                    {
                        mensaje.From = new MailAddress(remitenteEmail);
                        if (destino.Equals("error"))
                        {
                            destino = "speearscollectionbbc@gmail.com";
                        }
                        mensaje.To.Add(destino);
                        mensaje.Subject = "Tu contraseña";

                        // Cuerpo del mensaje
                        mensaje.Body = "Tu contraseña es: " + contrasena;

                        // Envía el correo
                        smtpClient.Send(mensaje);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
