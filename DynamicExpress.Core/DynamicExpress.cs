using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace MathDynamicExpress.Core
{
    /*
     * 统一处理表达式
     * 其中静态方法两个，可支持规则：
     * [1].Eval('{Field1} +|-|*|/|% {Field2}',Class)
     * [2].Eval('{ColIndex:RowIndex}+{ColIndex:RowIndex}',datatable)
     * [3].Eval('{0.Field1} +|-|*|/|% {1.Field1}',Class1,Class2)
     * 
     * 实例方法需要构造Express对象数组
     * 构造的方法可以通过json来产生或者调用Add方法来实现
     * ex:
       Express express = new Express
            {
                Logic = LogicAttrs.Empty,
                L = LInclude.One,
                Name = "Field1",
                Opr = OprAttrs.Add,
                Value = "Field2",
                R = RInclude.One
            };
     * 该表达式等同于 ({Field1}+{Field2})
     */
    public class DynamicExpress
	{
		IExpressBuilder _expressBuilder;
		Dictionary<int,Express> _expressions;

	    [ThreadStatic] private static IExpressBuilder s_expressBuilder;

	    static DynamicExpress()
	    {
            s_expressBuilder = GetDefaultBuilder();
	    }

	    static IExpressBuilder GetDefaultBuilder()
	    {
            var section = (DynamicExpressProviderSection)System.Configuration.ConfigurationManager.GetSection("dynamicExpressProvider");
            if (section != null)
            {
                string provierName = section.DefaultProvider;
                var builder = section.Providers[provierName];
                Type t = Type.GetType(builder.Type);
                return (IExpressBuilder)Activator.CreateInstance(t);
            }
            else
            {
                throw new ConfigurationErrorsException("在config中未找到dynamicExpressProvider配直节.");
            }
	    }

	    public DynamicExpress()
		{
			_expressions = new Dictionary<int, Express>();

		    try
		    {
		        _expressBuilder = GetDefaultBuilder();
		    }
		    catch (Exception ex)
		    {
                OnException(ex);
		        throw;
		    }
		}

		public DynamicExpress (IExpressBuilder builder):this()
		{
			_expressBuilder = builder;
		}

		public void Add(Express express)
		{
			_expressions.Add (_expressions.Count,express);
		}

		public void RemoveAt(int index)
		{
			if (_expressions.ContainsKey (index)) {
				_expressions.Remove (index);
			}
		}

		public void Remove(Express express)
		{
			int index = -0;
			foreach (KeyValuePair<int,Express> k in _expressions) {
				if (k.Value == express) {
					index = k.Key;
				}
			}
			if (index >= 0)
				RemoveAt (index);
		}

		public void Clear()
		{
			_expressions.Clear ();
		}

		public virtual void OnException(Exception x){

		}

        /// <summary>
        /// 获取表达式json描述
        /// </summary>
        /// <returns></returns>
        public string GetJson()
	    {
            if (_expressBuilder != null && _expressions != null && _expressions.Count > 0)
            {
                var r = from t in _expressions
                    select t.Value;
                var list = r.ToList();
                return Newtonsoft.Json.JsonConvert.SerializeObject(list);
            }
            return string.Empty;
	    }

        /// <summary>
        /// 根据json数据获取DynamicExpress实例
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
	    public static DynamicExpress GetDynamicExpress(string json)
	    {
            DynamicExpress de = new DynamicExpress();
	        var h = JArray.Parse(json);
	        foreach (var token in h)
	        {
	            de.Add(token.ToObject<Express>());
	        }

	        return de;
	    }

        /// <summary>
        /// 根据实体对象获取运算结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
	    public T Eval<T>(object entity)
		{
			try{
			    if (_expressBuilder != null && _expressions != null && _expressions.Count > 0)
			    {
			        var r = from t in _expressions
			            select t.Value;
			        string expression = _expressBuilder.Build(r.ToList(), entity);
			        return _expressBuilder.Run<T>(expression);
			    }
			}
			catch(Exception ex) {
				OnException (ex);
				throw;
			}

		    return default(T);
		}

        //eval("{filed1}+{field2}",o)
	    public static T Eval<T>(string expression, object entity)
	    {
	        try
	        {
                if (s_expressBuilder != null && !string.IsNullOrEmpty(expression)&&entity!=null)
	            {
	                string s = s_expressBuilder.Build(expression, entity);
	                return s_expressBuilder.Run<T>(s);
	            }

	            return default(T);
	        }
	        catch (Exception)
	        {
	            throw;
	        }
	    }

        //eval("{0.field1}+{1.field1}",o0,o1)
	    public static T Eval<T>(string expression, params object[] entities)
	    {
	        try
	        {
	            if (!string.IsNullOrEmpty(expression) && entities != null && entities.Length > 0)
	            {

	                expression = s_expressBuilder.Build(expression, entities);
	                return s_expressBuilder.Run<T>(expression);
	            }
	            return default(T);
	        }
	        catch (Exception)
	        {
	            throw;
	        }
	    }
	}
}

