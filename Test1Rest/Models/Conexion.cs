using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test1Rest.Models
{
    public abstract class Conexion
    {
        private string constring = "";
        protected SqlConnection conexion;
        protected SqlCommand command = new SqlCommand();

        public Conexion()
        {
            constring = $"server=DESKTOP-9RA64BM ; database=ApiRest ; integrated security=true";
            conexion = new SqlConnection(constring);
        }

        public void Run()
        {
            using (conexion)
            {
                Connect();
                Select();
                Process();
                Disconnect();
            }
        }

        protected void Connect()
        {
            conexion.Open();
        }

        protected void Disconnect()
        {
            conexion.Close();
        }

        protected abstract void Select();

        protected abstract void Process();
    }
}
