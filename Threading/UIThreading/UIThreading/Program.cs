using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIThreading
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        public static Form1 form1=null;
        public static Form2 form2=null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Thread thread1 = new Thread(() =>
            {
                  form1 = new Form1();
                  Application.Run(form1);
            });

            Thread thread2 = new Thread(() =>
            {
                  form2 = new Form2();
                  Application.Run(form2);
            });

            thread1.SetApartmentState(ApartmentState.STA);
            thread2.SetApartmentState(ApartmentState.STA);

            thread1.Start();
            thread2.Start();

            while (form1 == null || form2 == null)
            {
                Thread.Sleep(10);
            }

            form1.SetForm2(form2);
            form2.SetForm1(form1);

            form1.TextChangedEvent += form2.UpdaeText;

            thread1.Join();
            thread2.Join();

        }
    }
}
