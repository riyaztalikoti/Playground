using GraphQL.Database;
using GraphQL.Database.Models;
using GraphQL.Types;
using GraphQL_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types1
{
    public class DeviceTypeType : ObjectGraphType<DeviceType>
    {
        public DeviceTypeType(IDeviceRepository repository)
        {
            Field(x => x.DeviceTypeId);
            Field(x => x.DeviceTypeName);
            Field(x => x.UniqueId);
            Field<ListGraphType<DeviceType1>>("device",
                //arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name="name" }),
                resolve: context => repository.GetAllDevice());
        }
    }
}
