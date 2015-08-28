using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooQ.CooqDataException
{
    public class DataAccessException : Exception
    {
        public DataAccessException()
        {

        }

        public DataAccessException(String message)
            : base(message)
        {

        }

        public DataAccessException(String message, Exception e)
            : base(message, e)
        {

        }
    }
}
