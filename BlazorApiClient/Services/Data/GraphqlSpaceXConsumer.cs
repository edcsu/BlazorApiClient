using GraphQL.Client.Abstractions;

namespace BlazorApiClient.Services.Data
{
    public class GraphqlSpaceXConsumer
    {
        private readonly IGraphQLClient _client;

        public GraphqlSpaceXConsumer(IGraphQLClient client)
        {
            _client = client;
        }
    }
}
