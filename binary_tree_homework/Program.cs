using System;
using System.IO;

namespace ArvoreBinaria_AulaEstruturaDeDados
{
    class Program
    {
        public static void OpenFile()
        {
            CelulaArvore arvore = new CelulaArvore();
         //   int numeroSetores = 3; //Numero total de Setores
            int numerodeRodoviasPorSetor = 3; //Numero de BR's no arquivo
            string file = @"C:\Users\Vítor Lemos\Desktop\fluxo2.csv";
            string rodovia;
            int dia, setor;
            int controle = 1;
            int fluxo = 0;
            try
            {
                StreamReader arquivo = new StreamReader(file);
                string linha = arquivo.ReadLine();
                string[] linhaS = null;
                Console.WriteLine("************* REGISTROS *****************");
                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhaS = linha.Split(',');
                    fluxo += Convert.ToInt32(linhaS[3]);

                    if (controle == numerodeRodoviasPorSetor)
                    {
                        setor = Convert.ToInt32(linhaS[0]);
                        rodovia = linhaS[1];
                        dia = Convert.ToInt32(linhaS[2]);
                        arvore.inserir(new FluxoVeiculos(setor, dia, fluxo));
                        controle = 0;
                        fluxo = 0;

                    }
                    Console.WriteLine("Setor:{0}, Rod:{1}, Data:{2},Fluxo:{3}", linhaS[0], linhaS[1], linhaS[2], linhaS[3]);
                    controle = controle + 1;
                }
                arquivo.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("___________________________________________________");
            arvore.Percorrer();
            arvore.ObterMaxValue();
            arvore.ObterMinValue();
            arvore.PercorrerArvoreFluxos();
           
        }
        static void Main(string[] args)
        {

            OpenFile();
            Console.ReadKey();
        }
    }
}
