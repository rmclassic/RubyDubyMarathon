using Cassandra;
using System;

namespace RubyDub.Models
{
    public class GetService : Service
    {
        public string idservice;
        public string phoneunumber;
        public long starttime = 0;
        public long endtime = 0;
        public string barcode;

        public GetService()
        {

        }
        public GetService(Row _row)
        {
            idservice = _row["idservice"] as string;
            phoneunumber = _row["phonenumber"] as string;
            id = _row["id"] as string;
            starttime = DateTime.Parse(_row["starttime"].ToString()).Millisecond;
            endtime = DateTime.Parse(_row["endtime"].ToString()).Millisecond;
            barcode = _row["barcode"] as string;
            col = _row["col"] as string;
        }

        public GetService(string _idservice, string _phonenumber, string _id, long _starttime, long _endtime, string _barcode, string _col)
        {
            idservice = _idservice;
            phoneunumber = _phonenumber;
            id = _id;
            starttime = _starttime;
            endtime = _endtime;
            barcode = _barcode;
            col = _col;
        }
        public override string ToString()
        {
            DateTime start = new DateTime(starttime);
            DateTime end = new DateTime(endtime);
            string startstr = start.Year.ToString() + '-' + start.Month + '-' + start.Day;
            string endstr = start.Year.ToString() + '-' + start.Month + '-' + start.Day;
            return "\'" + phoneunumber + "\',\'" + idservice + "\',\'" + id + "\',\'" + startstr + "\',\'" + endstr + "\',\'" + barcode + "\',\'" + col + "\'";
        }
    }
}
