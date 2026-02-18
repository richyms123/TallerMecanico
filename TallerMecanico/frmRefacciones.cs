using Bunifu.UI.WinForms;
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
    public partial class frmRefacciones : Form
    {
        private RefaccionDominio refaccionDominio=new RefaccionDominio();
        private int idRefaccionSeleccionada = -1;
        private Timer timerRetraso;
        public frmRefacciones()
        {
            InitializeComponent();
            txtPrecio.KeyPress += SoloNumeros;
            txtStockActual.KeyPress += SoloNumerosEnteros;
            txtStockMinimo.KeyPress += SoloNumerosEnteros;
        }

        private void CargarRefacciones()
        {
            refaccionDominio = new RefaccionDominio();
            List<Refaccion> refacciones = refaccionDominio.ObtenerRefacciones();
            dgvRefacciones.DataSource = refacciones;    
        }

        private void frmRefacciones_Shown(object sender, EventArgs e)
        {
            CargarRefacciones();

        }

        private void dgvRefacciones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvRefacciones.Rows[e.RowIndex];

                    

                    idRefaccionSeleccionada = Convert.ToInt32(fila.Cells[0].Value);
                    txtIdRefaccion.Text=fila.Cells[0].Value?.ToString() ?? "";
                    txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                    txtMarca.Text = fila.Cells[2].Value?.ToString() ?? "";
                    txtPrecio.Text = fila.Cells[3].Value?.ToString() ?? "";
                    txtStockActual.Text = fila.Cells[4].Value?.ToString() ?? "";
                    txtStockMinimo.Text = fila.Cells[5].Value?.ToString() ?? "";
                    txtProveedor.Text = fila.Cells[6].Value?.ToString() ?? "";
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
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtStockActual.Text = "";
            txtProveedor.Text = "";
            txtStockMinimo.Text = "";
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
            if(txtNombre.Text == "" || txtMarca.Text == "" || txtPrecio.Text == "" || txtStockActual.Text == "" || txtStockMinimo.Text == "" || txtProveedor.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            refaccionDominio = new RefaccionDominio();
            Refaccion nuevaRefaccion = new Refaccion
            {
                nombre = txtNombre.Text,
                marca = txtMarca.Text,
                precioUnitario = decimal.Parse(txtPrecio.Text),
                stockActual = int.Parse(txtStockActual.Text),
                stockMinimo = int.Parse(txtStockMinimo.Text),
                proveedor = txtProveedor.Text
            };
            string resultado = refaccionDominio.AgregarRefaccion(nuevaRefaccion);
            List<Refaccion> refacciones = refaccionDominio.ObtenerRefacciones();
            dgvRefacciones.DataSource = refacciones;
            Limpiar();
            MessageBox.Show(resultado);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtMarca.Text == "" || txtPrecio.Text == "" || txtStockActual.Text == "" || txtStockMinimo.Text == "" || txtProveedor.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            refaccionDominio = new RefaccionDominio();
            Refaccion nuevaRefaccion = new Refaccion
            {

                idRefaccion = Convert.ToInt32( txtIdRefaccion.Text),
                nombre = txtNombre.Text,
                marca = txtMarca.Text,
                precioUnitario = decimal.Parse(txtPrecio.Text),
                stockActual = int.Parse(txtStockActual.Text),
                stockMinimo = int.Parse(txtStockMinimo.Text),
                proveedor = txtProveedor.Text
            };
            string resultado = refaccionDominio.ActualizarRefaccion(nuevaRefaccion);
            List<Refaccion> refacciones = refaccionDominio.ObtenerRefacciones();
            dgvRefacciones.DataSource = refacciones;
            Limpiar();
            MessageBox.Show(resultado);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idRefaccion = Convert.ToInt32(txtIdRefaccion.Text);
            refaccionDominio = new RefaccionDominio();
            string resultado = refaccionDominio.EliminarRefaccion(idRefaccion);
            List<Refaccion> refacciones = refaccionDominio.ObtenerRefacciones();
            dgvRefacciones.DataSource = refacciones;
            Limpiar();
            MessageBox.Show(resultado);
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
                var resultado = refaccionDominio.BuscarRefaccion(busqueda);
                dgvRefacciones.DataSource = resultado;
            };

            timerRetraso.Start();
            
        }
    }
}
