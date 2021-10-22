using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) // botao login
        {
            ServicoCentralWS.CentralServicoSoapClient aux = new ServicoCentralWS.CentralServicoSoapClient();
            string user = textBox1.Text;
            string pass = textBox2.Text;
            ServicoCentralWS.PessoaS pessoa = aux.ResultadoLogin(user, pass);
            if (pessoa.Tipo == 1)
            {
                MessageBox.Show("Login efetuado com sucesso.");
                PainelAdmin obj = new PainelAdmin(pessoa);
                obj.Show();
                this.Hide();
            }
            else if (pessoa.Tipo == 0)
            {
                EventosNormal obj = new EventosNormal(pessoa);
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(pessoa.Nome, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e) // botao registo
        {
            Signup obj = new Signup();
            obj.Show();
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) // quando se dá enter na textbox do usernmae, passa para a outra textbox
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e) // quando se dá enter na textbox da password, chama o botao login
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

    }
}
