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

        public Cliente(string nome, string cPF, DateTime dataNascimento, double rendaFamiliar)
        {
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            RendaFamiliar = rendaFamiliar;
        }

        public string Nome { get; set; }

        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public double RendaFamiliar { get; set; }
    }
}
