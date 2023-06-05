using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLLab3; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id ID,A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.Precio, I.ImagenUrl Imagen from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo";

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)lector["ID"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marcas = new Marcas();
                    aux.Marcas.DescripcionMarca = (string)lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.DescripcionCategoria = (string)lector["Categoria"];
                    aux.imagenes = new Imagenes();
                    aux.imagenes.ImagenUrl= (string)lector["Imagen"];
        
                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Articulos> listarConSP()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id ID,A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.Precio, I.ImagenUrl Imagen from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo";
                
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["ID"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marcas = new Marcas();
                    aux.Marcas.DescripcionMarca = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    aux.imagenes = new Imagenes();
                    aux.imagenes.ImagenUrl = (string)datos.Lector["Imagen"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Agregar(Articulos nuevo)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.ejecutarLectura();
                string query = $"INSERT INTO ARTICULOS VALUES (@codigo, @nombre, @descripcion, @marca, @categoria, @precio)";
                accesoDatos.setQuery(query);
                accesoDatos.setearParamento("@codigo", nuevo.Codigo);
                accesoDatos.setearParamento("@nombre", nuevo.Nombre);
                accesoDatos.setearParamento("@descripcion", nuevo.Descripcion);
                accesoDatos.setearParamento("@categoria", nuevo.Categoria.IdCategoria);
                accesoDatos.setearParamento("@marca", nuevo.Marcas.IdMarca);
                accesoDatos.setearParamento("@precio", nuevo.Precio);
                return accesoDatos.executeQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Articulos modificado)
        {

        }
        public void Eliminar(int id) 
        {
            try
            {
                //AccesoDatos datos = new AccesoDatos();
                //datos.setearConsulta("DELETE FROM ARTICULOS WHERE ID = @id");
                //datos.setearParametro("@id", id);
                //datos.ejecutarLectura();
                //MessageBox.Show("¿Eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.warning);
                //Messag;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

