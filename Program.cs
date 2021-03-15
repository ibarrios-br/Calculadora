using System;

namespace Calculadora
{
    class Calculator
    {
        public static double FazerConta(double num1, double num2, string op)
        {
            double result = double.NaN; // usado para não dar erro na divisão aparentemente, valor not a number.

            // switch para fazer as contas, melhor que if else achei, e esse valor de op no switch ? é o nome ?
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // pergunta para selecionar um numero que não seja zero
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // retorna texto para uma entrada incorreta.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //porque o nome "endApp" ?
            bool endApp = false; 
            
            Console.WriteLine("Calculadora");

            while (!endApp)
            {
                // Declara variáveis e atribui vazio porque ?
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                //Pergunta o primeiro número
                Console.Write("Digite um número e aperte Enter: ");
                numInput1 = Console.ReadLine();

                //porque isso ?
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Essa não é uma entrada válida, digite um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                //Pergunta o segundo número
                Console.Write("Digite outro número e aperte Enter: ");
                numInput2 = Console.ReadLine();

                //porque isso de novo ?
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Essa não é uma entrada válida, digite um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Pergunta para selecionar uma operação
                Console.WriteLine("Selecione uma operação: ");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
               

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.FazerConta(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Essa operação vai resultar em um erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não uma excessão ocorreu tentado fazer isso.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Pergunta se quer continuar ou fechar
                Console.Write("Aperte 'n' e Enter para sair, ou qualquer outra tecla e Enter para continuar.");
                if (Console.ReadLine() == "n") endApp = true;

             
            }
            return;
        }
    }

}
