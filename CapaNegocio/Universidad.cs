using System;
using System.Collections.Generic;
using Entidades;
using CapaDatos;
using System.Text;

/// <author>Francisco David Manzanedo Valle.</author>
namespace CapaNegocio
{
    /// <summary>
    /// Se encarga de prestar servicios a la capa de presentación llevando la gestión de matriculación
    /// de la universidad.
    /// </summary>
    public class Universidad
    {
        //Variables de instancia
        private readonly PersonaDAO _personaADO;
        private readonly ProfesorDAO _profesorADO;
        private readonly AsignaturaDAO _asignaturaADO;
        private readonly AlumnoSeMatriculaAsignaturaDAO _alumnoSeMatriculaAsignaturaADO;
        private readonly GradoDAO _gradoADO;
        private readonly DepartamentoDAO _departamentoADO;
        private readonly UsuarioDAO _usuarioADO;
        private readonly CursoEscolarDAO _cursoEscolarADO;
     
        private List<Persona> _listaPersonas_Alumnos;
        private List<Persona> _listaPersonas_Profesores;
        private List<Profesor> _listaProfesores;
        private List<Asignatura> _listaAsignaturasProfesor;
        private List<AlumnoSeMatriculaAsignatura> _listaAlumnoSeMatriculaAsignaturas;
        private List<Usuario> _listaUsuarios;


        /// <summary>
        /// Constructor sin argumentos encargado de instaciar los 
        /// objetos necesarios ADO y las listas para obtener la información.
        /// </summary>
        public Universidad()
        {
            _usuarioADO = new UsuarioDAO();
            _personaADO = new PersonaDAO();
            _profesorADO = new ProfesorDAO();
            _asignaturaADO = new AsignaturaDAO();
            _gradoADO = new GradoDAO();
            _alumnoSeMatriculaAsignaturaADO = new AlumnoSeMatriculaAsignaturaDAO();
            _departamentoADO = new DepartamentoDAO();
            _cursoEscolarADO = new CursoEscolarDAO();
         
            _listaPersonas_Alumnos = new List<Persona>();
            _listaPersonas_Profesores = new List<Persona>();
            _listaProfesores = new List<Profesor>();
            _listaAsignaturasProfesor = new List<Asignatura>();
            _listaAlumnoSeMatriculaAsignaturas = new List<AlumnoSeMatriculaAsignatura>();

            _listaUsuarios = _usuarioADO.LeerUsuarios();
        }


        ///// <summary>
        ///// Obtiene los datos de todos los profesores de un departamento.
        ///// </summary>
        ///// <param name="codigo_departamento">Integer correspondiente a <see cref="Departamento.Id_Departamento"/></param>
        ///// <returns><see cref="List{Persona}"/> con los profesores que pertenecen al departamento pasado como parámetro.</returns>
        //public List<Persona> ListarProfesorDepartamento(int codigo_departamento)
        //{
        //    List<Persona> resultado = new List<Persona>();
        //    _listaProfesores = _profesorADO.LeerProfesores();

        //    foreach (Profesor p in _listaProfesores)
        //    {
        //        if (p.Id_Departamento == codigo_departamento)
        //            resultado.Add(_personaADO.LeerPersona(p.Id_Profesor));
        //    }
        //    return resultado;
        //}

        ///// <summary>
        ///// Obtiene las asignaturas asignadas a un profesor.
        ///// </summary>
        ///// <param name="codigo_profesor">Integer correspondiente a <see cref="Profesor.Id_Persona"/></param>
        ///// <returns><see cref="List{Persona}"/> con los profesores asignados a esa asignatura.</returns>
        public List<Asignatura> ListarProfesorAsignatura(int codigo_profesor)
        {
            List<Asignatura> resultado = new List<Asignatura>();
            _listaAsignaturasProfesor = _asignaturaADO.LeerAsignaturas();

            foreach (Asignatura asignatura in _listaAsignaturasProfesor)
            {
                if (asignatura.Id_Profesor == codigo_profesor)
                    resultado.Add(_asignaturaADO.LeerAsignatura(asignatura.Id_Asignatura));
            }

            return resultado;
        }

