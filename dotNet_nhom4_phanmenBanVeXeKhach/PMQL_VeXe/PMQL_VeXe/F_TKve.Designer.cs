namespace PMQL_VeXe
{
    partial class F_TKve
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tab_ThongKe = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartVe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartVeMuaNhieu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TLP_Main.SuspendLayout();
            this.tab_ThongKe.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVe)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVeMuaNhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Controls.Add(this.tab_ThongKe, 0, 1);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Margin = new System.Windows.Forms.Padding(2);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 3;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.174905F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.8251F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_Main.Size = new System.Drawing.Size(829, 526);
            this.TLP_Main.TabIndex = 0;
            // 
            // tab_ThongKe
            // 
            this.tab_ThongKe.Controls.Add(this.tabPage3);
            this.tab_ThongKe.Controls.Add(this.tabPage2);
            this.tab_ThongKe.Location = new System.Drawing.Point(3, 42);
            this.tab_ThongKe.Name = "tab_ThongKe";
            this.tab_ThongKe.SelectedIndex = 0;
            this.tab_ThongKe.Size = new System.Drawing.Size(823, 438);
            this.tab_ThongKe.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartVe);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(815, 412);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Thống Kê Theo Ngày";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartVe
            // 
            chartArea3.Name = "ChartArea1";
            this.chartVe.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartVe.Legends.Add(legend3);
            this.chartVe.Location = new System.Drawing.Point(6, 6);
            this.chartVe.Name = "chartVe";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartVe.Series.Add(series3);
            this.chartVe.Size = new System.Drawing.Size(803, 400);
            this.chartVe.TabIndex = 0;
            this.chartVe.Text = "chart2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartVeMuaNhieu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(815, 412);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Thống kê vé mua nhiều nhất";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartVeMuaNhieu
            // 
            chartArea4.Name = "ChartArea1";
            this.chartVeMuaNhieu.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartVeMuaNhieu.Legends.Add(legend4);
            this.chartVeMuaNhieu.Location = new System.Drawing.Point(6, 6);
            this.chartVeMuaNhieu.Name = "chartVeMuaNhieu";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartVeMuaNhieu.Series.Add(series4);
            this.chartVeMuaNhieu.Size = new System.Drawing.Size(803, 400);
            this.chartVeMuaNhieu.TabIndex = 1;
            this.chartVeMuaNhieu.Text = "chart2";
            // 
            // F_TKve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 526);
            this.Controls.Add(this.TLP_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F_TKve";
            this.Text = "F_TKve";
            this.Load += new System.EventHandler(this.F_TKve_Load);
            this.TLP_Main.ResumeLayout(false);
            this.tab_ThongKe.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVe)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVeMuaNhieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.TabControl tab_ThongKe;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVe;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVeMuaNhieu;
    }
}