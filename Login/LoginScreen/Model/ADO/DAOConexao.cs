using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Model.ADO
{
    public class DAOConexao
    {
        public string StringDeConexao { get; set; }
        public DAOConexao()
        {
            StringDeConexao = "Server=localhost;Database=MiniProjetos;User Id=sa;Password=35487761;";
        }
        
        protected SqlConnection Conexao()
        {
            return new SqlConnection(StringDeConexao);
        }

        protected DbCommand Comando (DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }

        protected DbDataReader Leitor(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
        
    }
}
