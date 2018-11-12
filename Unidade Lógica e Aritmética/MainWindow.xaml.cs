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
            Conversor con = new Conversor();
            InitializeComponent();

            bool[] um = {false, false, false, false, false, false, false, true };
            bool[] dois = {false, false, false, false, false, false, true, false };
            bool[] tres = {false, false, false, false, false, false, true, true };
            bool[] zero = {false, false, false, false, false, false, false, false };

            Console.WriteLine("Sem complemento 2");
            Console.WriteLine(con.complemento2ParaDecimal(um));
            Console.WriteLine(con.complemento2ParaDecimal(dois));
            Console.WriteLine(con.complemento2ParaDecimal(tres));
            Console.WriteLine(con.complemento2ParaDecimal(zero));

            Console.WriteLine("Com complemento 2");
            Console.WriteLine(con.complemento2ParaDecimal(con.decimalParaComplemento2(um)));
            Console.WriteLine(con.complemento2ParaDecimal(con.decimalParaComplemento2(dois)));
            Console.WriteLine(con.complemento2ParaDecimal(con.decimalParaComplemento2(tres)));
            Console.WriteLine(con.complemento2ParaDecimal(con.decimalParaComplemento2(zero)));
        }

        #region Implementação dos botões da ULA
        private void button_AandB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  0  A and B
            bool[] f = { false, false, false }; //o contrario
            encaminhaULA(f);
            
        }

        private void button_AorB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  1  A or B
            bool[] f = { true, false, false }; //o contrario
            encaminhaULA(f);
        }

        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //1  0  0  A + B
            bool[] f = { false, false, true }; //o contrario
            encaminhaULA(f); 
        }

        private void buttonSubtracao_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //1  0  1  A - B ou (A + (-B))
            bool[] f = { true, false, true }; //o contrario
            encaminhaULA(f);
        }

        private void button_notA_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  0  Not A
            bool[] f = { false, true, false }; //o contrario
            encaminhaULA(f);
        }

        private void button_notB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  1  Not B
            bool[] f = { true, true, false }; //o contrario
            encaminhaULA(f);
        }
        #endregion

        #region Botões adicionais
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

        #region Ponto Flutuante
        private void chamarULAPontoFlutuante(bool[] f, float a, float b, bool possuiNegativo)
        {
            Conversor con = new Conversor();
            Console.WriteLine(con.imprimirBinario(con.PontoFlutuanteParaBinario(a)));
            Console.WriteLine(con.imprimirBinario(con.PontoFlutuanteParaBinario(b)));
        }

        private bool procuraVirgula(string numero)
        {
            for (int pos = 0; pos < numero.Length; pos++)
            {
                if (numero[pos] == ',')
                    return true;
            }

            return false;
        }
        #endregion

        #region Inteiro
        private void chamarULAinteiroPositivo(bool[] f, int a, int b, int tamanho)
        {
            Conversor converter = new Conversor();
            bool inverteu = false, complemento2A = false, complemento2B = false;
            bool[] A, B;
            int resposta;

            if(b>a && f[2] & !f[1] & f[0])
            {
                inverteu = true;
                int aux = a;
                a = b;
                b = aux;
            }

            //convertendo pra complemento 2 binario
            if (a < 0)
            {
                a *= -1; complemento2A = true;
                A = converter.decimalParaComplemento2(converter.InteiroParaBinario(tamanho, a));
            }
            else
            {
                A = converter.InteiroParaBinario(tamanho, a);
            }
            if (b < 0)
            {
                b *= -1; complemento2B = true;
                B = converter.decimalParaComplemento2(converter.InteiroParaBinario(tamanho, b));
            }
            else
            {
                B = converter.InteiroParaBinario(tamanho, b);
            }

            if (f[2] & !f[1] & f[0]) //SE SUBTRAÇÃO
                B = converter.decimalParaComplemento2(B);


            bool overflowSoma;
            bool[] resultado = new bool[tamanho];

            if(tamanho == 8) //8 bits
            {
                UnidadeLogica8bits ula = new UnidadeLogica8bits();
                overflowSoma = ula.ULA8Bits(A, B, f, resultado);
            }
            else //24 bits
            {
                UnidadeLogica24bits ula = new UnidadeLogica24bits();
                overflowSoma = ula.ULA24Bits(A, B, f, resultado);
            }

            if(overflowSoma)
            {
                MessageBox.Show("Houve overflow durante a soma", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //resultado
            if (complemento2A || complemento2B)
                resposta = converter.complemento2ParaDecimal(resultado);
            else
                resposta = converter.BinarioParaInteiro(resultado);


            if (inverteu)
            {
                resposta *= -1;
            }

            textBoxResultado10.Text = resposta + " ";
            textBoxResultado16.Text = converter.imprimirBinario(resultado);
            textBoxOperando16A.Text = converter.imprimirBinario(A);
            textBoxOperando16B.Text = converter.imprimirBinario(B);
            
        }
        #endregion

        private void encaminhaULA(bool[] f)
        {
            //esse método chama a ULA certa
            if (procuraVirgula(textBoxOperando1.Text) || (procuraVirgula(textBoxOperando2.Text)))
            {
                //Se existir virgula, vamos usar a ULA para numero "fracionário"
                try
                {
                    float a = float.Parse(textBoxOperando1.Text);
                    float b = float.Parse(textBoxOperando2.Text);
                    Console.WriteLine();
                    //chamar ula de 32 bits
                    chamarULAPontoFlutuante(f,a,b,false);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Os campos Operando 1 e/ou Operando 2 não possuem um formato correto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Erro: Estes número não podem ser representas usando uma ULA de 32 (ponto flutuante)", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                //numero inteiro
                try
                {
                    int a = Convert.ToInt32(textBoxOperando1.Text);
                    int b = Convert.ToInt32(textBoxOperando2.Text);

                    if (a >= 0 && b >= 0)
                    {
                        double limite8bits = (Math.Pow(2, 8) - 1);
                        double limite24bits = (Math.Pow(2, 24) - 1);
                        if (a <= limite8bits && b <= limite8bits)
                        {
                            //ula 8 bits
                            //inteiro
                            //apenas positivos
                            chamarULAinteiroPositivo(f, a, b, 8);
                        }
                        else if (a <= limite24bits && b <= limite24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //apenas positivos
                            chamarULAinteiroPositivo(f, a, b, 24);
                        }
                        else
                        {
                            MessageBox.Show("Erro: não é possível representar os números informados com 24 bits.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        double maximo8bits = (Math.Pow(2, 8 - 1) - 1);
                        double minimo8bits = -(Math.Pow(2, 8 - 1));
                        double maximo24bits = (Math.Pow(2, 24 - 1) - 1);
                        double minimo24bits = -(Math.Pow(2, 24 - 1));
                        if (a >= minimo8bits && b >= minimo8bits && a <= maximo8bits && b <= maximo8bits)
                        {
                            //ula 8 bits
                            //inteiro
                            //negativos e positivos
                            chamarULAinteiroPositivo(f, a, b, 8);
                        }
                        else if (a >= minimo24bits && b >= minimo24bits && a <= maximo24bits && b <= maximo24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //negativos e positivos
                            chamarULAinteiroPositivo(f, a, b, 24);
                        }
                        else
                        {
                            MessageBox.Show("Não é possível representar esses números com a ULA de 24 bits.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Os campos Operando 1 e / ou Operando 2 não possuem um formato correto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (OverflowException)
                {
                    
                    MessageBox.Show("Não é possível representar esses números com a nossa ULA.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
