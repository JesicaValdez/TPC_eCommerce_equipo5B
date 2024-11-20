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

        private string myEmail = "devops.codetesting@gmail.com";
        private string myPassword = "fngv fkzp wwyq canu";

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential(myEmail, myPassword);
            server.EnableSsl = true;
            server.Port = 25;
            server.Host = "smtp.gmail.com";
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
