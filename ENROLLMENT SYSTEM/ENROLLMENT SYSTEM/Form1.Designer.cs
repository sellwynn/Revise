namespace ENROLLMENT_SYSTEM
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SubjectCodeTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.UnitsTextBox = new System.Windows.Forms.TextBox();
            this.CurriculumYearTextBox = new System.Windows.Forms.TextBox();
            this.OfferingComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CourseCodeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SubjectCodeRequisiteTextBox = new System.Windows.Forms.TextBox();
            this.PreRequisiteRadioButton = new System.Windows.Forms.RadioButton();
            this.CoRequisiteRadioButton = new System.Windows.Forms.RadioButton();
            this.SubjectDataGridView = new System.Windows.Forms.DataGridView();
            this.SubjectCodeDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoPreDataGridView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUBJECT ENTRY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SUBJECT INFORMATION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Units:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Offering:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Category:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Course Code:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Curriculum Year: ";
            // 
            // SubjectCodeTextBox
            // 
            this.SubjectCodeTextBox.Location = new System.Drawing.Point(126, 93);
            this.SubjectCodeTextBox.Name = "SubjectCodeTextBox";
            this.SubjectCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubjectCodeTextBox.TabIndex = 9;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(126, 119);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 10;
            // 
            // UnitsTextBox
            // 
            this.UnitsTextBox.Location = new System.Drawing.Point(126, 145);
            this.UnitsTextBox.Name = "UnitsTextBox";
            this.UnitsTextBox.Size = new System.Drawing.Size(100, 20);
            this.UnitsTextBox.TabIndex = 11;
            // 
            // CurriculumYearTextBox
            // 
            this.CurriculumYearTextBox.Location = new System.Drawing.Point(126, 252);
            this.CurriculumYearTextBox.Name = "CurriculumYearTextBox";
            this.CurriculumYearTextBox.Size = new System.Drawing.Size(100, 20);
            this.CurriculumYearTextBox.TabIndex = 12;
            // 
            // OfferingComboBox
            // 
            this.OfferingComboBox.FormattingEnabled = true;
            this.OfferingComboBox.Items.AddRange(new object[] {
            "1 ",
            "2 ",
            "3 "});
            this.OfferingComboBox.Location = new System.Drawing.Point(126, 171);
            this.OfferingComboBox.Name = "OfferingComboBox";
            this.OfferingComboBox.Size = new System.Drawing.Size(121, 21);
            this.OfferingComboBox.TabIndex = 13;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "LECture",
            "LABoratory"});
            this.CategoryComboBox.Location = new System.Drawing.Point(126, 198);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.TabIndex = 14;
            // 
            // CourseCodeComboBox
            // 
            this.CourseCodeComboBox.FormattingEnabled = true;
            this.CourseCodeComboBox.Items.AddRange(new object[] {
            "BSIT",
            "BSN",
            "BSIS"});
            this.CourseCodeComboBox.Location = new System.Drawing.Point(126, 225);
            this.CourseCodeComboBox.Name = "CourseCodeComboBox";
            this.CourseCodeComboBox.Size = new System.Drawing.Size(121, 21);
            this.CourseCodeComboBox.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(29, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 217);
            this.label10.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(301, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(445, 216);
            this.label11.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label12.Location = new System.Drawing.Point(307, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Requisite Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(307, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Subject Code:";
            // 
            // SubjectCodeRequisiteTextBox
            // 
            this.SubjectCodeRequisiteTextBox.Location = new System.Drawing.Point(387, 92);
            this.SubjectCodeRequisiteTextBox.Name = "SubjectCodeRequisiteTextBox";
            this.SubjectCodeRequisiteTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubjectCodeRequisiteTextBox.TabIndex = 20;
            this.SubjectCodeRequisiteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SubjectCodeRequisiteTextBox_KeyPress);
            // 
            // PreRequisiteRadioButton
            // 
            this.PreRequisiteRadioButton.AutoSize = true;
            this.PreRequisiteRadioButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreRequisiteRadioButton.Location = new System.Drawing.Point(545, 88);
            this.PreRequisiteRadioButton.Name = "PreRequisiteRadioButton";
            this.PreRequisiteRadioButton.Size = new System.Drawing.Size(90, 20);
            this.PreRequisiteRadioButton.TabIndex = 21;
            this.PreRequisiteRadioButton.TabStop = true;
            this.PreRequisiteRadioButton.Text = "Pre-requisite";
            this.PreRequisiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // CoRequisiteRadioButton
            // 
            this.CoRequisiteRadioButton.AutoSize = true;
            this.CoRequisiteRadioButton.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoRequisiteRadioButton.Location = new System.Drawing.Point(545, 111);
            this.CoRequisiteRadioButton.Name = "CoRequisiteRadioButton";
            this.CoRequisiteRadioButton.Size = new System.Drawing.Size(90, 20);
            this.CoRequisiteRadioButton.TabIndex = 22;
            this.CoRequisiteRadioButton.TabStop = true;
            this.CoRequisiteRadioButton.Text = "Co-Requisite";
            this.CoRequisiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // SubjectDataGridView
            // 
            this.SubjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectCodeDataGridView,
            this.DescriptionDataGridView,
            this.UnitsDataGridView,
            this.CoPreDataGridView});
            this.SubjectDataGridView.Location = new System.Drawing.Point(301, 137);
            this.SubjectDataGridView.Name = "SubjectDataGridView";
            this.SubjectDataGridView.RowHeadersWidth = 62;
            this.SubjectDataGridView.Size = new System.Drawing.Size(445, 147);
            this.SubjectDataGridView.TabIndex = 23;
            // 
            // SubjectCodeDataGridView
            // 
            this.SubjectCodeDataGridView.HeaderText = "Subject Code";
            this.SubjectCodeDataGridView.MinimumWidth = 8;
            this.SubjectCodeDataGridView.Name = "SubjectCodeDataGridView";
            this.SubjectCodeDataGridView.Width = 150;
            // 
            // DescriptionDataGridView
            // 
            this.DescriptionDataGridView.HeaderText = "Description";
            this.DescriptionDataGridView.MinimumWidth = 8;
            this.DescriptionDataGridView.Name = "DescriptionDataGridView";
            this.DescriptionDataGridView.Width = 150;
            // 
            // UnitsDataGridView
            // 
            this.UnitsDataGridView.HeaderText = "Units";
            this.UnitsDataGridView.MinimumWidth = 8;
            this.UnitsDataGridView.Name = "UnitsDataGridView";
            this.UnitsDataGridView.Width = 150;
            // 
            // CoPreDataGridView
            // 
            this.CoPreDataGridView.HeaderText = "Co/Pre";
            this.CoPreDataGridView.MinimumWidth = 8;
            this.CoPreDataGridView.Name = "CoPreDataGridView";
            this.CoPreDataGridView.Width = 150;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(296, 295);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(85, 41);
            this.SaveButton.TabIndex = 24;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(387, 295);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(85, 41);
            this.CancelButton.TabIndex = 25;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 9);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 26;
            this.BackButton.Text = "MENU";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = global::ENROLLMENT_SYSTEM.Properties.Resources._4e5ba68efc23bbf165eda5da16c06cf9;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(788, 357);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SubjectDataGridView);
            this.Controls.Add(this.CoRequisiteRadioButton);
            this.Controls.Add(this.PreRequisiteRadioButton);
            this.Controls.Add(this.SubjectCodeRequisiteTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CourseCodeComboBox);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.OfferingComboBox);
            this.Controls.Add(this.CurriculumYearTextBox);
            this.Controls.Add(this.UnitsTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.SubjectCodeTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SubjectCodeTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox UnitsTextBox;
        private System.Windows.Forms.TextBox CurriculumYearTextBox;
        private System.Windows.Forms.ComboBox OfferingComboBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ComboBox CourseCodeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SubjectCodeRequisiteTextBox;
        private System.Windows.Forms.RadioButton PreRequisiteRadioButton;
        private System.Windows.Forms.RadioButton CoRequisiteRadioButton;
        private System.Windows.Forms.DataGridView SubjectDataGridView;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCodeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoPreDataGridView;
        private System.Windows.Forms.Button BackButton;
    }
}

