namespace WinFormBookClient
{
    partial class Form2
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
            label1 = new Label();
            txtId = new TextBox();
            btnClear = new Button();
            txtTitle = new TextBox();
            label2 = new Label();
            txtPages = new TextBox();
            label3 = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 50);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(25, 73);
            txtId.Name = "txtId";
            txtId.Size = new Size(390, 27);
            txtId.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(23, 17);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(25, 133);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(390, 27);
            txtTitle.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 110);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Title *";
            // 
            // txtPages
            // 
            txtPages.Location = new Point(25, 195);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(110, 27);
            txtPages.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 172);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 5;
            label3.Text = "Pages *";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(321, 17);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 242);
            Controls.Add(btnSubmit);
            Controls.Add(txtPages);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(btnClear);
            Controls.Add(txtId);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Creating Books";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private Button btnClear;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtPages;
        private Label label3;
        private Button btnSubmit;
    }
}