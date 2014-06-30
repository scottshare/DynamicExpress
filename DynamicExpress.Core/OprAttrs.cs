using System;

namespace MathDynamicExpress.Core
{
	/// <summary>
	/// The Express Opr attrs.
	/// 表达式中的操作符
	/// = ！= > < >= <= + - * / % like 
	/// </summary>
	public enum OprAttrs
	{
		/// <summary>
		/// The equal.
		/// </summary>
		Equal,
		/// <summary>
		/// The not equal.
		/// </summary>
		NotEqual,
		/// <summary>
		/// The greater than.
		/// </summary>
		GreaterThan,
		/// <summary>
		/// The less than.
		/// </summary>
		LessThan,
		/// <summary>
		/// The Greater or equal.
		/// </summary>
		GTE,
		/// <summary>
		/// The Less or equal.
		/// </summary>
		LTE,
		/// <summary>
		/// The add.
		/// </summary>
		Add,
		/// <summary>
		/// The minus.
		/// </summary>
		Minus,
		/// <summary>
		/// The multiply.
		/// </summary>
		Multiply,
		/// <summary>
		/// The Divided
		/// </summary>
		Divided,
		/// <summary>
		/// The mod.
		/// </summary>
		Mod,
		/// <summary>
		/// The include.
		/// </summary>
		Include,
		/// <summary>
		/// The not include.
		/// </summary>
		NotInclude
	}
}

