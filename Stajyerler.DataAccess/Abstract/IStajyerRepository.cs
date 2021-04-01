using Stajyerler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stajyerler.DataAccess.Abstract
{
    public interface IStajyerRepository
    {
        List<Stajyer> GetAllStajyers();
        Stajyer GetStajyerId(int id);
        Stajyer CreateStajyer(Stajyer stajyer);
        Stajyer UpdateStajyer(Stajyer stajyer);
        void DeleteStajyer(int id);

    }
}
