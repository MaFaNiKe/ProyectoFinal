namespace UltimoAliento 
{
    partial class CrearPost
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCrearPost = new System.Windows.Forms.Panel();
            this.botonNuevaPublicacion = new System.Windows.Forms.Button();
            this.labelTextoPost = new System.Windows.Forms.Label();
            this.textBoxTextoPost = new System.Windows.Forms.TextBox();
            this.buttonVolver2 = new System.Windows.Forms.Button();
            this.labelCrearPost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UsuarioActual = new System.Windows.Forms.TextBox();
            this.FechaActual = new System.Windows.Forms.TextBox();
            this.botonNuevaPublicacion.Click += new System.EventHandler(this.botonNuevaPublicacion_Click);

            this.panelCrearPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCrearPost
            // 
            this.panelCrearPost.Controls.Add(this.FechaActual);
            this.panelCrearPost.Controls.Add(this.UsuarioActual);
            this.panelCrearPost.Controls.Add(this.label4);
            this.panelCrearPost.Controls.Add(this.label3);
            this.panelCrearPost.Controls.Add(this.label2);
            this.panelCrearPost.Controls.Add(this.label1);
            this.panelCrearPost.Controls.Add(this.botonNuevaPublicacion);
            this.panelCrearPost.Controls.Add(this.labelTextoPost);
            this.panelCrearPost.Controls.Add(this.textBoxTextoPost);
            this.panelCrearPost.Controls.Add(this.buttonVolver2);
            this.panelCrearPost.Controls.Add(this.labelCrearPost);
            this.panelCrearPost.Location = new System.Drawing.Point(12, 12);
            this.panelCrearPost.Name = "panelCrearPost";
            this.panelCrearPost.Size = new System.Drawing.Size(500, 288);
            this.panelCrearPost.TabIndex = 7;
            // 
            // botonNuevaPublicacion
            // 
            this.botonNuevaPublicacion.Location = new System.Drawing.Point(298, 238);
            this.botonNuevaPublicacion.Name = "botonNuevaPublicacion";
            this.botonNuevaPublicacion.Size = new System.Drawing.Size(150, 23);
            this.botonNuevaPublicacion.TabIndex = 44;
            this.botonNuevaPublicacion.Text = "Nueva Publicación";
            this.botonNuevaPublicacion.UseVisualStyleBackColor = true;
            // 
            // labelTextoPost
            // 
            this.labelTextoPost.AutoSize = true;
            this.labelTextoPost.Location = new System.Drawing.Point(51, 103);
            this.labelTextoPost.Name = "labelTextoPost";
            this.labelTextoPost.Size = new System.Drawing.Size(77, 13);
            this.labelTextoPost.TabIndex = 40;
            this.labelTextoPost.Text = "Texto Del Post";
            // 
            // textBoxTextoPost
            // 
            this.textBoxTextoPost.Location = new System.Drawing.Point(54, 119);
            this.textBoxTextoPost.Multiline = true;
            this.textBoxTextoPost.Name = "textBoxTextoPost";
            this.textBoxTextoPost.Size = new System.Drawing.Size(394, 88);
            this.textBoxTextoPost.TabIndex = 39;
            // 
            // buttonVolver2
            // 
            this.buttonVolver2.Location = new System.Drawing.Point(54, 238);
            this.buttonVolver2.Name = "buttonVolver2";
            this.buttonVolver2.Size = new System.Drawing.Size(75, 23);
            this.buttonVolver2.TabIndex = 38;
            this.buttonVolver2.Text = "Volver";
            this.buttonVolver2.UseVisualStyleBackColor = true;
            this.buttonVolver2.Click += new System.EventHandler(this.buttonVolver2_Click);
            // 
            // labelCrearPost
            // 
            this.labelCrearPost.AutoSize = true;
            this.labelCrearPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrearPost.Location = new System.Drawing.Point(109, 9);
            this.labelCrearPost.Name = "labelCrearPost";
            this.labelCrearPost.Size = new System.Drawing.Size(254, 55);
            this.labelCrearPost.TabIndex = 33;
            this.labelCrearPost.Text = "Crear Post";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Likes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "0";
            // 
            // UsuarioActual
            // 
            this.UsuarioActual.Location = new System.Drawing.Point(100, 83);
            this.UsuarioActual.Name = "UsuarioActual";
            this.UsuarioActual.Size = new System.Drawing.Size(100, 20);
            this.UsuarioActual.TabIndex = 49;
            // 
            // FechaActual
            // 
            this.FechaActual.Location = new System.Drawing.Point(348, 83);
            this.FechaActual.Name = "FechaActual";
            this.FechaActual.Size = new System.Drawing.Size(100, 20);
            this.FechaActual.TabIndex = 50;
            // 
            // CrearPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 313);
            this.Controls.Add(this.panelCrearPost);
            this.Name = "CrearPost";
            this.Text = "Crear Post";
            this.panelCrearPost.ResumeLayout(false);
            this.panelCrearPost.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelCrearPost;
        private System.Windows.Forms.Label labelTextoPost;
        private System.Windows.Forms.TextBox textBoxTextoPost;
        private System.Windows.Forms.Button buttonVolver2;
        private System.Windows.Forms.Label labelCrearPost;
        private System.Windows.Forms.Button botonNuevaPublicacion;
        private System.Windows.Forms.TextBox FechaActual;
        private System.Windows.Forms.TextBox UsuarioActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
