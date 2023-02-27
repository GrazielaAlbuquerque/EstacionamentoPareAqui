using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoPareAqui
{
    public class Carro
    { //propriedades
      public string Placa {get; set; }
      public string Modelo {get; set; }
      public string Cor {get; set; }
      public string Marca {get; set;}
      public List<Ticket> Tickets {get; set;}  

        public Carro()
        { //nova lista
         Tickets = new List<Ticket>();
        }
        //construtor
      public Carro(string placa, string modelo, string cor, string marca)
      {
        placa = Placa;
        modelo = Modelo;
        cor = Cor;
        marca = Marca;
      }
    }
}
