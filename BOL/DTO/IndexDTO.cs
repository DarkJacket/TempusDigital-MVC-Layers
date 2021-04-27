using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.DTO
{
    public class IndexDTO
    {
        public IndexDTO(int clientesClasseA, int clientesClasseB, int clientesClasseC,
            int numbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia, int totalClientes,
            int clientesBiggerThanEighteen)
        {
            ClientesClasseA = clientesClasseA;
            ClientesClasseB = clientesClasseB;
            ClientesClasseC = clientesClasseC;
            NumbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia = numbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia;
            TotalClientes = totalClientes;
            ClientesBiggerThanEighteen = clientesBiggerThanEighteen;
        }

        public int ClientesClasseA { get; set; }
        public int ClientesClasseB { get; set; }
        public int ClientesClasseC { get; set; }
        public int NumbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia { get; set; }
        public int TotalClientes { get; set; }
        public int ClientesBiggerThanEighteen { get; set; }




    }
}
