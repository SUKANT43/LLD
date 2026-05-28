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
    public partial class Form2 : Form
    {
        Form1 _form1;
        public Form2()
        {
            InitializeComponent();
        }

        public void UpdaeText(string txt)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => {
                    label1.Text = txt;
                }));
            }

            else
            {
                label1.Text = txt;
            }

        }

        public void SetForm1(Form1 form1)
        {
            _form1 = form1;
        }


    }
}
