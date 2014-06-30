using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MathDynamicExpress;
using MathDynamicExpress.Core;

namespace DataTableDemo
{
    public partial class Form1 : Form
    {
        string[] lbls = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z".Split(new char[] { ' ' });
        private char[] oprs = new char[] {'+','-','*','/','%'};

        Dictionary<string, string> dicExpressConfig = new Dictionary<string, string>(); 

        public Form1()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            BuildDefaultSource(10, 62);

            InitDefaultExpressions();
        }

        private void BuildDefaultSource(int row,int col)
        {
            DataTable dt = new DataTable();

            for (int j = 0; j < col; j++)
            {
                dt.Columns.Add(GetColumnName(j));
            }

            for (int i = 0; i < row; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < col; j++)
                {
                    dr[j] = "";
                }
                dt.Rows.Add(dr);
            }

            bindingSource1.DataSource = dt;
        }

        private void InitDefaultExpressions()
        {
            DataTable dt = bindingSource1.DataSource as DataTable;
            dt.Rows[0][0] = "12";
            dt.Rows[0][1] = "23";
            dt.Rows[1][0] = "3";
            dt.Rows[2][0] = "3";

            dt.Rows[1][1] = "{A:0}";
            dicExpressConfig.Add("{B:1}", "{A:0}");

            dt.Rows[1][2] = "{B:1}+{A:1}";
            dicExpressConfig.Add("{C:1}", "{B:1}+{A:1}");

            dt.Rows[0][2] = "({A:0}+{A:1})*{A:2}";
            dicExpressConfig.Add("{C:0}", "({A:0}+{A:1})*{A:2}");
        }

        private string GetColumnName(int rel_index)
        {
            string lbl = string.Empty;
            if (lbls.Length <= rel_index)
            {
                int ic = rel_index % lbls.Length;
                lbl = lbls[ic];
                string tlbl = lbls[ic];
                double c = Math.Floor((double)rel_index / (double)lbls.Length);
                while (c > 0)
                {
                    lbl += tlbl;
                    c--;
                }
            }
            else
            {
                lbl = lbls[rel_index];
            }

            return lbl;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string currentExpress = dataGridView1.CurrentCell.Value.ToString();
            string columnName = GetColumnName(dataGridView1.CurrentCell.ColumnIndex);
            columnName = string.Concat("{", columnName, ":",dataGridView1.CurrentCell.RowIndex, "}");
            if (!dicExpressConfig.ContainsKey(columnName))
            {
                dicExpressConfig.Add(columnName, currentExpress);
            }
            else
            {
                dicExpressConfig[columnName] = currentExpress;
            }

            ShowCellResult();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowCellResult();
        }

        private void ShowCellResult()
        {
            string columnName = GetColumnName(dataGridView1.CurrentCell.ColumnIndex);
            columnName = string.Concat("{", columnName, ":", dataGridView1.CurrentCell.RowIndex, "}");
            if (dicExpressConfig.ContainsKey(columnName))
            {
                DataTable dt = bindingSource1.DataSource as DataTable;

                string expression = ProcessIncludeExpress(dicExpressConfig[columnName]);

                object o = DynamicExpress.Eval<object>(expression, dt);
                lblColumnName.Text = string.Concat("当前单元编号为:", columnName, ",当前单元表达式为:", dicExpressConfig[columnName],
                    ",最终计算结果为:", o == null ? "" : o.ToString());
            }
            else
                lblColumnName.Text = columnName;
        }

        #region 嵌套表达式支持

        private string ProcessIncludeExpress(string expression)
        {
            var regex = new System.Text.RegularExpressions.Regex("\\{(.+?)\\}");
            var regexNum = new Regex("^[0-9]+$");
            var ms = regex.Matches(expression);

            DataTable dt = bindingSource1.DataSource as DataTable;

            foreach (var m in ms)
            {
                Match match = m as Match;
                System.Diagnostics.Debug.WriteLine(string.Format("get current cell express:{0}.",match.Value));

                if (dicExpressConfig.ContainsKey(match.Value))
                {
                    expression = expression.Replace(match.Value, dicExpressConfig[match.Value]);
                    expression = ProcessIncludeExpress(expression);
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Format("该表达式递归处理后为:{0}.",expression));

            return expression;
        }

        #endregion

    }
}
