using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Ruta de csexport.exe - Asegúrate de que la ruta sea correcta en tu entorno
        string csexportPath = @"C:\Program Files\Microsoft Forefront Identity Manager\2010\Synchronization Service\Bin\csexport.exe";

        // Nombre del conector MIMMA
        string connectorName = "MIMMA"; // Reemplaza con el nombre correcto si es necesario

        // Ruta donde se exportarán los objetos
        string outputFilePath = @"C:\Exports\MIMMA_Export.xml";

        // Parámetros para el comando
        string parameters = $"{connectorName} {outputFilePath} /f:x";

        try
        {
            // Crear un nuevo proceso
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = csexportPath,   // Ruta del ejecutable
                Arguments = parameters,    // Parámetros para pasarle al ejecutable
                RedirectStandardOutput = true,  // Para obtener la salida del comando
                UseShellExecute = false,        // No utilizar el shell del sistema
                CreateNoWindow = true           // No crear ventana de consola
            };

            using (Process process = Process.Start(startInfo))
            {
               using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Ruta de csexport.exe - Asegúrate de que la ruta sea correcta en tu entorno
        string csexportPath = @"C:\Program Files\Microsoft Forefront Identity Manager\2010\Synchronization Service\Bin\csexport.exe";

        // Nombre del conector MIMMA
        string connectorName = "MIMMA"; // Reemplaza con el nombre correcto si es necesario

        // Ruta donde se exportarán los objetos
        string outputFilePath = @"C:\Exports\MIMMA_Export.xml";

        // Parámetros para el comando
        string parameters = $"{connectorName} {outputFilePath} /f:x";

        try
        {
            // Crear un nuevo proceso
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = csexportPath,   // Ruta del ejecutable
                Arguments = parameters,    // Parámetros para pasarle al ejecutable
                RedirectStandardOutput = true,  // Para obtener la salida del comando
                UseShellExecute = false,        // No utilizar el shell del sistema
                CreateNoWindow = true           // No crear ventana de consola
            };

            using (Process process = Process.Start(startInfo))
            {
                // Leer la salida estándar del comando
                string output = process.StandardOutput.ReadToEnd();
                // Leer los posibles errores de la ejecución
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Mostrar la salida en la consola
                Console.WriteLine("Resultado de la ejecución:");
                Console.WriteLine(output);

                // Mostrar cualquier error si ocurrió
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error en la ejecución:");
                    Console.WriteLine(error);
                }
                else
                {
                    // Verificar si el archivo XML se generó correctamente
                    if (File.Exists(outputFilePath))
                    {
                        Console.WriteLine($"Archivo XML generado correctamente en: {outputFilePath}");
                    }
                    else
                    {
                        Console.WriteLine("No se generó el archivo XML. Verifica si hay objetos pendientes de exportación.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción que pueda ocurrir
            Console.WriteLine($"Error al ejecutar el proceso: {ex.Message}");
        }
    }
}

            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción que pueda ocurrir
            Console.WriteLine($"Error al ejecutar el proceso: {ex.Message}");
        }
    }
}
