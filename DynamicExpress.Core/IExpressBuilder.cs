using System;
using System.Collections.Generic;
using System.Linq;

namespace MathDynamicExpress.Core
{
	/// <summary>
	/// Express builder interface.
	/// </summary>
	public interface IExpressBuilder
	{
		/// <summary>
		/// Build the specified expressions.
		/// 根据表达式列表生成动态表达式
		/// </summary>
		/// <param name="express">expressions.</param>
		string PreBuild(List<Express> expressions);
		/// <summary>
		/// Run the specified expressions and entity.
		/// 根据表达式列表和对应的实体类生成静态表达式
		/// </summary>
		/// <param name="express">Expressions.</param>
		/// <param name="entity">Entity.</param>
		string Build(List<Express> expressions,object entity);

	    string Build(string expression, object entity);

        string Build(string expression, params object[] entity);

		T Run<T> (string expression);
	}
}

