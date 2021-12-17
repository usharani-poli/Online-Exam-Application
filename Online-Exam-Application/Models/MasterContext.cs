using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Online_Exam_Application.Models
{
    public static class MasterContext
    {
        public static IEnumerable<T> ReturnList<T>(string spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2L6A1BJ;Initial Catalog=Online_Examination;Integrated Security=true");
            return con.Query<T>(spName, param, commandType: System.Data.CommandType.StoredProcedure);
        }
        public static P AddOrEdit<P>(string spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2L6A1BJ;Initial Catalog=Online_Examination;Integrated Security=true");
            var result = (P)Convert.ChangeType(con.Execute(spName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(P));
            return result;
        }

    }
}