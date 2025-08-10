using Grpc.Core;
using GrpcExample;

namespace Grpc.Services
{
    public class ChatService : GrpcExample.ChatService.ChatServiceBase
    {
        public override async Task Chat(IAsyncStreamReader<ChatMessage> requestStream, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {
            await foreach (var message in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"[{message.User}] {message.Text}");

                // 立即回覆
                await responseStream.WriteAsync(new ChatMessage
                {
                    User = "Server",
                    Text = $"Received: {message.Text}",
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                });
            }
        }
    }
}
