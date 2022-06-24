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
    public partial class frmCriarConta : Form
    {
        public frmCriarConta()
        {
            InitializeComponent();
        }
        private void frmCriarConta_Load(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            txtCpf.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
        }
        
        private string cpf;
        public string CPF
        {
            get { return cpf = txtCpf.Text; ; }
            set { cpf = value; }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario = txtUsuario.Text; }
            set { usuario = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha = txtSenha.Text; }
            set { senha = value; }
        }

        private string email;
        public string Email
        {
            get { return email = txtEmail.Text; }
            set { email = value; }
        }

        private string celular;
        public string Celular
        {
            get { return celular = txtCelular.Text; }
            set { celular = value; }
        }


        private void btnCriar_Click(object sender, EventArgs e)
        {
            CessaoLogin cessaoLogin = new CessaoLogin();
            try
            {
                cessaoLogin.CriarUsuario(CPF, Usuario, Senha, Email, Celular);                
                MessageBox.Show("Usuario cadastrado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
    }
}
