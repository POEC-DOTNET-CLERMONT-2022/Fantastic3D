using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Fantastic3D.DataManager
{
    /// <summary>
    /// A DataManager creating fake data for test purposes.
    /// </summary>
    public class MockDataManager<TTransfered, TPersistant> : IDataManager<TTransfered, TPersistant>
        where TTransfered : IManageable, new()
        where TPersistant : IManageable, new()
    {
        private List<TPersistant> _persistantData;

        public MockDataManager()
        {
            _persistantData = new List<TPersistant>();
        }

        public void PopulateMockData(int numberOfValues)
        {
            var faker = new Faker("fr");

            var user = new UserDto()
            {

            }
            _persistantData.
        }
        public int Count()
        {
            return 0;
        }


        public Task AddAsync(TTransfered objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TTransfered>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TTransfered> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, TTransfered objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
