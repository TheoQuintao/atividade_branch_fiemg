using System.IO;

Console.Clear();

int largura = 32; // Ajuste a largura do cabeçalho conforme necessário

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("=".PadLeft(largura, '='));
Console.WriteLine("Atividade 13 - Jogo da Mega-Sena");
Console.WriteLine("=".PadLeft(largura, '='));
Console.ResetColor();

Random rnd = new Random();
HashSet<int> numerosUnicos = new HashSet<int>();

int qtdDezena;

bool repetir;
using (StreamWriter escrever = new StreamWriter("jogos-mega-sena.txt"))
{
        Console.Write("Deseja realizar quantos jogos: ");
    if (int.TryParse(Console.ReadLine(), out int qtdJogoInformada))
    {
        do
        {
            Console.Write("Informar a quantidade de dezena: ");
            if (int.TryParse(Console.ReadLine(), out int qtdDezenaInformada))
            {
                if (qtdDezenaInformada < 6 || qtdDezenaInformada > 15)
                        repetir = true;
                    else
                            repetir = false;

                if (repetir == false)
                {
                    for (int i = 0; i < qtdJogoInformada; i++)
                        {
                            Console.Write($"\x0A Jogo {i + 1}: ");
                            while (numerosUnicos.Count < qtdDezenaInformada)
                            {
                                int numero = rnd.Next(1, 61);
                                numerosUnicos.Add(numero);
                            }
                            int[] Jogos = new int[qtdDezenaInformada];
                            numerosUnicos.CopyTo(Jogos);
                            foreach (int a in Jogos)
                            {
                                if (a == Jogos[0])
                                    Console.Write($"{a:D2}");
                                else
                                    Console.Write($"-{a:D2}");
                            }
                            numerosUnicos.Clear();
                        }
                        
                    escrever.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Jogos gerados e salvos no arquivo 'jogos-mega-sena.txt'.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Quantidade dezena menor que 6");
                    repetir = true;

                }
            
            }    
            else
                {
                    repetir = true;
                    Console.WriteLine("Número inválido!");
                }
        }while (repetir == true); 
    }   
    else
    {
            Console.WriteLine("Número inválido!");
    }

    // Solicitar o valor do prêmio

    Console.Write("Informe o valor do prêmio: ");
    if (float.TryParse(Console.ReadLine(), out float valorPremio))
    {
    }

}
