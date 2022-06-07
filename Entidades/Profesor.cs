using System;
using System.Collections.Generic;

/// <author>Francisco David Manzanedo Valle.</author>
namespace Entidades
{
    /// <summary>
    /// Clase que hereda atributos de la clase <see cref="Persona"/>. 
    ///  y define los suyos propios.
    /// </summary>
    public class Profesor : Persona
    {
        private int _idProfesor;
        private int _idDepartamento;
        private List<Asignatura> _listaAsignaturas;

        /// <summary> Propiedades </summary>
        public int Id_Profesor 
        { 
            get => _idProfesor;
            set
            {
                if (_idProfesor >= 0 || _idProfesor <= int.MaxValue)
                    _idProfesor = value;
                else throw new ArgumentException("ERROR 0012: El ID de profesor no es correcto.");
            }    
        }   

        public int Id_Departamento
        {
            get => _idDepartamento; 
            set
            {
                if (_idDepartamento >= 0 || Id_Departamento <= int.MaxValue)
                    _idDepartamento = value;
                else throw new ArgumentException("ERROR 0013: El ID de profesor no es correcto.");
            } 
        }

        public List<Asignatura> ListaAsignaturas { get => _listaAsignaturas; set => _listaAsignaturas = value; }


        /// <summary>
        /// Constructor sin parámetros.
        /// Llama al constructor sin parámetros de su clase base <see cref="Persona"/>
        /// </summary>
        public Profesor() : base() 
        {
            Id_Profesor = 0;
            Id_Departamento = 0;
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProfesor"></param>
        /// <param name="idDepartamento"></param>
        public Profesor(int idProfesor, int idDepartamento)
        {
            Id_Profesor = idProfesor;
            Id_Departamento = idDepartamento;
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nif">String correspondiente al NIF</param>
        /// <param name="nombre">String correspondiente al Nombre</param>
        /// <param name="apellido1">String correspondiente al primer Apellido</param>
        /// <param name="apellido2">String correspondiente al segundo Apellido</param>
        /// <param name="ciudad">String correspondiente a la Ciudad</param>
        /// <param name="direccion">String correspondiente a la Dirección</param>
        /// <param name="telefono">String correspondiente al Teléfono</param>
        /// <param name="fechaNacimiento">Objeto DateTime correspondiente a la fecha de naciemiento</param>
        /// <param name="sexo">String correspondiente al Sexo</param>
        /// <param name="tipo">String correspondiente al Tipo de Persona</param>
        /// <param name="rutaFoto">String correspondiente a la ruta de la imágen</param>
        /// <param name="idDepartamento">Integer correspondiente al ID del <see cref="Departamento"/></param>
        /// <param name="idProfesor">Integer correspondiente al ID de Profesor></param>
        public Profesor(string nif, string nombre, string apellido1, string apellido2, string ciudad,
            string direccion,string telefono, DateTime fechaNacimiento, string sexo, string tipo, 
            string rutaFoto, int idDepartamento)

            : base(nif, nombre, apellido1, apellido2, ciudad, direccion,
                  telefono, fechaNacimiento, sexo, tipo, rutaFoto)
        {
            Id_Departamento = idDepartamento;
            ListaAsignaturas = new List<Asignatura>();
        }

        /// <summary>
        /// Constructor con parámetros incluido el ID./>.
        /// </summary>
        /// <param name="idProfesor">Integer correspondiente al ID de Profesor></param>
        /// <param name="nif">String correspondiente al NIF</param>
        /// <param name="nombre">String correspondiente al Nombre</param>
        /// <param name="apellido1">String correspondiente al primer Apellido</param>
        /// <param name="apellido2">String correspondiente al segundo Apellido</param>
        /// <param name="ciudad">String correspondiente a la Ciudad</param>
        /// <param name="direccion">String correspondiente a la Dirección</param>
        /// <param name="telefono">String correspondiente al Teléfono</param>
        /// <param name="fechaNacimiento">Objeto DateTime correspondiente a la fecha de naciemiento</param>
        /// <param name="sexo">String correspondiente al Sexo</param>
        /// <param name="tipo">String correspondiente al Tipo de Persona</param>
        /// <param name="rutaFoto">String correspondiente a la ruta de la imágen</param>
        /// <param name="idDepartamento">Integer correspondiente al ID del <see cref="Departamento"/></param>
        public Profesor(int idProfesor, string nif, string nombre,
           string apellido1, string apellido2, string ciudad, string direccion, string telefono,
           DateTime fechaNacimiento, string sexo, string tipo, string rutaFoto, int idDepartamento)

           :base(idProfesor, nif,  nombre, apellido1,  apellido2,
            ciudad,  direccion, telefono,  fechaNacimiento, sexo,  tipo, rutaFoto)
        {
            Id_Profesor = idProfesor;
            Id_Departamento = idDepartamento;
            ListaAsignaturas = new List<Asignatura>();
        }


        /// <summary>
        ///Constructor copia.
        ///Copia un objeto de tipo Profesor pasado como parámetro.
        ///</summary>
        /// <param name="profesorCopia">Profesor: Objeto de tipo <see cref="Profesor"/>.</param>
        public Profesor(Profesor profesorCopia) 
            : base (profesorCopia.Id_Persona, profesorCopia.Nif, profesorCopia.Nombre, profesorCopia.Apellido1,
                  profesorCopia.Apellido2, profesorCopia.Ciudad, profesorCopia.Direccion, profesorCopia.Telefono,
                 profesorCopia.Fecha_Nacimiento, profesorCopia.Sexo, profesorCopia.Tipo, profesorCopia.Ruta_Foto)
        {
            Id_Departamento = profesorCopia.Id_Departamento;
            Id_Profesor = profesorCopia.Id_Profesor;
            ListaAsignaturas = new List<Asignatura>();
            foreach  (Asignatura  a in profesorCopia.ListaAsignaturas)
            {
                ListaAsignaturas.Add(a);
            }
        }

        /// <summary>
        /// Añade una asignatura a la Lista
        /// </summary>
        /// <param name="a">Objeto <see cref="Asignatura"/></param>
        public void AnyadirAsignatura(Asignatura a) => ListaAsignaturas.Add(a);


        /// <summary>
        /// Sobrecarga del método toString.
        /// Llama al método toString de la clase base <see cref="Persona"/>
        /// </summary>
        /// <returns>String con todos los valores de los atributos separados por " # "</returns>
        public override string ToString()
        {
            string resultado = base.ToString() + "#" + Id_Profesor + "#" + Id_Departamento + "#";
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
        ~Profesor()
        {
            ListaAsignaturas.Clear();
            ListaAsignaturas = null;
        }
    }
}
