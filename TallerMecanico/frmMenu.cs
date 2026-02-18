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
    public partial class frmMenu : Form
    {
        public Form ActiveForm = null;
        public frmMenu()
        {
            InitializeComponent();
        }

        public void AbrirFormHijo(Form ChildForm)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(ChildForm);
            pnlContenedor.Tag = ChildForm;
            ChildForm.BringToFront();

            ChildForm.Show();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlServicios_MouseHover(object sender, EventArgs e)
        {
            pnlServicios.BorderColor= Color.FromArgb(172, 110, 87);
            pnlServicios.BorderThickness= 2;
        }

        private void pnlServicios_MouseLeave(object sender, EventArgs e)
        {
            pnlServicios.BorderColor = Color.White;
            pnlServicios.BorderThickness = 1;
        }

        private void pnlServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmServicios());
        }

        private void pnlRefacciones_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmRefacciones());
        }

        private void pictureRefacciones_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmRefacciones());
        }

        private void lblRefacciones_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmRefacciones());
        }

        private void pictureServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmServicios());
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmServicios());
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            AbrirFormHijo(new frmServicios());
        }
    }
}
