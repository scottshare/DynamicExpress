DynamicExpress/动态表达式计算
==============

 作用
 -------------------------------------------
 根据动态算法以及给定的对象计算并返回计算结果
 <br>
 用法
 -------------------------------------------
  1.单个对象（single entity）
   ```C#
 T MathDynamicExpress.Core.DynamicExpress.Eval<T>(string expression, object entity)
 例如(ex)：
 MathDynamicExpress.Core.DynamicExpress.Eval<double>("({Field1}+{Field2})*{Field3}", new
            {
                Field1=txt_entity1_field1.Text,
                Field2 = txt_entity1_field2.Text,
                Field3 = txt_entity1_field3.Text
            });
```
  2.多个对象(entities)
   ```C#
   T MathDynamicExpress.Core.DynamicExpress.Eval<T>(string expression,params object[] entity)
   例如(ex):
   MathDynamicExpress.Core.DynamicExpress.Eval<double>("({0.Field1}-{1.Field1})+{1.Field2}*{0.Field2}", 
                new
                {
                    Field1=txt_entity1_field1.Text,
                    Field2 = txt_entity1_field2.Text
                }, 
                new
                {
                    Field1 = txt_entity2_field1.Text,
                    Field2 = txt_entity2_field2.Text
                });```
