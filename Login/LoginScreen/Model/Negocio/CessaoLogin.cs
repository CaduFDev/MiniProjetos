using Model.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Model.Negocio
{
    public class CessaoLogin : DAOConexao
    {
        public bool Logar(string usuario, string senha)
        {
            using (var conexao = Conexao())
            {
                conexao.Open();
                using (var comando = Comando(conexao))
                {
                    comando.CommandText = "SELECT * FROM dbo.USUARIOS WHERE USUARIO = @usuario AND SENHA = @senha;";
                    comando.Parameters.Add(new SqlParameter("@usuario", usuario));
                    comando.Parameters.Add(new SqlParameter("@senha", senha));
                    comando.CommandType = CommandType.Text;
                    using (var leitor = Leitor(comando))
                    {
                        if (leitor.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }

        }
        public void CriarUsuario(string cpf, string usuario, string senha, string email, string celular)
        {
            using (var conexao = Conexao())
            {
                conexao.Open();
                using (var comando = Comando(conexao))
                {
                    comando.CommandText = "INSERIR_USUARIO";
                    comando.Parameters.Add(new SqlParameter("@CPF", cpf));
                    comando.Parameters.Add(new SqlParameter("@USUARIO", usuario));
                    comando.Parameters.Add(new SqlParameter("@SENHA", senha));
                    comando.Parameters.Add(new SqlParameter("@EMAIL", email));
                    comando.Parameters.Add(new SqlParameter("@CELULAR", celular));
                    comando.CommandType = CommandType.StoredProcedure;
                    var resultado = comando.ExecuteNonQuery();
                }
            }
        }
        public async Task ConfirmarContaEmail(string emailDev, string emailUsuario, string usuario)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailDev, "CamelDev ");
            var to = new EmailAddress(emailUsuario, usuario);
            var subject = "Integration with C#";
            var plainTextContent = "Seja bem vindo a CamelDev!";
            var htmlContent = $"<Strong><h1>Olá, {usuario}</h1></Strong>" +
                              "<br><br><br>" +
                              "<h3> Recebemos sua solicitação para criação de conta!</h3>" +
                              $"<h3>Toda informação importante será enviada pelo e-mail tudo bem ?!</h3> ";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
