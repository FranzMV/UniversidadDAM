using System;

///<author>Francisco David Manzanedo Valle.</author>
namespace Entidades
{
    /// <summary>
    /// Define los atributos de un objeto de tipo Usuario.
    /// </summary>
    public class Usuario
    {
        //Variables de instancia
        private int _idUsuario;
        private string _nombre;
        private string _apellido1;
        private string _apellido2;
        private string _extension;
        private string _email;
        private string _pass;

        /// <summary>Propiedades</summary>
        public int Id_Usuario 
        { 
            get => _idUsuario; 
            set
            {
                if (_idUsuario <= int.MaxValue)
                    _idUsuario = value;
                else throw new ArgumentException("ERROR 0014: El ID de usuario no es correcto.");
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0015: El nombre de Usuario no puede quedar vacío.");
                else if (value.Length > 50)
                    throw new ArgumentException("ERROR 0015B: El nombre de Usuario no puede exceder de 50 caracteres.");
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
                    throw new ArgumentException("ERROR 0016: El primer apellido de Usuario no puede quedar vacío.");
                else if (value.Length > 50)
                    throw new ArgumentException("ERROR 0016B: El primer apellido de Usuario no puede exceder de 50 caracteres.");
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
                    _apellido2 = value;
                else if (value.Length > 50)
                    throw new ArgumentException("ERROR 0016: El segundo apellido de Usuario no puede exceder de 50 caracteres.");
                else
                    _apellido2 = value;
            }
        }
        public string Extension
        {
            get => _extension;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0017: La extensión de Usuario no puede quedar vacía.");
                else if (value.Length > 10)
                    throw new ArgumentException("ERROR 0017B: La extensión de Usuario no puede exceder de 10 caracteres.");
                else
                    _extension = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0018: El email no puede quedar vacío.");
                else if (value.Length > 100)
                    throw new ArgumentException("ERROR 0018B: El email no puede exceder de 100 caracteres.");
                else
                    _email = value;
            }
        }
        public string Pass
        {
            get => _pass;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ERROR 0019: El password de usuario no puede quedar vacío.");
                else if (value.Length > 32)
                    throw new ArgumentException("ERROR 0019B: El password de usuario no puede contener más de 32 caracteres.");
                else
                    _pass = value;
            }
        }

        /// <summary>
        /// Constructor sin parámetros.
        /// </summary>
        public Usuario()
        {
            Id_Usuario = 0;
            Apellido2 = null;
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nombre">String correspondiente al Nombre de Usuario.</param>
        /// <param name="apellido1">String correspondiente al primer Apellido de Usuario.</param>
        /// <param name="apellido2">String correspondiente al segundo Apellido de Usuario.</param>
        /// <param name="extension">String correspondiente a la Extensión de Usuario.</param>
        /// <param name="email">String correspondiente al Email de Usuario.</param>
        /// <param name="pass">String correspondiente al Password de Usuario.</param>
        public Usuario(string nombre, string apellido1,
            string apellido2, string extension, string email, string pass)
        {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Extension = extension;
            Email = email;
            Pass = pass;
        }

        /// <summary>
        /// Constructor con parámetros, incluido el ID.
        /// </summary>
        /// <param name="idUsuario">Integer correspondiente al ID de Usuario.</param>
        /// <param name="nombre">String correspondiente al Nombre de Usuario.</param>
        /// <param name="apellido1">String correspondiente al primer Apellido de Usuario.</param>
        /// <param name="apellido2">String correspondiente al segundo Apellido de Usuario.</param>
        /// <param name="extension">String correspondiente a la Extensión de Usuario.</param>
        /// <param name="email">String correspondiente al Email de Usuario.</param>
        /// <param name="pass">String correspondiente al Password de Usuario.</param>
        public Usuario(int idUsuario,string nombre, string apellido1,
           string apellido2, string extension, string email, string pass)
        {
            Id_Usuario = idUsuario;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Extension = extension;
            Email = email;
            Pass = pass;
        }

        /// <summary>
        /// Constructor copia. Copia un objeto Usuario pasado como parámetro.
        /// </summary>
        /// <param name="copiaUsuario">Objeto <see cref="Usuario"/> a copiar.</param>
        public Usuario(Usuario copiaUsuario)
        {
            Id_Usuario = copiaUsuario.Id_Usuario;
            Nombre = copiaUsuario.Nombre;
            Apellido1 = copiaUsuario.Apellido1;
            Apellido2 = copiaUsuario.Apellido2;
            Extension = copiaUsuario.Extension;
            Email = copiaUsuario.Email;
            Pass = copiaUsuario.Pass;
        }

        /// <summary>
        /// Sobrecarga del método ToString.
        /// </summary>
        /// <returns>String con la información separada por "#".</returns>
        public override string ToString() => Id_Usuario + "#" + Nombre + "#" +
            Apellido1 + "#" + Apellido2 + "#" + Extension + "#" +
            Email + "#" + Pass;

    }
}
