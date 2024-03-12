using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Exceptions
{
    public class SqlException: Exception
    {
        public SqlException(): base("SQL error occured while processing")
        {

        }

        public SqlException(string message): base(message)
        {

        }
    }
}
