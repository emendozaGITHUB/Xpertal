using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    private static readonly string instanceUrl = "https://xpertaltest.service-now.com";
    private static readonly string apiUrl = "/api/now/table/core_company";
    private static readonly string username = "your_username";  // Coloca aquí tu usuario de ServiceNow
    private static readonly string password = "your_password";  // Coloca aquí tu contraseña de ServiceNow

    static async Task Main(string[] args)
    {
        // Obtener la lista de compañías desde la API
        var companias = await ObtenerCompanias();

        // Construir la lista de entidades organizadas en jerarquía
        List<EntidadCompania> entidadesCompania = ConstruirJerarquia(companias);

        // Imprimir la jerarquía resultante
        foreach (var entidad in entidadesCompania)
        {
            Console.WriteLine(entidad.ToString());
        }
    }

    // Método para obtener las compañías desde la API
    public static async Task<List<Compania>> ObtenerCompanias()
    {
        List<Compania> companias = new List<Compania>();

        using (HttpClient client = new HttpClient())
        {
            // Autenticación básica
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // Realizar la solicitud HTTP GET
            HttpResponseMessage response = await client.GetAsync($"{instanceUrl}{apiUrl}");

            // Verificar si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceNowResponse>(jsonResponse);
                companias = result.result;
            }
            else
            {
                Console.WriteLine($"Error al obtener compañías: {response.StatusCode}");
            }
        }

        return companias;
    }

    // Método para construir la jerarquía de entidades
    public static List<EntidadCompania> ConstruirJerarquia(List<Compania> companias)
    {
        List<EntidadCompania> entidades = new List<EntidadCompania>();

        foreach (var compania in companias)
        {
            // Buscar la entidad padre en la jerarquía
            var entidadPadre = entidades.FirstOrDefault(e => e.Nombre == compania.parent);

            // Crear una nueva entidad de compañía
            var nuevaEntidad = new EntidadCompania
            {
                Nombre = compania.name,
                Tipo = compania.u_tipo_de_compania
            };

            if (entidadPadre != null)
            {
                // Si existe un padre, agregamos esta entidad como hijo
                entidadPadre.AgregarHijo(nuevaEntidad);
            }
            else
            {
                // Si no existe el padre, es una nueva entidad raíz
                entidades.Add(nuevaEntidad);
            }
        }

        return entidades;
    }
}

// Clase para deserializar la respuesta de ServiceNow
public class ServiceNowResponse
{
    public List<Compania> result { get; set; }
}

// Clase para representar una compañía
public class Compania
{
    public string name { get; set; }
    public string u_tipo_de_compania { get; set; }
    public string parent { get; set; }
}

// Clase para manejar la jerarquía de entidades (Unidad de Negocio, Sociedad, Sub Unidad de Negocio, División de Personal)
public class EntidadCompania
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public List<EntidadCompania> Hijos { get; set; } = new List<EntidadCompania>();

    public void AgregarHijo(EntidadCompania hijo)
    {
        Hijos.Add(hijo);
    }

    public override string ToString()
    {
        var hijosString = Hijos.Any() ? $"Hijos: {string.Join(", ", Hijos.Select(h => h.Nombre))}" : "Sin hijos";
        return $"{Tipo}: {Nombre} - {hijosString}";
    }
}
