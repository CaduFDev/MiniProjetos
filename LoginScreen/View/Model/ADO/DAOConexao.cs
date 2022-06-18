using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ADO
{
    public class DAOConexao
    {
        public string StringDeConexao { get; set; }
        public DAOConexao()
        {
            StringDeConexao = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        }

        
    }
}
