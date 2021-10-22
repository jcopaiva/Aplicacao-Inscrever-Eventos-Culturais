using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EventosNormal : Form
    {
        ServicoCentralWS.PessoaS username;

        public EventosNormal(ServicoCentralWS.PessoaS user)
        {
            username = user;
            InitializeComponent();
        }

        private void EventosNormal_Load(object sender, EventArgs e)
        {
            ServicoCentralWS.CentralServicoSoapClient aux = new ServicoCentralWS.CentralServicoSoapClient();
            ServicoCentralWS.EventoS[] listaE = aux.ResListaEventos();

            // funcao para popular comboBox1 (lista de eventos)
            for (int i = 0; i < listaE.Length; i++)
            {
                if (listaE[i].Lotacao >= listaE[i].Capacidade) // ver se está cheio
                {
                    this.comboBox1.Items.Add(listaE[i].Nome + " - Evento Cheio");
                }
                else if (listaE[i].Capacidade == 0) // ver se foi cancelado
                {
                    this.comboBox1.Items.Add(listaE[i].Nome + " - Evento Indisponível");
                }
                else
                {                 
                    this.comboBox1.Items.Add(listaE[i].Nome);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicoCentralWS.CentralServicoSoapClient aux = new ServicoCentralWS.CentralServicoSoapClient();
            ServicoCentralWS.EventoS[] listaE = aux.ResListaEventos();
            var eventoEscolhido = new ServicoCentralWS.EventoS();

            string nomeAux = comboBox1.SelectedItem.ToString();

            for (int i = 0; i < listaE.Length; i++)
            {
                if (nomeAux.Contains(listaE[i].Nome)) // encontrar o evento correspondente
                {
                    eventoEscolhido = listaE[i];
                }
            }

            VerEventoN obj = new VerEventoN(username, eventoEscolhido);
            obj.Show();
            this.Hide();
        }

    }
}
