using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Cassandra;

namespace RubyDub.Util
{
    public static class DataConnection
    {
        public static RowSet SendQuery(string _request)
        {
            try
            {
                Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
                var session = cluster.Connect(Constants.DatabaseKeySpace);
                return session.Execute(_request);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
