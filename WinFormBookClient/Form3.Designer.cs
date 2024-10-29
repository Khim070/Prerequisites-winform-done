namespace WinFormBookClient
{
    partial class Form3
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
            btnSubmit = new Button();
            txtPages = new TextBox();
            txtTitle = new TextBox();
            btnCancel = new Button();
            txtId = new TextBox();
            label1 = new Label();
            chkTitle = new CheckBox();
            chkPages = new CheckBox();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(310, 14);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 15;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // txtPages
            // 
            txtPages.Location = new Point(14, 192);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(110, 27);
            txtPages.TabIndex = 14;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(14, 130);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(390, 27);
            txtTitle.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 14);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Location = new Point(14, 70);
            txtId.Name = "txtId";
            txtId.Size = new Size(390, 27);
            txtId.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 47);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 8;
            label1.Text = "Id *";
            // 
            // chkTitle
            // 
            chkTitle.AutoSize = true;
            chkTitle.Location = new Point(14, 103);
            chkTitle.Name = "chkTitle";
            chkTitle.Size = new Size(60, 24);
            chkTitle.TabIndex = 16;
            chkTitle.Text = "Title";
            chkTitle.UseVisualStyleBackColor = true;
            // 
            // chkPages
            // 
            chkPages.AutoSize = true;
            chkPages.Location = new Point(14, 163);
            chkPages.Name = "chkPages";
            chkPages.Size = new Size(69, 24);
            chkPages.TabIndex = 17;
            chkPages.Text = "Pages";
            chkPages.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 231);
            Controls.Add(chkPages);
            Controls.Add(chkTitle);
            Controls.Add(btnSubmit);
            Controls.Add(txtPages);
            Controls.Add(txtTitle);
            Controls.Add(btnCancel);
            Controls.Add(txtId);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            Text = "Editing Books";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private TextBox txtPages;
        private TextBox txtTitle;
        private Button btnCancel;
        private TextBox txtId;
        private Label label1;
        private CheckBox chkTitle;
        private CheckBox chkPages;
    }
}