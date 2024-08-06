namespace ApiC; 
using System.Text.Json.Serialization;
using System.Text.Json;
    public class Root
    {
        public Current current { get; set; }
    }
    public class Current
    {
    
        public Condition condition { get; set; }
    
    }
     public class Condition
    {
        public string text { get; set; }
        
    }
public class ClimaApi
{
public static async Task<Root> ObtenerClima()
{
    var url = @"http://api.weatherapi.com/v1/current.json?key=27e9042461e8413bb63232035240108&q=Paris&aqi=no";
    try
    {
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = await cliente.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Root clima = JsonSerializer.Deserialize<Root>(responseBody);
        return clima;
    }

    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}
}

