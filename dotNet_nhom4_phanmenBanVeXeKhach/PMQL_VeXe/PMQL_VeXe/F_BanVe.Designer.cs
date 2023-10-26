namespace PMQL_VeXe
{
    partial class F_BanVe
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
            this.tLPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlPTop = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_BVXe = new System.Windows.Forms.DataGridView();
            this.tLPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BVXe)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanelMain
            // 
            this.tLPanelMain.ColumnCount = 1;
            this.tLPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanelMain.Controls.Add(this.tlPTop, 0, 0);
            this.tLPanelMain.Controls.Add(this.DGV_BVXe, 0, 1);
            this.tLPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tLPanelMain.Name = "tLPanelMain";
            this.tLPanelMain.RowCount = 2;
            this.tLPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.17647F));
            this.tLPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.82353F));
            this.tLPanelMain.Size = new System.Drawing.Size(1202, 459);
            this.tLPanelMain.TabIndex = 0;
            // 
            // tlPTop
            // 
            this.tlPTop.ColumnCount = 2;
            this.tlPTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPTop.Location = new System.Drawing.Point(3, 3);
            this.tlPTop.Name = "tlPTop";
            this.tlPTop.RowCount = 2;
            this.tlPTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPTop.Size = new System.Drawing.Size(1196, 183);
            this.tlPTop.TabIndex = 0;
            // 
            // DGV_BVXe
            // 
            this.DGV_BVXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BVXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_BVXe.Location = new System.Drawing.Point(3, 192);
            this.DGV_BVXe.Name = "DGV_BVXe";
            this.DGV_BVXe.Size = new System.Drawing.Size(1196, 264);
            this.DGV_BVXe.TabIndex = 1;
            // 
            // F_BanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 459);
            this.Controls.Add(this.tLPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_BanVe";
            this.Text = "F_BanVe";
            this.tLPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BVXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanelMain;
        private System.Windows.Forms.TableLayoutPanel tlPTop;
        private System.Windows.Forms.DataGridView DGV_BVXe;
    }
}