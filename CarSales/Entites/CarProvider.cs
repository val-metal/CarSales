using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CarSales.Entites
{
    public static class CarProvider
    {
        public static List<Car> loadedCars = new List<Car>();

        public static List<Car> fromXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("Sales"));

                using (StreamReader reader = new StreamReader(filePath))
                {
                    loadedCars = (List<Car>)serializer.Deserialize(reader);
                    return loadedCars;
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Chyba soubor nenalezen", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Chyba deserializace XML: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Chyba při čtení souboru: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Neočekávaná chyba: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new List<Car>(); 
        }

        public static string toXml(List<Car> cars)
        {
            loadedCars = cars;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("Sales"));

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, cars);
                return writer.ToString();  
            }
        }
        public static void saveToXml(List<Car> cars, string filePath)
        {
            try
            {
                string xmlContent = CarProvider.toXml(cars);
                System.IO.File.WriteAllText(filePath, xmlContent);

                MessageBox.Show($"Soubor byl úspěšně uložen do:\n{filePath}", "Uloženo", MessageBoxButtons.OK);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Nemáte oprávnění k zápisu do souboru:\n{filePath}\n\n{ex.Message}",
                                "Chyba přístupu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Chyba při zápisu do souboru:\n{filePath}\n\n{ex.Message}",
                                "Chyba I/O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Neočekávaná chyba:\n{ex.Message}","Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }
    }
}
