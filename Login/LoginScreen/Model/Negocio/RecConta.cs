using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ADO;
using Model.Tabelas;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace Model.Negocio
{
    public class RecConta : DAOConexao
    {
        public int RecuperarConta(string cpf)
        {
            using (var conexao = Conexao())
            {
                conexao.Open();
                using (var comando = Comando(conexao))
                {
                    int idUsuario;
                    comando.CommandText = "SELECT * FROM dbo.USUARIOS WHERE CPF = @cpf;";                    
                    comando.Parameters.Add(new SqlParameter("@cpf", cpf));                   
                    comando.CommandType = CommandType.Text;
                    return idUsuario = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }
        public string[] infoUsuario(int id)
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
                            while (listar.Read())
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
                            }
                        }
                        return infoUsuario;
                    }
                }
            }
        }
        public async Task EnviarEmail(string emailUsuario, string usuario, string senha)
        {
            var apiKey = Environment.GetEnvironmentVariable("xAgyoI6lQOKDVlXsvT6Djw");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("cefamaral22@outlook.com", "CamelDev ");
            var to = new EmailAddress(emailUsuario, usuario);
            var subject = "Integration with C#";
            var plainTextContent = "CamelDev: Troca de senha";
            var htmlContent =  $"<h3> Sua senha é {senha}</h3> ";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }

        public async Task EnviarSenha(string emailUsuario, string usuario, string senha)
        {
            var email = new SendGridMessage();
            email.AddTo("cefamaral22@outlook.com","CamelDev");
            email.From = new EmailAddress(emailUsuario, usuario);
            email.Subject = ("Recuperação de conta");
            email.HtmlContent = $"<h3> Sua senha é {senha}</h3> ";        
        }
        
    }
}
