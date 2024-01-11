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
            //TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // IMPLEMENTADO!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string veiculo = Console.ReadLine();

            var placa = ValidarPlaca(veiculo);
            var mensagem = placa ? "Veículo estacionado!" : "Placa inválida, digite novamente:";

            Console.WriteLine($"{mensagem}");

            if (placa)
            {
                veiculos.Add(veiculo);
            }
            return placa;
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

            // TODO: Pedir para o usuário digitar a placa e armazenar na variável placa
            // IMPLEMENTADO!
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                // IMPLEMENTADO!

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
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