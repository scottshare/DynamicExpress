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
                });
   ```
  3.datatable
  ```C#
  T MathDynamicExpress.Core.DynamicExpress.Eval<T>(string expression, object entity)
  例如(ex):
  MathDynamicExpress.Core.DynamicExpress.Eval<int>("{0:0}+{0:1}-{1:1}", datatable1);
  ```
  format:"{`col-index` or `col-name`:`row-index`}"
  
  --------------------------------------------------
  目前项目中提供了JS Provider使用了开源的V8Engine，在项目中使用是需要在webconfig中配置对应的provider
  ```XML
<configSections>
    <section name="dynamicExpressProvider" type="MathDynamicExpress.Core.DynamicExpressProviderSection, MathDynamicExpress.Core"/>
  </configSections>
<dynamicExpressProvider defaultProvider="JsExpressBuilder">
    <providers>
      <add name="JsExpressBuilder" type="MathDynamicExpress.JSExpressBuilder,MathDynamicExpress"></add>
    </providers>
  </dynamicExpressProvider>
  ```
另外需要设置一下兼容性：
```XML
<startup useLegacyV2RuntimeActivationPolicy="true">
<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
<supportedRuntime version="v2.0.50727"/>
</startup>
```
具体用法可以参考项目中提供的三个demo。
