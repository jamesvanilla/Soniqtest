using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Dbcon
/// </summary>
public class Dbcon
{
    SqlConnection connection;
    SqlCommand cmd,cmd1;
    DataSet DataSet1;
    SqlDataAdapter adapt;
    DataTable dt;
    SqlTransaction tran;
    SqlDataReader dr;
    
    public Dbcon()
    {
        connection=new SqlConnection();
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ConnectionString;    
       
    }
    public object ExecuteScalar(string query)
    {
        cmd = new SqlCommand(query,connection);
        cmd.Connection.Open();
        object obj = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return obj;
    }
    public DataTable ExecuteAdapter(string query)
    {
        adapt = new SqlDataAdapter(query,connection);
        DataSet1 = new DataSet();
        adapt.Fill(DataSet1);
        dt = DataSet1.Tables[0];
        return dt;  
    }
    public int ExecuteCommand(string query)
    {
        cmd = new SqlCommand(query, connection);
        cmd.Connection.Open();
        int n = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        if (n > 0)
            return n;
        else
            return 0;
    }
    public int ExecuteTrans(string query1, string query2)
    {
        int count = 0;

        try
        {
            connection.Open();
            tran = connection.BeginTransaction();
            cmd = new SqlCommand(query1, connection, tran);
            cmd1 = new SqlCommand(query2, connection, tran);
            count = cmd.ExecuteNonQuery();
            count = count + cmd1.ExecuteNonQuery();
            tran.Commit();
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            tran.Rollback();
        }
        finally
        {
            connection.Close();
        }
        return count;
    }
    public SqlDataReader ExecuteRead(string query)
    {
        cmd = new SqlCommand(query, connection);
        connection.Open();
        dr = cmd.ExecuteReader();
        return dr;
    }
    public DataSet ExecuteQuery(string query)
    {
        adapt = new SqlDataAdapter(query, connection);
        DataSet1 = new DataSet();
        adapt.Fill(DataSet1);
        return DataSet1;
    }
    public int ExecuteSP(string procName, params String[] values)
    {
        cmd = new SqlCommand(procName, connection);
        cmd.CommandType = CommandType.StoredProcedure;
        foreach(string val in values)
        {
            cmd.Parameters.Add(val);
        }
        connection.Open();
        int rs = cmd.ExecuteNonQuery();
        return rs;
    }
}
