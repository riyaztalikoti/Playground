using GraphQL.Types;
using GraphQL.Types1;
using GraphQL_DataAccess;

namespace WebApp.GraphQL.Queries
{
    public class DeviceQuery : ObjectGraphType
    {
        public DeviceQuery(IDeviceRepository deviceRepository)
        {

            Field<ListGraphType<DeviceType1>>(
                "properties",
                resolve: context => deviceRepository.GetAllDevice());


            Field<ListGraphType<DeviceTypeType>>(
              "devicetypes",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => deviceRepository.GetAllDeviceType(context.GetArgument<string>("name")));
        // arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
        //resolve: context => deviceRepository.GetAllDeviceType());

        }
        }
}

