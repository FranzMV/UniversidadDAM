namespace PresentacionWPF
{
    public class AsignaturaDTO
    {
        public AsignaturaDTO(string nombre, string tipo, byte curso, byte cuatrimestre, float creditos)
        {
            Nombre = nombre;
            Tipo = tipo;
            Curso = curso;
            Cuatrimestre = cuatrimestre;
            Creditos = creditos;
        }

        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public byte Curso { get; set; }
        public byte Cuatrimestre { get; set; }
        public float Creditos { get; set; } 
    }
}
