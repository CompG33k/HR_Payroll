using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public class SqlHelper
    {
        public static IQueryable<GetEmployeeSummary_Result> GetEmployeeSummaryResult(string connString)
        {
            List<GetEmployeeSummary_Result> list = new List<GetEmployeeSummary_Result>();

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //set stored procedure name
                    string spName = @"dbo.[GetEmployeeSummary]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //open connection
                    conn.Open();

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            list.Add(
                                new GetEmployeeSummary_Result
                                {
                                    ID = dr.GetInt32(0),
                                    fname = dr.GetString(1),
                                    lname = dr.GetString(2),
                                    StartDate = dr.GetDateTime(3),
                                    benefit_enrolled = (bool) dr["benefit_enrolled"],
                                    Dependents = dr.GetInt32(5),
                                    YearsEmployed = dr.GetInt32(6)
                                });
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
            return list.AsQueryable();
        }
    }
}
