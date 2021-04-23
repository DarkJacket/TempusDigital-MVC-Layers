using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BOL.DTO
{
    public class ClienteBriefDTO
    {
        public ClienteBriefDTO(int id, string nome, double rendaFamiliar)
        {
            Id = id;
            Nome = nome;
            RendaFamiliar = rendaFamiliar;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double RendaFamiliar { get; set; }
    }

    
}
