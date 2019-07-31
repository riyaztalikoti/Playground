using GraphQL.Database.Models;
using System.Collections.Generic;

namespace GraphQL_DataAccess
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetAllDevice();
        IEnumerable<DeviceType> GetAllDeviceType();

        IEnumerable<DeviceType> GetAllDeviceType(string name);

        IEnumerable<Device> GetAllDevice(string Name);
    }
}
