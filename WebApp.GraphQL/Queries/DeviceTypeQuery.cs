using GraphQL.Types;
using GraphQL.Types1;
using GraphQL_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.GraphQL.Queries
{
    public class DeviceTypeQuery : ObjectGraphType
    {
        public DeviceTypeQuery(IDeviceRepository deviceRepository)
        {

            Field<ListGraphType<DeviceTypeType>>(
                "devicetypes",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name="name"}),
                resolve: context => deviceRepository.GetAllDeviceType(context.GetArgument<string>("name")));
        }
    }
}
