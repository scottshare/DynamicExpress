using System;

/// <summary>
/// Logic attrs.
/// 用于标示两个表达式之间的关系
/// 
/// </summary>
namespace MathDynamicExpress.Core
{
	public enum LogicAttrs
	{
		/// <summary>
		/// The empty.
		/// </summary>
		Empty,
		/// <summary>
		/// The and.
		/// </summary>
		And,
		/// <summary>
		/// The or.
		/// </summary>
		Or,
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
		/// The divided.
		/// </summary>
		Divided,
		/// <summary>
		/// The mod.
		/// </summary>
		Mod
	}
}

