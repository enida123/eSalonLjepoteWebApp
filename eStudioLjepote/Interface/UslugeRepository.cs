using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStudioLjepote.Models;

namespace eStudioLjepote.Interface
{
    public class UslugeRepository : IUsluge
    {
        private readonly _150023Context _appDbContext;

        public UslugeRepository(_150023Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Usluge> Usluge =>_appDbContext.Usluge;

        
            public Usluge GetUslugeById(int uslugaId) => _appDbContext.Usluge.FirstOrDefault(p => p.Id == uslugaId);


        Dictionary<int, List<Ratings>> usluge = new Dictionary<int, List<Ratings>>();


        private double GetSimilarity(List<Ratings> ratings1, List<Ratings> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double numerator = 0, denominator1 = 0, denominator2 = 0;

            for (int i = 0; i < ratings1.Count; i++)
            {
                numerator = ratings1[i].Rating1 * ratings2[i].Rating1;

                denominator1 = ratings1[i].Rating1 * ratings1[i].Rating1 * 1.0;
                denominator2 = ratings2[i].Rating1 * ratings2[i].Rating1 * 1.0;

            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);

            double denominator = denominator1 * denominator2;
            if (denominator == 0)
            {
                return 0;
            }
            else
            {
                return numerator / denominator;
            }

        }



        private void GetProductsData(int uslugaId)
        {
            List<Usluge> aktivneUsluge = _appDbContext.Usluge.Where(x => x.Id != uslugaId).ToList();
            List<Ratings> ratings;

            foreach (Usluge item in aktivneUsluge)
            {
                ratings = _appDbContext.Ratings.Where(x => x.UslugeId == item.Id).OrderBy(x => x.KlijentId).ToList();

                if (ratings.Count > 0)
                {
                    usluge.Add(item.Id, ratings);
                }
            }


        }

        public List<Usluge> GetRecommendedUsluge(int uslugaId)
        {
            GetProductsData(uslugaId);

            List<Ratings> ratingsOfThisUsluga = _appDbContext.Ratings.Where(x => x.UslugeId == uslugaId).OrderBy(x => x.KlijentId).ToList();

            List<Ratings> ratings1 = new List<Ratings>();
            List<Ratings> ratings2 = new List<Ratings>();

            List<Usluge> recommendedUsluge = new List<Usluge>();

            foreach (var item in usluge)
            {
                foreach (Ratings r in ratingsOfThisUsluga)
                {
                    if (item.Value.Where(x => x.KlijentId == r.KlijentId).Count() > 0)
                    {
                        ratings1.Add(r);
                        ratings2.Add(item.Value.Where(x => x.KlijentId == r.KlijentId).First());
                    }
                }

                double similarity = 0;
                similarity = GetSimilarity(ratings1, ratings2);

                if (similarity > 0.6)
                {
                    recommendedUsluge.Add(_appDbContext.Usluge.Where(p => p.Id == item.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }

            return recommendedUsluge;

        }
    }
}
