using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskIO.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string email { get; set; }
        public DateTime? fechaValidacion { get; set; }

        public void Guardar()
        {
            var con = ConexionDb.ObtenerConexion();
            string sql = "";
            if (this.id > 0)
            {
                //Consulta de manipulacion de datos para un UPDATE
                sql = "update usuario set usuario=@usuaro,contrasena=@contrasena,nombre=@nombre,apellido_paterno=@apellido_paterno,apellido_materno=@apellido_paterno,email=@email where id=@id";
            }
            else
            {
                //Consulta de manipulacion de datos para un INSERT
                sql = "insert into usuario (usuario,contrasena,nombre,apellido_paterno,apellido_materno,email) values(@usuario,@contrasena,@nombre,@apellido_paterno,@apellido_materno,@email)";
            }

            using (MySqlCommand cmd = new MySqlCommand(sql, con))

            {
                cmd.Parameters.AddWithValue("@usuario", this.usuario);
                cmd.Parameters.AddWithValue("@contrasena", this.contrasena);
                cmd.Parameters.AddWithValue("@nombre", this.nombre);
                cmd.Parameters.AddWithValue("@apellido_paterno", this.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apellido_materno", this.apellidoMaterno);
                cmd.Parameters.AddWithValue("@email", this.email);
                if (this.id > 0)
                {
                    cmd.Parameters.AddWithValue("@id", this.id);
                }
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

      
    }
}
