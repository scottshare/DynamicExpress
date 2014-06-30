using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingleEntityDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_compute_Click(object sender, EventArgs e)
        {
            double d =
            MathDynamicExpress.Core.DynamicExpress.Eval<double>(txt_expression.Text, new
            {
                Field1=txt_entity1_field1.Text,
                Field2 = txt_entity1_field2.Text,
                Field3 = txt_entity1_field3.Text
            });

            lbl_result.Text = string.Concat("计算结果为:", d);
        }
    }
}
