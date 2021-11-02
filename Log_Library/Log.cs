using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace Log_Library
{
    public class Log : ILog<LogModel>
    {
        public void Insert(LogModel logModel)
        {
            SqlCommand com = DbConnection.GetCommand("Insert into dbo.LOG(MODAL,DESCRIPTION)values(@MODAL,@DESCRIPTION)");

            com.Parameters.AddWithValue("@MODAL", logModel.MODAL);
            com.Parameters.AddWithValue("@DESCRIPTION", logModel.DESCRIPTION);
            com.Connection.Open();
            com.ExecuteScalar();
            com.Connection.Close();
        }

        public List<LogModel> SelectAll()
        {
            SqlCommand Com = DbConnection.GetCommand("select * From LOG");
            List<LogModel> Plist = new List<LogModel>();
            Com.Connection.Open();
            SqlDataReader dr = Com.ExecuteReader();
            while (dr.Read())
            {
                Plist.Add(new LogModel()
                {
                    ID = Convert.ToInt32(dr["ID"].ToString()),
                    MODAL = dr["MODAL"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()

                });
            }
            Com.Connection.Close();
            return Plist;
        }

        public LogModel SelectById(string Id)
        {
            SqlCommand com = DbConnection.GetCommand("select * from LOG where ID=@ID");
            com.Parameters.AddWithValue("@ID", Id);
            com.Connection.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                return new LogModel()
                {
                    ID = Convert.ToInt32(dr["ID"].ToString()),
                    MODAL = dr["MODAL"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                };

            }
            else return null;
        }

        public void Update(LogModel logModel)
        {
            SqlCommand com = DbConnection.GetCommand("update LOG set MODAL=@MODAL,DESCRIPTION=@DESCRIPTION where ID=@ID");
            com.Parameters.AddWithValue("@ID", logModel.ID);
            com.Parameters.AddWithValue("@MODAL", logModel.MODAL);
            com.Parameters.AddWithValue("@DESCRIPTION", logModel.DESCRIPTION);

            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public void Delete(LogModel logModel)
        {
            SqlCommand com = DbConnection.GetCommand("Delete LOG where ID=@ID");
            com.Parameters.AddWithValue("@ID", logModel.ID);
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }
    }
}
