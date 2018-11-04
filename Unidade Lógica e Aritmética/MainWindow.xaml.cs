using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Unidade_Lógica_e_Aritmética
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        float x, y;
        bool val1, val2;

        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToSingle(textBoxOperando1.Text);
            y = Convert.ToSingle(textBoxOperando2.Text);

            //mudar para ponto flutuante
            
        }
    }
}
