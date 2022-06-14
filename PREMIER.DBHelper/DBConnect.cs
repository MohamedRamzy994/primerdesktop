using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections;

namespace PREMIER.dbhelper
{
    public class DBConnect
    {
        private string connectionString = String.Empty;
        public DBConnect()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        }
        public IEnumerable ExecuteQuery<T>(string command)
        {
            IEnumerable result;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                result = connection.Query<T>(command);

                connection.Close();
            }

            return result;
        }
        public void ExecuteStoredProcedure(string procedureName)
        {
            ExecuteStoredProcedure(procedureName, null);
        }
        public void ExecuteStoredProcedure(string procedureName, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (parameters != null)
                    connection.Query(procedureName, parameters, commandType: CommandType.StoredProcedure);
                else
                    connection.Query(procedureName, commandType: CommandType.StoredProcedure);

                connection.Close();
            }
        }
        public bool ExecuteStoredProcedureReturnValue(string procedureName, DynamicParameters parameters)
        {
            bool Authenticated;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (parameters != null)
                Authenticated= connection.ExecuteScalar<bool>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                else
                  Authenticated=  connection.ExecuteScalar<bool>(procedureName, commandType: CommandType.StoredProcedure);

                connection.Close();

               
            }
            return Authenticated;
        }
        public int ExecuteStoredProcedureReturnValueInt(string procedureName, DynamicParameters parameters)
        {
            int ProductID;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (parameters != null)
                    ProductID = connection.ExecuteScalar<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                else
                    ProductID = connection.ExecuteScalar<int>(procedureName, commandType: CommandType.StoredProcedure);

                connection.Close();


            }
            return ProductID;
        }
        public IEnumerable ExecuteStoredProcedure<T>(string procedureName)
        {
            return ExecuteStoredProcedure<T>(procedureName, null);
        }
        public IEnumerable ExecuteStoredProcedure<T>(string procedureName, DynamicParameters parameters)
        {
            IEnumerable result;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (parameters != null)
                    result = connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                else
                    result = connection.Query<T>(procedureName, commandType: CommandType.StoredProcedure);

                connection.Close();
            }

            return result;
        }
        public IList<IEnumerable> ExecuteStoredProcedureMultiple(string procedureName, IList<Type> classList)
        {
            return ExecuteStoredProcedureMultiple(procedureName, null, classList);
        }
        public IList<IEnumerable> ExecuteStoredProcedureMultiple(string procedureName, DynamicParameters parameters, IList<Type> classList)
        {
            var resultList = new List<IEnumerable>();
            SqlMapper.GridReader resultSet;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (parameters != null)
                    resultSet = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure);
                else
                    resultSet = connection.QueryMultiple(procedureName, commandType: CommandType.StoredProcedure);

                for (int i = 0; i < classList.Count; i++)
                    resultList.Add(resultSet.Read(classList[i]).ToList());

                connection.Close();
            }

            return resultList;
        }

        public void FillTable(DataSet appDataset, string appTableName, string spName, IDictionary<string, object> parameters)
        {
            SqlConnection oConTalentNowJobPortalDB = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = oConTalentNowJobPortalDB;
            sqlCommand.CommandText = spName;
            foreach (var param in parameters)
            {
                //sqlCommand.Parameters.Add(param);
                sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            SqlDataAdapter oDadTalentNowJobPortal = new SqlDataAdapter();
            oDadTalentNowJobPortal.SelectCommand = sqlCommand;
            try
            {
                oConTalentNowJobPortalDB.Open();
                oDadTalentNowJobPortal.Fill(appDataset, appTableName);
            }
            catch (Exception)
            {
            }
            finally
            {
                oConTalentNowJobPortalDB.Close();
                sqlCommand.Dispose();
                oDadTalentNowJobPortal.Dispose();
            }
        }

        public DataTable FillTable(string appTableName, string spName, IDictionary<string, object> parameters)
        {
            SqlConnection oConTalentNowJobPortalDB = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader appDataReader = null;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = oConTalentNowJobPortalDB;
            sqlCommand.CommandText = spName;

            foreach (var param in parameters)
            {
                sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            SqlDataAdapter oDadTalentNowJobPortal = new SqlDataAdapter();
            oDadTalentNowJobPortal = new SqlDataAdapter();
            oDadTalentNowJobPortal.SelectCommand = sqlCommand;

            DataTable dt1 = new DataTable();
            try
            {
                oConTalentNowJobPortalDB.Open();
                appDataReader = sqlCommand.ExecuteReader();
                dt1.Load(appDataReader);
            }
            catch (Exception ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<p style='font-size: 11px; font-weight: normal; line-height: 18px;'>");
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }
                sb.Append("</p>");

                string s = "<p><b>spName: </b>" + spName + "</p>" +
                                                    "<p><b>parameters: </b>" + sb.ToString() + "</p>";
                throw ex;

            }
            finally
            {
                oConTalentNowJobPortalDB.Close();
                sqlCommand.Dispose();
                oConTalentNowJobPortalDB.Dispose();
                oDadTalentNowJobPortal.Dispose();
            }

            return dt1;
        }
    }
}
