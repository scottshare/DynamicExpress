namespace SingleEntityDemo
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
            this.txt_entity1_field2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_entity1_field1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_entity1_field3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_compute = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.txt_expression = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_entity1_field2
            // 
            this.txt_entity1_field2.Location = new System.Drawing.Point(188, 61);
            this.txt_entity1_field2.Name = "txt_entity1_field2";
            this.txt_entity1_field2.Size = new System.Drawing.Size(53, 21);
            this.txt_entity1_field2.TabIndex = 9;
            this.txt_entity1_field2.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Field2:";
            // 
            // txt_entity1_field1
            // 
            this.txt_entity1_field1.Location = new System.Drawing.Point(188, 34);
            this.txt_entity1_field1.Name = "txt_entity1_field1";
            this.txt_entity1_field1.Size = new System.Drawing.Size(53, 21);
            this.txt_entity1_field1.TabIndex = 7;
            this.txt_entity1_field1.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Field1:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Entity:";
            // 
            // txt_entity1_field3
            // 
            this.txt_entity1_field3.Location = new System.Drawing.Point(188, 88);
            this.txt_entity1_field3.Name = "txt_entity1_field3";
            this.txt_entity1_field3.Size = new System.Drawing.Size(53, 21);
            this.txt_entity1_field3.TabIndex = 11;
            this.txt_entity1_field3.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Field3:";
            // 
            // btn_compute
            // 
            this.btn_compute.Location = new System.Drawing.Point(148, 152);
            this.btn_compute.Name = "btn_compute";
            this.btn_compute.Size = new System.Drawing.Size(75, 23);
            this.btn_compute.TabIndex = 12;
            this.btn_compute.Text = "计算结果";
            this.btn_compute.UseVisualStyleBackColor = true;
            this.btn_compute.Click += new System.EventHandler(this.btn_compute_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Location = new System.Drawing.Point(254, 162);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(0, 12);
            this.lbl_result.TabIndex = 13;
            // 
            // txt_expression
            // 
            this.txt_expression.Location = new System.Drawing.Point(106, 115);
            this.txt_expression.Name = "txt_expression";
            this.txt_expression.Size = new System.Drawing.Size(233, 21);
            this.txt_expression.TabIndex = 14;
            this.txt_expression.Text = "{Field1}+{Field2}-{Field3}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "表达式:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 181);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_expression);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btn_compute);
            this.Controls.Add(this.txt_entity1_field3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_entity1_field2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_entity1_field1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_entity1_field2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_entity1_field1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_entity1_field3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_compute;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.TextBox txt_expression;
        private System.Windows.Forms.Label label5;

    }
}

