using Grpc.Core;
using GrpcExample;

namespace Grpc.Services
{
    public class UploadService : GrpcExample.UploadService.UploadServiceBase
    {
        public override async Task<UploadResult> UploadFiles(IAsyncStreamReader<FileChunk> requestStream, ServerCallContext context)
        {
            int totalChunks = 0;
            string? fileName = null;

            await foreach (var chunk in requestStream.ReadAllAsync())
            {
                fileName ??= chunk.FileName;
                totalChunks++;
                // 這裡可將 chunk.Data 存檔
            }

            return new UploadResult
            {
                Success = true,
                Message = $"Received {totalChunks} chunks for {fileName}"
            };
        }
    }
}
