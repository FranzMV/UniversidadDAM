using System;

/// <author> Francisco David Manzanedo Valle </author>
namespace Entidades
{
    /// <summary>
    /// Define los atributos de un objeto de tipo Asignatura.
    /// Implementa la Interfaz <see cref="IComparable"/> 
    /// para ordenar una asignatura por el atributo <see cref="Nombre"/>.
    public class Asignatura : IComparable<Asignatura>
    {
        //Variables de instancia
        private int _idAsignatura;
        private string _nombreAsignatura;
        private float _creditos;
        private string _tipoAsignatura;
        private byte _curso;
        private byte _cuatrimestre;
        private int? _idProfesor;
        private int _idGrado;

        //Constantes para establecer valores máximos y mínimos en las restricicones.
        private const byte MIN_CURSO = 1;
        private const byte MAX_CURSO = 4;
        private const byte MAX_CUATRIMESTRE = 2;
        private const byte MIN_CUATRIMESTRE = 1;
        private const float MIN_CREDITOS = 0.0f;
        private const float MAX_CREDITOS = 6.0f;
        private const string TIPO_BASICA = "básica";
        private const string TIPO_OBLIGATORIA = "obligatoria";
        private const string TIPO_OPTATIVA = "optativa";

        /// <summary>Propiedades</summary>
        public int Id_Asignatura 
        { 
            get => _idAsignatura;
            set
            {
                if (_idAsignatura >= 0 || _idAsignatura <= int.MaxValue)
                    _idAsignatura = value;
                else throw new ArgumentException("ERROR 0025: El ID de Asignatura no es correcto.");
            }
        }
        public string Nombre
        {
            get => _nombreAsignatura;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 000017: El campo nombre de la asignatura no puede quedar vacío.");
                else if (value.Length > 100)
                    throw new ArgumentException("ERROR 000017B: El campo nombre no puede tener más de 100 caracteres.");
                else
                    _nombreAsignatura = value;
            }
        }
        public float Creditos
        {
            get => _creditos;
            set
            {
                if (value >= MIN_CREDITOS && value <= MAX_CREDITOS)
                    _creditos = value;
                else throw new ArgumentException("ERROR 000018: El valor de créditos no está permitido.");
            }
        }
        public string Tipo
        {
            get => _tipoAsignatura;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    _tipoAsignatura = TIPO_BASICA;

                 else if(value.Equals(TIPO_BASICA) || value.Equals(TIPO_OBLIGATORIA) || value.Equals(TIPO_OPTATIVA))
                    _tipoAsignatura = value;
                
                 else throw new ArgumentException("ERROR 000018: El campo nombre no puede tener más de 100 caracteres.");
            }
        }
        public byte Curso
        {
            get => _curso;
            set
            {
                if (value >= MIN_CURSO ||  value <= MAX_CURSO)
                    _curso = value;
                else throw new ArgumentException("ERROR 000019: Curso no permitido.");
            }
        }
        public byte Cuatrimestre
        {
            get => _cuatrimestre;
            set
            {
                if (value >= MIN_CUATRIMESTRE || value <= MAX_CUATRIMESTRE)
                    _cuatrimestre = value;
                else throw new ArgumentException("ERROR 000021: Cuatrimestre no permitido.");
            }
        }
        public int? Id_Profesor { get => _idProfesor; set => _idProfesor = value; }
        //{
        //    get => _idProfesor;
        //    set
        //    {
        //        if (value == null)
        //            _idProfesor = null;
        //        else if (_idProfesor >= 0 && _idProfesor <= int.MaxValue)
        //            _idProfesor = value;
        //        else _idProfesor = null;
        //    } 
        //}
        public int Id_Grado 
        { 
            get => _idGrado;
            set
            {
                 if(_idGrado >= 0 || _idGrado <= int.MaxValue)
                    _idGrado = value;
                else throw new ArgumentException("ERROR 0023: El ID de grado no es correcto.");
            } 
        }
        

        /// <summary>Constructor sin parámetros.</summary>
        public Asignatura()
        {
            Creditos = MIN_CREDITOS;
            Tipo = TIPO_BASICA;
            Curso = MIN_CURSO;
            Cuatrimestre = MIN_CUATRIMESTRE;
            //Id_Profesor = 0;
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nombreAsignatura">String correspondiente al Nombre de la Asignatura.</param>
        /// <param name="creditos">Float correspondiente a la cantidad de Créditos de la Asignatura.</param>
        /// <param name="tipoAsignatura">String que define los 3 tipos de Asignatura. </param>
        /// <param name="curso">Byte correspondiente al año del Curso</param>
        /// <param name="cuatrimestre">Byte correspondiente al Cuatrimestre.</param>
        /// <param name="idProfesor">Integer correspondiente al Id de <see cref="Profesor"/></param>
        /// <param name="idGrado">Integer correspondiente al ID de <see cref="Grado"/></param>
        public Asignatura(string nombreAsignatura, float creditos,
            string tipoAsignatura, byte curso, byte cuatrimestre, int idProfesor, int idGrado)
        {
            Nombre = nombreAsignatura;
            Creditos = creditos;
            Tipo = tipoAsignatura;
            Curso = curso;
            Cuatrimestre = cuatrimestre;
            Id_Profesor = idProfesor;
            Id_Grado = idGrado;
        }

        /// <summary>
        /// Constructor con parámetros, incluido el ID.
        /// </summary>
        /// <param name="idAsignatura">Integer correspondiente al ID de la Asignatura.</param>
        /// <param name="nombreAsignatura">String correspondiente al Nombre de la Asignatura.</param>
        /// <param name="creditos">Float correspondiente a la cantidad de Créditos de la Asignatura.</param>
        /// <param name="tipoAsignatura">String que define los 3 tipos de Asignatura. </param>
        /// <param name="curso">Byte correspondiente al año del Curso</param>
        /// <param name="cuatrimestre">Byte correspondiente al Cuatrimestre.</param>
        /// <param name="idProfesor">Integer correspondiente al Id de <see cref="Profesor"/></param>
        /// <param name="idGrado">Integer correspondiente al ID de <see cref="Grado"/></param>
        public Asignatura(int idAsignatura, string nombreAsignatura, float creditos,
           string tipoAsignatura, byte curso, byte cuatrimestre, int idProfesor, int idGrado)
        {
            Id_Asignatura = idAsignatura;
            Nombre = nombreAsignatura;
            Creditos = creditos;
            Tipo = tipoAsignatura;
            Curso = curso;
            Cuatrimestre = cuatrimestre;
            Id_Profesor = idProfesor;
            Id_Grado = idGrado;
        }

        /// <summary>
        /// Constructor Copia.
        /// Copia un objeto de tipo Asignatura pasado como parámetro.
        /// </summary>
        /// <param name="asignaturaCopia">Objeto <see cref="Asignatura"/> a copiar.</param>
        public Asignatura(Asignatura asignaturaCopia)
        {
            Id_Asignatura = asignaturaCopia.Id_Asignatura;
            Nombre = asignaturaCopia.Nombre;
            Creditos = asignaturaCopia.Creditos;
            Tipo = asignaturaCopia.Tipo;
            Curso = asignaturaCopia.Curso;
            Cuatrimestre = asignaturaCopia.Cuatrimestre;
            Id_Profesor = asignaturaCopia.Id_Profesor;
            Id_Grado = asignaturaCopia.Id_Grado;
        }

        /// <summary>
        /// Implementación del método CopareTo.
        /// La interfaz <seealso cref="IComparable"/>exige la implametación de un método CompareTo.
        /// Una Asignatura es comparada por <see cref="Nombre"/>
        /// </summary>
        /// <param name="other"> Objeto <see cref="Asignatura"/> a ser comparado.</param>
        /// <returns>
        ///  1 - Si el objeto actual es mayor que el recibido por parámetro
        /// -1 - Si el objeto actual es menor que el recibido por parámetro
        ///  0 - Si los objetos son iguales
        /// </returns>
        public int CompareTo(Asignatura other) => string.Compare(Nombre, other.Nombre);

        /// <summary>
        /// Sobrecarga del método toString.
        /// </summary>
        /// <returns>String con todos los valores de los atributos separados por " # "</returns>
        public override string ToString() => Id_Asignatura + "#" + Nombre + "#"
            + Creditos + "#" + Curso + "#" + Cuatrimestre + "#" + Id_Profesor + "#" + Id_Grado;

    }
}
