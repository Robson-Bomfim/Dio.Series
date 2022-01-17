using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series.Classes
{
    public class SerieRepository : IRepository<Series>
    {
        private string _exception = "ID da série não encontrado! Por favor, tente novamente.";
        List<Series> serieList = new List<Series>();

        public void Add(Series obj)
        {
            serieList.Add(obj);
        }

        public void Delete(int id)
        {
            try
            {
                serieList[id].Deleted = true;
            }
            catch (Exception)
            {
                Console.WriteLine(_exception);
            }
        }

        public Series GetById(int id)
        {
            Series serie = null;
            try
            {
                serie = serieList[id];
            }
            catch (Exception)
            {
                Console.WriteLine(_exception);
            }
            return serie;
        }

        public List<Series> list()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public void Update(int id, Series obj)
        {
            try
            {
                serieList[id] = obj;
            }
            catch (Exception)
            {
                Console.WriteLine(_exception);
            }
        }
    }
}