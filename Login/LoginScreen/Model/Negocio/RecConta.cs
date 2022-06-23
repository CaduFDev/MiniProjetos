using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ADO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Model.Negocio
{
    public class RecConta : DAOConexao
    {
        internal async Task EnviarEmail(string emailDev, string emailUsuario, string usuario, string novaSenha)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailDev, "CamelDev ");
            var to = new EmailAddress(emailUsuario, usuario);
            var subject = "Integration with C#";
            var plainTextContent = "CamelDev: Troca de senha";
            var htmlContent = $"<Strong><h1>Olá, {usuario}</h1></Strong>" +
                              "<br><br><br>" +
                              "<h3> Recebemos sua solicitação para recuperação de senha</h3>" +
                              $"<h3> Sua senha agora é {novaSenha} </h3> ";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        internal int RecuperarConta(string emailUsuario = "", string cpf = "", string celular = "")
        {
            using (var conexao = Conexao())
            {
                conexao.Open();
                using (var comando = Comando(conexao))
                {
                    int idUsuario;
                    comando.CommandText = "SELECT * FROM dbo.USUARIOS WHERE EMAIL = @emailUsuario or CPF = @cpf or CELULAR = @celular;";
                    comando.Parameters.Add(new SqlParameter("@emailUsuario", emailUsuario));
                    comando.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comando.Parameters.Add(new SqlParameter("@celular", celular));
                    comando.CommandType = CommandType.Text;
                    return idUsuario = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }
        internal string[] infoUsuario(int id)
        {
            using (var conexao = Conexao())
            {
                conexao.Open();
                using (var comando = Comando(conexao))
                {
                    string[] infoUsuario = new string[5];
                    comando.CommandText = "SELECT * FROM dbo.USUARIOS WHERE ID = @id;";
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    comando.CommandType = CommandType.Text;
                    using (var listar = Leitor(comando))
                    {
                        if (listar.HasRows)
                        {
                            //cpf
                            infoUsuario[0] = listar[1].ToString();
                            //usuario
                            infoUsuario[1] = listar[2].ToString();
                            //senha
                            infoUsuario[2] = listar[3].ToString();
                            //email
                            infoUsuario[3] = listar[4].ToString();
                            //celualr
                            infoUsuario[4] = listar[5].ToString();
                            return infoUsuario;
                        }
                        return infoUsuario;
                    }
                }
            }
        }
    }
}
