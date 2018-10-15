namespace L8T2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tBNumEnt = new System.Windows.Forms.TextBox();
            this.nUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
            this.SuspendLayout();
            // 
            // tBNumEnt
            // 
            this.tBNumEnt.Location = new System.Drawing.Point(138, 12);
            this.tBNumEnt.Name = "tBNumEnt";
            this.tBNumEnt.Size = new System.Drawing.Size(100, 20);
            this.tBNumEnt.TabIndex = 0;
            // 
            // nUD
            // 
            this.nUD.DecimalPlaces = 2;
            this.nUD.Location = new System.Drawing.Point(12, 12);
            this.nUD.Name = "nUD";
            this.nUD.Size = new System.Drawing.Size(120, 20);
            this.nUD.TabIndex = 1;
            this.nUD.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 72);
            this.Controls.Add(this.nUD);
            this.Controls.Add(this.tBNumEnt);
            this.Name = "Form1";
            this.Text = "Задача 2";
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBNumEnt;
        private System.Windows.Forms.NumericUpDown nUD;
    }
}

