using EMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace EMS.DbUtility
{
    public class EmpRepository
    {

        private readonly string sqlconn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


        public List<Employees> GetEmployees()
        {
            List<Employees> list = new List<Employees>();
            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Employees
                    {
                        EmpId = Convert.ToInt32(rdr["EMpId"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        DOB = Convert.ToDateTime(rdr["DOB"].ToString()),
                        EmailId = rdr["EmailId"].ToString(),
                        ContactNo = rdr["ContactNo"].ToString(),
                        Address = rdr["Address"].ToString()

                    });
                }
            }
            return list;
        }
        public Employees GetById(int? id)
        {
            Employees emp = new Employees();
            try
            {
                using (SqlConnection con = new SqlConnection(sqlconn))
                {
                    SqlCommand cmd = new SqlCommand("select * from Employees Where EmpId=@EmpId", con);
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                        emp.FirstName = rdr["FirstName"].ToString();
                        emp.LastName = rdr["LastName"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.DOB = Convert.ToDateTime(rdr["DOB"]);
                        emp.EmailId = rdr["EmailId"].ToString();
                        emp.ContactNo = rdr["ContactNo"].ToString();
                        emp.Address = rdr["Address"].ToString();



                    }
                }
            }catch(Exception ex)
            {
                throw ex.InnerException;
            }
            return emp;
        }



        public void AddEmployee(Employees emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sqlconn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FirstName, LastName, Gender,DOB ,EmailId,ContactNo,Address) VALUES (@FirstName, @LastName,@Gender,@DOB ,@EmailId ,@ContactNo,@Address )", con);
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                    cmd.Parameters.AddWithValue("@EmailId ", emp.EmailId);
                    cmd.Parameters.AddWithValue("@ContactNo ", emp.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", emp.Address);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            { 
                throw ex.InnerException; 
            }
        }

        public void UpdateEmployee(Employees emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sqlconn))
                {
                    string query = ("UPDATE Employees SET  FirstName=@FirstName, LastName=@LastName, Gender=@Gender, DOB=@DOB," +
                        " EmailId=@EmailId, ContactNo=@ContactNo, Address=@Address WHERE EmpId=@EmpId");
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                    cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                    cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
                    cmd.Parameters.AddWithValue("@ContactNo", emp.ContactNo);
                    cmd.Parameters.AddWithValue("@Address", emp.Address);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception  ex)
            {
                throw ex.InnerException;
            }
        }


        public void DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sqlconn))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpId=@EmpId", con);
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

