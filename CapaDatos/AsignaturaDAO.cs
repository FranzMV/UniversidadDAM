using System;
using System.Collections.Generic;

using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Entidades;

/// <author>Francisco David Manzanedo Valle.</author>
namespace CapaDatos
{
    /// <summary>
    /// Clase que hereda de la clase base <see cref="DAO"/>
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Asignatura"/>.
    /// </summary>
    public class AsignaturaDAO : DAO
    {
        private const string API_ASIGNATURAS = "api/Asignaturas";

        /// <summary>
        /// Obtiene todos los registros de <see cref="Asignatura"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Asignatura}"/>con todas las asignaturas almacenadas en la BD.</returns>
        public List<Asignatura> LeerAsignaturas()
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_ASIGNATURAS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaAsignaturas = JsonConvert.DeserializeObject<List<Asignatura>>(aux);
                }

            }catch(Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Asignaturas de la BD: " + e1); }

            return listaAsignaturas;
        }


        /// <summary>
        /// Obtiene una <see cref="Asignatura"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Asignatura.Id_Asignatura"/></param>
        /// <returns>Objeto de tipo <see cref="Asignatura"/> que coincide con el ID pasado como parámetro.</returns>
        public Asignatura LeerAsignatura(int id)
        {
            Asignatura asignatura = new Asignatura();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_ASIGNATURAS + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    asignatura = JsonConvert.DeserializeObject<Asignatura>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener una asignatura por id en la BD: " + e2); }

            return asignatura;
        }


        /// <summary>
        /// Inserta una nueva <see cref="Asignatura"/> en la BD.
        /// </summary>
        /// <param name="asignatura"><see cref="Asignatura"/> a guardar en la BD.</param>
        /// <returns></returns>
        public Asignatura InsertarAsignatura(Asignatura asignatura)
        {
            try
            {
                var response = client.PostAsync(API_ASIGNATURAS,
                    new StringContent(JsonConvert.SerializeObject(asignatura),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Asignatura>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar una asignatura en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de una <see cref="Asignatura"/> en la BD.
        /// </summary>
        /// <param name="asignatura"><see cref="Asignatura"/> a actualizar.</param>
        public Asignatura ActualizarAsignatura(Asignatura asignatura)
        {
            try
            {
                var response = client.PutAsync(API_ASIGNATURAS + "/" + asignatura.Id_Asignatura,
                     new StringContent(JsonConvert.SerializeObject(asignatura),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Asignatura>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar una asignatura en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="Asignatura"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de la <see cref="Asignatura"/> a eliminar.</param>
        /// <returns>Boolean: true si se ha eliminado con éxito, false si el registro no ha podido ser eliminado.</returns>
        public bool EliminarAsignatura(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_ASIGNATURAS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar una asignatura en la BD: " + e5); }

            return resultado;
        }
    }
}
