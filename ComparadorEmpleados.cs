using System;
using System.Collections.Generic;

public class Empleado
{
    public string UnidadDeNegocio { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Mail { get; set; }
}

public class ComparadorEmpleados
{
    public static List<string> CompararEmpleados(Empleado empleadoA, Empleado empleadoB)
    {
        var diferencias = new List<string>();

        if (empleadoA.UnidadDeNegocio != empleadoB.UnidadDeNegocio)
        {
            diferencias.Add(nameof(empleadoA.UnidadDeNegocio));
        }

        if (empleadoA.Nombre != empleadoB.Nombre)
        {
            diferencias.Add(nameof(empleadoA.Nombre));
        }

        if (empleadoA.Apellido != empleadoB.Apellido)
        {
            diferencias.Add(nameof(empleadoA.Apellido));
        }

        if (empleadoA.Mail != empleadoB.Mail)
        {
            diferencias.Add(nameof(empleadoA.Mail));
        }

        return diferencias;
    }
}

public class Program
{
    public static void Main()
    {
        // Crear dos empleados para comparar
        var empleadoA = new Empleado
        {
            UnidadDeNegocio = "Ventas",
            Nombre = "Juan",
            Apellido = "Pérez",
            Mail = "juan.perez@empresa.com"
        };

        var empleadoB = new Empleado
        {
            UnidadDeNegocio = "Ventas",
            Nombre = "Juan",
            Apellido = "Gómez",
            Mail = "juan.gomez@empresa.com"
        };

        // Comparar empleados
        var diferencias = ComparadorEmpleados.CompararEmpleados(empleadoA, empleadoB);

        // Mostrar resultados
        if (diferencias.Count > 0)
        {
            Console.WriteLine("Los siguientes atributos son diferentes:");
            foreach (var diferencia in diferencias)
            {
                Console.WriteLine(diferencia);
            }
        }
        else
        {
            Console.WriteLine("No hay diferencias en los atributos comparados.");
        }
    }
}
