using System;
using System.Net.Http;
using System.Net.Http.Headers;

/// <author>Francisco David Manzanedo Valle.</author>
namespace CapaDatos
{
    /// <summary>Clase abstracta encargada de conectarse con la WebApiUniversidad </summary>
    public abstract class DAO
    {
        protected HttpClient client = new HttpClient();

        public DAO()
        {
            client.BaseAddress = new Uri("http://localhost:60223/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(10);
        }
    }
}
