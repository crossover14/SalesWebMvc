﻿using System;
using System.Linq;
using System.Collections.Generic;
namespace SalesWebMvc.Models

{
    public class Seller
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double BaseSalarial { get; set; }
        public Departament Departamento { get; set; }
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
            Departamento = departament;
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