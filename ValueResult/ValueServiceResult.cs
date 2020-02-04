using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.ValueResult
{
    public class ValueServiceResult<T> : ServiceResult
    {
        protected ValueServiceResult(IEnumerable<string> errors) : base(errors)
        {
        }

        public new static ValueServiceResult<T> Success(T data) { return new ValueServiceResult<T>(data); }

        public ValueServiceResult(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}