using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Entity.Constant
{
    /// <summary>
    /// Metotların Dönüş Tiplerini Tek ve merkezi tip olarak yönetmek için....
    /// </summary>
    public class EntityResult
    {
        public EntityResult(ResultType resultType = ResultType.Success, string message = "Success")
        {
            ResultType = resultType;
            Message = message;
        }

        public ResultType ResultType { get; private set; }
        public string Message { get; private set; }
    }


    public class EntityResult<T>
        : EntityResult
    {
        public EntityResult(T data, ResultType resultType = ResultType.Success, string message = "Success") : base(resultType, message)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }


    public enum ResultType
    {
        Success, Info, Error, Notfound, Warning
    }
}
