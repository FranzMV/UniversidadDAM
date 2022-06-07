using System;
using System.Collections.Generic;

/// <author> Francisco David Manzanedo Valle </author>
namespace Entidades
{
    /// <summary> Define los atributos de un objeto de tipo Grado. </summary>
    public class Grado
    {
        //Variables de instancia
        private int _idGrado;
        private string _nombreGrado;
        private List<Asignatura> _listaAsignaturas;
        
        //Algunas constantes para validar datos
        private const byte MAX_TAMANYO_NOMBRE = 100;

        /// <summary>Propiedades</summary>
        public int Id_Grado 
        { 
            get => _idGrado;
            set 
            {
                if (_idGrado <= int.MaxValue)
                    _idGrado = value;
                else throw new ArgumentException("ERROR 0020: El ID de Grado no es correcto.");
            } 
        }
        
        public string Nombre
        {
            get => _nombreGrado;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0021: El nombre del Grado no puede quedar vacío");
                else if (value.Length > MAX_TAMANYO_NOMBRE)
                    throw new ArgumentException("ERROR 0021B: El nombre del Grado no puede contener más de: "
                        +MAX_TAMANYO_NOMBRE+"caracteres.");
                else
                    _nombreGrado = value;
            }
        }

        public List<Asignatura> ListaAsignaturas { get => _listaAsignaturas; set => _listaAsignaturas = value; }


        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public Grado()
        {
            Nombre = "desconocido";
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>S
        /// <param name="nombreGrado">String correspondiente al Nombre del Grado.</param>
        public Grado(string nombreGrado)
        {
            Nombre = nombreGrado;
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// Constructor con todos los parámetros.
        /// </summary>
        /// <param name="idGrado">Integer corresopondiente al ID del Grado.</param>
        /// <param name="nombreGrado">String correspondiente al Nombre del Grado.</param>
        public Grado(int idGrado, string nombreGrado)
        {
            Id_Grado = idGrado;
            Nombre = nombreGrado;
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// Constructor copia.
        /// Copia un objeto de tipo Grado pasado como parámetro.
        /// </summary>
        /// <param name="copiaGrado">Objeto <see cref="Grado"/> a copiar.</param>
        public Grado(Grado copiaGrado)
        {
            Id_Grado = copiaGrado.Id_Grado;
            Nombre = copiaGrado.Nombre;
            ListaAsignaturas = new List<Asignatura>();
            foreach (Asignatura a in copiaGrado.ListaAsignaturas)
            {
                ListaAsignaturas.Add(a);
            }
        }

        /// <summary>
        /// Sobrecarga del método ToString.
        /// </summary>
        /// <returns>String con la información separada por "#".</returns>
        public override string ToString()
        {
            string resultado = Id_Grado + "#" + Nombre+" # ";
            if (ListaAsignaturas.Count > 0)
            {
                foreach (Asignatura a in ListaAsignaturas)
                    resultado += a.ToString();
            }
            else
                resultado += "Sin asignaturas";

            return resultado;
        }


        /// <summary>
        /// Destructor.
        /// </summary>
        ~Grado()
        {
            ListaAsignaturas.Clear();
            ListaAsignaturas = null;
        }
    }
}
