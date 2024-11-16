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
            this.rtbMensajes = new System.Windows.Forms.RichTextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dtgChats = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.CargarChat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChats)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMensajes
            // 
            this.rtbMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMensajes.Location = new System.Drawing.Point(182, 3);
            this.rtbMensajes.Name = "rtbMensajes";
            this.rtbMensajes.ReadOnly = true;
            this.rtbMensajes.Size = new System.Drawing.Size(413, 243);
            this.rtbMensajes.TabIndex = 1;
            this.rtbMensajes.Text = "";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMensaje.Location = new System.Drawing.Point(182, 252);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(413, 20);
            this.txtMensaje.TabIndex = 2;
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdjuntar.Location = new System.Drawing.Point(3, 252);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(173, 29);
            this.btnAdjuntar.TabIndex = 3;
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*";
            // 
            // dtgChats
            // 
            this.dtgChats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChats.Location = new System.Drawing.Point(3, 3);
            this.dtgChats.Name = "dtgChats";
            this.dtgChats.ReadOnly = true;
            this.dtgChats.Size = new System.Drawing.Size(173, 243);
            this.dtgChats.TabIndex = 0;
            this.dtgChats.SelectionChanged += new System.EventHandler(this.dtgChats_SelectionChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVolver.Location = new System.Drawing.Point(3, 322);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(173, 32);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnviar.Location = new System.Drawing.Point(182, 287);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(413, 29);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click_1);
            // 
            // CargarChat
            // 
            this.CargarChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CargarChat.Location = new System.Drawing.Point(3, 287);
            this.CargarChat.Name = "CargarChat";
            this.CargarChat.Size = new System.Drawing.Size(173, 29);
            this.CargarChat.TabIndex = 6;
            this.CargarChat.Text = "Cargar Chat";
            this.CargarChat.UseVisualStyleBackColor = true;
            this.CargarChat.Click += new System.EventHandler(this.CargarChat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.dtgChats, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbMensajes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMensaje, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEnviar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAdjuntar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CargarChat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnVolver, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ChatForm
            // 
            this.ClientSize = new System.Drawing.Size(598, 357);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatForm";
            this.Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)(this.dtgChats)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.RichTextBox rtbMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dtgChats;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button CargarChat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        
    }
}
