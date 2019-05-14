namespace RLE_BW
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
            this.label_CompDegree = new System.Windows.Forms.Label();
            this.label_CompRatio = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_Output = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Input = new System.Windows.Forms.RichTextBox();
            this.btn_Swap = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_DecodeRLE = new System.Windows.Forms.Button();
            this.btn_Code = new System.Windows.Forms.Button();
            this.btn_DecodeBW = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CompDegree
            // 
            this.label_CompDegree.AutoSize = true;
            this.label_CompDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CompDegree.Location = new System.Drawing.Point(602, 444);
            this.label_CompDegree.Name = "label_CompDegree";
            this.label_CompDegree.Size = new System.Drawing.Size(0, 15);
            this.label_CompDegree.TabIndex = 21;
            // 
            // label_CompRatio
            // 
            this.label_CompRatio.AutoSize = true;
            this.label_CompRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CompRatio.Location = new System.Drawing.Point(602, 459);
            this.label_CompRatio.Name = "label_CompRatio";
            this.label_CompRatio.Size = new System.Drawing.Size(0, 15);
            this.label_CompRatio.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_Output);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 228);
            this.groupBox2.TabIndex = 13;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 228);
            this.groupBox1.TabIndex = 12;
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
            // btn_Swap
            // 
            this.btn_Swap.Location = new System.Drawing.Point(605, 182);
            this.btn_Swap.Name = "btn_Swap";
            this.btn_Swap.Size = new System.Drawing.Size(183, 23);
            this.btn_Swap.TabIndex = 17;
            this.btn_Swap.Text = "Поменять";
            this.btn_Swap.UseVisualStyleBackColor = true;
            this.btn_Swap.Click += new System.EventHandler(this.btn_Swap_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(605, 211);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(183, 23);
            this.btn_Clear.TabIndex = 18;
            this.btn_Clear.Text = "Стереть";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_DecodeRLE
            // 
            this.btn_DecodeRLE.Location = new System.Drawing.Point(605, 126);
            this.btn_DecodeRLE.Name = "btn_DecodeRLE";
            this.btn_DecodeRLE.Size = new System.Drawing.Size(183, 23);
            this.btn_DecodeRLE.TabIndex = 16;
            this.btn_DecodeRLE.Text = "Декодировать RLE";
            this.btn_DecodeRLE.UseVisualStyleBackColor = true;
            this.btn_DecodeRLE.Click += new System.EventHandler(this.btn_DecodeRLE_Click);
            // 
            // btn_Code
            // 
            this.btn_Code.Location = new System.Drawing.Point(605, 97);
            this.btn_Code.Name = "btn_Code";
            this.btn_Code.Size = new System.Drawing.Size(183, 23);
            this.btn_Code.TabIndex = 15;
            this.btn_Code.Text = "Кодировать";
            this.btn_Code.UseVisualStyleBackColor = true;
            this.btn_Code.Click += new System.EventHandler(this.btn_Code_Click);
            // 
            // btn_DecodeBW
            // 
            this.btn_DecodeBW.Location = new System.Drawing.Point(605, 153);
            this.btn_DecodeBW.Name = "btn_DecodeBW";
            this.btn_DecodeBW.Size = new System.Drawing.Size(183, 23);
            this.btn_DecodeBW.TabIndex = 22;
            this.btn_DecodeBW.Text = "Декодировать BW";
            this.btn_DecodeBW.UseVisualStyleBackColor = true;
            this.btn_DecodeBW.Click += new System.EventHandler(this.btn_DecodeBW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 481);
            this.Controls.Add(this.btn_DecodeBW);
            this.Controls.Add(this.btn_Code);
            this.Controls.Add(this.btn_DecodeRLE);
            this.Controls.Add(this.label_CompDegree);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.label_CompRatio);
            this.Controls.Add(this.btn_Swap);
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
        private System.Windows.Forms.Label label_CompDegree;
        private System.Windows.Forms.Label label_CompRatio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_Output;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_Input;
        private System.Windows.Forms.Button btn_Swap;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_DecodeRLE;
        private System.Windows.Forms.Button btn_Code;
        private System.Windows.Forms.Button btn_DecodeBW;
    }
}

