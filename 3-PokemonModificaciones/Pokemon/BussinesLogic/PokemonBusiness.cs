using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLogic;
using Dominio;

namespace BusinessLogic
{
    public class PokemonBusiness
    {

        //Consulta a base de datos, y leerlo, traerlos.
        public List<Pokemon> Listar()
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("select P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad  from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id And P.IdDebilidad = D.Id");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Pokemon auxPokemon = new Pokemon();
                    auxPokemon.Numero = (int)datos.Lector["Numero"];
                    auxPokemon.Nombre = (string)datos.Lector["Nombre"];
                    auxPokemon.Descripcion = (string)datos.Lector["Descripcion"];
                    if(!(datos.Lector["UrlImagen"] is DBNull))    
                        auxPokemon.UrlImagen = (string)datos.Lector["UrlImagen"];
                    auxPokemon.Tipo = new Elemento();
                    auxPokemon.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    auxPokemon.Debilidad = new Elemento();
                    auxPokemon.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    listaPokemones.Add(auxPokemon);
                }

                return listaPokemones;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Pokemon newPokemon)
        {

            DataAccess data = new DataAccess();
            
            try
            {
                data.setearConsulta("insert into POKEMONS (Numero,Nombre, Descripcion, UrlImagen, idTipo, idDebilidad,Activo) values (@Numero ,@Nombre, @Descripcion, @UrlImagen, @Tipo, @Debilidad, 1)");
                data.setearParametros("@Numero", newPokemon.Numero);
                data.setearParametros("@Nombre", newPokemon.Nombre);
                data.setearParametros("@Descripcion", newPokemon.Descripcion);
                data.setearParametros("@UrlImagen", newPokemon.UrlImagen);
                data.setearParametros("@Tipo", newPokemon.Tipo.Id);
                data.setearParametros("@Debilidad", newPokemon.Debilidad.Id);

                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                data.cerrarConexion();
            }
        }
    }
}
