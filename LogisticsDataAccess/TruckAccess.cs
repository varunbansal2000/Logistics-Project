using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsEntities;

namespace LogisticsDataAccess
{
    public class TruckAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public TruckAccess()
        {
            Conn = new SqlConnection("Data Source=IN-8QVTJM3;Initial Catalog=LogisticsApp;Integrated Security=SSPI");
        }

        public List<Truck> Get()
        {
            List<Truck> list = new List<Truck>();
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
                Cmd.CommandText = "Select * from Trucks";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    list.Add(new Truck()
                    {
                        truckID = (Reader["truckID"]).ToString(),
                        vendorID = Convert.ToInt32(Reader["vendorID"]),
                        //driverContact = Reader["driverContact"].ToString(),
                        costPerKM = Convert.ToInt32(Reader["costPerKM"]),
                        assignedTripID = Convert.ToInt32(Reader["assignedTripID"])
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
            return list;

        }

        public List<Truck> GetFreeTrucks()
        {
            List<Truck> list = new List<Truck>();
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
                Cmd.CommandText = "Select * from Trucks where assignedTripID = 0 order by costPerKM";
                // 5. Execute the Command
                SqlDataReader Reader = Cmd.ExecuteReader();
                // 6. Get Result by reading data from Reader object and put it in List<Department>
                // 6.a. Using While loop to start reading records from Reader from first record and so till end
                while (Reader.Read())
                {
                    // 6.b. Put each Row Value into the Department object 
                    list.Add(new Truck()
                    {
                        truckID = (Reader["truckID"]).ToString(),
                        vendorID = Convert.ToInt32(Reader["vendorID"]),
                        //driverContact = Reader["driverContact"].ToString(),
                        costPerKM = Convert.ToInt32(Reader["costPerKM"]),
                        assignedTripID = Convert.ToInt32(Reader["assignedTripID"])
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
            return list;

        }

        public Truck Get(string id)
        {
            Truck driver = null;
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Select * from Trucks where truckID='{id}'";
                SqlDataReader Reader = Cmd.ExecuteReader();
                //Cmd.CommandText = $"Select * from Department where DeptNo={id}";
                //SqlDataReader Reader2 = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    driver = new Truck()
                    {
                        truckID = Reader["truckID"].ToString(),
                        vendorID = Convert.ToInt32(Reader["vendorID"]),
                        //driverContact = Reader["driverContact"].ToString(),
                        costPerKM = Convert.ToInt32(Reader["costPerKM"]),
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

        public void Create(Truck entity)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"Insert into Trucks Values('{entity.truckID}', {entity.vendorID}, {entity.assignedTripID}, {entity.costPerKM})";
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

        public void changeStatus(string id, int s)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.CommandText = $"update Trucks set assignedTripID = {s} where truckID = '{id}'";
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
