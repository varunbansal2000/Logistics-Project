using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsEntities;


namespace LogisticsDataAccess
{
    public class SummaryAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public SummaryAccess()
        {
            Conn = new SqlConnection("Data Source=IN-8QVTJM3;Initial Catalog=LogisticsApp;Integrated Security=SSPI");

        }

        public void create(Summary entity)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Insert into Summary Values({entity.tripID}, {entity.fromABC}, {entity.vendorCharges}, {entity.driverCharges}, {entity.extraCharges},{entity.profitLoss})";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        public List<Summary> Get()
        {
            List<Summary> summaries= new List<Summary>();
            try
            {

                // 1. Connecto to Database by opening it
                Conn.Open();
                // 2. Create Command Object
                Cmd = new SqlCommand();
                // 2.a. Pass the Connection top Command so that Command Know to which Database
                // the query will be fired
                Cmd.Connection = Conn;
                // 3. Set the Command Type
                Cmd.CommandType = System.Data.CommandType.Text;
                // 4. Set the Command Text
                Cmd.CommandText = "Select * from Summary";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    summaries.Add(new Summary()
                    {
                        summaryID = Convert.ToInt32(Reader["summaryID"]),
                        tripID = Convert.ToInt32(Reader["tripID"]),
                        vendorCharges = Convert.ToInt32(Reader["vendorCharges"]),
                        fromABC = Convert.ToInt32(Reader["fromABC"]),
                        profitLoss = Convert.ToInt32(Reader["profitLoss"]),
                        driverCharges = Convert.ToInt32(Reader["driverCharges"]),
                         extraCharges = Convert.ToInt32(Reader["extraCharges"])
                    });
                }
                // 6.c. Close the Reader so that tthe Cursor will be closed
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return summaries;
        }
    }
}
