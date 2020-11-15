namespace Haccp_MES._2_management
{
    partial class mngmnt_2_1_insertData
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
            this.btnLoadMaterialList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gridInsertManageInput = new System.Windows.Forms.DataGridView();
            this.col_mat_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_input_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_input_inspec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ware_no = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_input_admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_input_etc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsertManageInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(749, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Text = "출고등록";
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
            this.btnSave.Location = new System.Drawing.Point(668, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 98;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadMaterialList
            // 
            this.btnLoadMaterialList.BackColor = System.Drawing.Color.Violet;
            this.btnLoadMaterialList.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadMaterialList.Location = new System.Drawing.Point(665, 40);
            this.btnLoadMaterialList.Name = "btnLoadMaterialList";
            this.btnLoadMaterialList.Size = new System.Drawing.Size(124, 23);
            this.btnLoadMaterialList.TabIndex = 99;
            this.btnLoadMaterialList.Text = "품목정보 불러오기";
            this.btnLoadMaterialList.UseVisualStyleBackColor = false;
            this.btnLoadMaterialList.Click += new System.EventHandler(this.btnLoadMaterialList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gold;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(795, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 23);
            this.btnDelete.TabIndex = 102;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gridInsertManageInput
            // 
            this.gridInsertManageInput.AllowUserToAddRows = false;
            this.gridInsertManageInput.AllowUserToDeleteRows = false;
            this.gridInsertManageInput.AllowUserToResizeColumns = false;
            this.gridInsertManageInput.AllowUserToResizeRows = false;
            this.gridInsertManageInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsertManageInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInsertManageInput.BackgroundColor = System.Drawing.Color.Silver;
            this.gridInsertManageInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInsertManageInput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridInsertManageInput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInsertManageInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInsertManageInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_mat_no,
            this.Column2,
            this.Column3,
            this.Column4,
            this.col_input_count,
            this.col_input_inspec,
            this.col_ware_no,
            this.col_input_admin,
            this.col_input_etc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInsertManageInput.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridInsertManageInput.EnableHeadersVisualStyles = false;
            this.gridInsertManageInput.Location = new System.Drawing.Point(34, 82);
            this.gridInsertManageInput.MultiSelect = false;
            this.gridInsertManageInput.Name = "gridInsertManageInput";
            this.gridInsertManageInput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInsertManageInput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridInsertManageInput.RowHeadersVisible = false;
            this.gridInsertManageInput.RowTemplate.Height = 23;
            this.gridInsertManageInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInsertManageInput.Size = new System.Drawing.Size(790, 181);
            this.gridInsertManageInput.TabIndex = 103;
            // 
            // col_mat_no
            // 
            this.col_mat_no.DataPropertyName = "mat_no";
            this.col_mat_no.HeaderText = "품목번호";
            this.col_mat_no.Name = "col_mat_no";
            this.col_mat_no.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "mat_name";
            this.Column2.HeaderText = "품목명";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "mat_type";
            this.Column3.HeaderText = "품목유형";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "mat_price";
            this.Column4.HeaderText = "단가";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // col_input_count
            // 
            this.col_input_count.DataPropertyName = "input_count";
            this.col_input_count.HeaderText = "수량";
            this.col_input_count.Name = "col_input_count";
            // 
            // col_input_inspec
            // 
            this.col_input_inspec.DataPropertyName = "input_inspec";
            this.col_input_inspec.HeaderText = "검사방법";
            this.col_input_inspec.Name = "col_input_inspec";
            // 
            // col_ware_no
            // 
            this.col_ware_no.DataPropertyName = "ware_name";
            this.col_ware_no.HeaderText = "창고명";
            this.col_ware_no.Name = "col_ware_no";
            // 
            // col_input_admin
            // 
            this.col_input_admin.DataPropertyName = "input_admin";
            this.col_input_admin.HeaderText = "관리자";
            this.col_input_admin.Name = "col_input_admin";
            this.col_input_admin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_input_admin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_input_etc
            // 
            this.col_input_etc.DataPropertyName = "input_etc";
            this.col_input_etc.HeaderText = "비고";
            this.col_input_etc.Name = "col_input_etc";
            this.col_input_etc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_input_etc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mngmnt_2_1_insertData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 319);
            this.Controls.Add(this.gridInsertManageInput);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLoadMaterialList);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mngmnt_2_1_insertData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "mngmnt_2_1_insertData";
            this.Load += new System.EventHandler(this.mngmnt_2_1_insertData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsertManageInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadMaterialList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView gridInsertManageInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mat_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_input_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_input_inspec;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_ware_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_input_admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_input_etc;
    }
}