using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Entidades;
using Newtonsoft.Json;

/// <author>Francisco David Manzanedo Valle.</author>
namespace CapaDatos
{
    /// <summary>
    /// Clase que hereda de la clase base <see cref="DAO"/>
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Departamento"/>.
    /// </summary>
    public class DepartamentoDAO : DAO
    {
        private const string API_DEPARTAMENTOS = "api/Departamentos";


        /// <summary>
        /// Obtiene todos los registros de <see cref="Departamento"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Departamento}"/>con todos los registros almacenados en la BD.</returns>
        public List<Departamento> LeerDepartamentos()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_DEPARTAMENTOS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaDepartamentos = JsonConvert.DeserializeObject<List<Departamento>>(aux);
                }
            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Departamentos de la BD: " + e1); }

            return listaDepartamentos;
        }


        /// <summary>
        /// Obtiene un <see cref="Departamento"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Departamento.Id_Departamento"/></param>
        /// <returns>Objeto de tipo <see cref="Departamento"/> que coincide con el ID pasado como parámetro.</returns>
        public Departamento LeerDepartamento(int id)
        {
            Departamento departamento = new Departamento();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_DEPARTAMENTOS + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    departamento = JsonConvert.DeserializeObject<Departamento>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Departamento por id en la BD: " + e2); }

            return departamento;
        }


        /// <summary>
        /// Inserta un nuevo <see cref="Departamento"/> en la BD.
        /// </summary>
        /// <param name="departamento"><see cref="Departamento"/> a guardar en la BD.</param>
        /// <returns>Objeto de tipo <see cref="Departamento"/> que coincide con el ID pasado como parámetro</returns>
        public Departamento InsertarDepartamento(Departamento departamento)
        {
            try
            {
                var response = client.PostAsync(API_DEPARTAMENTOS,
                    new StringContent(JsonConvert.SerializeObject(departamento),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Departamento>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Departamento en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de un <see cref="Departamento"/> en la BD.
        /// </summary>
        /// <param name="departamento><see cref="Departamento"/> a actualizar.</param>
        public Departamento ActualizarDepartamento(Departamento departamento)
        {
            try
            {
                var response = client.PutAsync(API_DEPARTAMENTOS + "/" + departamento.Id_Departamento,
                     new StringContent(JsonConvert.SerializeObject(departamento),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Departamento>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Departamento en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="Departamento"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de  <see cref="Departamento"/> a eliminar.</param>
        /// <returns>Boolean: <see cref="true"/>si se ha eliminado con éxito, <see cref="false"/> 
        /// si el registro no ha podido ser eliminado.</returns>
        public bool EliminarDepartamento(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_DEPARTAMENTOS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar un Departamento en la BD: " + e5); }

            return resultado;
        }
    }
}

