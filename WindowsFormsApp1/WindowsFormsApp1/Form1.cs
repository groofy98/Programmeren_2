using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Persoon> personen;

        public Form1() 
        {
            InitializeComponent();            
            Persoon sjors = new Persoon("sjors");
            Persoon twan = new Persoon("twan");
            Persoon trix = new Persoon("trix");
            Persoon just = new Persoon("just");
            Persoon dick = new Persoon("dick");
            Persoon lucia = new Persoon("lucia");
            personen = new List<Persoon> {sjors, twan, trix, just, dick, lucia };            

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string temp = "over: ";
            foreach(Persoon p in personen)
            {
                if (!p.ingenomen)
                {
                    temp += (p.naam + ", ");
                }
            }
            label2.Text = temp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            personen[0].ingenomen = true;
            button2.Select();
            checkOver();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            personen[1].ingenomen = true;
            button2.Select();
            checkOver();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            personen[2].ingenomen = true;
            button2.Select();
            checkOver();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            personen[3].ingenomen = true;
            button2.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            personen[4].ingenomen = true;
            button2.Select();
            checkOver();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            personen[5].ingenomen = true;
            button2.Select();
            checkOver();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach(Persoon p in personen)
            {
                p.ingenomen = false;
            }
            checkOver();
        }

        private void checkOver()
        {
            int temp = 6;
            foreach (Persoon p in personen)
            {
                if (p.ingenomen)
                {
                    temp--;
                }
            }
            label3.Text = "Aantal over: " + temp;

        }
    }
}
