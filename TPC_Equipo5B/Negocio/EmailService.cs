using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            server.EnableSsl = true;
            server.Port = smtpPort;
            server.Host = smtpHost;
        }
        public void armarCorreo(string correoDestino, string asutno, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreponder@tuticket.com");
            email.To.Add(correoDestino);
            email.Subject = asutno;
            email.Body = cuerpo;    
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
