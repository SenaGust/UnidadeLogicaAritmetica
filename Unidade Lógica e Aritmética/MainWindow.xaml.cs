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
            MessageBox.Show("Esta unidade lógica e aritmética está funcionando com até 8 bits.", "Aviso Importante", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            InitializeComponent();
        }

        #region Implementação dos botões
        private void button_AandB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  0  A and B
            bool[] f = { false, false, false }; //o contrario
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando2.Text), f);
        }

        private void button_AorB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  1  A or B
            bool[] f = { true, false, false }; //o contrario
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando2.Text), f);
        }

        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //1  0  0  A + B
            bool[] f = { false, false, true }; //o contrario
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando2.Text), f);
        }

        private void buttonSubtracao_Click(object sender, RoutedEventArgs e)
        {
            UnidadeLogica8bits ALU8 = new UnidadeLogica8bits();
            Conversor Converter = new Conversor();

            bool[] F = new bool[3];
            bool[] um = { false, false, false, false, false, false, false, true };

            bool[] A = Converter.InteiroParaBinario(8, Convert.ToInt32(textBoxOperando1.Text));
            bool[] B = Converter.InteiroParaBinario(8, Convert.ToInt32(textBoxOperando2.Text));
            bool[] resultado = new bool[8];

        //    *F2 F1 F0 Saída
        //* 0  0  0  A and B
        //* 0  0  1  A or B
        //* 0  1  0  Not A
        // *0  1  1  Not B
        // *1  0  0  A + B
        //* 1  0  1  A - B
        //* 1  1  0 -
        //*1  1  1 -


          // A-B = A - NOT(B) + 1						
          F[0] = true; F[1] = true; F[2] = false;  // *0  1  1  Not B 	NOT(B)	
            ALU8.ULA8Bits(A, B, F, resultado);
            F[0] = false; F[1] = false; F[2] = true;  // *1  0  0  A + B 	A + NOT(B)						
            ALU8.ULA8Bits(A, resultado, F, resultado);
            F[0] = false; F[1] = false; F[2] = true; // F2F1F0 =  101 	A + NOT(B) + 1						
            ALU8.ULA8Bits(resultado, um, F, resultado);

            textBoxResultado16.Text = Converter.BinarioParaHexadecimal(resultado);
            textBoxResultado10.Text = Convert.ToString(Converter.BinarioParaInteiro(resultado));
            textBoxOperando16A.Text = Converter.BinarioParaHexadecimal(A);
            textBoxOperando16B.Text = Converter.BinarioParaHexadecimal(B);
        }

        private void button_notA_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  0  Not A
            bool[] f = { false, true, false }; //o contrario
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando2.Text), f);
        }

        private void button_notB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  1  Not B
            bool[] f = { true, true, false }; //o contrario
            chamarULA8Bits(Convert.ToInt32(textBoxOperando1.Text), Convert.ToInt32(textBoxOperando2.Text), f);
        }

        private void buttonLimpar_Click(object sender, RoutedEventArgs e)
        {
            textBoxOperando1.Clear();
            textBoxOperando2.Clear();
            textBoxOperando16A.Clear();
            textBoxOperando16B.Clear();
            textBoxResultado10.Clear();
            textBoxResultado16.Clear();
            textBoxOperando1.Focus();
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

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
            bool over = alu.ULA8Bits(numA, numB, f, resultado);

            if (over)
                MessageBox.Show("Houve overflow", "Erro", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            //mostrando resultados
            textBoxResultado16.Text = Converter.BinarioParaHexadecimal(resultado);
            textBoxResultado10.Text = Convert.ToString(Converter.BinarioParaInteiro(resultado));
            textBoxOperando16A.Text = Converter.BinarioParaHexadecimal(numA);
            textBoxOperando16B.Text = Converter.BinarioParaHexadecimal(numB);
        }       
    }
}
