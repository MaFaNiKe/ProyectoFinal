namespace UltimoAliento
{
    partial class NotificacionesForm
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
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxNotificaciones = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxNotificaciones
            // 
            this.listBoxNotificaciones.FormattingEnabled = true;
            this.listBoxNotificaciones.Location = new System.Drawing.Point(12, 12);
            this.listBoxNotificaciones.Name = "listBoxNotificaciones";
            this.listBoxNotificaciones.Size = new System.Drawing.Size(360, 420);
            this.listBoxNotificaciones.TabIndex = 0;
            // 
            // NotificacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.listBoxNotificaciones);
            this.Name = "NotificacionesForm";
            this.Text = "Notificaciones";
            this.Load += new System.EventHandler(this.NotificacionesForm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNotificaciones;
    }
}
