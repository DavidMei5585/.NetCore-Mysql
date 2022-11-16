using System;
using System.Runtime.Serialization;

namespace Wytn.Util.Exception
{
    /// <summary>
    /// 業務邏輯 Exception
    /// </summary>
    public class BusinessException : SystemException, ISerializable
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
