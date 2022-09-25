using System;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia  { get; set; }
        public SelesStatus Status { get; set; }
        public  Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord( DateTime data, double quantia, SelesStatus status,Seller seller)
        {
           
            Data = data;
            Quantia = quantia;
            Status = status;
            Seller = seller;

        }
    }
}
