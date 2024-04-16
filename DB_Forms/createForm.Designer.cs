namespace DB_Forms
{
    partial class createForm
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
            this.testBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(33, 323);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(218, 22);
            this.testBox.TabIndex = 0;
            // 
            // createForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 357);
            this.Controls.Add(this.testBox);
            this.Name = "createForm";
            this.Text = "createForm";
            this.Load += new System.EventHandler(this.createForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox testBox;
    }
}