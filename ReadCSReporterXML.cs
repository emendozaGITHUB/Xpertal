using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del archivo XML generado por csexport.exe
        string filePath = @"C:\Exports\MIMMA_Export.xml";

        // EmployeeID que queremos buscar
        string employeeIDBuscado = "12345"; // Cambia por el valor que quieres buscar

        try
        {
            // Cargar el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // XPath para buscar un elemento con el atributo employeeID
            string xpath = $"//Object[@employeeID='{employeeIDBuscado}']";

            // Buscar el nodo que coincida con el employeeID
            XmlNode employeeNode = xmlDoc.SelectSingleNode(xpath);

            if (employeeNode != null)
            {
                Console.WriteLine($"El objeto con EmployeeID '{employeeIDBuscado}' ha sido encontrado.");

                // Aquí puedes hacer más validaciones o trabajar con los atributos del objeto
                // Por ejemplo, puedes verificar si tiene un atributo "connected" o alguna marca de conexión.
                string connectedStatus = employeeNode.Attributes["connected"]?.Value ?? "No especificado";

                if (connectedStatus == "true")
                {
                    Console.WriteLine($"El objeto con EmployeeID '{employeeIDBuscado}' está conectado.");
                }
                else
                {
                    Console.WriteLine($"El objeto con EmployeeID '{employeeIDBuscado}' no está conectado.");
                }
            }
            else
            {
                Console.WriteLine($"El objeto con EmployeeID '{employeeIDBuscado}' no fue encontrado en el archivo XML.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar el archivo XML: {ex.Message}");
        }
    }
}
