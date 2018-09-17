using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salary_Calculator
{
    public partial class Form2 : Form
    {
        Form1 form1;
        decimal aday = 0;
        decimal bday = 0;
        decimal cday = 0;
        decimal conVal = 0;
        decimal aPay = 0;
        decimal bPay = 0;
        decimal cPay = 0;
        int acount = 0;
        int bcount = 0;
        int ccount = 0;
        public List<String> empForm = new List<String>();
        public List<Decimal> daysForm = new List<Decimal>();
        public List<String> payForm = new List<String>();
        String str;
      
        public Form2(Form1 form_1)
        {
            InitializeComponent();
            form1 = form_1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            empForm.AddRange(form1.empcode);
            daysForm.AddRange(form1.days_value);
            payForm.AddRange(form1.pay);
            for (int i = 0; i < empForm.Count(); i++)
            {

                listBox1.Items.Add(empForm[i].ToUpper()+ " "+daysForm[i]);
            }

        

            for(int i=0; i < empForm.Count(); i++)
            {
                str = empForm[i];
                conVal = Convert.ToDecimal(payForm[i]);
                if(str[0]=='A' || str[0] == 'a')
                {
                    aday = aday + daysForm[i];
                    label12.Text = (aday.ToString());
                    aPay = aPay + conVal;
                    label15.Text = (aPay.ToString());
                    acount++;
                    label9.Text = (acount.ToString());
                    //MessageBox.Show("Value A");
                }
                else if (str[0] == 'B' || str[0] == 'b')
                {
                    bday = bday + daysForm[i];
                    label13.Text = (bday.ToString());
                    bPay = bPay + conVal;
                    label16.Text = (bPay.ToString());
                    bcount++;
                    label10.Text = (bcount.ToString());
                    //MessageBox.Show("Value B");
                }
                else
                {
                    cday = cday + daysForm[i];
                    label14.Text = (cday.ToString());
                    cPay = cPay + conVal;
                    label17.Text = (cPay.ToString());
                    ccount++;
                    label11.Text = (ccount.ToString());
                    //MessageBox.Show("Value C");
                }
            }

        }
    }
}
