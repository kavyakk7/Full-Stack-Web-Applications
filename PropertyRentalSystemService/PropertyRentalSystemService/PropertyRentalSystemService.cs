using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace PropertyRentalSystemService
{    
    public class PropertyRentalSystemService : IPropertyRentalSystemService
    {
        // defines all the data members of the class
        string address = "";
        string postalcode = "";
        bool currentStatus = true;
        string leaseEndDate = "";
        bool studentsAllowed = true;
        bool multipleOccupantsAllowed = true;
        int noOfOccupantsAllowed = 0;
        bool petsAllowed = true;
        bool childrenAllowed = true;

        // define all methods of the class
        public bool setAddress(string address)
        {
            this.address = address;
            return true;
        }
        public string getAddress()
        {
            return this.address;
        }
        public bool setPostalCode(string postalcode)
        {
            this.postalcode = postalcode;
            return true;
        }
        public string getPostalCode()
        {
            return this.postalcode;
        }

        public bool setCurrentStatus(bool status)
        {
            this.currentStatus = status;
            return true;
        }
        public bool getCurrentStatus()
        {
            return this.currentStatus;
        }

        public bool setLeaseEndDate(string date)
        {
            this.leaseEndDate = date;
            return true;
        }
        public string getLeaseEndDate()
        {
            return this.leaseEndDate;
        }

        public bool setStudentsAllowed(bool studentsAllowed)
        {
            this.studentsAllowed = studentsAllowed;
            return true;
        }
        public bool getStudentsAllowed()
        {
            return this.studentsAllowed;
        }

        public bool setMultipleOccupantsAllowed(bool multipleOccupantsAllowed)
        {
            this.multipleOccupantsAllowed = multipleOccupantsAllowed;
            return true;
        }
        public bool getMultpleOccupantsAllowed()
        {
            return this.multipleOccupantsAllowed;
        }

        public bool setNoOfOccupantsAllowed(int noOfOccupantsAllowed)
        {
            this.noOfOccupantsAllowed = noOfOccupantsAllowed;
            return true;
        }
        public int getNoOfOccupantsAllowed()
        {
            return this.noOfOccupantsAllowed;
        }

        public bool setPetsAllowed(bool petsAllowed)
        {
            this.petsAllowed = petsAllowed;
            return true;
        }
        public bool getPetsAllowed()
        {
            return this.petsAllowed;
        }

        public bool setChildrenAllowed(bool childrenAllowed)
        {
            this.childrenAllowed = childrenAllowed;
            return true;
        }
        public bool getChildrenAllowed()
        {
            return this.childrenAllowed;
        }

        // method to insert values of the new property into the table 'property' and 'lettings'
        public Boolean insertIntoTable()
        {            
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "property";
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            conn.Open();
            Console.WriteLine("Connected to Database!");
            string query = "INSERT INTO properties (address, postal_code, current_status, lease_end_date, students_allowed, " +
                "multiple_occupants_allowed, no_of_occupants, pets_allowed, children_allowed) VALUES (@add, @pc, @cs, @led, @sa, " +
                "@moa, @noo, @pa, @ca)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@add", this.getAddress());
            cmd.Parameters.AddWithValue("@pc", this.getPostalCode());
            cmd.Parameters.AddWithValue("@cs", this.getCurrentStatus() == true ? 1 : 0);
            cmd.Parameters.AddWithValue("@led", this.getLeaseEndDate());
            cmd.Parameters.AddWithValue("@sa", this.getStudentsAllowed() == true ? 1 : 0);
            cmd.Parameters.AddWithValue("@moa", this.getMultpleOccupantsAllowed() == true ? 1 : 0);
            if((this.getMultpleOccupantsAllowed() == true ? 1 : 0) == 1)
                cmd.Parameters.AddWithValue("@noo", this.getNoOfOccupantsAllowed());
            else
                cmd.Parameters.AddWithValue("@noo", 0);
            cmd.Parameters.AddWithValue("@pa", this.getPetsAllowed() == true ? 1 : 0);
            cmd.Parameters.AddWithValue("@ca", this.getChildrenAllowed() == true ? 1 : 0);
            int check1 = cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted into table property!");

            string query2 = "select max(property_no) from properties;";
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
            MySqlDataReader pno = cmd2.ExecuteReader();
            int p = 0;
            while (pno.Read())
            {
                p = pno.GetInt32(0);
            }
            pno.Close();
            string query3 = "SET FOREIGN_KEY_CHECKS = 0;INSERT INTO lettings (property_no, available) VALUES (@pno, @a);SET FOREIGN_KEY_CHECKS = 1;";
            MySqlCommand cmd3 = new MySqlCommand(query3, conn);
            cmd3.CommandText = query3;
            cmd3.Parameters.AddWithValue("@pno", p);
            cmd3.Parameters.AddWithValue("@a", this.getCurrentStatus()== true ? 1 : 0);
            int check2 = cmd3.ExecuteNonQuery();      
            conn.Close();
            if (check1 > 0 && check2 > 0)
                return true;
            return false;

        }

        // method to select property attributes from the table 'property' that have a postal code.
        public string selectFromTableUsingPostalCode()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "property";
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            conn.Open();
            Console.WriteLine("Connected to Database!");
            string query5 = "select address, current_status, lease_end_date, students_allowed, " +
                "multiple_occupants_allowed, no_of_occupants, pets_allowed, children_allowed from properties " +
                "where postal_code = '" + this.getPostalCode() +"'; ";
            MySqlCommand cmd5 = new MySqlCommand(query5, conn);
            MySqlDataReader rdr = cmd5.ExecuteReader();
            int i = 1;
            string data = "";
            while (rdr.Read())
            {
                data +="(" + i + ") Address : " + rdr.GetString(0) + "\n    Avaialable? : " + (rdr.GetInt32(1) == 1 ? "Yes" : "No")+
                    "\n    Lease End Date : " + rdr.GetString(2) + "\n    Students Allowed? : " + (rdr.GetInt32(3) == 1 ? "Yes" : "No");
                if (rdr.GetInt32(3) == 1) {
                    data += "\n    Multiple Occupancy Allowed? : " + (rdr.GetInt32(4) == 1 ? "Yes" : "No") +
                        "\n    No of occupants Allowed : " + rdr.GetInt32(5) + "\n";
                }
                else
                {
                    data += "\n    Pets Allowed? : " + (rdr.GetInt32(6) == 1 ? "Yes" : "No") +
                        "\n    Children Allowed? : " + (rdr.GetInt32(7) == 1 ? "Yes" : "No") + "\n";
                }
                i += 1;
            }
            conn.Close();
            return data;
        }

        // method to select property attributes from the table 'property' and 'lettings'
        // which is available and students are allowed
        public string selectFromTableForAvailableProperty()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "property";
            MySqlConnection conn = new MySqlConnection(builder.ToString());
            conn.Open();
            Console.WriteLine("Connected to Database!");
            string query4 = "select address, postal_code, lease_end_date, students_allowed, " +
                "multiple_occupants_allowed, no_of_occupants, pets_allowed, children_allowed from properties p, lettings l " +
                "where l.available = 1 and l.property_no = p.property_no and p.students_allowed = 1; ";
            MySqlCommand cmd4 = new MySqlCommand(query4, conn);
            MySqlDataReader rdr = cmd4.ExecuteReader();
            string data = "";
            int i = 1;
            while (rdr.Read())
            {
                data += "(" + i + ") Address : " + rdr.GetString(0) + "\n    Postal Code : " + rdr.GetString(1) + 
                    "\n    Lease End Date : " + rdr.GetString(2) + "\n    Students Allowed? : " + (rdr.GetInt32(3) == 1 ? "Yes" : "No") +
                    "\n    Multiple Occupancy Allowed? : " + (rdr.GetInt32(4) == 1 ? "Yes" : "No") +
                    "\n    No of occupants Allowed : " + rdr.GetInt32(5) + "\n";                
                i += 1;
            }
            conn.Close();
            return data;
        }
    }
}