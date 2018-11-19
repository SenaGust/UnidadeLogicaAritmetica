using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class UnidadeLogica32PontoFlutuante
    {
        UnidadeLogica1bitPontoFlutuante ALU23 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU22 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU21 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU20 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU19 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU18 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU17 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU16 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU15 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU14 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU13 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU12 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU11 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU10 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU9 = new UnidadeLogica1bitPontoFlutuante();


        UnidadeLogica1bitPontoFlutuante ALU24 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU25 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU26 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU27 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU28 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU29 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU30 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU31 = new UnidadeLogica1bitPontoFlutuante();
        UnidadeLogica1bitPontoFlutuante ALU32 = new UnidadeLogica1bitPontoFlutuante();

        /*
         *  Tabela
         * F0   Saída
         * 0    A + B
         * 1    A - B
         */
        public bool Ativa(bool[] A, bool[] B, bool F, bool[] resultado)
        {
            bool vai1, vem1 = false;


            
            resultado[31] = ALU31.ULA1Bit(A[31], B[31], F, vem1, out vai1);
            resultado[30] = ALU30.ULA1Bit(A[30], B[30], F, vem1, out vai1);
            resultado[29] = ALU29.ULA1Bit(A[29], B[29], F, vem1, out vai1);
            resultado[28] = ALU28.ULA1Bit(A[28], B[28], F, vem1, out vai1);
            resultado[27] = ALU27.ULA1Bit(A[27], B[27], F, vem1, out vai1);
            resultado[26] = ALU26.ULA1Bit(A[26], B[26], F, vem1, out vai1);
            resultado[25] = ALU25.ULA1Bit(A[25], B[25], F, vem1, out vai1);
            resultado[24] = ALU24.ULA1Bit(A[24], B[24], F, vem1, out vai1);
            resultado[23] = ALU23.ULA1Bit(A[23], B[23], F, vem1, out vai1);
            resultado[22] = ALU22.ULA1Bit(A[22], B[22], F, vem1, out vai1);
            resultado[21] = ALU21.ULA1Bit(A[21], B[21], F, vem1, out vai1);
            resultado[20] = ALU20.ULA1Bit(A[20], B[20], F, vem1, out vai1);
            resultado[19] = ALU19.ULA1Bit(A[19], B[19], F, vem1, out vai1);
            resultado[18] = ALU18.ULA1Bit(A[18], B[18], F, vem1, out vai1);
            resultado[17] = ALU17.ULA1Bit(A[17], B[17], F, vem1, out vai1);
            resultado[16] = ALU16.ULA1Bit(A[16], B[16], F, vem1, out vai1);
            resultado[15] = ALU15.ULA1Bit(A[15], B[15], F, vem1, out vai1);
            resultado[14] = ALU14.ULA1Bit(A[14], B[14], F, vem1, out vai1);
            resultado[13] = ALU13.ULA1Bit(A[13], B[13], F, vem1, out vai1);
            resultado[12] = ALU12.ULA1Bit(A[12], B[12], F, vem1, out vai1);
            resultado[11] = ALU11.ULA1Bit(A[11], B[11], F, vem1, out vai1);
            resultado[10] = ALU10.ULA1Bit(A[10], B[10], F, vem1, out vai1);
            resultado[9] = ALU9.ULA1Bit(A[9], B[9], F, vem1, out vai1);

            return vai1;
        }
    }
}
