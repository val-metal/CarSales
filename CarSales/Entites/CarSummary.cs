using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSales.Entites
{
    public class CarSummary
    {
        public string Model { get; set; }
        public double PriceWithoutVat { get; set; }
        public double PriceWithVat { get; set; }

        public CarSummary(string model, double priceWithoutVat, double priceWithVat)
        {
            this.Model = model;
            this.PriceWithoutVat = priceWithoutVat;
            this.PriceWithVat = priceWithVat;
        }
    }
}
