namespace Arithmetic
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
            this.label_AvLength = new System.Windows.Forms.Label();
            this.label_CompDegree = new System.Windows.Forms.Label();
            this.label_CompRatio = new System.Windows.Forms.Label();
            this.label_Entropy = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Swap = new System.Windows.Forms.Button();
            this.btn_Decode = new System.Windows.Forms.Button();
            this.btn_Code = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_Output = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Input = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_AvLength
            // 
            this.label_AvLength.AutoSize = true;
            this.label_AvLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_AvLength.Location = new System.Drawing.Point(602, 411);
            this.label_AvLength.Name = "label_AvLength";
            this.label_AvLength.Size = new System.Drawing.Size(0, 15);
            this.label_AvLength.TabIndex = 32;
            // 
            // label_CompDegree
            // 
            this.label_CompDegree.AutoSize = true;
            this.label_CompDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CompDegree.Location = new System.Drawing.Point(602, 426);
            this.label_CompDegree.Name = "label_CompDegree";
            this.label_CompDegree.Size = new System.Drawing.Size(0, 15);
            this.label_CompDegree.TabIndex = 31;
            // 
            // label_CompRatio
            // 
            this.label_CompRatio.AutoSize = true;
            this.label_CompRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CompRatio.Location = new System.Drawing.Point(602, 441);
            this.label_CompRatio.Name = "label_CompRatio";
            this.label_CompRatio.Size = new System.Drawing.Size(0, 15);
            this.label_CompRatio.TabIndex = 30;
            // 
            // label_Entropy
            // 
            this.label_Entropy.AutoSize = true;
            this.label_Entropy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Entropy.Location = new System.Drawing.Point(602, 456);
            this.label_Entropy.Name = "label_Entropy";
            this.label_Entropy.Size = new System.Drawing.Size(0, 15);
            this.label_Entropy.TabIndex = 29;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(605, 220);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(183, 23);
            this.btn_Clear.TabIndex = 28;
            this.btn_Clear.Text = "Стереть";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Swap
            // 
            this.btn_Swap.Location = new System.Drawing.Point(605, 191);
            this.btn_Swap.Name = "btn_Swap";
            this.btn_Swap.Size = new System.Drawing.Size(183, 23);
            this.btn_Swap.TabIndex = 27;
            this.btn_Swap.Text = "Поменять";
            this.btn_Swap.UseVisualStyleBackColor = true;
            this.btn_Swap.Click += new System.EventHandler(this.btn_Swap_Click);
            // 
            // btn_Decode
            // 
            this.btn_Decode.Location = new System.Drawing.Point(605, 162);
            this.btn_Decode.Name = "btn_Decode";
            this.btn_Decode.Size = new System.Drawing.Size(183, 23);
            this.btn_Decode.TabIndex = 26;
            this.btn_Decode.Text = "Декодировать";
            this.btn_Decode.UseVisualStyleBackColor = true;
            this.btn_Decode.Click += new System.EventHandler(this.btn_Decode_Click);
            // 
            // btn_Code
            // 
            this.btn_Code.Location = new System.Drawing.Point(605, 133);
            this.btn_Code.Name = "btn_Code";
            this.btn_Code.Size = new System.Drawing.Size(183, 23);
            this.btn_Code.TabIndex = 25;
            this.btn_Code.Text = "Кодировать";
            this.btn_Code.UseVisualStyleBackColor = true;
            this.btn_Code.Click += new System.EventHandler(this.btn_Code_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_Output);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 228);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шифр";
            // 
            // rtb_Output
            // 
            this.rtb_Output.BackColor = System.Drawing.Color.White;
            this.rtb_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_Output.Location = new System.Drawing.Point(6, 19);
            this.rtb_Output.Name = "rtb_Output";
            this.rtb_Output.ReadOnly = true;
            this.rtb_Output.Size = new System.Drawing.Size(572, 203);
            this.rtb_Output.TabIndex = 3;
            this.rtb_Output.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_Input);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 228);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Текст";
            // 
            // rtb_Input
            // 
            this.rtb_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_Input.Location = new System.Drawing.Point(6, 19);
            this.rtb_Input.Name = "rtb_Input";
            this.rtb_Input.Size = new System.Drawing.Size(572, 203);
            this.rtb_Input.TabIndex = 2;
            this.rtb_Input.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.label_AvLength);
            this.Controls.Add(this.label_CompDegree);
            this.Controls.Add(this.label_CompRatio);
            this.Controls.Add(this.label_Entropy);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Swap);
            this.Controls.Add(this.btn_Decode);
            this.Controls.Add(this.btn_Code);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_AvLength;
        private System.Windows.Forms.Label label_CompDegree;
        private System.Windows.Forms.Label label_CompRatio;
        private System.Windows.Forms.Label label_Entropy;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Swap;
        private System.Windows.Forms.Button btn_Decode;
        private System.Windows.Forms.Button btn_Code;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_Output;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_Input;
    }
}

