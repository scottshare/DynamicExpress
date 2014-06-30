using System;
using System.Configuration.Provider;

using MathDynamicExpress.Core;

namespace MathDynamicExpress
{
	public class JSExpressBuilder:ExpressBuilder
	{
		public JSExpressBuilder ()
		{
		}

		public override string PreBuild (System.Collections.Generic.List<Express> expressions)
		{
			return base.PreBuild (expressions);
		}

		public override T Run<T> (string expression)
		{
			v8sharp.V8Engine engine = v8sharp.V8Engine.Create();
			object o = engine.Execute(expression);
            if (typeof(T) == typeof(int))
            {
                int i = 0;
                int.TryParse(o.ToString(), out i);
                o = i;
                return (T) o;
            }
            else if (typeof(T) == typeof(float))
            {
                float f = 0;
                float.TryParse(o.ToString(), out f);
                o = f;
                return (T)o;
            }
            else if (typeof(T) == typeof(double))
            {
                double dbl = 0;
                double.TryParse(o.ToString(), out dbl);
                o = dbl;
                return (T)o;
            }
            else if (typeof(T)==typeof(decimal))
            {
                decimal de = 0;
                decimal.TryParse(o.ToString(), out de);
                o = de;
                return (T) o;
            }
		    return (T)o;
		}
	}
}

