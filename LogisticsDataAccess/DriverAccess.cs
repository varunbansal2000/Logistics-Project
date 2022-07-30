using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsEntities;


namespace LogisticsDataAccess
{
    public class DriverAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DriverAccess()
        {
            Conn = new SqlConnection("Data Source=IN-8QVTJM3;Initial Catalog=LogisticsApp;Integrated Security=SSPI");
        }

        public List<Driver> Get()
        {
            List<Driver> drivers = new List<Driver>();
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
                Cmd.CommandText = "Select * from Drivers";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    drivers.Add(new Driver()
                    {
                        driverID = Convert.ToInt32(Reader["driverID"]),
                        driverName = Reader["driverName"].ToString(),
                        driverContact = Reader["driverContact"].ToString(),
                        driverCharges = Convert.ToInt32(Reader["driverCharges"]),
                        assignedTripID = Convert.ToInt32(Reader["assignedTripID"])
                    });
                }
                // 6.c. Close the Reader so that tthe Cursor will be closed
                Reader.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return drivers;
        }

        public Driver Get(int id)
        {
            Driver driver = null;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Select * from Drivers where driverID={id}";
                SqlDataReader Reader = Cmd.ExecuteReader();
                //Cmd.CommandText = $"Select * from Department where DeptNo={id}";
                //SqlDataReader Reader2 = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    driver = new Driver()
                    {
                        driverID = Convert.ToInt32(Reader["driverID"]),
                        driverName = Reader["driverName"].ToString(),
                        driverContact = Reader["driverContact"].ToString(),
                        driverCharges = Convert.ToInt32(Reader["driverCharges"]),
                        assignedTripID = Convert.ToInt32(Reader["assignedTripID"])
                    };
                }
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
            return driver;
        }

        public void Create (Driver entity)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Insert into Drivers Values('{entity.driverName}', '{entity.driverContact}', '{entity.assignedTripID}', {entity.driverCharges})";
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

    }
}
