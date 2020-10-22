using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadUtil
{
    public enum StringMatchType
    {
        FullMatch,StartWith,EndWith
    }
    public class StringOption
    {
        public StringMatchType MatchType { get; set; }
        public string Value { get; set; }

        public bool Match(string str)
        {
            switch (MatchType)
            {
                case StringMatchType.FullMatch:
                    return Value == str;
                case StringMatchType.StartWith:
                    return str.StartsWith(Value);
                case StringMatchType.EndWith:
                    return str.EndsWith(Value);
                default:
                    return false;
            }
        }
    }
}
