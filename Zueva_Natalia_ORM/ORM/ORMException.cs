using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Serializable]
    public class ORMException : DbException
    {

        public ORMException()
            : base()
        {
        }
        public ORMException(string message)
            : base(message)
        {
        }

        public ORMException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
