
namespace design_CSLT2
{
    partial class _9
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
            this.cbMaTheMuonBC = new System.Windows.Forms.ComboBox();
            this.dataGridViewHSMtheoTM = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btndong = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHSMtheoTM)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMaTheMuonBC
            // 
            this.cbMaTheMuonBC.FormattingEnabled = true;
            this.cbMaTheMuonBC.Location = new System.Drawing.Point(270, 151);
            this.cbMaTheMuonBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaTheMuonBC.Name = "cbMaTheMuonBC";
            this.cbMaTheMuonBC.Size = new System.Drawing.Size(129, 24);
            this.cbMaTheMuonBC.TabIndex = 27;
            // 
            // dataGridViewHSMtheoTM
            // 
            this.dataGridViewHSMtheoTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHSMtheoTM.Location = new System.Drawing.Point(124, 231);
            this.dataGridViewHSMtheoTM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewHSMtheoTM.Name = "dataGridViewHSMtheoTM";
            this.dataGridViewHSMtheoTM.RowHeadersWidth = 62;
            this.dataGridViewHSMtheoTM.RowTemplate.Height = 28;
            this.dataGridViewHSMtheoTM.Size = new System.Drawing.Size(651, 208);
            this.dataGridViewHSMtheoTM.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Dongle", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 48);
            this.label2.TabIndex = 31;
            this.label2.Text = "Mã thẻ mượn";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndong.Location = new System.Drawing.Point(674, 139);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(101, 43);
            this.btndong.TabIndex = 38;
            this.btndong.Text = "In";
            this.btndong.UseVisualStyleBackColor = true;
            // 
            // btntimlai
            // 
            this.btntimlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btntimlai.Location = new System.Drawing.Point(548, 139);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(101, 43);
            this.btntimlai.TabIndex = 37;
            this.btntimlai.Text = "Tìm lại";
            this.btntimlai.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(423, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 43);
            this.button1.TabIndex = 36;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::design_CSLT2.Properties.Resources.báo_cáo_9;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 532);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMaTheMuonBC);
            this.Controls.Add(this.dataGridViewHSMtheoTM);
            this.DoubleBuffered = true;
            this.Name = "_9";
            this.Text = "Báo cáo danh sách hồ sơ mượn theo thẻ mượn ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHSMtheoTM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbMaTheMuonBC;
        private System.Windows.Forms.DataGridView dataGridViewHSMtheoTM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button button1;
    }
}