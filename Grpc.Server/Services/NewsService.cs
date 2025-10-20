using Grpc.Core;
using GrpcExample;

namespace Grpc.Services
{
    public class NewsService : GrpcExample.NewsService.NewsServiceBase
    {
        public override async Task GetNewsStream(NewsRequest request, IServerStreamWriter<NewsReply> responseStream, ServerCallContext context)
        {
            var newsList = new[]
            {
            new NewsReply { Title = "Breaking News 1", Content = "Content 1" },
            new NewsReply { Title = "Breaking News 2", Content = "Content 2" },
            new NewsReply { Title = "Breaking News 3", Content = "Content 3" }
        };

            foreach (var news in newsList)
            {
                await responseStream.WriteAsync(news);
                await Task.Delay(1000); // 模擬延遲
            }
        }
    }
}
