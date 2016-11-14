using Client.ServiciuLectori;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Meniu
{
    public partial class CorectareTest : Form
    {
        private ServiciuLectoriClient serviciuLectori;
        private List<TesteSalvateInBazaDeDate> vListTestSalvatInBD;
        private TestCreatDeLector vTestCreatDeLector;
        private Cursanti vCursant;
        private int index = 0;
        private double[] punctaje;

        public CorectareTest()
        {
            InitializeComponent();
            serviciuLectori = new ServiciuLectoriClient();
            vListTestSalvatInBD = new List<TesteSalvateInBazaDeDate>();
        }

        private void CorectareTest_Load(object sender, EventArgs e)
        {
            //comboBox1
            var lista = serviciuLectori.GetListaDiscipline().Select(s=>s.NumeDisciplina).ToList();
            comboBox1.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            var lista = serviciuLectori.GetListaLectoriPerDisciplina(comboBox1.Text).Select(s=>s.ContLector).ToList();
            comboBox2.DataSource = lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lista = serviciuLectori.GetListTesteCreateDeLectorByContLector(comboBox2.Text).Select(s=>s.NumeTest).ToList();
            comboBox3.DataSource = lista;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lista = serviciuLectori.GetListaCursantiCareAuDatTestulCreatDeLectorByNumeTest(comboBox3.Text).Select(s => s.ContCursant).ToList();
            comboBox4.DataSource = lista;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            comboBox3.DataSource = null;
            comboBox4.DataSource = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = null;
            comboBox4.DataSource = null;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vTestCreatDeLector = serviciuLectori.GetTestCreatDeLectorByName(comboBox3.Text);
            vCursant = serviciuLectori.GetCursantByCont(comboBox4.Text);
            var lista = serviciuLectori.GetListaTesteSalvateInBazaDeDateByID_CURSANT_ID_TestCreatDeLector(vCursant.IdCursant, vTestCreatDeLector.IdTest);

            foreach(var v in lista)
            {
                vListTestSalvatInBD.Add(v);
            }

            ActualizareInformatii(index);

            textBox1.ReadOnly = false;

            punctaje = new double[vTestCreatDeLector.NrIntrebari];
        }


        void ActualizareInformatii(int nr)
        {
            textBox1.Text = "   "+(index+1)+".   "+vListTestSalvatInBD[nr].Intrebari.Intrebarea;          
            var rasp = vListTestSalvatInBD[nr].Intrebari.Raspunsuris;
            cBoxStud.Items.Clear();
            checkBoxProf.Items.Clear();
            foreach (var v in rasp)
            {
                cBoxStud.Items.Add(v.Raspuns);
                checkBoxProf.Items.Add(v.Raspuns);
            }
            cBoxStud.SelectionMode = SelectionMode.None;
            checkBoxProf.SelectionMode = SelectionMode.None;

            justificareStud.Text = vListTestSalvatInBD[nr].MotivareRaspuns;
            justificareStud.ReadOnly = true;
            justificareProof.ReadOnly = true;

            // raspunsuri date de student
            var raspArray = vListTestSalvatInBD[nr].Raspuns.ToArray();
                for (int i = 0; i < rasp.Length; i++)
                {
                    if (raspArray[i] == '1')
                    {
                        cBoxStud.SetItemChecked(i, true);
                    }
                }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            var raspu = vListTestSalvatInBD[nr].Intrebari.Raspunsuris;
            for(int i=0; i<raspu.Count();i++)
            {
                if (raspu[i].RaspunsCorect==1)
                {
                    checkBoxProf.SetItemChecked(i, true);
                }
            }

            var justif = vListTestSalvatInBD[nr].Intrebari.Raspunsuris.Select(s => s.MotivareRaspuns).Distinct().ToList();
            string justificareProofstr = "";
            foreach(var v in justif)
            {
                justificareProofstr += v;
                justificareProofstr += "\r\n";
            }

            justificareProof.Text = justificareProofstr;


            try
            {
                textPunctaje.Text = punctaje[index].ToString();
            }
            catch(Exception)
            {
                textPunctaje.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            index++;
            if (index >= (vListTestSalvatInBD.Count - 1))
                next.Enabled = false;
            else
            {
                prev.Enabled = true;
            }
            ActualizareInformatii(index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                prev.Enabled = false;
                index = 0;
            }
            else
            {
                next.Enabled = true;
                ActualizareInformatii(index);
               
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            punctaje[index] = Convert.ToDouble(textPunctaje.Text);
        }
    }
}
