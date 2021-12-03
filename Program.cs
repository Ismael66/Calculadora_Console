using System;
namespace Calculadora
{
    public struct Parametros // TIPO
    {
        public int num1;
        public string? operador;
        public int num2;
        public Parametros(int num1, string operador, int num2)
        {
            this.num1 = num1;
            this.operador = operador;
            this.num2 = num2;
        }
    }
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Escreva o primeiro número!");
                int primeiroNumero = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Escreva o sínal de operação!");
                var sinal = Console.ReadLine();
                Console.WriteLine("Escreva o segundo número!");
                int segundoNumero = Convert.ToInt32(Console.ReadLine());
                var valores = new Parametros() // Melhor para editar os dados enquanto cria objeto 
                {
                    num1 = primeiroNumero,
                    operador = sinal,
                    num2 = segundoNumero
                };
                // var valores2 = new Parametros(primeiroNumero, sinal, segundoNumero);
                Calcula(valores);
            }
            catch //(Exception ex)
            {
                // Console.WriteLine(ex.Message);
                Console.WriteLine("Valor informado não é um número!");
                LoopCalcula();
            }
        }

        static void Calcula(Parametros parametros)
        {
            try
            {
                decimal resultado = 0;
                switch (parametros.operador)
                {
                    case "+":
                        resultado = parametros.num1 + parametros.num2;
                        break;
                    case "-":
                        resultado = parametros.num1 - parametros.num2;
                        break;
                    case "/":
                        if (parametros.num2 == 0)
                        {
                            Console.WriteLine("Impossivel dividir por zero.");
                            LoopCalcula();
                            break;
                        }
                        resultado = parametros.num1 / parametros.num2;
                        break;
                    case "*":
                        resultado = parametros.num1 * parametros.num2;
                        break;
                    default:
                        Console.WriteLine("Sinal de operação invalido.");
                        break;
                }
                Console.WriteLine($"{parametros.num1} {parametros.operador} {parametros.num2} = {resultado}");
                LoopCalcula();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu esse erro => {ex.Message}");
            }
        }
        static void LoopCalcula()
        {
            Console.WriteLine("Quer calcular novamente?{s/n}");
            string? resposta = Console.ReadLine();
            Console.Clear();
            // string opcao = resposta is not null ? resposta : string.Empty; Resolvendo erro null
            switch (resposta is not null ? resposta.ToLower() : string.Empty)
            {
                case "s":
                    Main();
                    break;
                default:
                    Console.WriteLine("Ok, tchau!");
                    break;
            }
            return;
        }
    }
}