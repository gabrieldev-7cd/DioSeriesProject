using System;
using System.Collections.Generic;
using DioSeriesLib.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioSeriesLib
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

        //Itera sobre a lista de series e retorna apenas
        //as resultantes da busca pelo id de Gênero;
        public List<Serie> BuscaPorGenero(int idGenero)
        {
            List<Serie> buscaResult = new List<Serie>();

            for(int i = 0; i  < listaSerie.Count; i++ )
            {
                if( Enum.GetName(typeof(Genero),listaSerie[i].retornaGenero() )  == Enum.GetName(typeof(Genero), idGenero))
                {
                    buscaResult.Add(listaSerie[i]);
                }
             
            }

            return buscaResult;
        }
 
    }
}
