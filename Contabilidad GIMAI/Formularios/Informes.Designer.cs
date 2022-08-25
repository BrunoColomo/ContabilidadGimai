namespace Contabilidad_GIMAI
{
    partial class Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MovimientosPorFecha = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ProcesandoLB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.InformeCMBX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DesdeMovsDP = new System.Windows.Forms.DateTimePicker();
            this.HastaMovsDP = new System.Windows.Forms.DateTimePicker();
            this.TipoCMBX = new System.Windows.Forms.ComboBox();
            this.GenerarBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.MovimientosPorFecha.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MovimientosPorFecha, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // MovimientosPorFecha
            // 
            this.MovimientosPorFecha.Controls.Add(this.tableLayoutPanel2);
            this.MovimientosPorFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MovimientosPorFecha.Location = new System.Drawing.Point(4, 5);
            this.MovimientosPorFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MovimientosPorFecha.Name = "MovimientosPorFecha";
            this.MovimientosPorFecha.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MovimientosPorFecha.Size = new System.Drawing.Size(513, 172);
            this.MovimientosPorFecha.TabIndex = 0;
            this.MovimientosPorFecha.TabStop = false;
            this.MovimientosPorFecha.Text = "Generar Informe";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.85714F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.96825F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.92857F));
            this.tableLayoutPanel2.Controls.Add(this.ProcesandoLB, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.InformeCMBX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.DesdeMovsDP, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.HastaMovsDP, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.TipoCMBX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.GenerarBTN, 3, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(505, 143);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // ProcesandoLB
            // 
            this.ProcesandoLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcesandoLB.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.ProcesandoLB, 3);
            this.ProcesandoLB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcesandoLB.Location = new System.Drawing.Point(4, 94);
            this.ProcesandoLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProcesandoLB.Name = "ProcesandoLB";
            this.ProcesandoLB.Size = new System.Drawing.Size(324, 49);
            this.ProcesandoLB.TabIndex = 22;
            this.ProcesandoLB.Text = "Procesando Informe...";
            this.ProcesandoLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProcesandoLB.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 47);
            this.label10.TabIndex = 7;
            this.label10.Text = "Informe:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InformeCMBX
            // 
            this.InformeCMBX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InformeCMBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InformeCMBX.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformeCMBX.FormattingEnabled = true;
            this.InformeCMBX.Items.AddRange(new object[] {
            "Compras",
            "Ventas",
            "Balance",
            "Contactos"});
            this.InformeCMBX.Location = new System.Drawing.Point(94, 11);
            this.InformeCMBX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InformeCMBX.Name = "InformeCMBX";
            this.InformeCMBX.Size = new System.Drawing.Size(138, 25);
            this.InformeCMBX.TabIndex = 6;
            this.InformeCMBX.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desde:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DesdeMovsDP
            // 
            this.DesdeMovsDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DesdeMovsDP.CustomFormat = "9999";
            this.DesdeMovsDP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesdeMovsDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DesdeMovsDP.Location = new System.Drawing.Point(336, 11);
            this.DesdeMovsDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DesdeMovsDP.Name = "DesdeMovsDP";
            this.DesdeMovsDP.Size = new System.Drawing.Size(165, 25);
            this.DesdeMovsDP.TabIndex = 4;
            this.DesdeMovsDP.Value = new System.DateTime(2022, 7, 1, 0, 0, 0, 0);
            this.DesdeMovsDP.ValueChanged += new System.EventHandler(this.DesdeMovsDP_ValueChanged);
            // 
            // HastaMovsDP
            // 
            this.HastaMovsDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HastaMovsDP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HastaMovsDP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.HastaMovsDP.Location = new System.Drawing.Point(336, 58);
            this.HastaMovsDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HastaMovsDP.Name = "HastaMovsDP";
            this.HastaMovsDP.Size = new System.Drawing.Size(165, 25);
            this.HastaMovsDP.TabIndex = 5;
            // 
            // TipoCMBX
            // 
            this.TipoCMBX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TipoCMBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoCMBX.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoCMBX.FormattingEnabled = true;
            this.TipoCMBX.Location = new System.Drawing.Point(94, 58);
            this.TipoCMBX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TipoCMBX.Name = "TipoCMBX";
            this.TipoCMBX.Size = new System.Drawing.Size(138, 25);
            this.TipoCMBX.TabIndex = 8;
            this.TipoCMBX.SelectedIndexChanged += new System.EventHandler(this.TipoCMBX_SelectedIndexChanged);
            // 
            // GenerarBTN
            // 
            this.GenerarBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenerarBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GenerarBTN.Location = new System.Drawing.Point(338, 102);
            this.GenerarBTN.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.GenerarBTN.Name = "GenerarBTN";
            this.GenerarBTN.Size = new System.Drawing.Size(161, 33);
            this.GenerarBTN.TabIndex = 21;
            this.GenerarBTN.Text = "Exportar";
            this.GenerarBTN.UseVisualStyleBackColor = true;
            this.GenerarBTN.Click += new System.EventHandler(this.GenerarBTN_Click);
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 212);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Informes";
            this.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contabilidad - Informes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Informes_Closed);
            this.Load += new System.EventHandler(this.Informes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MovimientosPorFecha.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox MovimientosPorFecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DesdeMovsDP;
        private System.Windows.Forms.DateTimePicker HastaMovsDP;
        private System.Windows.Forms.ComboBox InformeCMBX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TipoCMBX;
        private System.Windows.Forms.Button GenerarBTN;
        private System.Windows.Forms.Label ProcesandoLB;
    }
}