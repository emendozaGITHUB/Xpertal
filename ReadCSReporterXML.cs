using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del archivo XML
        string filePath = @"C:\Exports\MIMMA_Export.xml";

        // El valor de cs-dn que queremos buscar
        string csDnBuscado = "5325857"; // Cambia por el valor que quieres buscar

        try
        {
            // Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // XPath para buscar un cs-object que tenga el atributo cs-dn igual al valor buscado
            string xpath = $"//cs-object[@cs-dn='{csDnBuscado}']";

            // Buscar el nodo que coincida con el cs-dn
            XmlNode csObjectNode = xmlDoc.SelectSingleNode(xpath);

            if (csObjectNode != null)
            {
                Console.WriteLine($"El objeto con cs-dn '{csDnBuscado}' ha sido encontrado.");

                // Obtener otros atributos del nodo si es necesario
                string id = csObjectNode.Attributes["id"]?.Value ?? "No especificado";
                string objectType = csObjectNode.Attributes["object-type"]?.Value ?? "No especificado";

                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Tipo de Objeto: {objectType}");
            }
            else
            {
                Console.WriteLine($"El objeto con cs-dn '{csDnBuscado}' no fue encontrado en el archivo XML.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar el archivo XML: {ex.Message}");
        }
    }
}
