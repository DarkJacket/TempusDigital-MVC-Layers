using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using BOL.Entity;

namespace BOL.Entity
{
    public class Cliente : BaseEntity
    {



        public Cliente(string nome, string cPF, string dataNascimento, double rendaFamiliar)
        {
            Nome = nome;
            CPF = cPF;

            int[] datasplit = dataNascimento
                .Split('/')
                .Select(s => int.Parse(s))
                .ToArray();

            DataNascimento = new DateTime(datasplit[2], datasplit[1], datasplit[0]);
            RendaFamiliar = rendaFamiliar;
        }
        public Cliente(string nome, string cPF, DateTime dataNascimento, double rendaFamiliar)
        {
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            RendaFamiliar = rendaFamiliar;
        }



        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string CPF { get; set; }


        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public double RendaFamiliar { get; set; }
    }
}
