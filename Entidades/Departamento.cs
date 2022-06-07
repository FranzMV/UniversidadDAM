using System;
using System.Collections.Generic;

/// <author>Francisco David Manzanedo Valle.</author>
namespace Entidades
{
    /// <summary>
    /// Define los atributos de un objeto de tipo Departamento.
    /// </summary>
    public class Departamento
    {
        //Variables de instancia
        private int _idDepartamento;
        private string _nombreDepartamento;
        private List<Profesor> _listaProfesores;


        //Algunas constantes para validar datos
        private const byte MAX_TAMANYO_NOMBRE = 50;

        /// <summary>Propiedades</summary>
        public int Id_Departamento 
        {
            get => _idDepartamento;
            set 
            {
                if (_idDepartamento <= int.MaxValue)
                    _idDepartamento = value;
                else throw new ArgumentException("ERROR 0022: El ID de Departamento no es correcto.");
            } 
        }
       
        public string Nombre
        {
            get => _nombreDepartamento;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 000023: El nombre del departamente no puede quedar vacío.");
                else if (value.Length > MAX_TAMANYO_NOMBRE)
                    throw new ArgumentException("ERROR 000023B: El nombre del departamento no puede tener más de: "
                        +MAX_TAMANYO_NOMBRE+" caracteres.");
                else
                    _nombreDepartamento = value;
            }
        }

        public List<Profesor> ListaProfesores { get => _listaProfesores; set => _listaProfesores = value; }

        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public Departamento()
        {
            Nombre = "sin nombre";
            ListaProfesores = new List<Profesor>();
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nombre">String correspondiente al nombre del departamento</param>
        public Departamento(string nombre)
        {
            Nombre = nombre;
            ListaProfesores = new List<Profesor>();
        }

        /// <summary>
        /// Constructor con parámetros, incluido el ID.
        /// </summary>
        /// <param name="idDepartamento">Integer correspondiente al ID.</param>
        ///<param name="nombre">String correspondiente al nombre del departamento</param>
        public Departamento(int idDepartamento, string nombre)
        {
            Id_Departamento = idDepartamento;
            Nombre = nombre;
            ListaProfesores = new List<Profesor>();
            
        }
        /// <summary>Constructor copia.
        /// Copia un objeto de tipo Departamento pasado como parámetro.
        /// </summary>
        /// <param name="departamentoCopia">Departamento: Objeto de tipo Departamento</param>
        public Departamento(Departamento departamentoCopia)
        {
            Id_Departamento = departamentoCopia.Id_Departamento;
            Nombre = departamentoCopia.Nombre;
            ListaProfesores = new List<Profesor>();
            foreach (Profesor p in departamentoCopia.ListaProfesores)
            {
                ListaProfesores.Add(p);
            }
        }


        /// <summary>
        /// Sobrecarga del método toString.
        /// </summary>
        /// <returns>String con todos los valores de los atributos separados por " # ".</returns>
        public override string ToString()
        {
            string resultado = Id_Departamento + " # " + Nombre +" # ";
            if (ListaProfesores.Count > 0)
            {
                foreach (Profesor p in ListaProfesores)
                    resultado += p.ToString();
            }
            else
                resultado += "Sin profesores";

            return resultado;
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~Departamento()
        {
            ListaProfesores.Clear();
            ListaProfesores = null;
        }

    }
}
