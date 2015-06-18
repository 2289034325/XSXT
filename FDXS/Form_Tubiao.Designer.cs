namespace FDXS
{
    partial class Form_Tubiao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmb_leixing = new System.Windows.Forms.ComboBox();
            this.btn_shuaxin = new System.Windows.Forms.Button();
            this.cht_meiri = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cht_xingqi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cht_xiaoshi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_meiri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xingqi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xiaoshi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmb_leixing);
            this.panel5.Controls.Add(this.btn_shuaxin);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(887, 32);
            this.panel5.TabIndex = 6;
            // 
            // cmb_leixing
            // 
            this.cmb_leixing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_leixing.FormattingEnabled = true;
            this.cmb_leixing.Items.AddRange(new object[] {
            "件数",
            "金额"});
            this.cmb_leixing.Location = new System.Drawing.Point(5, 5);
            this.cmb_leixing.Name = "cmb_leixing";
            this.cmb_leixing.Size = new System.Drawing.Size(121, 20);
            this.cmb_leixing.TabIndex = 7;
            // 
            // btn_shuaxin
            // 
            this.btn_shuaxin.Location = new System.Drawing.Point(132, 3);
            this.btn_shuaxin.Name = "btn_shuaxin";
            this.btn_shuaxin.Size = new System.Drawing.Size(75, 23);
            this.btn_shuaxin.TabIndex = 6;
            this.btn_shuaxin.Text = "刷新";
            this.btn_shuaxin.UseVisualStyleBackColor = true;
            this.btn_shuaxin.Click += new System.EventHandler(this.btn_shuaxin_Click);
            // 
            // cht_meiri
            // 
            chartArea10.Name = "ChartArea1";
            this.cht_meiri.ChartAreas.Add(chartArea10);
            this.cht_meiri.Dock = System.Windows.Forms.DockStyle.Top;
            legend10.Name = "Legend1";
            this.cht_meiri.Legends.Add(legend10);
            this.cht_meiri.Location = new System.Drawing.Point(0, 32);
            this.cht_meiri.Name = "cht_meiri";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.cht_meiri.Series.Add(series10);
            this.cht_meiri.Size = new System.Drawing.Size(887, 215);
            this.cht_meiri.TabIndex = 7;
            this.cht_meiri.Text = "chart1";
            // 
            // cht_xingqi
            // 
            chartArea11.Name = "ChartArea1";
            this.cht_xingqi.ChartAreas.Add(chartArea11);
            this.cht_xingqi.Dock = System.Windows.Forms.DockStyle.Left;
            legend11.Name = "Legend1";
            this.cht_xingqi.Legends.Add(legend11);
            this.cht_xingqi.Location = new System.Drawing.Point(0, 247);
            this.cht_xingqi.Name = "cht_xingqi";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.cht_xingqi.Series.Add(series11);
            this.cht_xingqi.Size = new System.Drawing.Size(305, 236);
            this.cht_xingqi.TabIndex = 8;
            this.cht_xingqi.Text = "chart2";
            // 
            // cht_xiaoshi
            // 
            chartArea12.Name = "ChartArea1";
            this.cht_xiaoshi.ChartAreas.Add(chartArea12);
            this.cht_xiaoshi.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.Name = "Legend1";
            this.cht_xiaoshi.Legends.Add(legend12);
            this.cht_xiaoshi.Location = new System.Drawing.Point(305, 247);
            this.cht_xiaoshi.Name = "cht_xiaoshi";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.cht_xiaoshi.Series.Add(series12);
            this.cht_xiaoshi.Size = new System.Drawing.Size(582, 236);
            this.cht_xiaoshi.TabIndex = 9;
            this.cht_xiaoshi.Text = "chart3";
            // 
            // Form_Tubiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 483);
            this.Controls.Add(this.cht_xiaoshi);
            this.Controls.Add(this.cht_xingqi);
            this.Controls.Add(this.cht_meiri);
            this.Controls.Add(this.panel5);
            this.Name = "Form_Tubiao";
            this.Text = "图表";
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_meiri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xingqi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xiaoshi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmb_leixing;
        private System.Windows.Forms.Button btn_shuaxin;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_meiri;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_xingqi;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_xiaoshi;

    }
}