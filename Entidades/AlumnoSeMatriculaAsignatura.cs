using System;

/// <author>Francisco David Manzanedo Valle.</author>
namespace Entidades
{
    /// <summary>
    /// Define los atributos de un objeto de tipo AlumnoSeMatriculaAsignatura.
    /// </summary>
    public class AlumnoSeMatriculaAsignatura
    {
        //Variables de instancia
        private int _idAlumno;
        private int _idAsignatura;
        private int _idCursoEscolar;


        /// <summary> Propiedades </summary>
        public int Id_Alumno 
        { 
            get => _idAlumno;
            set 
            {
                if (_idAlumno <= int.MaxValue)
                    _idAlumno = value;
                else throw new ArgumentException("ERROR 0026: El ID de Alumno en Alumno_Se_Matricula_Asignatura no es correcto.");
            }
        }
        public int Id_Asignatura 
        { 
            get => _idAsignatura;
            set 
            {
                if (_idAsignatura <= int.MaxValue)
                    _idAsignatura = value;
                else throw new ArgumentException("ERROR 0027: El ID de Asignaturaen en Alumno_Se_Matricula_Asignatura no es correcto.");
            } 
        }
        public int Id_Curso_Escolar 
        { 
            get => _idCursoEscolar;
            set 
            {
                if (_idCursoEscolar <= int.MaxValue)
                    _idCursoEscolar = value;
                else throw new ArgumentException("ERROR 0028: El ID de Curso Escolar en Alumno_Se_Matricula_Asignatura no es correcto.");
            } 
        }

        public AlumnoSeMatriculaAsignatura()
        {
            Id_Alumno = 0;
            Id_Asignatura = 0;
            Id_Curso_Escolar = 0;
        }
       
        /// <summary>
        /// Constructor con parámetros. Instancia un objeto de tipo AlumnoSeMatriculaAsignatura.
        /// </summary>
        /// <param name="idAlumno">Integer correspondiente al ID de <see cref="Persona.Tipo"/></param>
        /// <param name="idAsignatura">Integer correspondiente al ID de la <see cref="Asignatura"/></param>
        /// <param name="idCursoEscolar">Integer correspondiente al ID de <see cref="CursoEscolar"/></param>
        public AlumnoSeMatriculaAsignatura(int idAlumno, int idAsignatura, int idCursoEscolar)
        {
            Id_Alumno = idAlumno;
            Id_Asignatura = idAsignatura;
            Id_Curso_Escolar = idCursoEscolar;
        }

        /// <summary>
        /// Sobrecarga del método toStrring();
        /// </summary>
        /// <returns>String con la información a mostrar.</returns>
        public override string ToString() => Id_Alumno + "#" + Id_Asignatura + "#" + Id_Curso_Escolar;
    }
}
