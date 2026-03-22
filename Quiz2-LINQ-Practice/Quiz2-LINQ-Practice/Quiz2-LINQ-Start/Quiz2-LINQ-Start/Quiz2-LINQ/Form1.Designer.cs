namespace Quiz2_LINQ
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboQuerySelector = new ComboBox();
            dgvQueryOutput = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblNumberOfRecords = new Label();
            label4 = new Label();
            txtQuery = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvQueryOutput).BeginInit();
            SuspendLayout();
            // 
            // cboQuerySelector
            // 
            cboQuerySelector.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuerySelector.FormattingEnabled = true;
            cboQuerySelector.Items.AddRange(new object[] { "Query1", "Query2", "Query3", "Query4", "Query5", "Query6", "Query7", "Query8", "Bonus Query" });
            cboQuerySelector.Location = new Point(16, 56);
            cboQuerySelector.Name = "cboQuerySelector";
            cboQuerySelector.Size = new Size(222, 28);
            cboQuerySelector.TabIndex = 0;
            cboQuerySelector.SelectedIndexChanged += cboQuerySelector_SelectedIndexChanged;
            // 
            // dgvQueryOutput
            // 
            dgvQueryOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueryOutput.Location = new Point(11, 228);
            dgvQueryOutput.Name = "dgvQueryOutput";
            dgvQueryOutput.RowHeadersWidth = 51;
            dgvQueryOutput.Size = new Size(1325, 655);
            dgvQueryOutput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 33);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 2;
            label1.Text = "Query Selector:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 205);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 3;
            label2.Text = "Query Output:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 205);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 4;
            label3.Text = "Number of Records: ";
            // 
            // lblNumberOfRecords
            // 
            lblNumberOfRecords.AutoSize = true;
            lblNumberOfRecords.Location = new Point(321, 205);
            lblNumberOfRecords.Name = "lblNumberOfRecords";
            lblNumberOfRecords.Size = new Size(0, 20);
            lblNumberOfRecords.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(415, 33);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 7;
            label4.Text = "Query:";
            // 
            // txtQuery
            // 
            txtQuery.Location = new Point(486, 30);
            txtQuery.Name = "txtQuery";
            txtQuery.ReadOnly = true;
            txtQuery.Size = new Size(850, 180);
            txtQuery.TabIndex = 8;
            txtQuery.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 895);
            Controls.Add(txtQuery);
            Controls.Add(label4);
            Controls.Add(lblNumberOfRecords);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvQueryOutput);
            Controls.Add(cboQuerySelector);
            Name = "Form1";
            Text = "Quiz 2";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQueryOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboQuerySelector;
        private DataGridView dgvQueryOutput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblNumberOfRecords;
        private Label label4;
        private RichTextBox txtQuery;
    }
}
