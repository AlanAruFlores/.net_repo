using GestorEmpleadosWinForm.Entidad;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GestorEmpleadosWinForm
{
    public partial class Form1 : Form
    {
        HttpClient _httpClient;

        public Form1()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7109/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardarEmpleado_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textBoxNDNI.Text);
            string nombre = textBoxNombre.Text;
            int edad = Convert.ToInt32(textBoxEdad.Text);
            double sueldo = Convert.ToDouble(textBoxSueldo.Text);

            Empleado nuevo = new Empleado(DNI, nombre, edad, sueldo);
            GuardarEmpleado(nuevo);
        }

        private async Task GuardarEmpleado(Empleado empleado)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Empleado>("api/Empleado/PostNewEmpleado", empleado);
            response.EnsureSuccessStatusCode();

            dataGridEmpleados.Rows.Clear();
            await LoadDataEmpleadosOnDataGrid();
        }

        private async Task LoadDataEmpleadosOnDataGrid()
        {
            List<Empleado> empleados = await GetEmpleadosFromAPI();
            //MessageBox.Show("" + empleados.Count);
            empleados.ForEach(empleado =>
            {
                AgregarFila(dataGridEmpleados, empleado);
            });
        }

        private void AgregarFila(DataGridView dataGridEmpleados, Empleado empleado)
        {
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dataGridEmpleados);

            fila.Cells[0].Value = empleado.DNI;
            fila.Cells[1].Value = empleado.Nombre;
            fila.Cells[2].Value = empleado.Edad;
            fila.Cells[3].Value = empleado.Sueldo;

            dataGridEmpleados.Rows.Add(fila);
        }

        private async Task<List<Empleado>> GetEmpleadosFromAPI()
        {
            List<Empleado> empleados = new List<Empleado>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/Empleado/GetAllEmpleados");

            if (response.IsSuccessStatusCode)
            {
                empleados = await response.Content.ReadFromJsonAsync<List<Empleado>>();
            }
            return empleados;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataEmpleadosOnDataGrid();
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int dniEliminar = Convert.ToInt32(textBoxDNIEliminar.Text);
            EliminarEmpleadoPorDNI(dniEliminar);
        }

        private async Task EliminarEmpleadoPorDNI(int dni)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Empleado/DeleteEmpleado/{dni}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Se elimino el empleado con exito");
                dataGridEmpleados.Rows.Clear();
                await LoadDataEmpleadosOnDataGrid();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }
    }
}
