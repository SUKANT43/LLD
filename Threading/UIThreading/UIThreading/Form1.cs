using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIThreading
{
    public partial class Form1 : Form
    {

        Form2 _form2;

        public event Action<string> TextChangedEvent;

        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += UpdateFrom2;
        }

        private void UpdateFrom2(object sender, EventArgs e)
        {

           // _form2.UpdaeText(textBox1.Text);

            TextChangedEvent?.Invoke(textBox1.Text);
        }

        public void SetForm2(Form2 form2)
        {
            _form2 = form2;
        }


    }
}
