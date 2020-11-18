namespace Haccp_MES._1_information
{
    partial class info_4_2_inputBOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridSelectBOM = new System.Windows.Forms.DataGridView();
            this.index1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bom_parent_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bom_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bom_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbProNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMatNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBomCount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSelectBOM
            // 
            this.gridSelectBOM.AllowUserToAddRows = false;
            this.gridSelectBOM.AllowUserToDeleteRows = false;
            this.gridSelectBOM.AllowUserToResizeColumns = false;
            this.gridSelectBOM.AllowUserToResizeRows = false;
            this.gridSelectBOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSelectBOM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSelectBOM.BackgroundColor = System.Drawing.Color.Silver;
            this.gridSelectBOM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSelectBOM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSelectBOM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSelectBOM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridSelectBOM.ColumnHeadersHeight = 29;
            this.gridSelectBOM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index1,
            this.bom_parent_no,
            this.bom_no,
            this.bom_count});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSelectBOM.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridSelectBOM.EnableHeadersVisualStyles = false;
            this.gridSelectBOM.Location = new System.Drawing.Point(39, 158);
            this.gridSelectBOM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridSelectBOM.MultiSelect = false;
            this.gridSelectBOM.Name = "gridSelectBOM";
            this.gridSelectBOM.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSelectBOM.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridSelectBOM.RowHeadersVisible = false;
            this.gridSelectBOM.RowHeadersWidth = 51;
            this.gridSelectBOM.RowTemplate.Height = 23;
            this.gridSelectBOM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSelectBOM.Size = new System.Drawing.Size(903, 171);
            this.gridSelectBOM.TabIndex = 110;
            // 
            // index1
            // 
            this.index1.HeaderText = "";
            this.index1.MinimumWidth = 6;
            this.index1.Name = "index1";
            // 
            // bom_parent_no
            // 
            this.bom_parent_no.DataPropertyName = "bom_parent_no";
            this.bom_parent_no.HeaderText = "bom코드";
            this.bom_parent_no.MinimumWidth = 6;
            this.bom_parent_no.Name = "bom_parent_no";
            this.bom_parent_no.ReadOnly = true;
            // 
            // bom_no
            // 
            this.bom_no.DataPropertyName = "bom_no";
            this.bom_no.HeaderText = "재료코드";
            this.bom_no.MinimumWidth = 6;
            this.bom_no.Name = "bom_no";
            this.bom_no.ReadOnly = true;
            // 
            // bom_count
            // 
            this.bom_count.DataPropertyName = "bom_count";
            this.bom_count.HeaderText = "수량";
            this.bom_count.MinimumWidth = 6;
            this.bom_count.Name = "bom_count";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(690, 337);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 40);
            this.btnUpdate.TabIndex = 107;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Haccp_MES.Properties.Resources.aperture_3x;
            this.pictureBox2.Location = new System.Drawing.Point(39, 46);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 106;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(73, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 105;
            this.label1.Text = "BOM등록";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(862, 337);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 104;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(776, 337);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbProNo
            // 
            this.cbProNo.FormattingEnabled = true;
            this.cbProNo.Location = new System.Drawing.Point(176, 112);
            this.cbProNo.Name = "cbProNo";
            this.cbProNo.Size = new System.Drawing.Size(121, 23);
            this.cbProNo.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 113;
            this.label2.Text = "bom코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 114;
            this.label3.Text = "재료코드";
            // 
            // cbMatNo
            // 
            this.cbMatNo.FormattingEnabled = true;
            this.cbMatNo.Location = new System.Drawing.Point(412, 112);
            this.cbMatNo.Name = "cbMatNo";
            this.cbMatNo.Size = new System.Drawing.Size(121, 23);
            this.cbMatNo.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(561, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 116;
            this.label4.Text = "수량";
            // 
            // txtBomCount
            // 
            this.txtBomCount.Location = new System.Drawing.Point(621, 111);
            this.txtBomCount.Name = "txtBomCount";
            this.txtBomCount.Size = new System.Drawing.Size(112, 25);
            this.txtBomCount.TabIndex = 117;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(842, 101);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 118;
            this.btnAdd.Text = "신규 등록";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // info_4_2_inputBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 400);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBomCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMatNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbProNo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridSelectBOM);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "info_4_2_inputBOM";
            this.Text = "info_4_2_inputBOM";
            this.Load += new System.EventHandler(this.info_4_2_inputBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSelectBOM;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbProNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMatNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBomCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn index1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bom_parent_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bom_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bom_count;
    }
}