using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utils.ValueResult
{
    public class ServiceResult
    {
        private string errorsSeparator = "/n";

        protected ServiceResult()
        {
            Errors = new List<string>();
        }

        protected ServiceResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public static ServiceResult Success => new ServiceResult();

        public static TServiceResult Failed<TServiceResult>(string error) where TServiceResult : ServiceResult
        {
            return Failed<TServiceResult>(new string[] { error });
        }

        public static TServiceResult Failed<TServiceResult>(IEnumerable<string> errors) where TServiceResult : ServiceResult
        {
            return (TServiceResult)
                    typeof(TServiceResult).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                        new[] { typeof(IEnumerable<string>) },
                        new ParameterModifier[] { }).Invoke(new object[] { errors });
        }

        public string ErrosJoined => string.Join(errorsSeparator, Errors);

        public IEnumerable<string> Errors { get; set; }

        public bool Succeed => !Errors.Any();
    }
}
