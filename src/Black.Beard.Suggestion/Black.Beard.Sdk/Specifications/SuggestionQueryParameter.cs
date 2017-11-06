using System;
using System.Linq.Expressions;

namespace Bb.Specifications
{

    public class SuggestionQueryParameter
    {
        private Type _type;
        private object _value;

        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public object GetValue()
        {

            if (this._type == null)
                this._type = System.Type.GetType(this.Type);

            if (this._value == null)
            {
                if (this._type == typeof(string))
                    return this.Value;

                this._value = System.Convert.ChangeType(this.Value, this._type);
            }

            return this._value;

        }
    }

}