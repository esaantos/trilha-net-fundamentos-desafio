using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoHora)
        {
            this.precoInicial = precoInicial;
            this.precoHora = precoHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");            
            var placa = Console.ReadLine().ToUpper();
            bool validaPlaca = Regex.Match(placa, @"(\D{3})\-?\s?(\d{4}|\d{1}\D{1}\d{2})").Success;
            if(!validaPlaca || placa.Length > 8)
                Console.WriteLine("A placa informada não é valida!");
            else
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            
        }

        public void ListarVeiculos()
        {
            if(veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
                Console.WriteLine("Não há veículos estacionados!");

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veiculo para remover:");
            var placa = Console.ReadLine().ToUpper();

            if(veiculos.Any(v => v.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if(!Int32.TryParse(Console.ReadLine(),out int quantidadeHoras))
                    Console.WriteLine("Valor inválido!");
                else
                {
                    decimal precoTotal = (quantidadeHoras * precoHora) + precoInicial;
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veiculo {placa} foi removido e o preço total foi de R$ {precoTotal}.");
                }

            }
            else
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");

        }
    }
}
