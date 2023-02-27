using EstacionamentoPareAqui;

List<Carro> ListaDeCarros = new List<Carro>();
string opcao;

do
{
    Console.WriteLine("Bem vindo ao Estacionamento Pare Aqui, escolha uma opção:");
    Console.WriteLine("1 - Cadastrar Carro ");
    Console.WriteLine("2 - Marcar Entrada");
    Console.WriteLine("3 - Marcar Saída");
    Console.WriteLine("4 - Consultar Histórico");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        CadastrarCarro();
    }
    else if (opcao == "2")
    {
        MarcarEntrada();
    }
    else if (opcao == "3")
    {
        MarcarSaida();
    }
    else if (opcao == "4")
    {
        ConsultarHistorico();
    }
    Console.WriteLine("Tecle Enter para continuar");
    Console.ReadLine();
} while (opcao != "5");

void CadastrarCarro()
{
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa é a ser cadastrada: ");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("O modelo do carro é: ");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("A cor do carro é: ");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("A marca do carro é: ");
    carro.Marca = Console.ReadLine();
    ListaDeCarros.Add(carro);
}
void MarcarEntrada()
{
    Carro carro = ObterCarro();
    if (carro == null)
    {
        Console.WriteLine("Placa não cadastrada, favor cadastrar antes para gerar entrada.");
        return;
    }
    else
    {
        if (carro.Tickets.Count == 0)
        {
            Ticket novoTicket = new Ticket();
            novoTicket.Entrada = DateTime.Now;
            novoTicket.Ativo = true;
            Console.WriteLine($"O Veículo placa {carro.Placa} entrou em {novoTicket.Entrada}.");
            carro.Tickets.Add(novoTicket);
        }
        else
        {
            for (int index = 0; index < carro.Tickets.Count(); index++)
            {
                if (carro.Tickets[index].Ativo == false)
                {
                    Ticket novoTicket = new Ticket();
                    novoTicket.Entrada = DateTime.Now;
                    novoTicket.Ativo = true;
                    Console.WriteLine($"O Veículo placa {carro.Placa} entrou em {novoTicket.Entrada}.");
                    carro.Tickets.Add(novoTicket);
                }
                else
                {
                    Console.WriteLine("Este veículo já possui ticket ativo.");
                }
            }
        }
    }
}
void MarcarSaida()
{ //fechar ticket 
    //Console.WriteLine("Digite a placa para gerar a saída do veículo:");
    Carro carro = ObterCarro();
    if (carro.Tickets.Count == 0)
    {
        Console.WriteLine("Veículo sem ticket cadastrado.");
    }
    for (int index = 0; index < carro.Tickets.Count(); index++)
    {
        if (carro.Tickets[index].Ativo == true)
        {
            carro.Tickets[index].Saida = DateTime.Now;
            carro.Tickets[index].Ativo = false;
            Console.WriteLine($"O Veículo placa {carro.Placa} saiu em {carro.Tickets[index].Saida} e deve pagar {carro.Tickets[index].CalcularValor()}.");
        }
    }
}

void ConsultarHistorico()
{
    Carro carro = ObterCarro();
    if (carro.Tickets.Count == 0)
    {
        Console.WriteLine("Veículo sem ticket cadastrado.");
    }
    for (int index = 0; index < carro.Tickets.Count(); index++)
    {
        if (carro.Tickets[index].Ativo == true)
        {
            Console.WriteLine($"Entrada veículo {carro.Placa} registrada.");
        }
        else
        {
            Console.WriteLine($"O Veículo placa {carro.Placa} entro em {carro.Tickets[index].Entrada}, saiu em {carro.Tickets[index].Saida} e pagou{carro.Tickets[index].CalcularValor()}.");
        }
    }
}

Carro ObterCarro()
{
    Console.WriteLine("Digite a placa do carro: ");
    string buscarPlaca = Console.ReadLine();

    //Item do tipo Carro que está dentro da lista carro
    for (int index = 0; index < ListaDeCarros.Count(); index++)
    {
        if (buscarPlaca == ListaDeCarros[index].Placa)
        {
            //Console.WriteLine($"A placa {ListaDeCarros[index].Placa} está cadastrado.");
            return ListaDeCarros[index];
        }
    }
    return null;
}
