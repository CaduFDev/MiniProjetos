using Model.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreen
{
    public partial class frmRecConta : Form
    {
        public frmRecConta()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            RecConta recConta = new RecConta();
            
            string[] infoUsuario = new string[5];
            int idUsuario = recConta.RecuperarConta(Convert.ToString(textBox1.Text));
            
            infoUsuario = recConta.infoUsuario(idUsuario);
            
             recConta.EnviarEmail(infoUsuario[3].ToString(), infoUsuario[1].ToString(), infoUsuario[2].ToString()).Wait();
            MessageBox.Show("Senha  enviada no E-Mail cadastrado!");

        }
    }
}
