namespace DB_Forms
{
    partial class UpdateOrderForm
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
            this.updateOrderBtn = new System.Windows.Forms.Button();
            this.costInput = new System.Windows.Forms.TextBox();
            this.statusInput = new System.Windows.Forms.ComboBox();
            this.dateInput = new System.Windows.Forms.TextBox();
            this.clientInput = new System.Windows.Forms.ComboBox();
            this.hairdresserInput = new System.Windows.Forms.ComboBox();
            this.idInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateOrderBtn
            // 
            this.updateOrderBtn.Location = new System.Drawing.Point(110, 351);
            this.updateOrderBtn.Name = "updateOrderBtn";
            this.updateOrderBtn.Size = new System.Drawing.Size(155, 36);
            this.updateOrderBtn.TabIndex = 27;
            this.updateOrderBtn.Text = "Применить ";
            this.updateOrderBtn.UseVisualStyleBackColor = true;
            this.updateOrderBtn.Click += new System.EventHandler(this.updateOrderBtn_Click);
            // 
            // costInput
            // 
            this.costInput.Location = new System.Drawing.Point(173, 294);
            this.costInput.Name = "costInput";
            this.costInput.Size = new System.Drawing.Size(186, 20);
            this.costInput.TabIndex = 26;
            // 
            // statusInput
            // 
            this.statusInput.FormattingEnabled = true;
            this.statusInput.Location = new System.Drawing.Point(173, 254);
            this.statusInput.Name = "statusInput";
            this.statusInput.Size = new System.Drawing.Size(186, 21);
            this.statusInput.TabIndex = 25;
            // 
            // dateInput
            // 
            this.dateInput.Location = new System.Drawing.Point(173, 213);
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(186, 20);
            this.dateInput.TabIndex = 24;
            this.dateInput.Text = "default";
            // 
            // clientInput
            // 
            this.clientInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientInput.FormattingEnabled = true;
            this.clientInput.Location = new System.Drawing.Point(173, 169);
            this.clientInput.Name = "clientInput";
            this.clientInput.Size = new System.Drawing.Size(186, 21);
            this.clientInput.TabIndex = 23;
            // 
            // hairdresserInput
            // 
            this.hairdresserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hairdresserInput.FormattingEnabled = true;
            this.hairdresserInput.Location = new System.Drawing.Point(173, 122);
            this.hairdresserInput.Name = "hairdresserInput";
            this.hairdresserInput.Size = new System.Drawing.Size(186, 21);
            this.hairdresserInput.TabIndex = 22;
            // 
            // idInput
            // 
            this.idInput.Location = new System.Drawing.Point(173, 80);
            this.idInput.Name = "idInput";
            this.idInput.ReadOnly = true;
            this.idInput.Size = new System.Drawing.Size(186, 20);
            this.idInput.TabIndex = 21;
            this.idInput.Text = "default";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(41, 297);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Стоимость";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(41, 256);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Статус";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(41, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(41, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Клиент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(126, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Изменение заказа\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Парикмахер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "id";
            // 
            // UpdateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.updateOrderBtn);
            this.Controls.Add(this.costInput);
            this.Controls.Add(this.statusInput);
            this.Controls.Add(this.dateInput);
            this.Controls.Add(this.clientInput);
            this.Controls.Add(this.hairdresserInput);
            this.Controls.Add(this.idInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateOrderForm";
            this.Text = "UpdateOrderForm";
            this.Load += new System.EventHandler(this.UpdateOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateOrderBtn;
        private System.Windows.Forms.TextBox costInput;
        private System.Windows.Forms.ComboBox statusInput;
        private System.Windows.Forms.TextBox dateInput;
        private System.Windows.Forms.ComboBox clientInput;
        private System.Windows.Forms.ComboBox hairdresserInput;
        private System.Windows.Forms.TextBox idInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}