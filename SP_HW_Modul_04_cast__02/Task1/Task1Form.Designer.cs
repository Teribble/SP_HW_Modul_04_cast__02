namespace SP_HW_Modul_04_cast__02
{
    partial class Task1Form
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Начать выполнение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnButton1Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Открыть папку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnButton2Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(109, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 225);
            this.listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(315, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(200, 225);
            this.listBox2.TabIndex = 3;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(521, 12);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(200, 225);
            this.listBox3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(109, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Открыть файл";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnButton3Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(315, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Открыть файл";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnButton4Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(521, 243);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Открыть файл";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnButton5Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 280);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

