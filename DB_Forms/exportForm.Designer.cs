namespace DB_Forms
{
    partial class exportForm
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
            this.blackboxCheck = new System.Windows.Forms.CheckBox();
            this.ordersviewCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.excelRadio = new System.Windows.Forms.RadioButton();
            this.htmlRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.exportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // blackboxCheck
            // 
            this.blackboxCheck.AutoSize = true;
            this.blackboxCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blackboxCheck.Location = new System.Drawing.Point(12, 44);
            this.blackboxCheck.Name = "blackboxCheck";
            this.blackboxCheck.Size = new System.Drawing.Size(209, 24);
            this.blackboxCheck.TabIndex = 0;
            this.blackboxCheck.Text = "Информация об услугах";
            this.blackboxCheck.UseVisualStyleBackColor = true;
            // 
            // ordersviewCheck
            // 
            this.ordersviewCheck.AutoSize = true;
            this.ordersviewCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordersviewCheck.Location = new System.Drawing.Point(12, 77);
            this.ordersviewCheck.Name = "ordersviewCheck";
            this.ordersviewCheck.Size = new System.Drawing.Size(203, 24);
            this.ordersviewCheck.TabIndex = 1;
            this.ordersviewCheck.Text = "Информация о заказах";
            this.ordersviewCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Форма экспорта:";
            // 
            // excelRadio
            // 
            this.excelRadio.AutoSize = true;
            this.excelRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.excelRadio.Location = new System.Drawing.Point(27, 152);
            this.excelRadio.Name = "excelRadio";
            this.excelRadio.Size = new System.Drawing.Size(209, 24);
            this.excelRadio.TabIndex = 3;
            this.excelRadio.TabStop = true;
            this.excelRadio.Text = "Экспортировать в Excel";
            this.excelRadio.UseVisualStyleBackColor = true;
            // 
            // htmlRadio
            // 
            this.htmlRadio.AutoSize = true;
            this.htmlRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.htmlRadio.Location = new System.Drawing.Point(27, 175);
            this.htmlRadio.Name = "htmlRadio";
            this.htmlRadio.Size = new System.Drawing.Size(214, 24);
            this.htmlRadio.TabIndex = 4;
            this.htmlRadio.TabStop = true;
            this.htmlRadio.Text = "Экспортировать в HTML";
            this.htmlRadio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Экспорт отчетных данных";
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportBtn.Location = new System.Drawing.Point(60, 218);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(155, 44);
            this.exportBtn.TabIndex = 6;
            this.exportBtn.Text = "Экспорт";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // exportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 312);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.htmlRadio);
            this.Controls.Add(this.excelRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ordersviewCheck);
            this.Controls.Add(this.blackboxCheck);
            this.Name = "exportForm";
            this.Text = "exportForm";
            this.Load += new System.EventHandler(this.exportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox blackboxCheck;
        private System.Windows.Forms.CheckBox ordersviewCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton excelRadio;
        private System.Windows.Forms.RadioButton htmlRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportBtn;
    }
}