using Employee_Payroll.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace Employee_Payroll.Repository
{
    public class Employee : IEmployee
    {
        public Employee(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        SqlConnection connection;
        List<GetEmployeeModel> getEmployeeList = new List<GetEmployeeModel>();

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("AddEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    command.Parameters.AddWithValue("@Profile", employeeModel.Profile);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }
        public List<GetEmployeeModel> GetEmployee()
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("GetEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetEmployeeModel employeeModel = new GetEmployeeModel();
                        employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employeeModel.Name = reader["Name"].ToString();
                        employeeModel.Profile = reader["Profile"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.Salary = Convert.ToDouble(reader["Salary"]);
                        employeeModel.StartDate = reader["StartDate"].ToString();
                        this.getEmployeeList.Add(employeeModel);
                    }
                    return this.getEmployeeList;
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateEmployee(GetEmployeeModel employeeModel)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                command.Parameters.AddWithValue("@Name", employeeModel.Name);
                command.Parameters.AddWithValue("@Profile", employeeModel.Profile);
                command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                command.Parameters.AddWithValue("@Department", employeeModel.Department);
                command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
