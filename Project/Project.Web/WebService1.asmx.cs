using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace Project.Web
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public bool SaveBallon(int ballonsCount)
        {
            string connString = "Data Source=sql-server;Initial Catalog=na213;Integrated Security=True";
            string myQuery = "INSERT INTO Ballon(Balloncount, gameDate) VALUES ( " + ballonsCount + ", '" + DateTime.Now + "' )";

            SqlConnection myConnection = new SqlConnection(connString);
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        [WebMethod]
        public string ShowScores()
        {
            string connString = "Data Source=sql-server;Initial Catalog=na213;Integrated Security=True";
            string myQuery = "SELECT Balloncount, gameDate  FROM Ballon ORDER BY count DESC";
            SqlConnection myCon = new SqlConnection(connString);
            SqlCommand myCommand = new SqlCommand(myQuery, myCon);
            SqlDataReader myReader;
            string s = "";

            try
            {
                myCon.Open();
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    s += myReader["Balloncount"] + ",  " + myReader["gameDate"] + "\n";
                }
                myReader.Close();
                return s;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
            finally { myCon.Close(); }
        }









    }





}
