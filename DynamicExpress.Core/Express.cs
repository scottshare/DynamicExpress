using System;

namespace MathDynamicExpress.Core
{
	/// <summary>
	/// Express.
	/// 表达式描述类
	/// </summary>
	public class Express
	{
		public Express ()
		{
		}

		public LogicAttrs Logic
		{ get; set;}

		public LInclude L
		{ get; set;}

		public string Name
		{get;set;}

		public OprAttrs Opr
		{ get; set;}

		public string Value
		{ get; set;}

		public RInclude R
		{ get; set;}

	    public string ToJson()
	    {
	        return Newtonsoft.Json.JsonConvert.SerializeObject(this);
	    }

	    public static Express GetExpress(string json)
	    {
	        var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<Express>(json);
	        return entity;
	    }
	}
}

