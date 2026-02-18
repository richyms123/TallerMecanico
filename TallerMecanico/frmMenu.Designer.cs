namespace TallerMecanico
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.pnlRefacciones = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblRefacciones = new System.Windows.Forms.Label();
            this.pictureRefacciones = new FontAwesome.Sharp.Material.MaterialPictureBox();
            this.pnlServicios = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblServicios = new System.Windows.Forms.Label();
            this.pictureServicios = new FontAwesome.Sharp.Material.MaterialPictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnRestaurar = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnMaximizar = new FontAwesome.Sharp.Material.MaterialButton();
            this.btnCerrar = new FontAwesome.Sharp.Material.MaterialButton();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            this.pnlRefacciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRefacciones)).BeginInit();
            this.pnlServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServicios)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.pnlRefacciones);
            this.bunifuGradientPanel1.Controls.Add(this.pnlServicios);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(100)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(62)))), ((int)(((byte)(98)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(258, 784);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // pnlRefacciones
            // 
            this.pnlRefacciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlRefacciones.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnlRefacciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRefacciones.BackgroundImage")));
            this.pnlRefacciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRefacciones.BorderColor = System.Drawing.Color.White;
            this.pnlRefacciones.BorderRadius = 20;
            this.pnlRefacciones.BorderThickness = 1;
            this.pnlRefacciones.Controls.Add(this.lblRefacciones);
            this.pnlRefacciones.Controls.Add(this.pictureRefacciones);
            this.pnlRefacciones.Location = new System.Drawing.Point(12, 400);
            this.pnlRefacciones.Name = "pnlRefacciones";
            this.pnlRefacciones.ShowBorders = true;
            this.pnlRefacciones.Size = new System.Drawing.Size(232, 149);
            this.pnlRefacciones.TabIndex = 2;
            this.pnlRefacciones.Click += new System.EventHandler(this.pnlRefacciones_Click);
            // 
            // lblRefacciones
            // 
            this.lblRefacciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRefacciones.AutoSize = true;
            this.lblRefacciones.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefacciones.ForeColor = System.Drawing.Color.White;
            this.lblRefacciones.Location = new System.Drawing.Point(44, 85);
            this.lblRefacciones.Name = "lblRefacciones";
            this.lblRefacciones.Size = new System.Drawing.Size(149, 28);
            this.lblRefacciones.TabIndex = 1;
            this.lblRefacciones.Text = "REFACCIONES";
            this.lblRefacciones.Click += new System.EventHandler(this.lblRefacciones_Click);
            // 
            // pictureRefacciones
            // 
            this.pictureRefacciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureRefacciones.BackColor = System.Drawing.Color.Transparent;
            this.pictureRefacciones.IconChar = FontAwesome.Sharp.MaterialIcons.Engine;
            this.pictureRefacciones.IconColor = System.Drawing.Color.White;
            this.pictureRefacciones.IconSize = 65;
            this.pictureRefacciones.Location = new System.Drawing.Point(84, 26);
            this.pictureRefacciones.Name = "pictureRefacciones";
            this.pictureRefacciones.Size = new System.Drawing.Size(65, 65);
            this.pictureRefacciones.TabIndex = 0;
            this.pictureRefacciones.TabStop = false;
            this.pictureRefacciones.Click += new System.EventHandler(this.pictureRefacciones_Click);
            // 
            // pnlServicios
            // 
            this.pnlServicios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlServicios.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnlServicios.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlServicios.BackgroundImage")));
            this.pnlServicios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlServicios.BorderColor = System.Drawing.Color.White;
            this.pnlServicios.BorderRadius = 20;
            this.pnlServicios.BorderThickness = 1;
            this.pnlServicios.Controls.Add(this.lblServicios);
            this.pnlServicios.Controls.Add(this.pictureServicios);
            this.pnlServicios.Location = new System.Drawing.Point(12, 225);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.ShowBorders = true;
            this.pnlServicios.Size = new System.Drawing.Size(232, 149);
            this.pnlServicios.TabIndex = 0;
            this.pnlServicios.Click += new System.EventHandler(this.pnlServicios_Click);
            // 
            // lblServicios
            // 
            this.lblServicios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.ForeColor = System.Drawing.Color.White;
            this.lblServicios.Location = new System.Drawing.Point(61, 85);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(115, 28);
            this.lblServicios.TabIndex = 1;
            this.lblServicios.Text = "SERVICIOS";
            this.lblServicios.Click += new System.EventHandler(this.lblServicios_Click);
            // 
            // pictureServicios
            // 
            this.pictureServicios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureServicios.BackColor = System.Drawing.Color.Transparent;
            this.pictureServicios.IconChar = FontAwesome.Sharp.MaterialIcons.Cog;
            this.pictureServicios.IconColor = System.Drawing.Color.White;
            this.pictureServicios.IconSize = 65;
            this.pictureServicios.Location = new System.Drawing.Point(84, 26);
            this.pictureServicios.Name = "pictureServicios";
            this.pictureServicios.Size = new System.Drawing.Size(65, 65);
            this.pictureServicios.TabIndex = 0;
            this.pictureServicios.TabStop = false;
            this.pictureServicios.Click += new System.EventHandler(this.pictureServicios_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.btnMinimizar);
            this.pnlSuperior.Controls.Add(this.btnRestaurar);
            this.pnlSuperior.Controls.Add(this.btnMaximizar);
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(258, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1184, 45);
            this.pnlSuperior.TabIndex = 1;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.MaterialIcons.WindowMinimize;
            this.btnMinimizar.IconColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(1004, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(45, 45);
            this.btnMinimizar.TabIndex = 191;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.IconChar = FontAwesome.Sharp.MaterialIcons.WindowRestore;
            this.btnRestaurar.IconColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(1049, 0);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(45, 45);
            this.btnRestaurar.TabIndex = 190;
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.IconChar = FontAwesome.Sharp.MaterialIcons.WindowMaximize;
            this.btnMaximizar.IconColor = System.Drawing.Color.White;
            this.btnMaximizar.Location = new System.Drawing.Point(1094, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(45, 45);
            this.btnMaximizar.TabIndex = 189;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.MaterialIcons.WindowClose;
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1139, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 45);
            this.btnCerrar.TabIndex = 188;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(258, 45);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1184, 739);
            this.pnlContenedor.TabIndex = 2;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlSuperior;
            this.bunifuDragControl1.Vertical = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1442, 784);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.pnlRefacciones.ResumeLayout(false);
            this.pnlRefacciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRefacciones)).EndInit();
            this.pnlServicios.ResumeLayout(false);
            this.pnlServicios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureServicios)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.UI.WinForms.BunifuPanel pnlServicios;
        private FontAwesome.Sharp.Material.MaterialPictureBox pictureServicios;
        private Bunifu.UI.WinForms.BunifuPanel pnlRefacciones;
        private System.Windows.Forms.Label lblRefacciones;
        private FontAwesome.Sharp.Material.MaterialPictureBox pictureRefacciones;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Panel pnlSuperior;
        private FontAwesome.Sharp.Material.MaterialButton btnMinimizar;
        private FontAwesome.Sharp.Material.MaterialButton btnRestaurar;
        private FontAwesome.Sharp.Material.MaterialButton btnMaximizar;
        private FontAwesome.Sharp.Material.MaterialButton btnCerrar;
        private System.Windows.Forms.Panel pnlContenedor;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}

