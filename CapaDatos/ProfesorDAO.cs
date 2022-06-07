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
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Profesor"/>.
    /// </summary>
    public class ProfesorDAO : DAO
    {
        private const string API_PROFESORES = "api/Profesores";

        /// <summary>
        /// Obtiene todos los registros de <see cref="Profesor"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Profesor}"/>con todos los registros almacenados en la BD.</returns>
        public List<Profesor> LeerProfesores()
        {
            List<Profesor> listaProfesores = new List<Profesor>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_PROFESORES).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaProfesores = JsonConvert.DeserializeObject<List<Profesor>>(aux);
                }
            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Profesores de la BD: " + e1); }

            return listaProfesores;
        }


        /// <summary>
        /// Obtiene un <see cref="Profesor"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Profesor.Id_Persona"/></param>
        /// <returns>Objeto de tipo <see cref="Profesor"/> que coincide con el ID pasado como parámetro.</returns>
        public Profesor LeerProfesor(int id)
        {
            Profesor profesor = new Profesor();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_PROFESORES + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    profesor = JsonConvert.DeserializeObject<Profesor>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Profesor por id en la BD: " + e2); }

            return profesor;
        }


        /// <summary>
        /// Inserta un nuevo <see cref="Profesor"/> en la BD.
        /// </summary>
        /// <param name="profesor"><see cref="Profesor"/> a guardar en la BD.</param>
        /// <returns>Objeto de tipo <see cref="Profesor"/> que coincide con el ID pasado como parámetro</returns>
        public Profesor InsertarProfesor(Profesor profesor)
        {
            try
            {
                var response = client.PostAsync(API_PROFESORES,
                    new StringContent(JsonConvert.SerializeObject(profesor),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Profesor>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Profesor en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de un <see cref="Profesor"/> en la BD.
        /// </summary>
        /// <param name="profesor"><see cref="Profesor"/> a actualizar.</param>
        public Profesor ActualizarProfesor(Profesor profesor)
        {
            try
            {
                var response = client.PutAsync(API_PROFESORES + "/" + profesor.Id_Profesor,
                     new StringContent(JsonConvert.SerializeObject(profesor),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Profesor>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Profesor en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="Profesor"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de  <see cref="Profesor"/> a eliminar.</param>
        /// <returns>Boolean: <see cref="true"/>si se ha eliminado con éxito, <see cref="false"/> 
        /// si el registro no ha podido ser eliminado.</returns>
        public bool EliminarProfesor(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_PROFESORES + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar un Profesor en la BD: " + e5); }

            return resultado;
        }
    }
}
