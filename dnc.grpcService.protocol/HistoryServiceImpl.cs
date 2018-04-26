using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dnc.GrpcService.Protocol;
using Grpc.Core;

namespace dnc.grpcService.protocol
{
    public class HistoryServiceImpl : HistoryService.HistoryServiceBase
    {
        public override Task<GetHistoriesRsp> GetHistories(GetHistoriesReq request, ServerCallContext context)
        {
            return base.GetHistories(request, context);
        }
    }
}
