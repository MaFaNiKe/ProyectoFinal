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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.flowLayoutPanelPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.perfilMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificacionesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPosts
            // 
            this.flowLayoutPanelPosts.AutoScroll = true;
            this.flowLayoutPanelPosts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanelPosts.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanelPosts.Name = "flowLayoutPanelPosts";
            this.flowLayoutPanelPosts.Size = new System.Drawing.Size(526, 392);
            this.flowLayoutPanelPosts.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilMenuItem,
            this.mensajesMenuItem,
            this.notificacionesMenuItem,
            this.configuracionMenuItem,
            this.crearPostToolStripMenuItem,
            this.cerrarSesionMenuItem,
            this.actualizarToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip.Size = new System.Drawing.Size(31, 422);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // perfilMenuItem
            // 
            this.perfilMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perfilMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("perfilMenuItem.Image")));
            this.perfilMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.perfilMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.perfilMenuItem.Name = "perfilMenuItem";
            this.perfilMenuItem.Size = new System.Drawing.Size(24, 20);
            this.perfilMenuItem.Click += new System.EventHandler(this.perfilMenuItem_Click);
            // 
            // mensajesMenuItem
            // 
            this.mensajesMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mensajesMenuItem.Image")));
            this.mensajesMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mensajesMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mensajesMenuItem.Name = "mensajesMenuItem";
            this.mensajesMenuItem.Size = new System.Drawing.Size(24, 20);
            this.mensajesMenuItem.Click += new System.EventHandler(this.mensajesMenuItem_Click);
            // 
            // notificacionesMenuItem
            // 
            this.notificacionesMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("notificacionesMenuItem.Image")));
            this.notificacionesMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notificacionesMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.notificacionesMenuItem.Name = "notificacionesMenuItem";
            this.notificacionesMenuItem.Size = new System.Drawing.Size(24, 20);
            this.notificacionesMenuItem.Click += new System.EventHandler(this.BotonNotificaciones_Click);
            // 
            // configuracionMenuItem
            // 
            this.configuracionMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuracionMenuItem.Image")));
            this.configuracionMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.configuracionMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.configuracionMenuItem.Name = "configuracionMenuItem";
            this.configuracionMenuItem.Size = new System.Drawing.Size(24, 20);
            this.configuracionMenuItem.Click += new System.EventHandler(this.BotonConfiguracion_Click);
            // 
            // crearPostToolStripMenuItem
            // 
            this.crearPostToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("crearPostToolStripMenuItem.Image")));
            this.crearPostToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.crearPostToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.crearPostToolStripMenuItem.Name = "crearPostToolStripMenuItem";
            this.crearPostToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.crearPostToolStripMenuItem.Click += new System.EventHandler(this.crearPostToolStripMenuItem_Click);
            // 
            // cerrarSesionMenuItem
            // 
            this.cerrarSesionMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesionMenuItem.Image")));
            this.cerrarSesionMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cerrarSesionMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.cerrarSesionMenuItem.Name = "cerrarSesionMenuItem";
            this.cerrarSesionMenuItem.Size = new System.Drawing.Size(24, 20);
            this.cerrarSesionMenuItem.Click += new System.EventHandler(this.BotonCerrarSesion_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("actualizarToolStripMenuItem.Image")));
            this.actualizarToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.actualizarToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelPosts);
            this.panel1.Location = new System.Drawing.Point(132, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 401);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel2.Location = new System.Drawing.Point(667, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 401);
            this.panel2.TabIndex = 5;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(230, 401);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(909, 422);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PantallaPrincipal";
            this.Text = "Feed";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}
