using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test1Rest.Models.Personas
{
    public class LeerPersonaById : Conexion
    {
        Persona persona;
        int id;

        public LeerPersonaById(int id)
        {
            this.id = id;
            persona = new Persona();
        }

        public Persona GetPersonaById()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                persona = null;
            }
            return persona;
        }

        protected override void Process()
        {
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                persona.Id = (int)reader["Id"];
                persona.Nombre = (string)reader["Nombre"];
                persona.Apellido = (string)reader["Apellido"];
                persona.Dni = (int)reader["Dni"];
                persona.Edad = (int)reader["Edad"];

            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "sp_leerPersonaById";
            command.Parameters.AddWithValue("@Id", id);
        }
    }
}
