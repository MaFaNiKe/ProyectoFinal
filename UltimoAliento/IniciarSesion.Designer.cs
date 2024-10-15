namespace UltimoAliento
{
    partial class IniciarSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.</summary>
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
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelRegistrarse = new System.Windows.Forms.Label();
            this.BotonRegistrarse = new System.Windows.Forms.Button();
            this.BotonIniciarSesion = new System.Windows.Forms.Button();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.LabelContraseñaInicio = new System.Windows.Forms.Label();
            this.LabelCorreoInicio = new System.Windows.Forms.Label();
            this.Label_Inicio_Sesion = new System.Windows.Forms.Label();
            this.textBoxTerminosYCondiciones = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxTerminosYCondiciones);
            this.panel1.Controls.Add(this.LabelRegistrarse);
            this.panel1.Controls.Add(this.BotonRegistrarse);
            this.panel1.Controls.Add(this.BotonIniciarSesion);
            this.panel1.Controls.Add(this.txtContrasena);
            this.panel1.Controls.Add(this.txtCorreo);
            this.panel1.Controls.Add(this.LabelContraseñaInicio);
            this.panel1.Controls.Add(this.LabelCorreoInicio);
            this.panel1.Controls.Add(this.Label_Inicio_Sesion);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 403);
            this.panel1.TabIndex = 0;
            // 
            // LabelRegistrarse
            // 
            this.LabelRegistrarse.AutoSize = true;
            this.LabelRegistrarse.Location = new System.Drawing.Point(45, 184);
            this.LabelRegistrarse.Name = "LabelRegistrarse";
            this.LabelRegistrarse.Size = new System.Drawing.Size(100, 13);
            this.LabelRegistrarse.TabIndex = 7;
            this.LabelRegistrarse.Text = "¿No tienes cuenta?";
            // 
            // BotonRegistrarse
            // 
            this.BotonRegistrarse.Location = new System.Drawing.Point(151, 174);
            this.BotonRegistrarse.Name = "BotonRegistrarse";
            this.BotonRegistrarse.Size = new System.Drawing.Size(75, 23);
            this.BotonRegistrarse.TabIndex = 6;
            this.BotonRegistrarse.Text = "Registrate";
            this.BotonRegistrarse.UseVisualStyleBackColor = true;
            this.BotonRegistrarse.Click += new System.EventHandler(this.BotonRegistrarse_Click_1);
            // 
            // BotonIniciarSesion
            // 
            this.BotonIniciarSesion.Location = new System.Drawing.Point(83, 136);
            this.BotonIniciarSesion.Name = "BotonIniciarSesion";
            this.BotonIniciarSesion.Size = new System.Drawing.Size(100, 25);
            this.BotonIniciarSesion.TabIndex = 5;
            this.BotonIniciarSesion.Text = "Iniciar Sesión";
            this.BotonIniciarSesion.UseVisualStyleBackColor = true;
            this.BotonIniciarSesion.Click += new System.EventHandler(this.BotonIniciarSesion_Click);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(119, 97);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(100, 20);
            this.txtContrasena.TabIndex = 4;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(119, 59);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 20);
            this.txtCorreo.TabIndex = 3;
            // 
            // LabelContraseñaInicio
            // 
            this.LabelContraseñaInicio.AutoSize = true;
            this.LabelContraseñaInicio.Location = new System.Drawing.Point(45, 104);
            this.LabelContraseñaInicio.Name = "LabelContraseñaInicio";
            this.LabelContraseñaInicio.Size = new System.Drawing.Size(64, 13);
            this.LabelContraseñaInicio.TabIndex = 2;
            this.LabelContraseñaInicio.Text = "Contraseña:";
            // 
            // LabelCorreoInicio
            // 
            this.LabelCorreoInicio.AutoSize = true;
            this.LabelCorreoInicio.Location = new System.Drawing.Point(45, 66);
            this.LabelCorreoInicio.Name = "LabelCorreoInicio";
            this.LabelCorreoInicio.Size = new System.Drawing.Size(41, 13);
            this.LabelCorreoInicio.TabIndex = 1;
            this.LabelCorreoInicio.Text = "Correo:";
            // 
            // Label_Inicio_Sesion
            // 
            this.Label_Inicio_Sesion.AutoSize = true;
            this.Label_Inicio_Sesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Label_Inicio_Sesion.Location = new System.Drawing.Point(53, 18);
            this.Label_Inicio_Sesion.Name = "Label_Inicio_Sesion";
            this.Label_Inicio_Sesion.Size = new System.Drawing.Size(166, 26);
            this.Label_Inicio_Sesion.TabIndex = 0;
            this.Label_Inicio_Sesion.Text = "Inicio de Sesión";
            // 
            // textBoxTerminosYCondiciones
            // 
            this.textBoxTerminosYCondiciones.Location = new System.Drawing.Point(9, 212);
            this.textBoxTerminosYCondiciones.Multiline = true;
            this.textBoxTerminosYCondiciones.Name = "textBoxTerminosYCondiciones";
            this.textBoxTerminosYCondiciones.ReadOnly = true;
            this.textBoxTerminosYCondiciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTerminosYCondiciones.Size = new System.Drawing.Size(263, 185);
            this.textBoxTerminosYCondiciones.TabIndex = 16;
            this.textBoxTerminosYCondiciones.Text = resources.GetString("textBoxTerminosYCondiciones.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 413);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Inicio de Sesión";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelRegistrarse;
        private System.Windows.Forms.Button BotonRegistrarse;
        private System.Windows.Forms.Button BotonIniciarSesion;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label LabelContraseñaInicio;
        private System.Windows.Forms.Label LabelCorreoInicio;
        private System.Windows.Forms.Label Label_Inicio_Sesion;
        private System.Windows.Forms.TextBox textBoxTerminosYCondiciones;
    }
}
