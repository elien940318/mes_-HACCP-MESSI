namespace Haccp_MES._1_information
{
    partial class info_2_2_inputitem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gridInsertProductInput = new System.Windows.Forms.DataGridView();
            this.mat_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mat_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mat_spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mat_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mat_etc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsertProductInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(754, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(64, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 96;
            this.label1.Text = "품목등록";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Haccp_MES.Properties.Resources.aperture_3x;
            this.pictureBox2.Location = new System.Drawing.Point(34, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 97;
            this.pictureBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(679, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 32);
            this.btnSave.TabIndex = 98;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.Violet;
            this.btnAddRow.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddRow.Location = new System.Drawing.Point(749, 40);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(35, 32);
            this.btnAddRow.TabIndex = 99;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gold;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(789, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 32);
            this.btnDelete.TabIndex = 102;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gridInsertProductInput
            // 
            this.gridInsertProductInput.AllowUserToAddRows = false;
            this.gridInsertProductInput.AllowUserToDeleteRows = false;
            this.gridInsertProductInput.AllowUserToResizeColumns = false;
            this.gridInsertProductInput.AllowUserToResizeRows = false;
            this.gridInsertProductInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsertProductInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInsertProductInput.BackgroundColor = System.Drawing.Color.Silver;
            this.gridInsertProductInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInsertProductInput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridInsertProductInput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInsertProductInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInsertProductInput.ColumnHeadersHeight = 29;
            this.gridInsertProductInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mat_name,
            this.mat_type,
            this.mat_spec,
            this.mat_price,
            this.mat_etc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInsertProductInput.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridInsertProductInput.EnableHeadersVisualStyles = false;
            this.gridInsertProductInput.Location = new System.Drawing.Point(34, 82);
            this.gridInsertProductInput.MultiSelect = false;
            this.gridInsertProductInput.Name = "gridInsertProductInput";
            this.gridInsertProductInput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInsertProductInput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridInsertProductInput.RowHeadersVisible = false;
            this.gridInsertProductInput.RowHeadersWidth = 51;
            this.gridInsertProductInput.RowTemplate.Height = 23;
            this.gridInsertProductInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInsertProductInput.Size = new System.Drawing.Size(790, 181);
            this.gridInsertProductInput.TabIndex = 103;
            // 
            // mat_name
            // 
            this.mat_name.DataPropertyName = "mat_name";
            this.mat_name.HeaderText = "품목명";
            this.mat_name.MinimumWidth = 6;
            this.mat_name.Name = "mat_name";
            // 
            // mat_type
            // 
            this.mat_type.DataPropertyName = "mat_type";
            this.mat_type.HeaderText = "품목유형";
            this.mat_type.MinimumWidth = 6;
            this.mat_type.Name = "mat_type";
            // 
            // mat_spec
            // 
            this.mat_spec.DataPropertyName = "mat_spec";
            this.mat_spec.HeaderText = "규격";
            this.mat_spec.MinimumWidth = 6;
            this.mat_spec.Name = "mat_spec";
            // 
            // mat_price
            // 
            this.mat_price.DataPropertyName = "mat_price";
            this.mat_price.HeaderText = "가격";
            this.mat_price.MinimumWidth = 6;
            this.mat_price.Name = "mat_price";
            // 
            // mat_etc
            // 
            this.mat_etc.DataPropertyName = "mat_etc";
            this.mat_etc.HeaderText = "비고란";
            this.mat_etc.MinimumWidth = 6;
            this.mat_etc.Name = "mat_etc";
            // 
            // info_2_2_inputitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 320);
            this.Controls.Add(this.gridInsertProductInput);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "info_2_2_inputitem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.info_2_2_inputitem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsertProductInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView gridInsertProductInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn mat_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mat_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mat_spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn mat_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn mat_etc;
    }
}