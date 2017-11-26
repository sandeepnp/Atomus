using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using AtomusFileUpload.Models;

namespace AtomusFileUpload.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["AtomusDB"].ToString();
        }

        public bool UploadEmployees(HttpPostedFileBase uploadedFile)
        {
            try
            {
                // Read employees from file
                var employees = ReadEmployeesFromFile(uploadedFile);

                if (employees != null)
                {
                    // Write employees to DB
                    foreach (var employee in employees)
                    {
                        AddEmployee(employee);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                
                return false;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                // Perform validations etc. here before the employee record is created in the DB
                Create(employee);

                return true;
            }
            catch (Exception ex)
            {
                // Log exception here

                return false;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return Get();
            }
            catch (Exception)
            {
                // Log exception here

                return null;
            }
        }

        private IEnumerable<Employee> Get()
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_GetEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Company = reader.GetString(reader.GetOrdinal("Company")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            County = reader.GetString(reader.GetOrdinal("County")),
                            PostCode = reader.GetString(reader.GetOrdinal("Postcode")),
                            Phone1 = reader.GetString(reader.GetOrdinal("Phone1")),
                            Phone2 = reader.GetString(reader.GetOrdinal("Phone2")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Web = reader.GetString(reader.GetOrdinal("Website"))
                        };

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        private IEnumerable<Employee> ReadEmployeesFromFile(HttpPostedFileBase uploadedFile)
        {
            IList<Employee> employees = new List<Employee>();

            using (StreamReader streamReader = new StreamReader(uploadedFile.InputStream))
            {
                // Read the first line. 
                // Assumption: The first line will always be a header.
                if (streamReader.ReadLine() == null)
                {
                    streamReader.Close();
                    return null;
                }

                string employeeLine;

                // Read lines of employee data from the uploaded csv file
                while ((employeeLine = streamReader.ReadLine()) != null)
                {
                    string[] values = employeeLine.Split(new char[] {','});

                    // Assumption: The order of fields is fixed.
                    var employee = new Employee
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Company = values[2],
                        Address = values[3],
                        City = values[4],
                        County = values[5],
                        PostCode = values[6],
                        Phone1 = values[7],
                        Phone2 = values[8],
                        Email = values[9],
                        Web = values[10]
                    };

                    employees.Add(employee);
                }

                streamReader.Close();
            }

            return employees;
        }
        
        private void Create(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspCreateEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Company", employee.Company);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@County", employee.County);
                cmd.Parameters.AddWithValue("@Postcode", employee.PostCode);
                cmd.Parameters.AddWithValue("@Phone1", employee.Phone1);
                cmd.Parameters.AddWithValue("@Phone2", employee.Phone2);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Website", employee.Web);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}