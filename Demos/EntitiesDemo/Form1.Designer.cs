namespace EntitiesDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_entity1_field1 = new System.Windows.Forms.TextBox();
            this.txt_entity1_field2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_entity2_field2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_entity2_field1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Expression = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_compute = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Field1:";
            // 
            // txt_entity1_field1
            // 
            this.txt_entity1_field1.Location = new System.Drawing.Point(107, 49);
            this.txt_entity1_field1.Name = "txt_entity1_field1";
            this.txt_entity1_field1.Size = new System.Drawing.Size(53, 21);
            this.txt_entity1_field1.TabIndex = 2;
            this.txt_entity1_field1.Text = "10";
            // 
            // txt_entity1_field2
            // 
            this.txt_entity1_field2.Location = new System.Drawing.Point(107, 76);
            this.txt_entity1_field2.Name = "txt_entity1_field2";
            this.txt_entity1_field2.Size = new System.Drawing.Size(53, 21);
            this.txt_entity1_field2.TabIndex = 4;
            this.txt_entity1_field2.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Field2:";
            // 
            // txt_entity2_field2
            // 
            this.txt_entity2_field2.Location = new System.Drawing.Point(321, 76);
            this.txt_entity2_field2.Name = "txt_entity2_field2";
            this.txt_entity2_field2.Size = new System.Drawing.Size(53, 21);
            this.txt_entity2_field2.TabIndex = 9;
            this.txt_entity2_field2.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Field2:";
            // 
            // txt_entity2_field1
            // 
            this.txt_entity2_field1.Location = new System.Drawing.Point(321, 49);
            this.txt_entity2_field1.Name = "txt_entity2_field1";
            this.txt_entity2_field1.Size = new System.Drawing.Size(53, 21);
            this.txt_entity2_field1.TabIndex = 7;
            this.txt_entity2_field1.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Field1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Entity2:";
            // 
            // txt_Expression
            // 
            this.txt_Expression.Location = new System.Drawing.Point(78, 116);
            this.txt_Expression.Name = "txt_Expression";
            this.txt_Expression.Size = new System.Drawing.Size(296, 21);
            this.txt_Expression.TabIndex = 11;
            this.txt_Expression.Text = "({0.Field1}+{1.Field2})*{0.Field2}+{1.Field1}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "表达式:";
            // 
            // btn_compute
            // 
            this.btn_compute.Location = new System.Drawing.Point(167, 161);
            this.btn_compute.Name = "btn_compute";
            this.btn_compute.Size = new System.Drawing.Size(75, 23);
            this.btn_compute.TabIndex = 12;
            this.btn_compute.Text = "计算";
            this.btn_compute.UseVisualStyleBackColor = true;
            this.btn_compute.Click += new System.EventHandler(this.btn_compute_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Location = new System.Drawing.Point(270, 169);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(0, 12);
            this.lbl_result.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 207);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btn_compute);
            this.Controls.Add(this.txt_Expression);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_entity2_field2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_entity2_field1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_entity1_field2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_entity1_field1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_entity1_field1;
        private System.Windows.Forms.TextBox txt_entity1_field2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_entity2_field2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_entity2_field1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Expression;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_compute;
        private System.Windows.Forms.Label lbl_result;
    }
}

