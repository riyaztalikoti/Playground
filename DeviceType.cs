using GraphQL.Database.Models;
using GraphQL.Types;
using System;

namespace GraphQL.Types1
{
    public class DeviceType1 : ObjectGraphType<Device>
    {
        public DeviceType1()
        {
            Field(x => x.Id);
            Field(x => x.DeviceName);
            Field(x => x.Version);
        }
    }
}
