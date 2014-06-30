using System;
using System.Configuration.Provider;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MathDynamicExpress.Core
{
    public class ExpressBuilder : ProviderBase, IExpressBuilder
	{
		const string _expressFormat = "{0} {1} {2} {3} {4} {5}";

		#region express tag mappings

		internal virtual string Prefix{
			get{ 
				return "{";
			}
		}

		internal virtual string Suffix{
			get{ 
				return "}";
			}
		}

		internal virtual string LogicAnd{
			get{ 
				return "&&";
			}
		}

		internal virtual string LogicOr{
			get{ 
				return "||";
			}
		}

		internal virtual string LogicAdd{
			get{ 
				return "+";
			}
		}

		internal virtual string LogicMinus{
			get{ 
				return "-";
			}
		}

		internal virtual string LogicMultiply{
			get{ 
				return "*";
			}
		}

		internal virtual string LogicDivided{
			get{ 
				return "/";
			}
		}

		internal virtual string LogicMod{
			get{ 
				return "%";
			}
		}


		internal virtual string OprEqual{
			get{ 
				return "==";
			}
		}

		internal virtual string OprNotEqual{
			get{ 
				return "!=";
			}
		}

		internal virtual string OprGreaterThan{
			get{ 
				return ">";
			}
		}

		internal virtual string OprLessThan{
			get{ 
				return "<";
			}
		}

		internal virtual string OprGTE{
			get{ 
				return ">=";
			}
		}

		internal virtual string OprLTE{
			get{ 
				return "<=";
			}
		}

		internal virtual string OprAdd{
			get{ 
				return "+";
			}
		}

		internal virtual string OprMinus{
			get{ 
				return "-";
			}
		}

		internal virtual string OprMultiply{
			get{ 
				return "*";
			}
		}

		internal virtual string OprDivided{
			get{ 
				return "/";
			}
		}

		internal virtual string OprMod{
			get{ 
				return "%";
			}
		}

		internal virtual string OprInclude{
			get{ 
				return "[Include]";
			}
		}

		internal virtual string OprNotInclude{
			get{ 
				return "[NotInclude]";
			}
		}

        internal virtual string FieldValueFix
        {
            get { return "'"; }
        }

        internal virtual string GetMappingFromLInclude(LInclude l)
		{
			switch (l) {
				case LInclude.One:
					return "(";
				case LInclude.Two:
					return "((";
				case LInclude.Three:
					return "(((";
				case LInclude.Four:
					return "((((";
				case LInclude.Five:
					return "(((((";
				case LInclude.Empty:
				default:
					return string.Empty;
			}
		}

		internal virtual string GetMappingFromRInclude(RInclude r)
		{
			switch (r) {
			case RInclude.One:
				return ")";
			case RInclude.Two:
				return "))";
			case RInclude.Three:
				return ")))";
			case RInclude.Four:
				return "))))";
			case RInclude.Five:
				return ")))))";
			case RInclude.Empty:
			default:
				return string.Empty;
			}
		}

		internal virtual string GetMappingFromLogicAttrs(LogicAttrs attr)
		{
			switch (attr) {
				case LogicAttrs.Add:
					return LogicAdd;
				case LogicAttrs.And:
					return LogicAnd;
				case LogicAttrs.Divided:
					return LogicDivided;
				case LogicAttrs.Minus:
					return LogicMinus;
				case LogicAttrs.Mod:
					return LogicMod;
				case LogicAttrs.Multiply:
					return LogicMultiply;
				case LogicAttrs.Or:
					return LogicOr;
				case LogicAttrs.Empty:
				default:
					return string.Empty;
			}
		}

		internal virtual string GetMappingFromOprAttrs(OprAttrs attr)
		{
			switch (attr) {
				case OprAttrs.Add:
					return OprAdd;
				case OprAttrs.Divided:
					return OprDivided;
				case OprAttrs.Equal:
					return OprEqual;
				case OprAttrs.GreaterThan:
					return OprGreaterThan;
				case OprAttrs.GTE:
					return OprGTE;
				case OprAttrs.LessThan:
					return OprLessThan;
				case OprAttrs.LTE:
					return OprLTE;
				case OprAttrs.Minus:
					return OprMinus;
				case OprAttrs.Mod:
					return OprMod;
				case OprAttrs.Multiply:
					return OprMultiply;
				case OprAttrs.NotEqual:
					return OprNotEqual;
				case OprAttrs.Include:
					return OprInclude;
				case OprAttrs.NotInclude:
					return OprNotInclude;
			default:
				return string.Empty;
			}
		}

        private string GetFieldName(string name)
        {
            var regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(name))
            {
                return name;
            }
            return string.Concat(Prefix, name, Suffix);
        }

        private string GetFieldValue(string name)
        {
            var regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(name))
            {
                return name;
            }
            if (name.StartsWith(FieldValueFix) && name.EndsWith(FieldValueFix))
                return name;
            return string.Concat(FieldValueFix, name, FieldValueFix);
        }

        #endregion

		#region IExpressBuilder implementation

		public virtual string PreBuild (System.Collections.Generic.List<Express> expressions)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder ();

			foreach (Express express in expressions) {
				builder.Append (string.Format (_expressFormat,
					GetMappingFromLogicAttrs (express.Logic),
					GetMappingFromLInclude(express.L),
					//string.Concat (Prefix, express.Name, Suffix),
                    GetFieldName(express.Name),
					GetMappingFromOprAttrs (express.Opr), 
					//express.Value, 
                    GetFieldName(express.Value),
					GetMappingFromRInclude(express.R)));
			}

			return builder.ToString ();
		}

		public string Build (System.Collections.Generic.List<Express> expressions, object entity)
		{
			string expression = PreBuild (expressions);
		    return Build(expression, entity);
		}

        public virtual string Build(string expression, params object[] entities)
        {
            var regex = new System.Text.RegularExpressions.Regex("\\{(.+?)\\}");
            var regexNum = new Regex("^[0-9]+$");
            var matchs = regex.Matches(expression);
            for (int i = 0; i < matchs.Count; i++)
            {
                var m = matchs[i];
                string name = m.Value.Substring(1, m.Value.Length - 2);
                string[] ss = name.Split(new char[] {'.'});
                if (ss.Length == 2)
                {
                    int j = 0;
                    int.TryParse(ss[0], out j);
                    if (entities.Length > j)
                    {
                        expression =expression.Replace(m.Value,Build(string.Concat("{", ss[1], "}"), entities[j]));
                    }
                }
                else
                {
                    throw new Exception("语法不正确.");
                }
            }

            return expression;
        }

        public virtual string Build(string expression, object entity)
        {
            var regex = new System.Text.RegularExpressions.Regex("\\{(.+?)\\}");
            var regexNum = new Regex("^[0-9]+$");
            var matchs = regex.Matches(expression);
            for (int i = 0; i < matchs.Count; i++)
            {
                var m = matchs[i];

                object o = null;
                string name = m.Value.Substring(1, m.Value.Length - 2);
                if (entity is System.Data.DataTable)
                {
                    string[] l = name.Split(new char[] {':'});
                    if (l.Length == 2)
                    {
                        //{A:2}
                        string col = l[0];
                        string row = l[1];
                        int icol = -1;
                        int irow = -1;

                        var dt = entity as DataTable;
                        if (regexNum.IsMatch(col))
                        {
                            int.TryParse(col, out icol);
                        }
                        if (regexNum.IsMatch(row))
                        {
                            int.TryParse(row, out irow);
                        }

                        if (irow >= 0 && icol >= 0)
                        {
                            o = dt.Rows[irow][icol];
                        }
                        else if (irow >= 0 && icol < 0)
                        {
                            o = dt.Rows[irow][col];
                        }

                    }
                }
                else
                {
                    System.Reflection.PropertyInfo p = entity.GetType().GetProperty(name);
                    if (p == null)
                    {
                        expression = expression.Replace(m.Value, GetFieldValue(name));
                    }
                    else
                        o = p.GetValue(entity, null);
                }
                if (o != null)
                {
                    expression = expression.Replace(m.Value,GetFieldValue(o.ToString()));
                }
            }

            return expression;
        }

        public virtual T Run<T>(string expression)
		{
			return default(T);
		}

		#endregion

		public ExpressBuilder ()
		{
		}
	}
}

