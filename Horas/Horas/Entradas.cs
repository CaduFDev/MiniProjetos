using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas
{
    public class Entradas
    {
        public string[] ColetarDados()
        {
            string[] result = new string[2];
            Console.WriteLine("Me informe seu nome? (S)");
                result[0] = Convert.ToString(Console.ReadLine());
            if (result[0] == "S" || result[0] == "s")
            {
                Console.Clear();
                Console.WriteLine("Pode Digitar");

                Console.BackgroundColor = ConsoleColor.DarkRed;
                result[1] = Convert.ToString(Console.ReadLine());
                Console.BackgroundColor = default;

                Console.WriteLine($"Olá {result[1]}, Vou atualizar as horas ...");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Ok, prosseguindo...");
                result[1] = "Sem nome";
                Thread.Sleep(1000);
            } 

            Thread.Sleep(1000);
            Console.WriteLine("Atualizando as horas ...");
            
            return result;
        }
        public void AtualizarHoras()
        {
            string mes;
            string diaDaSemana;
            while (true)
            {
                switch ((int)DateTime.Now.DayOfWeek)
                {
                    case 0:
                        diaDaSemana = "Domingo";
                        break;
                    case 1:
                        diaDaSemana = "Segunda-Feira";
                        break;
                    case 2:
                        diaDaSemana = "Terça-Feira";
                        break;
                    case 3:
                        diaDaSemana = "Quarta-Feira";
                        break;
                    case 4:
                        diaDaSemana = "Quinta-Feira";
                        break;
                    case 5:
                        diaDaSemana = "Sexta-Feira";
                        break;
                    case 6:
                        diaDaSemana = "Sábado";
                        break;
                    default:
                        diaDaSemana = "N/D";
                        break;
                }
                switch ((int)DateTime.Now.Month)
                {
                    case 1:
                        mes = "Janeiro";
                        break;
                    case 2:
                        mes = "Fevereiro";
                        break;
                    case 3:
                        mes = "Março";
                        break;
                    case 4:
                        mes = "Abril";
                        break;
                    case 5:
                        mes = "Maio";
                        break;
                    case 6:
                        mes = "Junho";
                        break;
                    case 7:
                        mes = "Julho";
                        break;
                    case 8:
                        mes = "Agosto";
                        break;
                    case 9:
                        mes = "Setembro";
                        break;
                    case 10:
                        mes = "Outubro";
                        break;
                    case 11:
                        mes = "Novembro";
                        break;
                    case 12:
                        mes = "Dezembro";
                        break;
                    default:
                        mes = "N/D";
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;                
                Console.Write("\rHoje é {0}, dia {1} de {2} de {3} Hora: {4}",
                    diaDaSemana,
                    DateTime.Now.Day,
                    mes,
                    DateTime.Now.Year,
                    DateTime.Now.ToString("hh:mm:sss"));
                Thread.Sleep(1000);
            }
        }
    }
}
