using GraphQL.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_DataAccess
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly GraphQL.Database.DeviceDBContext _dbContext;
        public DeviceRepository(GraphQL.Database.DeviceDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Device> GetAllDevice()
        {
            return _dbContext.Device;
        }

        public IEnumerable<Device> GetAllDevice(string Name)
        {
            return _dbContext.Device.Where(d=>d.DeviceName.Contains(Name)).ToList(); 
        }

        public IEnumerable<DeviceType> GetAllDeviceType()
        {
            return _dbContext.DeviceType;
        }

        public IEnumerable<DeviceType> GetAllDeviceType(string name)
        {
            return _dbContext.DeviceType.Where(d => d.DeviceTypeName.Contains(name)).ToList();
        }
    }

   
}
