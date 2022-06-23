using Model.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model.Negocio
{
    public class CessaoLogin : DAOConexao
    {
        internal bool Logar(string usuario, string senha)
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
        internal void CriarUsuario(string cpf, string usuario, string senha, string email, string celular)
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
    }
}
