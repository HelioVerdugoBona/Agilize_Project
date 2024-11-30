using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolder = Path.Combine(documentsPath, "Agilize");
            Directory.CreateDirectory(appFolder);  
            
            Application.Run(new Login(appFolder));
        }
    }
}
