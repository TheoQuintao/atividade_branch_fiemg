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

bool repetir;
using (StreamWriter escrever = new StreamWriter("jogos-mega-sena.txt"))
{   
    do
    {
        Console.Write("\nDeseja realizar quantos jogos: ");
        if (int.TryParse(Console.ReadLine(), out int qtdJogoInformada))
        {
            
            Console.Write("\nInformar a quantidade de dezena: ");
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
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"\x0A Jogo {i + 1}: ");
                            escrever.Write($"\x0A Jogo {i + 1}: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                                {
                                    Console.Write($"{a:D2}");
                                    escrever.Write($"{a:D2}");
                                }  
                                else
                                {
                                    Console.Write($"-{a:D2}");
                                    escrever.Write($"-{a:D2}");
                                }
                            }
                            numerosUnicos.Clear();
                        }
                            
                        escrever.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nJogos gerados e salvos no arquivo 'jogos-mega-sena.txt'.\n");
                        Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nQuantidade dezena menor que 6");
                    repetir = true;
                }
            }    
            else
            {
                repetir = true;
                Console.WriteLine("\nNúmero inválido!");
            }
        
        }   
        else
        {
            repetir = true;
            Console.WriteLine("\nNúmero inválido!");
        }
    }while (repetir == true);

    // Solicitar o valor do prêmio

    repeat:
    Console.Write("Informe o valor do prêmio: ");
    if (float.TryParse(Console.ReadLine(), out float valorPremio))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nQuem acertar 6 números ganhará R$ {valorPremio * 0.75:F2}");
        Console.WriteLine($"\nQuem acertar 5 números ganhará R$ {valorPremio * 0.15:F2}");
        Console.WriteLine($"\nQuem acertar 6 números ganhará R$ {valorPremio * 0.10:F2}");
    }
    else
    {
        Console.WriteLine("\nNúmero inválido!");
        goto repeat;
    }
}
