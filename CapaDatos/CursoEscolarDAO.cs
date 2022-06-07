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
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="CursoEscolar"/>.
    /// </summary>
    public class CursoEscolarDAO : DAO 
    {
        private const string API_CURSOS = "api/Cursos_Escolares";


        /// <summary>
        /// Obtiene todos los registros de <see cref="CursoEscolar"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{CursoEscolar}"/>con todos los cursos almacenados en la BD.</returns>
        public List<CursoEscolar> LeerCursos()
        {
            List<CursoEscolar> listaCursos = new List<CursoEscolar>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_CURSOS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaCursos = JsonConvert.DeserializeObject<List<CursoEscolar>>(aux);
                }

            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Curso Escolar de la BD: " + e1); }

            return listaCursos;
        }


        /// <summary>
        /// Obtiene un <see cref="CursoEscolar"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="CursoEscolar.Id_Curso_Escolar"/></param>
        /// <returns>Objeto de tipo <see cref="CursoEscolar"/> que coincide con el ID pasado como parámetro.</returns>
        public CursoEscolar LeerCurso(int id)
        {
            CursoEscolar cursoEscolar = new CursoEscolar();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_CURSOS + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    cursoEscolar = JsonConvert.DeserializeObject<CursoEscolar>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el curso escolar por id en la BD: " + e2); }

            return cursoEscolar;
        }


        /// <summary>
        /// Inserta un nuevo <see cref="CursoEscolar"/> en la BD.
        /// </summary>
        /// <param name="curso"><see cref="CursoEscolar"/> a guardar en la BD.</param>
        /// <returns>Objeto de tipo <see cref="CursoEscolar"/> que coincide con el ID pasado como parámetro</returns>
        public CursoEscolar InsertarCurso(CursoEscolar curso)
        {
            try
            {
                var response = client.PostAsync(API_CURSOS,
                    new StringContent(JsonConvert.SerializeObject(curso),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<CursoEscolar>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Curso Escolar en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de un <see cref="CursoEscolar"/> en la BD.
        /// </summary>
        /// <param name="curso"><see cref="CursoEscolar"/> a actualizar.</param>
        public CursoEscolar ActualizarCurso(CursoEscolar curso)
        {
            try
            {
                var response = client.PutAsync(API_CURSOS + "/" + curso.Id_Curso_Escolar,
                     new StringContent(JsonConvert.SerializeObject(curso),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<CursoEscolar>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Curso Escolar en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="CursoEscolar"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de  <see cref="CursoEscolar"/> a eliminar.</param>
        /// <returns>Boolean: true si se ha eliminado con éxito, false si el registro no ha podido ser eliminado.</returns>
        public bool EliminarCurso(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_CURSOS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar Curso Escolar en la BD: " + e5); }

            return resultado;
        }
    }
}
