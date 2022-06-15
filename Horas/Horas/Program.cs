using Horas;

Entradas entradas = new Entradas();
string[] infoCliente = entradas.ColetarDados();
Console.WriteLine("Para sair, pressione: CRTL + C ");

entradas.AtualizarHoras();

Console.BackgroundColor = ConsoleColor.Blue;
Console.WriteLine($"Até logo {infoCliente[1]} !");