using System;
using System.Collections.Generic;

using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Entidades;


/// <author>Francisco David Manzanedo Valle.</author>
/// <version>1.0</version>
namespace CapaDatos
{
    /// <summary>
    /// Clase que hereda de la clase base <see cref="DAO"/> 
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Persona"/>.
    /// </summary>
    public class PersonaDAO : DAO
    {
        private const string API_PERSONAS = "api/Personas";


        /// <summary>
        /// Obtiene todos los registros de <see cref="Persona"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Persona}"/>con todas las personas que hay almacenadas en la BD.</returns>
        public List<Persona> LeerPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_PERSONAS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaPersonas = JsonConvert.DeserializeObject<List<Persona>>(aux);
                }
            }
            catch(Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla personas de la BD: " + e1); }

            return listaPersonas;
        }

        /// <summary>
        /// Obtiene una <see cref="Persona"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Persona.Id_Persona"/></param>
        /// <returns>Objeto de tipo <see cref="Persona"/> que coincide con el ID pasado como parámetro.</returns>
        public Persona LeerPersona(int id)
        {
            Persona persona = new Persona();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync( API_PERSONAS +"/"+ id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    persona = JsonConvert.DeserializeObject<Persona>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener una persona por id en la BD: " + e2); }

            return persona;
        }

        /// <summary>
        /// Inserta una nueva <see cref="Persona"/> en la BD.
        /// </summary>
        /// <param name="persona"><see cref="Persona"/> a guardar en la BD.</param>
        /// <returns></returns>
        public Persona InsertarPersona(Persona persona)
        {
           
            try
            {
                var response = client.PostAsync(API_PERSONAS, 
                    new StringContent(JsonConvert.SerializeObject(persona),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Persona>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch(Exception e3) { throw new Exception("ERROR 03: Error al insertar una persona en la BD: " + e3); }
        }


        /// <summary>
        /// Actualiza los datos de una <see cref="Persona"/> en la BD.
        /// </summary>
        /// <param name="persona"><see cref="Persona"/> a actualizar.</param>
        /// <returns></returns>
        public Persona ActualizarPersona(Persona persona)
        {
            try
            {
                var response = client.PutAsync(API_PERSONAS +"/"+ persona.Id_Persona,
                     new StringContent(JsonConvert.SerializeObject(persona),
                         Encoding.UTF8, "application/json")).Result;

                if(response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Persona>(response.Content.ReadAsStringAsync().Result);
                else 
                    return null;
            }
            catch(Exception e4) { throw new Exception("ERROR 04: Error al actualizar una persona en la BD: " + e4); }
        }


        /// <summary>
        /// Elimina una <see cref="Persona"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de la <see cref="Persona"/> a eliminar.</param>
        ///<returns>Boolean: true si se ha eliminado con éxito, false si el registro no ha podido ser eliminado.</returns>
        public bool EliminarPersona(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_PERSONAS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;

            }catch(Exception e5) { throw new Exception("ERROR 05: Error al eliminar una persona en la BD: " + e5); }

            return resultado;
        }
    }
}
