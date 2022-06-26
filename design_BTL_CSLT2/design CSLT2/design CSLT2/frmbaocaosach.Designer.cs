
namespace design_CSLT2
{
    partial class frmbaocaosach
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtthang = new System.Windows.Forms.TextBox();
            this.txtnam = new System.Windows.Forms.TextBox();
            this.dataGridViewbcsach = new System.Windows.Forms.DataGridView();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnthoát = new System.Windows.Forms.Button();
            this.btninbaocao = new System.Windows.Forms.Button();
            this.btnbaocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbcsach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Dongle", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Dongle", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // txtthang
            // 
            this.txtthang.Location = new System.Drawing.Point(190, 129);
            this.txtthang.Name = "txtthang";
            this.txtthang.Size = new System.Drawing.Size(378, 22);
            this.txtthang.TabIndex = 2;
            // 
            // txtnam
            // 
            this.txtnam.Location = new System.Drawing.Point(190, 164);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(378, 22);
            this.txtnam.TabIndex = 3;
            // 
            // dataGridViewbcsach
            // 
            this.dataGridViewbcsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewbcsach.Location = new System.Drawing.Point(118, 200);
            this.dataGridViewbcsach.Name = "dataGridViewbcsach";
            this.dataGridViewbcsach.RowHeadersWidth = 51;
            this.dataGridViewbcsach.RowTemplate.Height = 24;
            this.dataGridViewbcsach.Size = new System.Drawing.Size(450, 145);
            this.dataGridViewbcsach.TabIndex = 4;
            // 
            // btnboqua
            // 
            this.btnboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnboqua.Location = new System.Drawing.Point(586, 303);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(100, 42);
            this.btnboqua.TabIndex = 40;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            // 
            // btnthoát
            // 
            this.btnthoát.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthoát.Location = new System.Drawing.Point(586, 247);
            this.btnthoát.Name = "btnthoát";
            this.btnthoát.Size = new System.Drawing.Size(100, 42);
            this.btnthoát.TabIndex = 39;
            this.btnthoát.Text = "Thoát";
            this.btnthoát.UseVisualStyleBackColor = true;
            // 
            // btninbaocao
            // 
            this.btninbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btninbaocao.Location = new System.Drawing.Point(586, 188);
            this.btninbaocao.Name = "btninbaocao";
            this.btninbaocao.Size = new System.Drawing.Size(100, 42);
            this.btninbaocao.TabIndex = 38;
            this.btninbaocao.Text = "In báo cáo";
            this.btninbaocao.UseVisualStyleBackColor = true;
            // 
            // btnbaocao
            // 
            this.btnbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnbaocao.Location = new System.Drawing.Point(586, 129);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(100, 42);
            this.btnbaocao.TabIndex = 37;
            this.btnbaocao.Text = "Báo cáo";
            this.btnbaocao.UseVisualStyleBackColor = true;
            // 
            // frmbaocaosach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::design_CSLT2.Properties.Resources.báo_cáo_sáhc_chưa_trả;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btnthoát);
            this.Controls.Add(this.btninbaocao);
            this.Controls.Add(this.btnbaocao);
            this.Controls.Add(this.dataGridViewbcsach);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.txtthang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmbaocaosach";
            this.Text = "Báo cáo sách chưa trả";
            this.Load += new System.EventHandler(this.frmbaocaosach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbcsach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtthang;
        private System.Windows.Forms.TextBox txtnam;
        private System.Windows.Forms.DataGridView dataGridViewbcsach;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnthoát;
        private System.Windows.Forms.Button btninbaocao;
        private System.Windows.Forms.Button btnbaocao;
    }
}

