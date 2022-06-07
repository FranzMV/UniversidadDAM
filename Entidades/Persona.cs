using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <author> Francisco David Manzanedo Valle </author>
namespace Entidades
{
    /// <summary>
    /// Clase que define los atributos de un objeto de tipo Persona.
    /// Implementa la Interfaz <see cref="IComparable"/> para que 
    /// una persona se pueda ordenar por <see cref="Persona.Nif"/>.
    /// </summary>
    public class Persona : IComparable<Persona> 
    {
        //Variables de instancia
        protected int _idPersona;
        protected string _nif;
        protected string _nombre;
        protected string _apellido1;
        protected string _apellido2;
        protected string _ciudad;
        protected string _direccion;
        protected string  _telefono;
        protected DateTime _fechaNacimiento;
        protected string _sexo;
        protected string _tipo;
        protected string _rutaFoto;

        //Constantes para validar datos
        private const string TIPO_PERSONA_PROFESOR = "profesor";
        private const string TIPO_PERSONA_ALUMNO = "alumno";
        private const string SEXO_HOMBRE = "H";
        private const string SEXO_MUJER = "M";
        private const int MAX_RUTA_FOTO = 250;
        private const string VALOR_POR_DEFECTO_RUTA_FOTO = "SIN_FOTO.PNG";

        public event PropertyChangedEventHandler PropertyChanged;

