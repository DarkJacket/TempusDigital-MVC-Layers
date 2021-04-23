using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOL.DTO
{
    public class ClienteDTO
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public ClienteDTO() { }

        public ClienteDTO(string nome, string cPF, string dataNascimento, double rendaFamiliar)
        {
            Nome = nome;
            CPF = cPF;


            DataNascimento = dataNascimento;
            RendaFamiliar = rendaFamiliar;
        }
        

        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public double RendaFamiliar { get; set; }
    }
}
