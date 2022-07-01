using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test1Rest.Models
{
    public class LeerPersonas : Conexion
    {
        List<Persona> lista;

        public LeerPersonas()
        {
            lista = new List<Persona>();
        }

        public List<Persona> ListaPersonas()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                lista = null;
            }
            return lista;
        }

        protected override void Process()
        {
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Persona persona = new Persona();
                persona.Id = (int)reader["Id"];
                persona.Nombre = (string)reader["Nombre"];
                persona.Apellido = (string)reader["Apellido"];
                persona.Dni = (int)reader["Dni"];
                persona.Edad = (int)reader["Edad"];

                lista.Add(persona);
            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "sp_leerPersonas";
        }
    }
}