        //public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Propiedades </summary>
        public int Id_Persona 
        { 
            get => _idPersona;
            set
            {
                if (_idPersona >= 0 || _idPersona <= int.MaxValue)
                    _idPersona = value;
                else throw new ArgumentException("ERROR 0001: El ID no es correcto");
            } 
        
        }
        public string Nif
        {
            get => _nif;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0002: El campo NIF no puede quedar vacío.");
                //else if (value.Length > 9)
                 //   throw new ArgumentException("ERROR: 0002B: El NIF introducido no tiene el formato correcto.");
                else
                    _nif = value;
               
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0003: El campo nombre no puede quedar vacío.");
                else if (value.Length > 25)
                    throw new ArgumentException("ERROR 0003B: El campo nombre no puede tener más de 25 caracteres.");
                else
                    _nombre = value;
               
            }
        }
        public string Apellido1
        {
            get => _apellido1;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0004: El apellido no puede estar vacío.");
                else if (value.Length > 50)
                    throw new ArgumentException("ERROR 0004B: El apellido no puede contener más de 50 caracteres.");
                else
                    _apellido1 = value;
               
            }
        }
        public string Apellido2
        {
            get => _apellido2;
            set
            {
                if (value == null)
                    _apellido2 = null;
                else if (value.Length > 0 && value.Length <= 50)
                    _apellido2 = value;
                else
                    _apellido2 = null;
                
            }
        }
        public string Ciudad
        {
            get => _ciudad;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0005: La ciudad no puede estar vacía.");
                else if (value.Length > 25)
                    throw new ArgumentException("ERROR 0005B: La ciudad no puede contener más de 25 caracteres.");
                else
                    _ciudad = value;
                
            }
        }
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0006: La dirección no puede estar vacía.");
                else if (value.Length > 50)
                    throw new ArgumentException("ERROR 0006B: La dirección no puede contener más de 50 caracteres.");
                else
                    _direccion = value;
               
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (value == null)
                    _telefono = null;
                else if (value.Length == 9)
                    _telefono = value;
                else if (value.Length == 0)
                    _telefono = null;
                else
                    throw new ArgumentException("ERROR 0007: El teléfono introducido no tiene el formato correcto.");
              
            }
        }
        public DateTime Fecha_Nacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value != null)
                    _fechaNacimiento = value;
                else throw new ArgumentException("ERROR 0008: La fecha de nacimiento no puede ser nula.");
              
            }
        }
        public string Sexo
        {
            get => _sexo;
            set
            {
                if(value.Equals(SEXO_HOMBRE) || value.Equals(SEXO_MUJER))
                    _sexo = value;
                else throw new ArgumentException("ERROR 0009B :El valor debe ser: H (Hombre) o M (Mujer).");

               
            }
        }
        public string Tipo
        {
            get => _tipo;
            set
            {
                if (value.Equals(TIPO_PERSONA_PROFESOR) || (value.Equals(TIPO_PERSONA_ALUMNO)))
                    _tipo = value.ToLower();
                else throw new ArgumentException("ERROR 0010: El campo tipo no puede quedar vacío.");
               
            }
        }
        public string Ruta_Foto
        {
            get => _rutaFoto;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    _rutaFoto = VALOR_POR_DEFECTO_RUTA_FOTO;
                else if (value.Length > MAX_RUTA_FOTO)
                    throw new ArgumentException("ERROR 0011: La ruta para la imagen no puede contener más de 250 caracteres.");
                else
                    _rutaFoto = value;
              
            }
        }
        //Propiedad de sólo lectura
        public string NombreCompleto { get => Nombre + " " + Apellido1 + " " + Apellido2; }


        /// <summary> Constructor sin argumentos. </summary>
        public Persona()
        {
            Apellido2 = "";
            Fecha_Nacimiento = new DateTime();
            Sexo = SEXO_HOMBRE;
            Tipo = TIPO_PERSONA_ALUMNO;
            Ruta_Foto = VALOR_POR_DEFECTO_RUTA_FOTO;
        }
        

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al id </param>
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
        public Persona(string nif, string nombre, string apellido1, string apellido2,
            string ciudad, string direccion, string telefono, DateTime fechaNacimiento,
            string sexo, string tipo, string rutaFoto)
        {
            Nif = nif;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Ciudad = ciudad;
            Direccion = direccion;
            Telefono = telefono;
            Fecha_Nacimiento = fechaNacimiento;
            Sexo = sexo;
            Tipo = tipo;
            Ruta_Foto = rutaFoto;
        }

        /// <summary>
        /// Constructor con todos los atributos, incluido el ID.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al id </param>
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
        public Persona(int idPersona,string nif, string nombre, string apellido1, string apellido2,
            string ciudad, string direccion, string telefono, DateTime fechaNacimiento,
            string sexo, string tipo, string rutaFoto)
        {
            Id_Persona = idPersona;
            Nif = nif;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Ciudad = ciudad;
            Direccion = direccion;
            Telefono = telefono;
            Fecha_Nacimiento = fechaNacimiento;
            Sexo = sexo;
            Tipo = tipo;
            Ruta_Foto = rutaFoto;
        }

        /// <summary>
        /// Constructor copia.
        /// Copia un objeto de tipo Persona con todos sus atributos pasado como parámetro.
        /// </summary>
        /// <param name="copiaPersona">Persona objeto de tipo <see cref="Persona"/> para ser copiado.</param>
        public Persona(Persona copiaPersona)
        {
            Id_Persona = copiaPersona.Id_Persona;
            Nif = copiaPersona.Nif;
            Nombre = copiaPersona.Nombre;
            Apellido1 = copiaPersona.Apellido1;
            Apellido2 = copiaPersona.Apellido2;
            Ciudad = copiaPersona.Ciudad;
            Direccion = copiaPersona.Direccion;
            Telefono = copiaPersona.Telefono;
            Fecha_Nacimiento = copiaPersona.Fecha_Nacimiento;
            Sexo = copiaPersona.Sexo;
            Tipo = copiaPersona.Tipo;
            Ruta_Foto = copiaPersona.Ruta_Foto;
        }



      
       


        /// <summary>
        /// Implementación del método CopareTo.
        /// La interfaz <see cref="IComparable"/> exige la implametación de un método CompareTo.
        /// La comparación se realiza a través del atributo <see cref="Persona.Nif"/>
        /// </summary>
        /// <param name="other">Objeto <see cref="Persona"/> a ser comparado.</param>
        /// <returns>
        ///  1 - Si el objeto actual es mayor que el recibido por parámetro
        /// -1 - Si el objeto actual es menor que el recibido por parámetro
        ///  0 - Si los objetos son iguales
        /// </returns>
        public int CompareTo(Persona other) => String.Compare(Nif, other.Nif);

        /// <summary>
        /// Sobrecarga del método toString.
        /// </summary>
        /// <returns>String con todos los valores de los atributos separados por " # ".</returns>
        public override string ToString() =>
            Id_Persona + "#" + Nif + "#" + Nombre + "#" + Apellido1 + "#" + Apellido2 + "#" +
            Ciudad + "#" + Direccion + "#" + Telefono + "#" + Fecha_Nacimiento + "#" +
            Sexo + "#" + Tipo + "#" + Ruta_Foto;
    }
}
