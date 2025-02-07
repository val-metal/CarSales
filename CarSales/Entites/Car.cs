using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSales.Entites
{
    public class Car
    {

        [XmlElement("Model")]
        [DisplayName("Název modelu")]
        public string Model { get; set; }

        [XmlElement("Date")]
        [DisplayName("Datum prodeje")]
        public DateTime Date { get; set; }

        [XmlElement("Price")]
        [DisplayName("Cena (Kč)")]
        public double Price { get; set; }

        [XmlElement("VAT")]
        [DisplayName("DPH (%)")]
        public double VAT { get; set; }

        public Car() { }
        public Car(string model, DateTime date, double price, double vAT)
        {
            Model = model;
            Date = date;
            Price = price;
            VAT = vAT;
        }
    }
}