        ///// <summary>
        ///// Obtiene los alumnnos matriculados en una asignatura.
        ///// </summary>
        ///// <param name="codigo_asignatura">Integer: correspondiente al ID de <see cref="Asignatura.Id_Asignatura"/></param>
        ///// <returns><see cref="List{Persona}"/> Personas que son Alumnos y están matriculados en la Asignatura.</returns>
        //public List<Persona> ListarAlumnosAsignatura(int codigo_asignatura)
        //{
        //    List<Persona> resultado = new List<Persona>();
        //    _listaAlumnoSeMatriculaAsignaturas =
        //        _alumnoSeMatriculaAsignaturaADO.LeerAlumnosMatriculados();

        //    foreach (AlumnoSeMatriculaAsignatura alumno in _listaAlumnoSeMatriculaAsignaturas)
        //    {
        //        if (alumno.Id_Asignatura == codigo_asignatura)
        //            resultado.Add(_personaADO.LeerPersona(alumno.Id_Alumno));
        //    }

        //    return resultado;
        //}

     

        ///--------------------------------- PERSONAS ---------------------------------------------------------//



        /// <summary>
        /// Obtiene todas las personas almacenas de la BD.
        /// </summary>
        /// <returns><see cref="List{Persona}"/></returns>
        public List<Persona> ListarPersonas() => _personaADO.LeerPersonas();

