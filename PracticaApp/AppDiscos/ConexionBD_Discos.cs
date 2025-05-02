using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppDiscos
{
    class ConexionBD_Discos
    {
        public List<Discos> ListaConex() //este metodo devolvera una lista de pokemon
        {
            List<Discos> lista = new List<Discos>();//creamos la lista
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS;database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo,FechaLanzamiento,CantidadCanciones,UrlImagenTapa, E.Descripcion Genero,P.Descripcion Edition from Discos D, ESTILOS E, TIPOSEDICION P where E.Id=D.IdTipoEdicion and P.Id= D.IdTipoEdicion";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Genero = new Estilos();
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Edition = new TiposEdicion();
                    aux.Edition.Descripcion = (string)lector["Edition"];





                    lista.Add(aux);
                }
                conexion.Close();

                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }




            


        }
    }
}
