using Stajyerler.DataAccess.Abstract;
using Stajyerler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stajyerler.DataAccess.Concrete
{
    public class StajyerRepository : IStajyerRepository
    {
        public Stajyer CreateStajyer(Stajyer stajyer)
        {
            using (var stajyerContextDb = new StajyerContextDb())
            {
                stajyerContextDb.Stajyers.Add(stajyer);
                stajyerContextDb.SaveChanges();
                return stajyer;
            }
        }

        public void DeleteStajyer(int id)
        {
            using (var stajyerContextDb = new StajyerContextDb())
            {
                var deleteStajyer = GetStajyerId(id);
                stajyerContextDb.Stajyers.Remove(deleteStajyer);
                stajyerContextDb.SaveChanges();
            }
        }

        public List<Stajyer> GetAllStajyers()
        {
            using (var stajyerContextDb = new StajyerContextDb()) {
                return stajyerContextDb.Stajyers.ToList();
            }
        }

        public Stajyer GetStajyerId(int id)
        {
            using (var stajyerContextDb = new StajyerContextDb())
            {
                return stajyerContextDb.Stajyers.Find(id);
            }
        }

        public Stajyer UpdateStajyer(Stajyer stajyer)
        {
            using (var stajyerContextDb = new StajyerContextDb())
            {
                stajyerContextDb.Stajyers.Update(stajyer);
                stajyerContextDb.SaveChanges();
                return stajyer;
            }
        }
    }
}
