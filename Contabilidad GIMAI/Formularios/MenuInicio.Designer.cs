namespace Contabilidad_GIMAI
{
    partial class MenuInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuInicio));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SalirBTN = new System.Windows.Forms.Button();
            this.ContabilidadTN = new System.Windows.Forms.Button();
            this.VentasBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SalirBTN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ContabilidadTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.VentasBTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.01923F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.98077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 328);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SalirBTN
            // 
            this.SalirBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SalirBTN.AutoSize = true;
            this.SalirBTN.BackColor = System.Drawing.SystemColors.Control;
            this.SalirBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.SalirBTN, 2);
            this.SalirBTN.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalirBTN.Location = new System.Drawing.Point(157, 240);
            this.SalirBTN.Margin = new System.Windows.Forms.Padding(20);
            this.SalirBTN.Name = "SalirBTN";
            this.SalirBTN.Padding = new System.Windows.Forms.Padding(10);
            this.SalirBTN.Size = new System.Drawing.Size(233, 68);
            this.SalirBTN.TabIndex = 2;
            this.SalirBTN.Text = "Salir";
            this.SalirBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.SalirBTN.UseVisualStyleBackColor = false;
            this.SalirBTN.Click += new System.EventHandler(this.SalirBTN_Click);
            // 
            // ContabilidadTN
            // 
            this.ContabilidadTN.BackColor = System.Drawing.SystemColors.Control;
            this.ContabilidadTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContabilidadTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContabilidadTN.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContabilidadTN.Location = new System.Drawing.Point(293, 101);
            this.ContabilidadTN.Margin = new System.Windows.Forms.Padding(20);
            this.ContabilidadTN.Name = "ContabilidadTN";
            this.ContabilidadTN.Padding = new System.Windows.Forms.Padding(10);
            this.ContabilidadTN.Size = new System.Drawing.Size(234, 99);
            this.ContabilidadTN.TabIndex = 1;
            this.ContabilidadTN.Text = "Contabilidad";
            this.ContabilidadTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ContabilidadTN.UseVisualStyleBackColor = false;
            this.ContabilidadTN.Click += new System.EventHandler(this.ContabilidadBTN_Click);
            // 
            // VentasBTN
            // 
            this.VentasBTN.BackColor = System.Drawing.SystemColors.Control;
            this.VentasBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.VentasBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VentasBTN.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VentasBTN.Location = new System.Drawing.Point(20, 101);
            this.VentasBTN.Margin = new System.Windows.Forms.Padding(20);
            this.VentasBTN.Name = "VentasBTN";
            this.VentasBTN.Padding = new System.Windows.Forms.Padding(10);
            this.VentasBTN.Size = new System.Drawing.Size(233, 99);
            this.VentasBTN.TabIndex = 0;
            this.VentasBTN.Text = "Ventas";
            this.VentasBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.VentasBTN.UseVisualStyleBackColor = false;
            this.VentasBTN.Click += new System.EventHandler(this.VentasBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 81);
            this.label1.TabIndex = 3;
            this.label1.Text = "SGLA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 328);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión La Amistad";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button VentasBTN;
        private System.Windows.Forms.Button SalirBTN;
        private System.Windows.Forms.Button ContabilidadTN;
        private System.Windows.Forms.Label label1;
    }
}