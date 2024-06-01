
namespace AKMDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(162, 132);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(404, 30);
            txtAuthor.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(162, 54);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(404, 30);
            txtTitle.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(162, 221);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(404, 158);
            txtContent.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 28);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 4;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 97);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 5;
            label2.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 180);
            label3.Name = "label3";
            label3.Size = new Size(76, 23);
            label3.TabIndex = 6;
            label3.Text = "Content:";
            label3.Click += label3_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(96, 125, 139);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(162, 385);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 39);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 150, 243);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(291, 385);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 39);
            btnSave.TabIndex = 8;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 128, 255);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Location = new Point(291, 385);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 39);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 573);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
        private Button btnSave;
        private Button btnUpdate;
    }
}
