using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsEntities;

namespace LogisticsDataAccess
{

    
    public class TripAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public TripAccess()
        {
            Conn = new SqlConnection("Data Source=IN-8QVTJM3;Initial Catalog=LogisticsApp;Integrated Security=SSPI");
        }
        public List<Trip> Get()
        {
            List<Trip> trips = new List<Trip>();
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
                Cmd.CommandText = "Select * from Trips";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    trips.Add(new Trip()
                    {
                        tripID = Convert.ToInt32(Reader["tripID"]),
                        driverID = Convert.ToInt32(Reader["driverID"]),
                        truckID = (Reader["truckID"]).ToString(),
                        startDate = Reader["dateStarted"].ToString(),
                        endDate = Reader["dateEnded"].ToString(),
                        extraCharges = Convert.ToInt32(Reader["extraCharges"]),
                        extraDistance = Convert.ToInt32(Reader["extraDistance"]),
                        tollCharges = Convert.ToInt32(Reader["tollCharges"]),
                        maintainceCharges = Convert.ToInt32(Reader["maintainceCharges"]),
                        destinationID = Convert.ToInt32(Reader["destinationID"]),
                        status = Convert.ToInt32(Reader["status"])
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
            return trips;
        }

        public List<Trip> GetOngoingTripusingDriverID(int id)
        {
            List<Trip> trips = new List<Trip>();
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
                Cmd.CommandText = $"Select * from Trips where driverID = {id} and status = 1";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    trips.Add(new Trip()
                    {
                        tripID = Convert.ToInt32(Reader["tripID"]),
                        driverID = Convert.ToInt32(Reader["driverID"]),
                        truckID = (Reader["truckID"]).ToString(),
                        startDate = Reader["dateStarted"].ToString(),
                        //endDate = Reader["dateEnded"].ToString(),
                        //extraCharges = Convert.ToInt32(Reader["extraCharges"]),
                        //extraDistance = Convert.ToInt32(Reader["extraDistance"]),
                        //tollCharges = Convert.ToInt32(Reader["tollCharges"]),
                        //maintainceCharges = Convert.ToInt32(Reader["maintainceCharges"]),
                        destinationID = Convert.ToInt32(Reader["destinationID"]),
                        status = Convert.ToInt32(Reader["status"])
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
            return trips;
        }
        public List<Trip> GetNewTrips()
        {
            List<Trip> trips = new List<Trip>();
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
                Cmd.CommandText = "Select * from Trips where status = 0";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    trips.Add(new Trip()
                    {
                        tripID = Convert.ToInt32(Reader["tripID"]),
                        //driverID = Convert.ToInt32(Reader["driverID"]),
                        //truckID = Convert.ToInt32(Reader["truckID"]),
                        startDate = Reader["dateStarted"].ToString(),
                        //endDate = Reader["driverContact"].ToString(),
                        //extraCharges = Convert.ToInt32(Reader["extraCharges"]),
                        //extraDistance = Convert.ToInt32(Reader["extraDistance"]),
                        //tollCharges = Convert.ToInt32(Reader["tollCharges"]),
                        //maintainceCharges = Convert.ToInt32(Reader["maintainceCharges"]),
                        destinationID = Convert.ToInt32(Reader["destinationID"]),
                        status = Convert.ToInt32(Reader["status"])
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
            return trips;
        }
        public Trip Get(int id)
        {
            Trip driver = null;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Select * from Trips where tripID={id}";
                SqlDataReader Reader = Cmd.ExecuteReader();
                //Cmd.CommandText = $"Select * from Department where DeptNo={id}";
                //SqlDataReader Reader2 = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    driver = new Trip()
                    {
                        tripID = Convert.ToInt32(Reader["tripID"]),
                        driverID = Convert.ToInt32(Reader["driverID"]),
                        truckID = (Reader["truckID"]).ToString(),
                        startDate = Reader["dateStarted"].ToString(),
                        endDate = Reader["dateEnded"].ToString(),
                        extraCharges = Convert.ToInt32(Reader["extraCharges"]),
                        extraDistance = Convert.ToInt32(Reader["extraDistance"]),
                        tollCharges = Convert.ToInt32(Reader["tollCharges"]),
                        maintainceCharges = Convert.ToInt32(Reader["maintainceCharges"]),
                        status = Convert.ToInt32(Reader["status"])
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

        public void CreateforABC(Trip entity)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Insert into Trips(destinationID,dateStarted) Values('{entity.destinationID}', '{entity.startDate}')";
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

        public void update(int id,string truckID, int driverID)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Update Trips set truckID = '{truckID}', driverID={driverID},status = 1 where tripID = {id}";
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

        public void UpdateCompleted(int tripID, int toll, int main, int extra, int extraDis, string dateEnd)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Update Trips set dateEnded='{dateEnd}',extraDistance={extra},tollCharges={toll}, maintainceCharges={main},extraCharges={extra},status = 2 where tripID = {tripID}";
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
