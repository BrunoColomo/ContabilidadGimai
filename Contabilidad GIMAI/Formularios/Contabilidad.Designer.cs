namespace Contabilidad_GIMAI

{
    partial class Contabilidad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contabilidad));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BuscarContactoBTN = new System.Windows.Forms.Button();
            this.ParametrosBTN = new System.Windows.Forms.Button();
            this.InformesBTN = new System.Windows.Forms.Button();
            this.ExportarMovBTN = new System.Windows.Forms.Button();
            this.AbrirMovBTN = new System.Windows.Forms.Button();
            this.TituloLB = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TituloLB, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.08547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.91453F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 498);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BuscarContactoBTN, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ParametrosBTN, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.InformesBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ExportarMovBTN, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.AbrirMovBTN, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 440);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BuscarContactoBTN
            // 
            this.BuscarContactoBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BuscarContactoBTN.BackColor = System.Drawing.SystemColors.Control;
            this.BuscarContactoBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BuscarContactoBTN.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarContactoBTN.Location = new System.Drawing.Point(50, 20);
            this.BuscarContactoBTN.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.BuscarContactoBTN.Name = "BuscarContactoBTN";
            this.BuscarContactoBTN.Padding = new System.Windows.Forms.Padding(5);
            this.BuscarContactoBTN.Size = new System.Drawing.Size(244, 43);
            this.BuscarContactoBTN.TabIndex = 1;
            this.BuscarContactoBTN.Text = "Buscar Contacto";
            this.BuscarContactoBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BuscarContactoBTN.UseVisualStyleBackColor = false;
            this.BuscarContactoBTN.Click += new System.EventHandler(this.BuscarContactoBTN_Click);
            // 
            // ParametrosBTN
            // 
            this.ParametrosBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ParametrosBTN.BackColor = System.Drawing.SystemColors.Control;
            this.ParametrosBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ParametrosBTN.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametrosBTN.Location = new System.Drawing.Point(50, 374);
            this.ParametrosBTN.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.ParametrosBTN.Name = "ParametrosBTN";
            this.ParametrosBTN.Padding = new System.Windows.Forms.Padding(5);
            this.ParametrosBTN.Size = new System.Drawing.Size(244, 43);
            this.ParametrosBTN.TabIndex = 5;
            this.ParametrosBTN.Text = "Parametros";
            this.ParametrosBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ParametrosBTN.UseVisualStyleBackColor = false;
            this.ParametrosBTN.Click += new System.EventHandler(this.ParametrosBTN_Click);
            // 
            // InformesBTN
            // 
            this.InformesBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InformesBTN.BackColor = System.Drawing.SystemColors.Control;
            this.InformesBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InformesBTN.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformesBTN.Location = new System.Drawing.Point(50, 103);
            this.InformesBTN.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.InformesBTN.Name = "InformesBTN";
            this.InformesBTN.Padding = new System.Windows.Forms.Padding(5);
            this.InformesBTN.Size = new System.Drawing.Size(244, 43);
            this.InformesBTN.TabIndex = 2;
            this.InformesBTN.Text = "Informes";
            this.InformesBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.InformesBTN.UseVisualStyleBackColor = false;
            this.InformesBTN.Click += new System.EventHandler(this.InformesBTN_Click);
            // 
            // ExportarMovBTN
            // 
            this.ExportarMovBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExportarMovBTN.BackColor = System.Drawing.SystemColors.Control;
            this.ExportarMovBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExportarMovBTN.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportarMovBTN.Location = new System.Drawing.Point(50, 291);
            this.ExportarMovBTN.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.ExportarMovBTN.Name = "ExportarMovBTN";
            this.ExportarMovBTN.Padding = new System.Windows.Forms.Padding(5);
            this.ExportarMovBTN.Size = new System.Drawing.Size(244, 43);
            this.ExportarMovBTN.TabIndex = 4;
            this.ExportarMovBTN.Text = "Exportar Movimientos";
            this.ExportarMovBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ExportarMovBTN.UseVisualStyleBackColor = false;
            this.ExportarMovBTN.Click += new System.EventHandler(this.ExportarMovBTN_Click);
            // 
            // AbrirMovBTN
            // 
            this.AbrirMovBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AbrirMovBTN.BackColor = System.Drawing.SystemColors.Control;
            this.AbrirMovBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AbrirMovBTN.Font = new System.Drawing.Font("Calibri Light", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbrirMovBTN.Location = new System.Drawing.Point(50, 208);
            this.AbrirMovBTN.Margin = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.AbrirMovBTN.Name = "AbrirMovBTN";
            this.AbrirMovBTN.Padding = new System.Windows.Forms.Padding(5);
            this.AbrirMovBTN.Size = new System.Drawing.Size(244, 43);
            this.AbrirMovBTN.TabIndex = 3;
            this.AbrirMovBTN.Text = "Abrir Movimientos";
            this.AbrirMovBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.AbrirMovBTN.UseVisualStyleBackColor = false;
            this.AbrirMovBTN.Click += new System.EventHandler(this.AbrirMovBTN_Click);
            // 
            // TituloLB
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TituloLB, 2);
            this.TituloLB.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloLB.Location = new System.Drawing.Point(3, 0);
            this.TituloLB.Name = "TituloLB";
            this.TituloLB.Size = new System.Drawing.Size(344, 50);
            this.TituloLB.TabIndex = 1;
            this.TituloLB.Text = "Contabilidad";
            this.TituloLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Contabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 498);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contabilidad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contabilidad_Closed);
            this.Load += new System.EventHandler(this.Contabilidad_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ExportarMovBTN;
        private System.Windows.Forms.Button AbrirMovBTN;
        private System.Windows.Forms.Button InformesBTN;
        private System.Windows.Forms.Button ParametrosBTN;
        private System.Windows.Forms.Label TituloLB;
        private System.Windows.Forms.Button BuscarContactoBTN;
    }
}