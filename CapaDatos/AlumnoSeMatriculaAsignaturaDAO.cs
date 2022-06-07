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
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="AlumnoSeMatriculaAsignatura"/>.
    /// </summary>
    public class AlumnoSeMatriculaAsignaturaDAO : DAO 
    {
        private const string API_ALUMNOS_SE_MATRICULAN_ASIGNATURA = "api/Alumnos_se_matriculan_asignaturas";

        /// <summary>
        /// Obtiene todos los registros de <see cref="AlumnoSeMatriculaAsignatura"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{AlumnoSeMatriculaAsignatura}"/>con todos los registros almacenados en la BD.</returns>
        public List<AlumnoSeMatriculaAsignatura> LeerAlumnosMatriculados()
        {
            List<AlumnoSeMatriculaAsignatura> listaAlumnosMatriculados = new List<AlumnoSeMatriculaAsignatura>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaAlumnosMatriculados= JsonConvert.DeserializeObject<List<AlumnoSeMatriculaAsignatura>>(aux);
                }
            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Grados de la BD: " + e1); }

            return listaAlumnosMatriculados;
        }


        /// <summary>
        /// Obtiene un <see cref="AlumnoSeMatriculaAsignatura"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="AlumnoSeMatriculaAsignatura.Id_Alumno"/></param>
        /// <returns>Objeto de tipo <see cref="AlumnoSeMatriculaAsignatura"/> que coincide con el ID pasado como parámetro.</returns>
        public AlumnoSeMatriculaAsignatura LeerAlumnoMatriculado(int id)
        {
            AlumnoSeMatriculaAsignatura alumnoSeMatriculaAsignatura = new AlumnoSeMatriculaAsignatura();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA + "/alumno/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    alumnoSeMatriculaAsignatura = JsonConvert.DeserializeObject<AlumnoSeMatriculaAsignatura>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Alumno Matriculado en la BD: " + e2); }

            return alumnoSeMatriculaAsignatura;
        }

        /// <summary>
        /// Obtiene un <see cref="AlumnoSeMatriculaAsignatura"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="AlumnoSeMatriculaAsignatura.Id_Alumno"/></param>
        /// <returns>Objeto de tipo <see cref="AlumnoSeMatriculaAsignatura"/> que coincide con el ID pasado como parámetro.</returns>
        public List<Asignatura> ObtenerAsignaturasDeAlumnoMatriculado(int id_Alumno)
        {
            List<Asignatura> resultado = new List<Asignatura>();
            //AlumnoSeMatriculaAsignatura alumnoSeMatriculaAsignatura = new AlumnoSeMatriculaAsignatura();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA + "/alumno/" + id_Alumno).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<List<Asignatura>>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Alumno Matriculado en la BD: " + e2); }

            return resultado;
        }


        /// <summary>
        /// Inserta un nuevo registro de <see cref="AlumnoSeMatriculaAsignatura"/> en la BD
        /// </summary>
        /// <param name="id_Alumno">Integer correspondiente al id de Alumno.</param>
        /// <param name="id_Asignatura">Integer correspondiente al id de la <see cref="Asignatura"/></param>
        /// <param name="id_Curso">Integer correspondiente al id de <see cref="CursoEscolar"/></param>
        /// <returns>Objeto <see cref="AlumnoSeMatriculaAsignatura"/></returns>
        public AlumnoSeMatriculaAsignatura InsertarAlumnoMatriculadoAsignatura(int id_Alumno, int id_Asignatura, int id_Curso)
        {
            try
            {
                AlumnoSeMatriculaAsignatura alumnoSeMatriculaAsignatura = new AlumnoSeMatriculaAsignatura
                {
                    Id_Alumno = id_Alumno,
                    Id_Asignatura = id_Asignatura,
                    Id_Curso_Escolar = id_Curso
                };

                var response = client.PostAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA+"/",
                    new StringContent(JsonConvert.SerializeObject(alumnoSeMatriculaAsignatura),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<AlumnoSeMatriculaAsignatura>
                        (response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Alumno Matriculado en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza el registo de un alumno matriculado.
        /// </summary>
        /// <param name = "id_Alumno" > Integer correspondiente al id de Alumno.</param>
        /// <param name="id_Asignatura">Integer correspondiente al id de la <see cref="Asignatura"/></param>
        /// <param name="id_Curso">Integer correspondiente al id de <see cref="CursoEscolar"/></param>
        /// <returns>Objeto <see cref="AlumnoSeMatriculaAsignatura"/> actualizado.</returns>
        public AlumnoSeMatriculaAsignatura ActualizarAlumnoMatriculadoAsignatura(int id_Alumno, int id_Asignatura, int id_Curso)
        {
            AlumnoSeMatriculaAsignatura alumnoSeMatriculaAsignatura = new AlumnoSeMatriculaAsignatura
            {
                Id_Alumno = id_Alumno,
                Id_Asignatura = id_Asignatura,
                Id_Curso_Escolar = id_Curso
            };

            try
            {
                var response = client.PutAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA 
                    +"/" + id_Alumno + "/" + id_Asignatura + "/" + id_Curso,
                     new StringContent(JsonConvert.SerializeObject(alumnoSeMatriculaAsignatura),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<AlumnoSeMatriculaAsignatura>
                        (response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Alumno Matriculado en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina un alumno matriculado en una asignatura.
        /// </summary>
        /// <param name = "id_Alumno" > Integer correspondiente al id de Alumno.</param>
        /// <param name="id_Asignatura">Integer correspondiente al id de la <see cref="Asignatura"/></param>
        /// <param name="id_Curso">Integer correspondiente al id de <see cref="CursoEscolar"/></param>
        /// <returns>Boolean: True si se ha podido eliminar, False su no ha sido eliminado.</returns>
        public bool EliminarAlumnoMatriculadoAsignatura(int id_Alumno, int id_Asignatura, int id_Curso)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_ALUMNOS_SE_MATRICULAN_ASIGNATURA 
                    + "/" + id_Alumno+"/"+id_Asignatura+"/"+id_Curso).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar un Alumno Matriculado en la BD: " + e5); }

            return resultado;
        }
    }
    
}
