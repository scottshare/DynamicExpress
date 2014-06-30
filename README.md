DynamicExpress/动态表达式计算
==============

 作用
 -------------------------------------------
 根据动态算法以及给定的对象计算并返回计算结果
 
 
 
 用法
 -------------------------------------------
 1.单个对象（single entity）
 ###
 T MathDynamicExpress.Core.DynamicExpress.Eval<T>(string expression, object entity)
 例如(ex)：
 MathDynamicExpress.Core.DynamicExpress.Eval<double>(txt_expression.Text, new
            {
                Field1=txt_entity1_field1.Text,
                Field2 = txt_entity1_field2.Text,
                Field3 = txt_entity1_field3.Text
            });
