namespace UltimoAliento
{
    partial class ChatForm
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
            this.lstChats = new System.Windows.Forms.ListBox();
            this.rtbMensajes = new System.Windows.Forms.RichTextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBoxNuevoChat = new System.Windows.Forms.TextBox();
            this.btnCrearChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstChats
            // 
            this.lstChats.FormattingEnabled = true;
            this.lstChats.Location = new System.Drawing.Point(11, 67);
            this.lstChats.Name = "lstChats";
            this.lstChats.Size = new System.Drawing.Size(160, 277);
            this.lstChats.TabIndex = 0;
            this.lstChats.SelectedIndexChanged += new System.EventHandler(this.lstChats_SelectedIndexChanged);
            // 
            // rtbMensajes
            // 
            this.rtbMensajes.Location = new System.Drawing.Point(177, 40);
            this.rtbMensajes.Name = "rtbMensajes";
            this.rtbMensajes.ReadOnly = true;
            this.rtbMensajes.Size = new System.Drawing.Size(400, 276);
            this.rtbMensajes.TabIndex = 1;
            this.rtbMensajes.Text = "";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(237, 324);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(259, 20);
            this.txtMensaje.TabIndex = 2;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(502, 322);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Location = new System.Drawing.Point(177, 322);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(54, 23);
            this.btnAdjuntar.TabIndex = 4;
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(11, 40);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(78, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(95, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBoxNuevoChat
            // 
            this.txtBoxNuevoChat.Location = new System.Drawing.Point(177, 11);
            this.txtBoxNuevoChat.Name = "txtBoxNuevoChat";
            this.txtBoxNuevoChat.Size = new System.Drawing.Size(319, 20);
            this.txtBoxNuevoChat.TabIndex = 9;
            // 
            // btnCrearChat
            // 
            this.btnCrearChat.Location = new System.Drawing.Point(502, 8);
            this.btnCrearChat.Name = "btnCrearChat";
            this.btnCrearChat.Size = new System.Drawing.Size(75, 23);
            this.btnCrearChat.TabIndex = 10;
            this.btnCrearChat.Text = "Crear Chat";
            this.btnCrearChat.UseVisualStyleBackColor = true;
            this.btnCrearChat.Click += new System.EventHandler(this.btnCrearChat_Click_1);
            // 
            // ChatForm
            // 
            this.ClientSize = new System.Drawing.Size(598, 357);
            this.Controls.Add(this.btnCrearChat);
            this.Controls.Add(this.txtBoxNuevoChat);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.rtbMensajes);
            this.Controls.Add(this.lstChats);
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lstChats;
        private System.Windows.Forms.RichTextBox rtbMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBoxNuevoChat;
        private System.Windows.Forms.Button btnCrearChat;
    }
}
