using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoHora = 0;

Console.WriteLine("Seja bem vindo sistema de estacionamento! \n" +
    "Digite o preço inicial: ");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoHora = Convert.ToDecimal(Console.ReadLine());

var estacionamento = new Estacionamento(precoInicial, precoHora);
var opcao = string.Empty;
bool exibirMenu = true;

while(exibirMenu)
{
    Console.Clear();
    Console.WriteLine("=========================================");
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Lista veículos");
    Console.WriteLine("4 - Encerrar");
    Console.WriteLine("=========================================");

    switch (Console.ReadLine())
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;
        case "2":
            estacionamento.RemoverVeiculo();
            break;
        case "3":
            estacionamento.ListaVeiculos();
            break;
        case "4":
            exibirMenu= false;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
    Console.WriteLine("Pressione um tecla para continuar.");
    Console.ReadLine();
}
Console.WriteLine("O programa se encerrou!");