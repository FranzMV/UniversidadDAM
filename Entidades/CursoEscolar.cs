using System;

/// <author>Francisco David Manzanedo Valle.</author>
namespace Entidades
{
    /// <summary>
    ///  Define los atributos de un objeto de tipo Curso Escolar.
    /// </summary>
    public class CursoEscolar 
    {
        //Variables de instancia
        private int _idCursoEscolar;
        private int _anyoInicio;
        private int _anyoFin;

        /// <summary> Propiedades </summary>
        public int Id_Curso_Escolar 
        {
            get => _idCursoEscolar;
            set 
            {
                if (_idCursoEscolar <= int.MaxValue)
                    _idCursoEscolar = value;
                else throw new ArgumentException("ERROR 0024: El ID de Curso Escolar no es correcto.");
            } 
        }
        
        public int Anyo_Inicio { get => _anyoInicio; set => _anyoInicio = value; }
        public int Anyo_Fin { get => _anyoFin; set => _anyoFin = value; }

        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public CursoEscolar()
        {
            Anyo_Inicio = 1;
            Anyo_Fin = 1;
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="anyoIncio">Integer correspondiente al Año de inicio del Curso Escolar.</param>
        /// <param name="anyoFin">Integer correspondiente al Año de finalización del Curso Escolar.</param>
        public CursoEscolar(int anyoIncio, int anyoFin)
        {
            Anyo_Inicio = anyoIncio;
            Anyo_Fin = anyoFin;
        }

        /// <summary>
        /// Constructor con parámetros, incluido el ID.
        /// </summary>
        /// <param name="idCurso">Integer correspondiente al ID del Curso Escolar.</param>
        /// <param name="anyoIncio">Integer correspondiente al Año de inicio del Curso Escolar.</param>
        /// <param name="anyoFin">Integer correspondiente al Año de finalización del Curso Escolar.</param>
        public CursoEscolar(int idCurso, int anyoIncio, int anyoFin)
        {
            Id_Curso_Escolar = idCurso;
            Anyo_Inicio = anyoIncio;
            Anyo_Fin = anyoFin;
        }

        /// <summary>
        /// Constructor copia.
        /// Copia un objeto de tipo CursoEscolar pasado como parámetro.
        /// </summary>
        /// <param name="cursoEscolarCopia">Objeto <see cref="CursoEscolar"/> a copiar.</param>
        public CursoEscolar(CursoEscolar copiaCrusoEscolar)
        {
            Id_Curso_Escolar = copiaCrusoEscolar.Id_Curso_Escolar;
            Anyo_Inicio = copiaCrusoEscolar.Anyo_Inicio;
            Anyo_Fin = copiaCrusoEscolar.Anyo_Fin;
        }

        /// <summary>
        /// Sobrecarga del método ToString.
        /// </summary>
        /// <returns>String con la información separada por "#".</returns>
        public override string ToString() => Id_Curso_Escolar + " # " + Anyo_Inicio + " # " + Anyo_Fin;

       
    }
}
