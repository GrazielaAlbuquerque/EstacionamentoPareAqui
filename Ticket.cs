using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoPareAqui
{
    public class Ticket
    {
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public Boolean Ativo { get; set; }

        public Ticket()
        {
        }

        public Ticket(DateTime entrada, DateTime saida, Boolean ativo) : this() 
        {
            Entrada = entrada;
            Saida = saida;
            Ativo = ativo;
        }

        public double CalcularTempo()
        {
            TimeSpan tempo = Saida - Entrada;
            return tempo.TotalMinutes;
        }

        public double CalcularValor()
        {
            double valor = CalcularTempo() * 0.09;
            return valor;
        }
    }
}
