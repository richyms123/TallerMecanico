using CapaDatos;
using CapaNehocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanico
{
    public partial class frmServicios : Form
    {
        private ServicioDominio servicioDominio = new ServicioDominio();
        private int idServicio = -1;
        private Timer timerRetraso;
        public frmServicios()
        {
            InitializeComponent();
            txtCostoBase.KeyPress += SoloNumeros;
            txtTiempoEstimado.KeyPress += SoloNumerosEnteros;
        }

        private void CargarServicios()
        {
            List<Servicio> servicios = servicioDominio.ObtenerServicios();
            dgvServicios.DataSource = servicios;
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (e.KeyChar == '.')
            {
                e.Handled = ((sender as TextBox).Text.Contains("."));
            }
            else { e.Handled = true; }
        }

        private void SoloNumerosEnteros(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmServicios_Shown(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvServicios.Rows[e.RowIndex];



                    txtIdServicio.Text = fila.Cells[0].Value?.ToString()??"";
                    txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                    txtDescripcion.Text = fila.Cells[2].Value?.ToString() ?? "";
                    txtCostoBase.Text = fila.Cells[3].Value?.ToString() ?? "";
                    txtTiempoEstimado.Text = fila.Cells[4].Value?.ToString() ?? "";
                   
                    btnGuardar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al leer la fila: " + ex.Message);
            }
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCostoBase.Text = "";
            txtTiempoEstimado.Text = "";
            txtIdServicio.Text = "";
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del servicio es obligatorio.");
                return;
            }
            if(txtCostoBase.Text.Trim() == "")
            {
                MessageBox.Show("El costo base es obligatorio.");
                return;
            }
            if (txtTiempoEstimado.Text.Trim()=="")
            {
                MessageBox.Show("El tiempo estimado es obligatorio.");
                return;
            }
            Servicio nuevoServicio=new Servicio();
            nuevoServicio.nombre = txtNombre.Text.Trim();
            nuevoServicio.descripcion = txtDescripcion.Text.Trim();
            nuevoServicio.costoBase = decimal.Parse(txtCostoBase.Text.Trim());
            nuevoServicio.tiempoEstimado = int.Parse(txtTiempoEstimado.Text.Trim());
            string mensaje = servicioDominio.AgregarServicio(nuevoServicio);
            List<Servicio> servicios = servicioDominio.ObtenerServicios();
            dgvServicios.DataSource = servicios;
            Limpiar();
            MessageBox.Show(mensaje);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del servicio es obligatorio.");
                return;
            }
            if (txtCostoBase.Text.Trim() == "")
            {
                MessageBox.Show("El costo base es obligatorio.");
                return;
            }
            if (txtTiempoEstimado.Text.Trim() == "")
            {
                MessageBox.Show("El tiempo estimado es obligatorio.");
                return;
            }
            Servicio servicio = new Servicio();
            servicio.idServicio = int.Parse(txtIdServicio.Text.Trim());
            servicio.nombre = txtNombre.Text.Trim();
            servicio.descripcion = txtDescripcion.Text.Trim();
            servicio.costoBase = decimal.Parse(txtCostoBase.Text.Trim());
            servicio.tiempoEstimado = int.Parse(txtTiempoEstimado.Text.Trim());
            string mensaje = servicioDominio.ActualizarServicio(servicio);
            List<Servicio> servicios = servicioDominio.ObtenerServicios();
            dgvServicios.DataSource = servicios;
            Limpiar();
            MessageBox.Show(mensaje);
        }

        private void txtBuscar_TextChange(object sender, EventArgs e)
        {
            if (timerRetraso != null)
            {
                timerRetraso.Stop();
                timerRetraso.Dispose();
            }

            timerRetraso = new Timer();
            timerRetraso.Interval = 300;

            timerRetraso.Tick += async (s, args) =>
            {
                timerRetraso.Stop();
                timerRetraso.Dispose();

                string busqueda = txtBuscar.Text.Trim();
                var resultado = servicioDominio.BuscarServicios(busqueda);
                dgvServicios.DataSource = resultado;
            };

            timerRetraso.Start();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idServicio = Convert.ToInt32(txtIdServicio.Text);
            string resultado = servicioDominio.EliminarServicio(idServicio);
            List<Servicio> refacciones = servicioDominio.ObtenerServicios();
            dgvServicios.DataSource = refacciones;
            Limpiar();
            MessageBox.Show(resultado);
        }
    }
}
