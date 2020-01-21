using MAA.Basecore.Data.ADONET;
using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAA.Basecore.Data.Grup92MicroORM
{
    public class Initializer<T> where T : BaseSqlHelper
    {
        public void CreateDatabase()
        {
            //Data Source=.; Initial Catalog=TestDB; Integrated Security=true
            var helper = (BaseSqlHelper)Activator.CreateInstance(typeof(T));
            var dbName = helper.ConnectionString.Split(';')[1].Split('=')[1];
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=master; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("create database " + dbName, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void CreateTable<TModel>() where TModel : BaseModel
        {
            Type type = typeof(TModel);
            BaseSqlHelper helper = (BaseSqlHelper)Activator.CreateInstance(typeof(T));
            string cmdText = "Create table " + type.Name + "(";
            foreach (var p in type.GetProperties())
            {
                cmdText += p.Name + " " + TypeResolver(p,50,false);
            }
            cmdText = cmdText.Substring(0, cmdText.Length - 1)+")";
            helper.ExecuteCommand(cmdText);
        }
        private string TypeResolver(PropertyInfo p, int length, bool nullable)
        {
            string result = "";
            if (p.PropertyType==typeof(int))
            {
                result = "int";
            }
            else if (p.PropertyType == typeof(string))
            {
                result = "nvarchar(" + length + ")";
            }
            result += nullable ? "," : " not null,";
            return result;
        }
    }
}
