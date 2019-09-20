using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Models
{
    public class Transaction
    {
        public string phonenumber;
        public string idservice;
        public string idCS;
        public string id;
        public int score;
        public long deadline;
        public long paytime;

        public Transaction(Row _row)
        {
            phonenumber = _row["phonenumber"] as string;
            idservice = _row["idservice"] as string;
            id = _row["id"] as string;
            idCS = _row["idCS"] as string;
            score = (int)_row["score"];
            deadline = DateTime.Parse(_row["deadline"].ToString()).Millisecond;
            paytime = DateTime.Parse(_row["paytime"].ToString()).Millisecond;
        }
    }
}
