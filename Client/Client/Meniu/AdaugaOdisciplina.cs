using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ServiciuLectori;

namespace Client.Meniu
{
    public partial class AdaugaOdisciplina : Form
    {
        private ServiciuLectoriClient serviciuLectori;

        public AdaugaOdisciplina()
        {
            InitializeComponent();
            serviciuLectori = new ServiciuLectoriClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disciplina d = new Disciplina
            {
                NumeDisciplina = numeDisciplina.Text
            };
            d.State = State.Added;
            serviciuLectori.DisciplinaUDI(d);

            listareDiscipline();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(idDisciplina.Text!="")
            {
                Disciplina d = serviciuLectori.GetDisciplinaById(Convert.ToInt32(idDisciplina.Text));

                try
                {
                    numeDisciplina.Text = d.NumeDisciplina;
                }
                catch(Exception)
                {
                    numeDisciplina.Text = "Id invalid";
                }
                
            }       
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Disciplina d = serviciuLectori.GetDisciplinaById(Convert.ToInt32(idDisciplina.Text));
            Capitole c= new Capitole
            {
                DisciplinaIdDisciplina = d.IdDisciplina,
                NumeCapitol = capitolDis.Text
            };

            c.State = State.Added;
            serviciuLectori.CapitoleUDI(c);

            listareDiscipline();
        }

        void listareDiscipline()
        {
            listBox1.Items.Clear();

            var lista = serviciuLectori.GetListaDiscipline();
            foreach(var disicplina in lista)
            {
                listBox1.Items.Add(disicplina.IdDisciplina+".    "+disicplina.NumeDisciplina);
                foreach(var capitole in disicplina.Capitoles )
                {
                    listBox1.Items.Add("                " + capitole.NumeCapitol);
                }
                listBox1.Items.Add("");
            }
        }

        private void AdaugaOdisciplina_Load(object sender, EventArgs e)
        {
            listareDiscipline();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var disciplina = serviciuLectori.GetDisciplinaById(Convert.ToInt32(idDisciplina.Text));
        }
    }
}
