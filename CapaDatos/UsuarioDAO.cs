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
    /// Maneja los datos de la BD correspondientes a la clase: <see cref="Usuario"/>.
    /// </summary>
    public class UsuarioDAO : DAO 
    {
        private const string API_USUARIOS = "api/Usuarios";

        /// <summary>
        /// Obtiene todos los registros de <see cref="Usuario"/> almacenados en la BD.
        /// </summary>
        /// <returns><see cref="List{Usuario}"/>con todos los registros almacenados en la BD.</returns>
        public List<Usuario> LeerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_USUARIOS).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception e1) { throw new Exception("ERROR 01: Error al leer la tabla Usuarios de la BD: " + e1); }

            return listaUsuarios;
        }


        /// <summary>
        /// Obtiene un <see cref="Usuario"/> a través de su ID.
        /// </summary>
        /// <param name="id">Integer correspondiente a <see cref="Usuario.Id_Usuario"/></param>
        /// <returns>Objeto de tipo <see cref="Usuarios"/> que coincide con el ID pasado como parámetro.</returns>
        public Usuario LeerUsuario(int id)
        {
            Usuario usuario = new Usuario();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync(API_USUARIOS + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<Usuario>(aux);
                }
            }
            catch (Exception e2) { throw new Exception("ERROR 02: Error al obtener el Usuario por id en la BD: " + e2); }

            return usuario;
        }


        /// <summary>
        /// Inserta un nuevo <see cref="Usuario"/> en la BD.
        /// </summary>
        /// <param name="usuario"><see cref="Usuario"/> a guardar en la BD.</param>
        /// <returns>Objeto de tipo <see cref="Usuario"/> que coincide con el ID pasado como parámetro</returns>
        public Usuario InsertarUsuario(Usuario usuario)
        {
            try
            {
                var response = client.PostAsync(API_USUARIOS,
                    new StringContent(JsonConvert.SerializeObject(usuario),
                    Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;

            }
            catch (Exception e3) { throw new Exception("ERROR 03: Error al insertar un Usuario en la BD: " + e3); }
        }

        /// <summary>
        /// Actualiza los datos de un <see cref="Usuario"/> en la BD.
        /// </summary>
        /// <param name="usuario"><see cref="Usuario"/> a actualizar.</param>
        public Usuario ActualizarUsuario(Usuario usuario)
        {
            try
            {
                var response = client.PutAsync(API_USUARIOS + "/" + usuario.Id_Usuario,
                     new StringContent(JsonConvert.SerializeObject(usuario),
                         Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e4) { throw new Exception("ERROR 04: Error al actualizar un Usuario en la BD: " + e4); }
        }

        /// <summary>
        /// Elimina una <see cref="Usuario"/> de la BD.
        /// </summary>
        /// <param name="id">Integer correspondiente al ID de  <see cref="Usuario"/> a eliminar.</param>
        /// <returns>Boolean: <see cref="true"/>si se ha eliminado con éxito, <see cref="false"/> 
        /// si el registro no ha podido ser eliminado.</returns>
        public bool EliminarUsuario(int id)
        {
            bool resultado;
            try
            {
                HttpResponseMessage response = client.DeleteAsync(API_USUARIOS + "/" + id).Result;
                resultado = response.IsSuccessStatusCode ? resultado = true : resultado = false;
            }
            catch (Exception e5) { throw new Exception("ERROR 05: Error al eliminar un Usuario en la BD: " + e5); }

            return resultado;
        }
    }
}
