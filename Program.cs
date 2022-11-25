using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace ConexionBaseDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String coneectionString = 
                "Server=sql.bsite.net\\MSSQL2016;" +
                "Database=fedecipo_C#Coder;" +
                "User Id=fedecipo_C#Coder;" +
                "Password=Hearmyroar14;";
            try
            {
                Console.WriteLine("Creando la conexión!");
                Console.WriteLine(" ");
                using (SqlConnection sqlConnection = new SqlConnection(coneectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                    {
                        Console.WriteLine("Abriendo la conexión!");
                        Console.WriteLine(" ");
                        sqlConnection.Open();
                        List<Usuario> lista = new List<Usuario>();
                        List<Producto> lista2 = new List<Producto>();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Usuario usuario = new Usuario();
                                    usuario.Id = long.Parse(reader["Id"].ToString());
                                    usuario.Nombre = reader["Nombre"].ToString();
                                    usuario.Apellido = reader["Apellido"].ToString();
                                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                    usuario.Contrasenia = reader["Contraseña"].ToString();
                                    usuario.Mail = reader["Mail"].ToString();
                                    lista.Add(usuario);
                                }
                                Console.WriteLine("Imprimiendo lista de Usuarios");
                                Console.WriteLine(" ");
                                foreach (Usuario usuario in lista)
                                {
                                    Console.WriteLine("Id: " + usuario.Id);
                                    Console.WriteLine("Nomnbre: " + usuario.Nombre);
                                    Console.WriteLine("Apellido: " + usuario.Apellido);
                                    Console.WriteLine("Nombre de Usuario: " + usuario.NombreUsuario);
                                    Console.WriteLine("Contraseña: " + usuario.Contrasenia);
                                    Console.WriteLine("Email: " + usuario.Mail);
                                    Console.WriteLine(" ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No tiene registros");
                                Console.WriteLine(" ");
                            }
                        }
                        //Console.WriteLine("Cerrando la conexión!");
                        //sqlConnection.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                    {
                        //Console.WriteLine("Abriendo la conexión!");
                        //sqlConnection.Open();
                        List<Producto> lista2 = new List<Producto>();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Producto producto = new Producto();
                                    producto.Id = long.Parse(reader["Id"].ToString());
                                    producto.Descripciones = reader["Descripciones"].ToString();
                                    producto.Costo = float.Parse(reader["Costo"].ToString());
                                    producto.PrecioVenta = float.Parse(reader["PrecioVenta"].ToString());
                                    producto.Stock = int.Parse(reader["Stock"].ToString());
                                    producto.IdUsuario = long.Parse(reader["IdUsuario"].ToString());
                                    lista2.Add(producto);

                                }
                                Console.WriteLine("Imprimiendo lista de Productos");
                                Console.WriteLine(" ");
                                foreach (Producto producto in lista2)
                                {
                                    Console.WriteLine("Id: " + producto.Id);
                                    Console.WriteLine("Descripciones: " + producto.Descripciones);
                                    Console.WriteLine("Costo: " + producto.Costo);
                                    Console.WriteLine("Precio de Venta: " + producto.PrecioVenta);
                                    Console.WriteLine("Stock: " + producto.Stock);
                                    Console.WriteLine("Id Usuario: " + producto.IdUsuario);
                                    Console.WriteLine(" ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No tiene registros");
                                Console.WriteLine(" ");
                            }
                        }

                        Console.WriteLine("Cerrando la conexión!");
                        Console.WriteLine(" ");
                        sqlConnection.Close();
                    }
                }  
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CreandoConsultas()
        {
            String coneectionString =
                "Server=sql.bsite.net\\MSSQL2016;" +
                "Database=fedecipo_C#Coder;" +
                "User Id=fedecipo_C#Coder;" +
                "Password=Hearmyroar14;";
            try
            {
                Console.WriteLine("Creando la conexión!");
                using (SqlConnection sqlConnection = new SqlConnection(coneectionString))
                {
                    //FORMA DESCONECTADA DEL SERVIDOR
                    /*SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Usuario", sqlConnection);
                    sqlConnection.Open();

                    DataSet dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);*/

                    //FORMA CONECTADA AL SERVIDOR
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE Id = @Id", sqlConnection))
                    {
                        SqlParameter sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "Id";
                        sqlParameter.DbType = System.Data.DbType.Int32;
                        sqlParameter.Value = 1;
                        cmd.Parameters.Add(sqlParameter);
                        Console.WriteLine("Abriendo la conexión!");
                        sqlConnection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(reader.GetInt64(0));
                                    Console.WriteLine(reader.GetString(1));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No tiene registros");
                            }
                        }
                    }
                    Console.WriteLine("Cerrando la conexión!");
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}