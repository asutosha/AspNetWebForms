using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Util.ReenvioSenha
{
    public class ControleEnvioSenha : IControleEnvioSenha
    {
        private readonly string conta = "4pptester@gmail.com";
        private readonly string senha = "meri2009";
        private readonly string smtp = "smtp.gmail.com";
        private readonly int porta = 587;

        public void EnvioSenha(string email, string msgBody)
        {
            try
            {
                MailMessage msg = new MailMessage(conta, email);

                msg.Subject = "Reenvio de Senha";
                msg.Body = "Utilize a senha: " + msgBody;

                SmtpClient s = new SmtpClient(smtp, porta);

                s.EnableSsl = true;
                s.Credentials = new NetworkCredential(conta, senha);
                s.Send(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
