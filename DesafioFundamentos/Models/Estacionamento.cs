using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
       
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool AdicionarVeiculo()
        {
            // IMPLEMENTADO!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string veiculo = Console.ReadLine();

            var estacionar = ValidarPlaca(veiculo);
            var mensagem = estacionar ? "Veículo estacionado!" : "Placa inválida, digite novamente:";
            
            Console.WriteLine($"{mensagem}");
            Console.ReadKey();

            if(estacionar) 
            {
              veiculos.Add(veiculo);
            }
            return estacionar;
        }

        private static bool ValidarPlaca(string veiculo)
        {
            if (string.IsNullOrWhiteSpace(veiculo))
             { 
                return false;
             }
            if (veiculo.Length > 8) 
             { 
                return false;
             }
            veiculo = veiculo.Replace("-", "").Trim();

            if (char.IsLetter(veiculo, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(veiculo);
            }
            else
            {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(veiculo);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // IMPLEMENTADO!
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // IMPLEMENTADO!
                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = 0;
                valorTotal = precoInicial + precoPorHora * horas;

                // IMPLEMENTADO!
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: {valorTotal:C}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // IMPLEMENTADO!
                foreach (var item in veiculos)
                {
                    Console.WriteLine(item.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}