using Stajyerler.Business.Abstract;
using Stajyerler.DataAccess;
using Stajyerler.DataAccess.Abstract;
using Stajyerler.DataAccess.Concrete;
using Stajyerler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stajyerler.Business.Concrete
{
    public class StajyerManager : IStajyerService
    {
        private IStajyerRepository _stajyerRepository;
        public StajyerManager()
        {
            _stajyerRepository = new StajyerRepository();
        }
        public Stajyer CreateStajyer(Stajyer stajyer)
        {
            return _stajyerRepository.CreateStajyer(stajyer);
        }

        public void DeleteStajyer(int id)
        {
            _stajyerRepository.DeleteStajyer(id);
        }

        public List<Stajyer> GetAllStajyers()
        {
            return _stajyerRepository.GetAllStajyers();
        }

        public Stajyer GetStajyerId(int id)
        {
            if (id>0) 
            {
                return _stajyerRepository.GetStajyerId(id);
            }
            throw new Exception("ID CANNOT BE BELOW 1");
           
        }

        public Stajyer UpdateStajyer(Stajyer stajyer)
        {
            return _stajyerRepository.UpdateStajyer(stajyer);
        }
    }
}
