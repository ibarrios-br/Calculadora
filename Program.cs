using System;

namespace Calculadora
{
    class Calculator
    {
        public static double FazerConta(double num1, double num2, string op)
        {
            double result = double.NaN; // usado para não dar erro na divisão aparentemente, valor not a number.

            // switch para fazer as contas, melhor que if else achei, e esse valor de op no switch ? é o nome ?

            //lizardo: esta declaração toda, começando na linha 7 e terminando na linha 38, é um método
            // um metodo que estatico que retorna um double e recebe 3 parametros
            // double num1
            // double num1
            // string op - op é só o nome da variavel string, a mesma que vc usa para saber qual operação o cara escolhou,
            // podia ser qualquer coisa, mas deve ser OP para abreviar OPERACAO
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
            //lizardo: endApp porque traduzindo significado terminar app, ou seja, é a variável que controla se é pra parar ou não a execução do app,
            //faz sentido as variáveis terem nomes que transmitam o que elas fazem
            bool endApp = false;

            Console.WriteLine("Calculadora");

            while (!endApp)
            {
                // Declara variáveis e atribui vazio porque ?
                //lizardo: o padrao é iniciar as suas variáveis com algum valor, isso é uma boa pratica de desenvolvimento.
                //o vazio porque é uma string e o ZERO porque é um double

                string numInput1 = string.Empty; //string numInput1 = string.Empty é uma opção de iniciar com mais classe uma string com valor vazio
                string numInput2 = "";
                double result = 0;

                //Pergunta o primeiro número
                Console.Write("Digite um número e aperte Enter: ");
                numInput1 = Console.ReadLine();

                //porque isso ?
                //lizardo: foi declarada essa variavel para validar se o que o usuario digitou é um double ou nao,
                //aquele TryParse vai  tentar converter, se ele nao conseguir converter quer dizer que não é um double válido

                //esse OUT, é um tipo de preenchimento de valor por refe
                double cleanNum1 = 0;
                //https://pt.stackoverflow.com/questions/82630/o-que-s%C3%A3o-os-par%C3%A2metros-out-e-ref#:~:text=O%20out%20indica%20que%20o,dar%20sa%C3%ADda%20para%20um%20valor.
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Essa não é uma entrada válida, digite um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                //Pergunta o segundo número
                Console.Write("Digite outro número e aperte Enter: ");
                numInput2 = Console.ReadLine();

                //porque isso de novo ?
                //lizardo: mesma coisa que expliquei ali em cima
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
