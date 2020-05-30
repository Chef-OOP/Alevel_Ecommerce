using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    /// <summary>
    /// Hata Yöenetiminde InnerException hatlarını tespit ve yönetmek için...
    /// </summary>
    public static class Extensions
    {
        public static Exception ToInnest(this Exception exception)
        {
            if (exception.InnerException != null)
            {
                return exception.InnerException.ToInnest();
            }
            return exception;
        }
    }
}
