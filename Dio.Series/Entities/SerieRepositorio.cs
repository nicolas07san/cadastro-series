using Dio.Series.Interfaces;

namespace Dio.Series.Entities
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            if(listaSerie.Count() > id)
            {
                listaSerie[id] = entidade;
                Console.WriteLine("--- Série atualizada com sucesso. ---");
            }
            else
            {   
                System.Console.WriteLine("---ID não corresponde a nenhuma série existente.---");
            }

        }

        public void Exclui(int id)
        {
            if(listaSerie.Count() > id)
            {
                listaSerie[id].Excluir();
                Console.WriteLine("--- Série excluída com sucesso. ---");
            }
            else
            {
                System.Console.WriteLine("---ID não corresponde a nenhuma série existente.---");
            }
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
            return listaSerie.Count();
        }

        public Serie RetornaPorId(int id)
        {
            if(listaSerie.Count() > id)
            {
                return listaSerie[id];
                Console.WriteLine("--- Série excluída com sucesso. ---");
            }
            else
            {
                System.Console.WriteLine("---ID não corresponde a nenhuma série existente.---");
                return null;
            }
        }
    }
}