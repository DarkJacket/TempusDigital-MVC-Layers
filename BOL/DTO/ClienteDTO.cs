using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL.DTO
{
    public class ClienteDTO
    {
        
        
        
        public ClienteDTO() { }

        public ClienteDTO(string nome, string cPF, string dataNascimento, double rendaFamiliar)
        {
            Nome = nome;
            CPF = cPF;


            DataNascimento = dataNascimento;
            RendaFamiliar = rendaFamiliar;
        }


        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public double RendaFamiliar { get; set; }
    }
}
