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
            this.comboBoxIntereses = new System.Windows.Forms.ComboBox();
            this.labelInteresesPost = new System.Windows.Forms.Label();
            this.labelTextoPost = new System.Windows.Forms.Label();
            this.textBoxContPost = new System.Windows.Forms.TextBox();
            this.buttonVolver2 = new System.Windows.Forms.Button();
            this.labelCrearPost = new System.Windows.Forms.Label();
            this.panelCrearPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCrearPost
            // 
            this.panelCrearPost.Controls.Add(this.botonNuevaPublicacion);
            this.panelCrearPost.Controls.Add(this.comboBoxIntereses);
            this.panelCrearPost.Controls.Add(this.labelInteresesPost);
            this.panelCrearPost.Controls.Add(this.labelTextoPost);
            this.panelCrearPost.Controls.Add(this.textBoxContPost);
            this.panelCrearPost.Controls.Add(this.buttonVolver2);
            this.panelCrearPost.Controls.Add(this.labelCrearPost);
            this.panelCrearPost.Location = new System.Drawing.Point(10, 11);
            this.panelCrearPost.Name = "panelCrearPost";
            this.panelCrearPost.Size = new System.Drawing.Size(300, 400);
            this.panelCrearPost.TabIndex = 7;
            // 
            // botonNuevaPublicacion
            // 
            this.botonNuevaPublicacion.Location = new System.Drawing.Point(147, 357);
            this.botonNuevaPublicacion.Name = "botonNuevaPublicacion";
            this.botonNuevaPublicacion.Size = new System.Drawing.Size(150, 30);
            this.botonNuevaPublicacion.TabIndex = 44;
            this.botonNuevaPublicacion.Text = "Nueva Publicación";
            this.botonNuevaPublicacion.UseVisualStyleBackColor = true;
            // 
            // comboBoxIntereses
            // 
            this.comboBoxIntereses.FormattingEnabled = true;
            this.comboBoxIntereses.Items.AddRange(new object[] {
            "Deportes",
            "Cine",
            "Tecnología",
            "Arte",
            "Música",
            "Literatura",
            "Viajes",
            "Comida"});
            this.comboBoxIntereses.Location = new System.Drawing.Point(15, 218);
            this.comboBoxIntereses.Name = "comboBoxIntereses";
            this.comboBoxIntereses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIntereses.TabIndex = 42;
            // 
            // labelInteresesPost
            // 
            this.labelInteresesPost.AutoSize = true;
            this.labelInteresesPost.Location = new System.Drawing.Point(12, 202);
            this.labelInteresesPost.Name = "labelInteresesPost";
            this.labelInteresesPost.Size = new System.Drawing.Size(79, 13);
            this.labelInteresesPost.TabIndex = 41;
            this.labelInteresesPost.Text = "Área de Interes";
            // 
            // labelTextoPost
            // 
            this.labelTextoPost.AutoSize = true;
            this.labelTextoPost.Location = new System.Drawing.Point(12, 83);
            this.labelTextoPost.Name = "labelTextoPost";
            this.labelTextoPost.Size = new System.Drawing.Size(77, 13);
            this.labelTextoPost.TabIndex = 40;
            this.labelTextoPost.Text = "Texto Del Post";
            // 
            // textBoxContPost
            // 
            this.textBoxContPost.Location = new System.Drawing.Point(15, 102);
            this.textBoxContPost.Multiline = true;
            this.textBoxContPost.Name = "textBoxContPost";
            this.textBoxContPost.Size = new System.Drawing.Size(253, 88);
            this.textBoxContPost.TabIndex = 39;
            // 
            // buttonVolver2
            // 
            this.buttonVolver2.Location = new System.Drawing.Point(14, 364);
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
            this.labelCrearPost.Location = new System.Drawing.Point(14, 15);
            this.labelCrearPost.Name = "labelCrearPost";
            this.labelCrearPost.Size = new System.Drawing.Size(254, 55);
            this.labelCrearPost.TabIndex = 33;
            this.labelCrearPost.Text = "Crear Post";
            // 
            // CrearPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 423);
            this.Controls.Add(this.panelCrearPost);
            this.Name = "CrearPost";
            this.Text = "Crear Post";
            this.panelCrearPost.ResumeLayout(false);
            this.panelCrearPost.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelCrearPost;
        private System.Windows.Forms.ComboBox comboBoxIntereses;
        private System.Windows.Forms.Label labelInteresesPost;
        private System.Windows.Forms.Label labelTextoPost;
        private System.Windows.Forms.TextBox textBoxContPost;
        private System.Windows.Forms.Button buttonVolver2;
        private System.Windows.Forms.Label labelCrearPost;
        private System.Windows.Forms.Button botonNuevaPublicacion;
    }
}
