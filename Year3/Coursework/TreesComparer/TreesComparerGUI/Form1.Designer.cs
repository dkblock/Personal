namespace TreesComparerGUI
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
            this.info_RTB = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.binary_CB = new System.Windows.Forms.CheckBox();
            this.avl_CB = new System.Windows.Forms.CheckBox();
            this.rb_CB = new System.Windows.Forms.CheckBox();
            this.b_CB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.random_RB = new System.Windows.Forms.RadioButton();
            this.sorted_RB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.countOfTests_TB = new System.Windows.Forms.TextBox();
            this.test_BTN = new System.Windows.Forms.Button();
            this.countOfElements_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeFrom_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.removeTo_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // info_RTB
            // 
            this.info_RTB.BackColor = System.Drawing.Color.White;
            this.info_RTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_RTB.Location = new System.Drawing.Point(12, 12);
            this.info_RTB.Name = "info_RTB";
            this.info_RTB.ReadOnly = true;
            this.info_RTB.Size = new System.Drawing.Size(509, 425);
            this.info_RTB.TabIndex = 0;
            this.info_RTB.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.test_BTN);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.countOfTests_TB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(527, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 431);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_CB);
            this.groupBox2.Controls.Add(this.rb_CB);
            this.groupBox2.Controls.Add(this.avl_CB);
            this.groupBox2.Controls.Add(this.binary_CB);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 132);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select trees for test:";
            // 
            // binary_CB
            // 
            this.binary_CB.AutoSize = true;
            this.binary_CB.Checked = true;
            this.binary_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.binary_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.binary_CB.Location = new System.Drawing.Point(6, 21);
            this.binary_CB.Name = "binary_CB";
            this.binary_CB.Size = new System.Drawing.Size(91, 20);
            this.binary_CB.TabIndex = 0;
            this.binary_CB.Text = "Binary tree";
            this.binary_CB.UseVisualStyleBackColor = true;
            // 
            // avl_CB
            // 
            this.avl_CB.AutoSize = true;
            this.avl_CB.Checked = true;
            this.avl_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.avl_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avl_CB.Location = new System.Drawing.Point(6, 47);
            this.avl_CB.Name = "avl_CB";
            this.avl_CB.Size = new System.Drawing.Size(79, 20);
            this.avl_CB.TabIndex = 1;
            this.avl_CB.Text = "AVL-tree";
            this.avl_CB.UseVisualStyleBackColor = true;
            // 
            // rb_CB
            // 
            this.rb_CB.AutoSize = true;
            this.rb_CB.Checked = true;
            this.rb_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rb_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_CB.Location = new System.Drawing.Point(6, 73);
            this.rb_CB.Name = "rb_CB";
            this.rb_CB.Size = new System.Drawing.Size(116, 20);
            this.rb_CB.TabIndex = 2;
            this.rb_CB.Text = "Red-black tree";
            this.rb_CB.UseVisualStyleBackColor = true;
            // 
            // b_CB
            // 
            this.b_CB.AutoSize = true;
            this.b_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_CB.Location = new System.Drawing.Point(6, 99);
            this.b_CB.Name = "b_CB";
            this.b_CB.Size = new System.Drawing.Size(63, 20);
            this.b_CB.TabIndex = 3;
            this.b_CB.Text = "B-tree";
            this.b_CB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.removeTo_TB);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.removeFrom_TB);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.countOfElements_TB);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.sorted_RB);
            this.groupBox3.Controls.Add(this.random_RB);
            this.groupBox3.Location = new System.Drawing.Point(6, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 164);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test settings:";
            // 
            // random_RB
            // 
            this.random_RB.AutoSize = true;
            this.random_RB.Checked = true;
            this.random_RB.Location = new System.Drawing.Point(6, 21);
            this.random_RB.Name = "random_RB";
            this.random_RB.Size = new System.Drawing.Size(121, 20);
            this.random_RB.TabIndex = 0;
            this.random_RB.TabStop = true;
            this.random_RB.Text = "Random values";
            this.random_RB.UseVisualStyleBackColor = true;
            // 
            // sorted_RB
            // 
            this.sorted_RB.AutoSize = true;
            this.sorted_RB.Location = new System.Drawing.Point(6, 47);
            this.sorted_RB.Name = "sorted_RB";
            this.sorted_RB.Size = new System.Drawing.Size(109, 20);
            this.sorted_RB.TabIndex = 1;
            this.sorted_RB.Text = "Sorted values";
            this.sorted_RB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of tests:";
            // 
            // countOfTests_TB
            // 
            this.countOfTests_TB.Location = new System.Drawing.Point(135, 334);
            this.countOfTests_TB.Name = "countOfTests_TB";
            this.countOfTests_TB.Size = new System.Drawing.Size(114, 22);
            this.countOfTests_TB.TabIndex = 3;
            this.countOfTests_TB.Text = "100";
            // 
            // test_BTN
            // 
            this.test_BTN.Location = new System.Drawing.Point(15, 381);
            this.test_BTN.Name = "test_BTN";
            this.test_BTN.Size = new System.Drawing.Size(234, 29);
            this.test_BTN.TabIndex = 2;
            this.test_BTN.Text = "Test";
            this.test_BTN.UseVisualStyleBackColor = true;
            this.test_BTN.Click += new System.EventHandler(this.test_BTN_Click);
            // 
            // countOfElements_TB
            // 
            this.countOfElements_TB.Location = new System.Drawing.Point(129, 77);
            this.countOfElements_TB.Name = "countOfElements_TB";
            this.countOfElements_TB.Size = new System.Drawing.Size(114, 22);
            this.countOfElements_TB.TabIndex = 5;
            this.countOfElements_TB.Text = "100000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count of elements:";
            // 
            // removeFrom_TB
            // 
            this.removeFrom_TB.Location = new System.Drawing.Point(129, 105);
            this.removeFrom_TB.Name = "removeFrom_TB";
            this.removeFrom_TB.Size = new System.Drawing.Size(114, 22);
            this.removeFrom_TB.TabIndex = 7;
            this.removeFrom_TB.Text = "25000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remove from:";
            // 
            // removeTo_TB
            // 
            this.removeTo_TB.Location = new System.Drawing.Point(129, 133);
            this.removeTo_TB.Name = "removeTo_TB";
            this.removeTo_TB.Size = new System.Drawing.Size(114, 22);
            this.removeTo_TB.TabIndex = 9;
            this.removeTo_TB.Text = "75000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Remove to:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.info_RTB);
            this.Name = "Form1";
            this.Text = "TreesComparer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox info_RTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button test_BTN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox countOfTests_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sorted_RB;
        private System.Windows.Forms.RadioButton random_RB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox b_CB;
        private System.Windows.Forms.CheckBox rb_CB;
        private System.Windows.Forms.CheckBox avl_CB;
        private System.Windows.Forms.CheckBox binary_CB;
        private System.Windows.Forms.TextBox removeTo_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox removeFrom_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countOfElements_TB;
        private System.Windows.Forms.Label label2;
    }
}

