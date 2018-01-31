using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp9.db_csDataSetTableAdapters;

namespace WindowsFormsApp9
{
    class Controler
    {
        
        public bool checkLogin(string txtName, string txtPass, db_csDataSet dts)
        {
            DataTable dt = new DataTable();

            if(dts.user.Count() > 0)
            {
                dt = dts.Tables["User"];
                var q = from qds in dt.AsEnumerable()
                        where qds.Field<string>("user_id").ToString().Trim() == txtName.ToString().Trim() &&
                        qds.Field<string>("user_password").ToString().Trim() == txtPass.ToString().Trim()
                        select new
                        {
                            userID = qds.Field<string>("user_id").ToString(),
                            userpass = qds.Field<string>("user_password").ToString()
                        };
                if (q.Count() <= 0)
                {
                    return false;
                }
                else { return true; }
            }
            else { return false; }
            
        }
    }
}
