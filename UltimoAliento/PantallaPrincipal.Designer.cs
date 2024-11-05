namespace UltimoAliento
{
    partial class PantallaPrincipal
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
            this.flowLayoutPanelPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.perfilMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificacionesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPosts
            // 
            this.flowLayoutPanelPosts.AutoScroll = true;
            this.flowLayoutPanelPosts.Location = new System.Drawing.Point(12, 3);
            this.flowLayoutPanelPosts.Name = "flowLayoutPanelPosts";
            this.flowLayoutPanelPosts.Size = new System.Drawing.Size(540, 305);
            this.flowLayoutPanelPosts.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilMenuItem,
            this.mensajesMenuItem,
            this.notificacionesMenuItem,
            this.configuracionMenuItem,
            this.crearPostToolStripMenuItem,
            this.cerrarSesionMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // perfilMenuItem
            // 
            this.perfilMenuItem.Name = "perfilMenuItem";
            this.perfilMenuItem.Size = new System.Drawing.Size(46, 20);
            this.perfilMenuItem.Text = "Perfil";
            this.perfilMenuItem.Click += new System.EventHandler(this.perfilMenuItem_Click_1);
            // 
            // mensajesMenuItem
            // 
            this.mensajesMenuItem.Name = "mensajesMenuItem";
            this.mensajesMenuItem.Size = new System.Drawing.Size(68, 20);
            this.mensajesMenuItem.Text = "Mensajes";
            this.mensajesMenuItem.Click += new System.EventHandler(this.mensajesMenuItem_Click);
            // 
            // notificacionesMenuItem
            // 
            this.notificacionesMenuItem.Name = "notificacionesMenuItem";
            this.notificacionesMenuItem.Size = new System.Drawing.Size(95, 20);
            this.notificacionesMenuItem.Text = "Notificaciones";
            this.notificacionesMenuItem.Click += new System.EventHandler(this.BotonNotificaciones_Click);
            // 
            // configuracionMenuItem
            // 
            this.configuracionMenuItem.Name = "configuracionMenuItem";
            this.configuracionMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionMenuItem.Text = "Configuración";
            this.configuracionMenuItem.Click += new System.EventHandler(this.BotonConfiguracion_Click);
            // 
            // cerrarSesionMenuItem
            // 
            this.cerrarSesionMenuItem.Name = "cerrarSesionMenuItem";
            this.cerrarSesionMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesionMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesionMenuItem.Click += new System.EventHandler(this.BotonCerrarSesion_Click);
            // 
            // crearPostToolStripMenuItem
            // 
            this.crearPostToolStripMenuItem.Name = "crearPostToolStripMenuItem";
            this.crearPostToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.crearPostToolStripMenuItem.Text = "Crear Post";
            this.crearPostToolStripMenuItem.Click += new System.EventHandler(this.crearPostToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelPosts);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 311);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(573, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 337);
            this.panel2.TabIndex = 5;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PantallaPrincipal";
            this.Text = "Feed";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPosts;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem perfilMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensajesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificacionesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem crearPostToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
    }
}
