using System;
using System.Windows.Forms;
using VisualPerception.Student;
using VisualPerception.Teacher;

namespace VisualPerception
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form34());
        }
    }
}
