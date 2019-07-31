
using GraphQL;
using WebApp.GraphQL.Queries;
using Graphql = GraphQL.Types;

namespace WebApp.GraphQL.Schema
{   
    public class DeviceSchema : Graphql.Schema
    {
        public DeviceSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<DeviceQuery>();
            //Mutation = resolver.Resolve<PropertyMutation>();
        }
    }
}
