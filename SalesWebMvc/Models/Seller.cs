using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models

{
    public class Seller
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [Display(Name = "Salario Base")]
        [DataType(DataType.Currency)]
        public double BaseSalarial { get; set; }

        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller( string nome, string email, DateTime dataDeNascimento, double basesalarial, Departament departament)
        {
            
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            BaseSalarial = basesalarial;
            Departament = departament;
        }

        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
           Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Data >= initial && sr.Data <= final).Sum(sr => sr.Quantia);
        }

    }
}
