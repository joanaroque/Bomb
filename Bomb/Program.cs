using System;
using System.Text.RegularExpressions;

namespace Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            string colors = Console.ReadLine();

            Regex regex = new Regex("^[0-9]+$");


            if (colors == null || colors.Length == 0)
            {
                Log.Add("Os argumentos que colocou não são suportados. Prima Enter para voltar a tentar.");

            }
            else
            {
                string[] cable = colors.Split(',');

                bool exploded = false;

                if (cable.Length == 1)
                {
                    if (regex.IsMatch(cable[0]))
                    {
                        Log.Add($"O argumento {cable[0]} não é suportado");
                    }
                }
                else
                {


                    for (int turn = 1; turn < cable.Length - 1 && !exploded; turn++)
                    {
                        Log.Add($"Cor Anterior {cable[turn - 1]} | Cor Atual {cable[turn]}");

                        string previouscolor = cable[turn - 1].ToLower();
                        string currentColor = cable[turn].ToLower();


                        switch (previouscolor)
                        {
                            case "branco":
                                if (currentColor == "branco" || currentColor == "preto")
                                {
                                    Log.Add("Caso 1");
                                    exploded = true;
                                }
                                break;

                            case "preto":
                                if (currentColor == "branco" || currentColor == "verde" || currentColor == "laranja")
                                {
                                    Log.Add("Caso 2");
                                    exploded = true;
                                }
                                break;

                            case "roxo":
                                if (currentColor == "roxo" || currentColor == "verde" || currentColor == "laranja" || currentColor == "branco")
                                {
                                    Log.Add("Caso 3");
                                    exploded = true;
                                }
                                break;

                            case "vermelho":
                                if (currentColor != "verde")
                                {
                                    Log.Add("Caso 4");
                                    exploded = true;
                                }
                                break;

                            case "verde":
                                if (currentColor != "laranja" && currentColor != "branco")
                                {

                                    Log.Add("Caso 5");
                                    exploded = true;
                                }
                                break;

                            case "laranja":
                                if (currentColor != "vermelho" && currentColor != "preto")
                                {
                                    Log.Add("Caso 6");
                                    exploded = true;
                                }
                                break;
                            default:
                                Log.Add("O que introduziu não é uma cor suportada.");
                                break;

                        }
                    }
                }
                Log.Add(exploded ? "\"Bomba explodiu\"" : "\"Bomba desarmada\"");


            }
            Console.ReadKey(true);
        }
    }
}
