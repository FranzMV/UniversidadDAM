using CapaNegocio;
using Entidades;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace PresentacionWPF
{
    /// <summary>
    /// Interaction logic for Informe.xaml
    /// </summary>
    public partial class Informe : UserControl
    {
        private FixedDocument fixedDocument;
        private readonly Universidad _universidad;
        private const int ID_CURSO_ACTUAL = 8;
        private List<AlumnoSeMatriculaAsignatura> _listaAlumnosMatriculados;
        private List<Asignatura> _listaAsignaturas;

        public Persona AlumnoSeleccionado { get; set; }

        public IDocumentPaginatorSource Document
        {
            get { return _viewer.Document; }
            set { _viewer.Document = value; }
        }

        public Informe()
        {
            InitializeComponent();
            _universidad = new();
        }

        /// <summary>
        /// Crea el contenedor del informe y añade tanto la cabecera con los datos de las asignaturas en las que 
        /// el alumno está matriculado.
        /// </summary>
        /// <param name="size"></param>
        private void CrearInforme(Size size)
        {
            _listaAsignaturas = _universidad.ListarAsignaturas();
            CursoEscolar cursoEscolar = _universidad.LeerCursoEscolar(ID_CURSO_ACTUAL);
            if (AlumnoSeleccionado != null)
            {
                if (ExisteAlumnoMatriculado(AlumnoSeleccionado))
                {

                    List<AsignaturaDTO> listaAsignaturasAlumnoDTO = ObtenerAsignaturasAlumnoDTO(AlumnoSeleccionado);
                    List<Asignatura> listaAsignaturas = ObtenerAsignaturas(AlumnoSeleccionado);
                    List<Grado> listaGrado = ObtenerGradoAlumno(listaAsignaturas);

                    fixedDocument.DocumentPaginator.PageSize = size;
                    FixedPage fixedPage = new FixedPage
                    {
                        Width = fixedDocument.DocumentPaginator.PageSize.Width,
                        Height = fixedDocument.DocumentPaginator.PageSize.Height
                    };


                    CabeceraInforme cabeceraInforme = new();
                    cabeceraInforme.txtNIF.Text = AlumnoSeleccionado.Nif;
                    cabeceraInforme.txtNombre.Text = AlumnoSeleccionado.Nombre;
                    cabeceraInforme.txtApellido1.Text = AlumnoSeleccionado.Apellido1;
                    cabeceraInforme.txtApellido2.Text = AlumnoSeleccionado.Apellido2;
                    cabeceraInforme.txtCiudad.Text = AlumnoSeleccionado.Ciudad;
                    cabeceraInforme.txtDireccion.Text = AlumnoSeleccionado.Direccion;
                    cabeceraInforme.txtTelefono.Text = AlumnoSeleccionado.Telefono;
                    cabeceraInforme.txtFechNac.Text = AlumnoSeleccionado.Fecha_Nacimiento.ToString("dd/MM/yyyy");
                    listaGrado.ForEach(x => cabeceraInforme.lblGrado.Content = "Grado: " + x.Nombre);
                    cabeceraInforme.lblCursoEscolar.Content = "Curso Escolar: " + cursoEscolar.Anyo_Inicio + "/" + cursoEscolar.Anyo_Fin;


                    Grid myGrid = new();
                    myGrid.Width = 793;
                    myGrid.Height = 630;
                    myGrid.HorizontalAlignment = HorizontalAlignment.Center;
                    myGrid.VerticalAlignment = VerticalAlignment.Center;
                    myGrid.Margin = new Thickness(5, 0, 0, 0);
                    myGrid.ShowGridLines = true;

                    RowDefinition rowDefinition1 = new();
                    RowDefinition rowDefinition2 = new();
                    myGrid.RowDefinitions.Add(rowDefinition1);
                    myGrid.RowDefinitions.Add(rowDefinition2);

                    DataGrid datos = new();
                    datos.AutoGenerateColumns = true;
                    //datos.ColumnWidth = 250;
                    datos.Width = 600;
                    datos.Margin = new Thickness(5, 30, 0, 0);
                    datos.HorizontalAlignment = HorizontalAlignment.Center;
                    datos.ItemsSource = listaAsignaturasAlumnoDTO;

                    //Se añade la cabecera
                    myGrid.Children.Add(cabeceraInforme);
                    Grid.SetRow(cabeceraInforme, 0);

                    //Se añaden los datos de las asignaturas.
                    myGrid.Children.Add(datos);
                    Grid.SetRow(datos, 1);

                    fixedPage.Children.Add(myGrid);

                    PageContent pageContent = new PageContent();
                    ((IAddChild)pageContent).AddChild(fixedPage);
                    fixedDocument.Pages.Add(pageContent);
                }
                else
                {
                    MessageBox.Show("El alumno seleccionado no está matriculado en el curso actual", "Información");
                }
            }
            
        }

        /// <summary>
        /// Metodo load de la vista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _listaAlumnosMatriculados = _universidad.ListarAlumnoSeMatriculaAsignatura();

            fixedDocument = new();
            PrintDialog printDialog = new();
            CrearInforme(new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));
            // se asigna el documento al viewer
            Document = fixedDocument;
            printDialog = null;
            EliminarVentanaBusqueda();
        }

        /// <summary>
        /// Evento click sobre el boton de imprimir matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Matrícula");
        }


        /// <summary>
        /// Comprueba si el alumno está matriculado en el curso actual y devuelve una lista con las asignaturas 
        /// en las que está matriculado.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private List<Asignatura> ObtenerAsignaturas(Persona alumno)
        {
            List<Asignatura> resultado = new();
            List<AlumnoSeMatriculaAsignatura> alumnoSeMatriculaAsignaturas = new();

            foreach (AlumnoSeMatriculaAsignatura asa in _listaAlumnosMatriculados)
            {
                //Si el alumno está matriculado en el curso actual (idCursoEscolar = 8)
                if (alumno.Id_Persona == asa.Id_Alumno && asa.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                    alumnoSeMatriculaAsignaturas.Add(asa);
            }
            foreach (AlumnoSeMatriculaAsignatura asa in alumnoSeMatriculaAsignaturas)
            {
                foreach (Asignatura a in _listaAsignaturas)
                {
                    if (asa.Id_Asignatura == a.Id_Asignatura)
                        resultado.Add(a);
                }
            }
            return resultado;
           
        }
        /// <summary>
        /// Comprueba si el alumno está matriculado en el curso actual y devuelve una lista con las asignaturasDTO
        /// en las que está matriculado.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private List<AsignaturaDTO> ObtenerAsignaturasAlumnoDTO(Persona alumno)
        {
            List<AsignaturaDTO> resultado = new();
            List<Asignatura> asignaturas= new();
            List<AlumnoSeMatriculaAsignatura> alumnoSeMatriculaAsignaturas = new();

            foreach (AlumnoSeMatriculaAsignatura asa in _listaAlumnosMatriculados)
            {
                //Si el alumno está matriculado en el curso actual (idCursoEscolar = 8)
                if (alumno.Id_Persona == asa.Id_Alumno && asa.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                    alumnoSeMatriculaAsignaturas.Add(asa);
            }
            foreach (AlumnoSeMatriculaAsignatura asa in alumnoSeMatriculaAsignaturas)
            {
                foreach (Asignatura a in _listaAsignaturas)
                {
                    if (asa.Id_Asignatura == a.Id_Asignatura)
                        asignaturas.Add(a);
                }
            }
            asignaturas.ForEach(a => resultado.Add(new AsignaturaDTO(a.Nombre, a.Tipo, a.Curso, a.Cuatrimestre, a.Creditos)));
            return resultado;
        }


        /// <summary>
        /// Obtiene el grado en el que esta matriculado el alumno seleccionado.
        /// </summary>
        /// <param name="asignaturas"></param>
        private List<Grado> ObtenerGradoAlumno(List<Asignatura> asignaturas)
        {
            List<Grado> gradoAsignaturas = new();
            foreach (Asignatura a in asignaturas)
            {
                Grado grado = _universidad.LeerGrado(a.Id_Grado);
                gradoAsignaturas.Add(grado);
            }
            List<Grado> unique = gradoAsignaturas.GroupBy(x => x.Id_Grado)
                                                 .Select(x => x.First())
                                                 .ToList();
            return unique;
        }

        /// <summary>
        /// Elimina la ventana de busqueda en la vista del informe.
        /// </summary>
        private void EliminarVentanaBusqueda()
        {
            DocumentViewer dv1 = LogicalTreeHelper.FindLogicalNode(this, "_viewer") as DocumentViewer;
            ContentControl cc = dv1.Template.FindName("PART_FindToolBarHost", dv1) as ContentControl;
            cc.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Comprueba que el alumno seleccionado este matriculado en el curso actual.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private bool ExisteAlumnoMatriculado(Persona alumno)
        {
            bool resultado = false;
            foreach (AlumnoSeMatriculaAsignatura asa in _listaAlumnosMatriculados)
            {
                if (asa.Id_Alumno == alumno.Id_Persona && asa.Id_Curso_Escolar == ID_CURSO_ACTUAL)
                    resultado = true;
            }

            if (resultado)
                Trace.WriteLine("Matriculado en el curso actual");
            return resultado;
        }
    }
}
