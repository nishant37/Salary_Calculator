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
    public partial class Form1 : Form
    {
        String str1;
        
        decimal days;

        public List<String> empcode = new List<String>();
        public List<Decimal> days_value = new List<Decimal>();
        public List<String> pay = new List<String>();
      
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                str1 = Convert.ToString(textBox1.Text);
                empcode.Add(str1);

                days = Convert.ToDecimal(textBox2.Text);
                days_value.Add(days);
                if (str1[0] == 'A' || str1[0] == 'a')
                {
                   
                    decimal Total = 100 * days;
                    var NewValue = Total.ToString("N2");
                    pay.Add(NewValue);
                  
                    label8.Text = NewValue;
                }
                else if (str1[0] == 'B' || str1[0] == 'b')
                {
                   
                    decimal Total = 200 * days;
                    var NewValue = Total.ToString("N2");
                    pay.Add(NewValue);
                  
                    label8.Text = NewValue;
                }
                else if (str1[0] == 'C' || str1[0] == 'c')
                {
                   
                    decimal Total = 300 * days;
                    
                    var NewValue = Total.ToString("N2");
                    pay.Add(NewValue);
                  
                    
                    label8.Text = NewValue;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        public bool IsWithinRange(TextBox textbox, string name,decimal min,decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text);
            if(number<min || number > max)
            {
                MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error");
                textbox.Focus();
                return false;
            }
            return true;
        }


        public bool IsValidData()
        {
            // Check Validation for grades
            return
                IsPresent(textBox1, "Employee ID") &&
               IsDigit(textBox1, "Employee ID") &&
                IsWithinRange(textBox1, "Employee ID", 'A', 'C') &&
                length(textBox1, "Employee ID") &&


            // Check Validation for Credit Hours
            IsPresent(textBox2, "Total Days") &&
            IsDecimal(textBox2, "Total Days") &&
              IsWithinRange(textBox2, "Total Days", 0, 25);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field. ", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDigit(TextBox textBox, string name)
        {
            String str = Convert.ToString(textBox1.Text.ToUpper());
             char ch1 = str[1];
            char ch2 = str[2];
            if(Char.IsDigit(ch1) && Char.IsDigit(ch2))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The 2nd and 3rd character of "+name+ " must be a digit.", "Entry error");
                textBox.Clear();
                textBox.Focus();
                return false;
            }
        }
       
        private bool IsWithinRange(TextBox textBox, string name, char min, char max)
        {

            String textboxstring = Convert.ToString(textBox1.Text.ToUpper());
            Char character = textboxstring[0]; 
           
            int value = Convert.ToInt32(character);
            //MessageBox.Show(value.ToString());
           
           if (value <=67 )
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must begin with A or B or C. ", "Entry error");
                textBox.Clear();
                textBox.Focus();
                return false;
            }

        }
        
        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "INPUT ERROR");
                textBox.Focus();
                return false;
            }
        }

        public bool length(TextBox textBox, string name)
        {
            if (textBox.Text.Length == 3)
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must contain exactly three characters. ", "Entry Error");
                textBox.Focus();
                return false;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }
    }
}
