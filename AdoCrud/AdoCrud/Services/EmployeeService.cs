using EDMCrud.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AdoCrud.Services
{
    public class EmployeeService
    {
        SqlConnection cn;
        public EmployeeService()
        {
            cn = new SqlConnection("Data Source=DESKTOP-52IAUQR;Initial Catalog=Company;Integrated Security=True");
        }
        public List<tblemployee> GetAllEmployees()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblemployee", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<tblemployee> li = new List<tblemployee>();
            foreach (DataRow item in dt.Rows)
            {
                li.Add(new tblemployee
                {
                    emp_id = Convert.ToInt32(item["emp_id"].ToString()),
                    salary = Convert.ToInt32(item["salary"].ToString()),
                    f_name = item["f_name"].ToString(),
                    email = item["email"].ToString(),
                    mobile = item["mobile"].ToString(),
                    password = item["password"].ToString(),
                    address = item["address"].ToString(),
                    gender = item["gender"].ToString()
                });
            }
            return li;
        }
        public tblemployee GetEmployeeById(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblemployee where emp_id=" + id, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            tblemployee li = new tblemployee();

            li.emp_id = Convert.ToInt32(dt.Rows[0]["emp_id"].ToString());
            li.salary = Convert.ToInt32(dt.Rows[0]["salary"].ToString());
            li.f_name = dt.Rows[0]["f_name"].ToString();
            li.email = dt.Rows[0]["email"].ToString();
            li.mobile = dt.Rows[0]["mobile"].ToString();
            li.password = dt.Rows[0]["password"].ToString();
            li.address = dt.Rows[0]["address"].ToString();
            li.gender = dt.Rows[0]["gender"].ToString();

            return li;
        }

        public void AddEmployee(tblemployee obj)
        {
            SqlCommand cmd = new SqlCommand("insert into tblemployee (f_name,salary,email,mobile,password,address,gender) values (@fn,@sl,@em,@mb,@ps,@ad,@gn)", cn);
            cmd.Parameters.AddWithValue("@fn", obj.f_name);
            cmd.Parameters.AddWithValue("@sl", obj.salary);
            cmd.Parameters.AddWithValue("@em", obj.email);
            cmd.Parameters.AddWithValue("@mb", obj.mobile);
            cmd.Parameters.AddWithValue("@ps", obj.password);
            cmd.Parameters.AddWithValue("@ad", obj.address);
            cmd.Parameters.AddWithValue("@gn", obj.gender);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void UpdateEmployee(tblemployee obj)
        {
            SqlCommand cmd = new SqlCommand("update tblemployee set f_name=@fn,salary=@sl,email=@em,mobile=@mb,password=@ps,address=@ad,gender=@gn where emp_id=@id", cn);
            cmd.Parameters.AddWithValue("@fn", obj.f_name);
            cmd.Parameters.AddWithValue("@id", obj.emp_id);
            cmd.Parameters.AddWithValue("@sl", obj.salary);
            cmd.Parameters.AddWithValue("@em", obj.email);
            cmd.Parameters.AddWithValue("@mb", obj.mobile);
            cmd.Parameters.AddWithValue("@ps", obj.password);
            cmd.Parameters.AddWithValue("@ad", obj.address);
            cmd.Parameters.AddWithValue("@gn", obj.gender);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        
        public void DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from tblemployee where emp_id=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}