using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del archivo XML
        string filePath = @"C:\Exports\MIMMA_Export.xml"; // Cambia la ruta a tu archivo XML

        // El valor de inicio de dn que queremos buscar
        string dnStartWith = "5325"; // Cambia por el valor con el que deseas que comience

        try
        {
            // Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // Definir el namespace del documento
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("ns", "http://www.microsoft.com/mms/mmsml/v2");

            // XPath para buscar nodos delta cuyo atributo dn comience con el valor especificado
            string xpath = $"//ns:delta[starts-with(@dn, '{dnStartWith}')]";

            // Buscar los nodos que coincidan con el criterio
            XmlNodeList deltaNodes = xmlDoc.SelectNodes(xpath, nsmgr);

            if (deltaNodes != null && deltaNodes.Count > 0)
            {
                Console.WriteLine($"Se encontraron {deltaNodes.Count} objetos que comienzan con 'dn' = '{dnStartWith}'.");

                // Recorrer los nodos encontrados
                foreach (XmlNode node in deltaNodes)
                {
                    string dn = node.Attributes["dn"]?.Value ?? "No especificado";
                    string primaryObjectClass = node["primary-objectclass"]?.InnerText ?? "No especificado";
                    Console.WriteLine($"DN: {dn}");
                    Console.WriteLine($"Primary Object Class: {primaryObjectClass}");

                    // Puedes acceder a otros atributos del nodo delta si es necesario
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron objetos cuyo 'dn' comience con '{dnStartWith}' en el archivo XML.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar el archivo XML: {ex.Message}");
        }
    }
}
