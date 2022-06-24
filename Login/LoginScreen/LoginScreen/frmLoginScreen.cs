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
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            CessaoLogin cessaoLogin = new CessaoLogin();
            try
            {
                if (cessaoLogin.Logar(Convert.ToString(txtLogin.Text), Convert.ToString(txtSenha.Text)))
                {
                    MessageBox.Show("Bem vindo!");
                }
                else
                {
                    var mensagem = MessageBox.Show("Login ou Senha, estão incorretos \nDeseja recuperar a senha?", "Cessão Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mensagem == DialogResult.Yes)
                    {
                        frmRecConta recConta = new frmRecConta();
                        recConta.Show();
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmCriarConta novaConta = new frmCriarConta();
                novaConta.Show();                
                this.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
