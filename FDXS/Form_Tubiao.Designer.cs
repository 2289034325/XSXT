using MyFormControls;
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cht_xiaoshi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cht_xingqi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cht_meiri = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmb_leixing = new MyFormControls.MyComboBox();
            this.btn_shuaxin = new MyFormControls.MyButton();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xiaoshi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xingqi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_meiri)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cht_xiaoshi
            // 
            chartArea1.Name = "ChartArea1";
            this.cht_xiaoshi.ChartAreas.Add(chartArea1);
            this.cht_xiaoshi.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.cht_xiaoshi.Legends.Add(legend1);
            this.cht_xiaoshi.Location = new System.Drawing.Point(380, 245);
            this.cht_xiaoshi.Name = "cht_xiaoshi";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht_xiaoshi.Series.Add(series1);
            this.cht_xiaoshi.Size = new System.Drawing.Size(507, 238);
            this.cht_xiaoshi.TabIndex = 9;
            this.cht_xiaoshi.Text = "chart3";
            // 
            // cht_xingqi
            // 
            chartArea2.Name = "ChartArea1";
            this.cht_xingqi.ChartAreas.Add(chartArea2);
            this.cht_xingqi.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.Name = "Legend1";
            this.cht_xingqi.Legends.Add(legend2);
            this.cht_xingqi.Location = new System.Drawing.Point(0, 245);
            this.cht_xingqi.Name = "cht_xingqi";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.cht_xingqi.Series.Add(series2);
            this.cht_xingqi.Size = new System.Drawing.Size(380, 238);
            this.cht_xingqi.TabIndex = 8;
            this.cht_xingqi.Text = "chart2";
            // 
            // cht_meiri
            // 
            this.cht_meiri.BackImageTransparentColor = System.Drawing.Color.White;
            this.cht_meiri.BackSecondaryColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.cht_meiri.ChartAreas.Add(chartArea3);
            this.cht_meiri.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.cht_meiri.Legends.Add(legend3);
            this.cht_meiri.Location = new System.Drawing.Point(0, 30);
            this.cht_meiri.Name = "cht_meiri";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.cht_meiri.Series.Add(series3);
            this.cht_meiri.Size = new System.Drawing.Size(887, 215);
            this.cht_meiri.TabIndex = 7;
            this.cht_meiri.Text = "chart1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmb_leixing);
            this.flowLayoutPanel1.Controls.Add(this.btn_shuaxin);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(887, 30);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // cmb_leixing
            // 
            this.cmb_leixing.BackColor = System.Drawing.Color.Black;
            this.cmb_leixing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_leixing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_leixing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_leixing.ForeColor = System.Drawing.Color.White;
            this.cmb_leixing.FormattingEnabled = true;
            this.cmb_leixing.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_leixing.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_leixing.Items.AddRange(new object[] {
            "件数",
            "金额"});
            this.cmb_leixing.Location = new System.Drawing.Point(3, 3);
            this.cmb_leixing.Name = "cmb_leixing";
            this.cmb_leixing.Size = new System.Drawing.Size(100, 27);
            this.cmb_leixing.TabIndex = 7;
            this.cmb_leixing.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_shuaxin
            // 
            this.btn_shuaxin.BackColor = System.Drawing.Color.Black;
            this.btn_shuaxin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_shuaxin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_shuaxin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shuaxin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_shuaxin.ForeColor = System.Drawing.Color.White;
            this.btn_shuaxin.Location = new System.Drawing.Point(109, 3);
            this.btn_shuaxin.Name = "btn_shuaxin";
            this.btn_shuaxin.Size = new System.Drawing.Size(100, 26);
            this.btn_shuaxin.TabIndex = 6;
            this.btn_shuaxin.Text = "刷新";
            this.btn_shuaxin.Type = MyFormControls.MyControlType.Standard;
            this.btn_shuaxin.UseVisualStyleBackColor = true;
            this.btn_shuaxin.Click += new System.EventHandler(this.btn_shuaxin_Click);
            // 
            // Form_Tubiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 483);
            this.Controls.Add(this.cht_xiaoshi);
            this.Controls.Add(this.cht_xingqi);
            this.Controls.Add(this.cht_meiri);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Tubiao";
            this.Text = "图表";
            ((System.ComponentModel.ISupportInitialize)(this.cht_xiaoshi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_xingqi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_meiri)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyComboBox cmb_leixing;
        private MyButton btn_shuaxin;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_meiri;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_xingqi;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_xiaoshi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}