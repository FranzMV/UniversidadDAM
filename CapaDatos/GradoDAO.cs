using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Entidades;
using Newtonsoft.Json;


/// <author>Francisco David Manzanedo Valle.</author>
/// <version>1.0</version>
namespace CapaDatos
{
    /// <summary>
    /// Clase que hereda de la clase base <see cref="DAO"/>
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Grado"/>.
    /// </summary>
    public class GradoDAO : DAO
    {
        private const string API_GRADOS = "api/Grados";

        /// <summary>
        /// Obtiene todos los registros de <see cref="Grado"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Grado}"/>con todos los registros almacenados en la BD.</returns>
        public List<Grado> LeerGrados()
        {
            List<Grado> listaGrados= new List<Grado>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_GRADOS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaGrados = JsonConvert.DeserializeObject<List<Grado>>(aux);
                }
            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Grados de la BD: " + e1); }

            return listaGrados;
        }


        /// <summary>
        /// Obtiene un <see cref="Grado"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Grado.Id_Grado"/></param>
        /// <returns>Objeto de tipo <see cref="Grado"/> que coincide con el ID pasado como parámetro.</returns>
        public Grado LeerGrado(int id)
        {
            Grado grado = new Grado();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_GRADOS + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    grado = JsonConvert.DeserializeObject<Grado>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Grado por id en la BD: " + e2); }

            return grado;
        }


        /// <summary>
        /// Inserta un nuevo <see cref="Grado"/> en la BD.
        /// </summary>
        /// <param name="grado"><see cref="Grado"/> a guardar en la BD.</param>
        /// <returns>Objeto de tipo <see cref="Grado"/> que coincide con el ID pasado como parámetro</returns>
        public Grado InsertarGrado(Grado grado)
        {
            try
            {
                var response = client.PostAsync(API_GRADOS,
                    new StringContent(JsonConvert.SerializeObject(grado),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Grado>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Grado en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de un <see cref="Grado"/> en la BD.
        /// </summary>
        /// <param name="usuario"><see cref="Grado"/> a actualizar.</param>
        public Grado ActualizarGrado(Grado grado)
        {
            try
            {
                var response = client.PutAsync(API_GRADOS + "/" + grado.Id_Grado,
                     new StringContent(JsonConvert.SerializeObject(grado),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Grado>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Grado en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="Grado"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de  <see cref="Grado"/> a eliminar.</param>
        /// <returns>Boolean: <see cref="true"/>si se ha eliminado con éxito, <see cref="false"/> 
        /// si el registro no ha podido ser eliminado.</returns>
        public bool EliminarGrado(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_GRADOS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar un Usuario en la BD: " + e5); }

            return resultado;
        }
    }
}