        /// <summary>
        /// Obtiene todos los profesores.
        /// </summary>
        /// <returns><see cref="List{Persona}"/> con los registros que corresponde a Profesor.</returns>
        public List<Persona> ListarProfesores() 
        {
            List<Persona> resultado = new List<Persona>();
            _listaProfesores = _profesorADO.LeerProfesores();
            foreach(Profesor p in _listaProfesores)
            {
                resultado.Add(_personaADO.LeerPersona(p.Id_Persona));
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene todos los alumnos.
        /// </summary>
        /// <returns><see cref="List{Persona}"/> con los registros que corresponde a Alumno.</returns>
        public List<Persona> ListarAlumnos()
        {
            List<Persona> resultado = new List<Persona>();
            _listaPersonas_Alumnos = _personaADO.LeerPersonas();
            foreach(Persona p in _listaPersonas_Alumnos)
            {
                if (p.Tipo.Equals("alumno"))
                    resultado.Add(p);
            }
            return resultado;
        }

        /// <summary>
        /// Obtine una persona de la BD.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al ID de la persona a obtener.</param>
        /// <returns> Objeto de tipo <see cref="Persona"/></returns>
        public Persona LeerPersona(int idPersona) => _personaADO.LeerPersona(idPersona);
       
        /// <summary>
        /// Inserta un nuevo registro de tipo <see cref="Persona"/> en la BD.
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Persona"/> a insertar.</param>
        /// <returns>Objeto de tipo <see cref="Persona"/></returns>
        public Persona InsertarPersona(Persona p)
        {
            if (p != null)
                return _personaADO.InsertarPersona(p);
            else return null;
        }

        /// <summary>
        /// Actualiza un registro de tipo <see cref="Persona"/> en la BD.
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Persona"/> a actualizar</param>
        /// <returns>Objeto de tipo <see cref="Persona"/></returns>
        public Persona ActualizarPersona(Persona p)
        {
            return p != null ? _personaADO.ActualizarPersona(p) : null;
        }

        /// <summary>
        /// Elimina un registro de tipo <see cref="Persona"/> de la BD.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al ID de la persona.</param>
        /// <returns>Boolean: Si la operación de borrado se ha llevado a cabo o no.</returns>
        public bool EliminarPersona(int idPersona) => _personaADO.EliminarPersona(idPersona);

        /// <summary>
        /// Obtiene un profesor de la tabla Profesor en la BD.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al ID del profesor a abtener.</param>
        /// <returns></returns>
        public Profesor LeerProfesor(int idPersona) => _profesorADO.LeerProfesor(idPersona);

        /// <summary>
        /// Inserta un nuevo registro de tipo <see cref="Profesor"/> en la BD.
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Profesor"/> a insertar.</param>
        /// <returns>Objeto de tipo <see cref="Profesor"/></returns>
        public Profesor InsertarProfesor(Profesor p)
        {
            if (p != null)
                return _profesorADO.InsertarProfesor(p);
            else return null;
        }

        /// <summary>
        /// Elimina un registro de tipo <see cref="Profesor"/> de la BD.
        /// </summary>
        /// <param name="idPersona">Integer correspondiente al ID del profesor.</param>
        /// <returns>>Boolean: Si la operación de borrado se ha llevado a cabo o no</returns>
        public bool EliminarProfesor(int idPersona) => _profesorADO.EliminarProfesor(idPersona);

        /// <summary>
        /// Actualiza un Profesor en la tabla Profesor de la BD
        /// </summary>
        /// <param name="p">Objeto de tipo <see cref="Profesor"/></param>
        /// <returns>Objeto de tipo <see cref="Profesor"/></returns>
        public Profesor ActualizarProfesor(Profesor p)
        {
            if (p != null)
                return _profesorADO.ActualizarProfesor(p);

            else return null;
        }




        //----------------------------------- ASIGNATURAS -----------------------------------------------------//



        /// <summary>
        /// Lista todas las Asignaturas que hay en la BD.
        /// </summary>
        /// <returns><see cref="List{Asignatura}"/></returns>
        public List<Asignatura> ListarAsignaturas() => _asignaturaADO.LeerAsignaturas();

        /// <summary>
        /// Obtine una Asignatura de la BD.
        /// </summary>
        /// <param name="idAsignatura">Integer correspondiente al ID de la persona a obtener.</param>
        /// <returns> Objeto de tipo <see cref="Asignatura"/></returns>
        public Asignatura LeerAsignatura(int idAsignatura) => _asignaturaADO.LeerAsignatura(idAsignatura);

        /// <summary>
        /// Inserta un nuevo registro en de tipo <see cref="Asignatura"/> en la BD.
        /// </summary>
        /// <param name="a">Objeto de tipo <see cref="Asignatura"/> a insertar.</param>
        /// <returns><see cref="Asignatura"/></returns>
        public Asignatura InsertarAsignatura(Asignatura a)
        {
            if (a != null)
                return _asignaturaADO.InsertarAsignatura(a);
            else
                return null;
        }

        /// <summary>
        /// Actualiza un registro de tipo <see cref="Asignatura"/> en la BD.
        /// </summary>
        /// <param name="a">Objeto de tipo <see cref="Asignatura"/> a actualizar</param>
        /// <returns><see cref="Asignatura"/></returns>
        public Asignatura ActualizarAsignatura(Asignatura a)
        {
            if (a != null)
                return _asignaturaADO.ActualizarAsignatura(a);
            else
                return null;
        }

        /// <summary>
        /// Elimina un registro de tipo <see cref="Asignatura"/> de la BD.
        /// persona de la BD.
        /// </summary>
        /// <param name="idAsignatura">Integer correspondiente al ID de Asignatura</param>
        /// <returns>Boolean: Si la operación de borrado se ha llevado a cabo o no.</returns>
        public bool EliminarAsignatura(int idAsignatura) => _asignaturaADO.EliminarAsignatura(idAsignatura);



        //------------------------------------------- GRADOS --------------------------------------------------//



        /// <summary>
        /// Lista todos los Grados que hay en la BD.
        /// </summary>
        /// <returns><see cref="List{Grado}"/></returns>
        public List<Grado> ListarGrados() => _gradoADO.LeerGrados();

        /// <summary>
        /// Obtine un Grado de la BD.
        /// </summary>
        /// <param name="idGrado">Integer correspondiente al ID del Grado a obtener.</param>
        /// <returns> Objeto de tipo <see cref="Grado"/></returns>
        public Grado LeerGrado(int idGrado) => _gradoADO.LeerGrado(idGrado);

        /// <summary>
        /// Inserta un nuevo registro en de tipo <see cref="Grado"/> en la BD.
        /// </summary>
        /// <param name="g">Objeto de tipo <see cref="Grado"/> a insertar.</param>
        /// <returns><see cref="Grado"/></returns>
        public Grado InsertarGrado(Grado g)
        {
            if (g != null)
                return _gradoADO.InsertarGrado(g);
            else
                return null;
        }

        /// <summary>
        /// Actualiza un registro de tipo <see cref="Grado"/> en la BD.
        /// </summary>
        /// <param name="g">Objeto de tipo <see cref="Grado"/> a actualizar</param>
        /// <returns>Objeto de tipo <see cref="Grado"/></returns>
        public Grado ActualizarGrado(Grado g)
        {
            if (g != null)
                return _gradoADO.ActualizarGrado(g);
            else
                return null;
        }

        /// <summary>
        /// Elimina un registro de tipo <see cref="Grado"/> de la BD.
        /// persona de la BD.
        /// </summary>
        /// <param name="idGrado">Integer correspondiente al ID de Grado.</param>
        /// <returns>Boolean: Si la operación de borrado se ha llevado a cabo o no.</returns>
        public bool EliminarGrado(int idGrado) => _gradoADO.EliminarGrado(idGrado);

        /// <summary>
        /// Obtiene las <see cref="Asignatura"/> correspondientes a un <see cref="Grado"/>
        /// </summary>
        /// <param name="idGrado">Integer correspondiente al id de Grado.</param>
        /// <returns><see cref="List{Asignatura}"/> con las asignaturas correspondiente a un grado.</returns>
        public List<Asignatura> LeerAsignaturasDeUnGrado(int idGrado)
        {
            List<Asignatura> resultado = new List<Asignatura>();
            foreach(Asignatura a in ListarAsignaturas())
            {
                if(a.Id_Grado == idGrado)
                {
                    resultado.Add(a);
                }
            }

            return resultado;
        }

        /// <summary>
        /// TODO -HACER
        /// Sobrecarga del método ToString()
        /// </summary>
        /// <returns>String: correspondiente a los datos alamacenados en las Listas.</returns>
        public override string ToString()
        {
            string resultado = "";
            
           // _listaPersonas_Alumnos + "#" + _listaProfesores + "#" + _listaAsignaturasProfesor;

            return resultado;
        }


        //-------------------------------- DEPARTAMENTOS ------------------------------------------------------//


        /// <summary>
        /// Lista todos los departamentos de la BD.
        /// </summary>
        /// <returns><see cref="List{Departamento}"/></returns>
        public List<Departamento> ListarDepartamentos() => _departamentoADO.LeerDepartamentos();

        
        /// <summary>
        /// Obtiene un departamento a través de su ID.
        /// </summary>
        /// <param name="idDepartamento">Integer correspondiente al Id de <see cref="Departamento"/></param>
        /// <returns></returns>
        public Departamento LeerDepartamento(int idDepartamento) => _departamentoADO.LeerDepartamento(idDepartamento);
        


        //----------------------------------- USUARIOS ----------------------------------------------------------//


        /// <summary>
        /// Cifra de una contraseña en MD5.
        /// </summary>
        /// <param name="input">String correspondiente a la contraseña.</param>
        /// <returns>String correspondiente a la contraseña cifrada.</returns>
        public string CalcularMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
        
            return sb.ToString();
        }

        /// <summary>
        /// Comprueba el email y password del usuario al hacer login en la aplicación
        /// </summary>
        /// <param name="email">String correspondiente al email de usuario.</param>
        /// <param name="pass">String correspondiente al password del usuario.</param>
        /// <returns></returns>
        public bool LoginUsuario(string email, string pass)
        {
            bool resultado = false;
            String passAux = CalcularMD5Hash(pass);
            foreach(Usuario user in _listaUsuarios)
            {
                if (user.Email.Equals(email) && user.Pass.Equals(passAux))
                    return true;
            }

            return resultado;
        }


        //----------------------------------- CURSOS ESCOLARES ----------------------------------------------------------//


        /// <summary>
        /// Lista todos los Cursos escolares que hay en la BD.
        /// </summary>
        /// <returns><see cref="List{CursoEscolar}"/></returns>
        public List<CursoEscolar> ListarCursosEscolares() => _cursoEscolarADO.LeerCursos();

        /// <summary>
        /// Obtiene un <see cref="CursoEscolar"/>
        /// </summary>
        /// <param name="idCursoEscolar">Integer correspondiente al id de Curso Escolar</param>
        /// <returns>Un <see cref="CursoEscolar"/></returns>
        public CursoEscolar LeerCursoEscolar(int idCursoEscolar) => _cursoEscolarADO.LeerCurso(idCursoEscolar);

        //----------------------------------- ALUMNO SE MATRICULA ASIGNATURA ----------------------------------------------//


        /// <summary>
        /// Lista todos los alumnos matriculados.
        /// </summary>
        /// <returns><see cref="List{AlumnoSeMatriculaAsignatura}"/></returns>
        public List<AlumnoSeMatriculaAsignatura> ListarAlumnoSeMatriculaAsignatura() 
            => _alumnoSeMatriculaAsignaturaADO.LeerAlumnosMatriculados();

        /// <summary>
        /// Obtiene un <see cref="AlumnoSeMatriculaAsignatura"/> a través de el id del alumno
        /// </summary>
        /// <param name="idAlumno">Integer correspondiente al id del alumno</param>
        /// <returns><see cref="AlumnoSeMatriculaAsignatura"/></returns>
        public AlumnoSeMatriculaAsignatura LeerAlumnoMatriculado(int id_Alumno)
            => _alumnoSeMatriculaAsignaturaADO.LeerAlumnoMatriculado(id_Alumno);

        public List<Asignatura> ObtenerAsignaturasAlumnoMatriculado(int id_Alumno) 
            => _alumnoSeMatriculaAsignaturaADO.ObtenerAsignaturasDeAlumnoMatriculado(id_Alumno);

        /// <summary>
        /// Inserta un nuevo registro de <see cref="AlumnoSeMatriculaAsignatura"/> en la BD.
        /// </summary>
        /// <param name="id_Alumno">Integer correspondiente al Id del alumno</param>
        /// <param name="id_Asignatura">Integer correspondiente al Id de la Asigntura</param>
        /// <param name="id_CursoEscolar">Integer correspondiente al Id del curso escolar</param>
        /// <returns><see cref="AlumnoSeMatriculaAsignatura"/></returns>
        public AlumnoSeMatriculaAsignatura InsertarAlumnoMatriculado(int id_Alumno, int id_Asignatura, int id_CursoEscolar)
            => _alumnoSeMatriculaAsignaturaADO.InsertarAlumnoMatriculadoAsignatura(id_Alumno, id_Asignatura, id_CursoEscolar);

        /// <summary>
        /// Actualiza un registro de <see cref="AlumnoSeMatriculaAsignatura"/> en la BD.
        /// </summary>
        /// <param name="id_Alumno">Integer correspondiente al Id del alumno</param>
        /// <param name="id_Asignatura">Integer correspondiente al Id de la Asigntura</param>
        /// <param name="id_CursoEscolar">Integer correspondiente al Id del curso escolar</param>
        /// <returns><see cref="AlumnoSeMatriculaAsignatura"/></returns>
        public AlumnoSeMatriculaAsignatura ActualizarAlumnoMatriculado(int id_Alumno, int id_Asignatura, int id_CursoEscolar) 
            => _alumnoSeMatriculaAsignaturaADO.ActualizarAlumnoMatriculadoAsignatura(id_Alumno, id_Asignatura, id_CursoEscolar);

        /// <summary>
        /// Elimina un registro de <see cref="AlumnoSeMatriculaAsignatura"/> en la BD.
        /// </summary>
        /// <param name="id_Alumno">Integer correspondiente al Id del alumno</param>
        /// <param name="id_Asignatura">Integer correspondiente al Id de la Asigntura</param>
        /// <param name="id_CursoEscolar">Integer correspondiente al Id del curso escolar</param>
        /// <returns>Boolean: Si la operación de borrado se ha llevado a cabo o no. </returns>
        public bool EliminarAlumnoMatriculado(int id_Alumno, int id_Asignatura, int id_CursoEscolar)
            => _alumnoSeMatriculaAsignaturaADO.EliminarAlumnoMatriculadoAsignatura(id_Alumno, id_Asignatura, id_CursoEscolar);


        /// <summary>
        /// Destructor de la clase.
        /// </summary>
        ~Universidad()
        {
            _listaPersonas_Alumnos.Clear();
            _listaPersonas_Alumnos = null;
            _listaPersonas_Profesores.Clear();
            _listaPersonas_Profesores = null;
            _listaAsignaturasProfesor.Clear();
            _listaAsignaturasProfesor = null;
            _listaProfesores.Clear();
            _listaProfesores = null;
            _listaAlumnoSeMatriculaAsignaturas.Clear();
            _listaAlumnoSeMatriculaAsignaturas = null;
            _listaUsuarios.Clear();
            _listaUsuarios = null;
        }
    }
}
