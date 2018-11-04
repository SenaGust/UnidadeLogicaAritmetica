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

        private void button_AandB_Click(object sender, RoutedEventArgs e)
        {
            bool[] f = { false, false, false };
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando1.Text), f);
        }

        private void button_AorB_Click(object sender, RoutedEventArgs e)
        {
            bool[] f = { true, false, false };
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando1.Text), f);
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToSingle(textBoxOperando1.Text);
            y = Convert.ToSingle(textBoxOperando2.Text);

            //mudar para ponto flutuante

        }
        private void chamarULA8Bits(int a, int b, bool[] f)
        {
            //objetos
            Conversor Converter = new Conversor();
            UnidadeLogica8bits alu = new UnidadeLogica8bits();

            //converter os dois números inteiros para binários, nesse caso 8 bits máximo
            bool[] numA = Converter.InteiroParaBinario(8, Convert.ToInt32(textBoxOperando1.Text));
            bool[] numB = Converter.InteiroParaBinario(8, Convert.ToInt32(textBoxOperando2.Text));

            //chamando ula
            bool[] resultado = new bool[8];
            alu.ULA8Bits(numA, numB, f, resultado);

            //mostrando resultados
            resultado10.Text = Converter.imprimirBinario(resultado);
            textBoxOperando16A.Text = Converter.imprimirBinario(numA);
            textBoxOperando16B.Text = Converter.imprimirBinario(numB);
        }
    }
}
