// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: historyservice.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Dnc.GrpcService.Protocol {
  /// <summary>
  /// 数学运算服务 
  /// </summary>
  public static partial class HistoryService
  {
    static readonly string __ServiceName = "dnc.grpcService.protocol.HistoryService";

    static readonly grpc::Marshaller<global::Dnc.GrpcService.Protocol.GetHistoriesReq> __Marshaller_GetHistoriesReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Dnc.GrpcService.Protocol.GetHistoriesReq.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Dnc.GrpcService.Protocol.GetHistoriesRsp> __Marshaller_GetHistoriesRsp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Dnc.GrpcService.Protocol.GetHistoriesRsp.Parser.ParseFrom);

    static readonly grpc::Method<global::Dnc.GrpcService.Protocol.GetHistoriesReq, global::Dnc.GrpcService.Protocol.GetHistoriesRsp> __Method_GetHistories = new grpc::Method<global::Dnc.GrpcService.Protocol.GetHistoriesReq, global::Dnc.GrpcService.Protocol.GetHistoriesRsp>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetHistories",
        __Marshaller_GetHistoriesReq,
        __Marshaller_GetHistoriesRsp);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Dnc.GrpcService.Protocol.HistoryserviceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of HistoryService</summary>
    public abstract partial class HistoryServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Dnc.GrpcService.Protocol.GetHistoriesRsp> GetHistories(global::Dnc.GrpcService.Protocol.GetHistoriesReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for HistoryService</summary>
    public partial class HistoryServiceClient : grpc::ClientBase<HistoryServiceClient>
    {
      /// <summary>Creates a new client for HistoryService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public HistoryServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for HistoryService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public HistoryServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected HistoryServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected HistoryServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Dnc.GrpcService.Protocol.GetHistoriesRsp GetHistories(global::Dnc.GrpcService.Protocol.GetHistoriesReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHistories(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Dnc.GrpcService.Protocol.GetHistoriesRsp GetHistories(global::Dnc.GrpcService.Protocol.GetHistoriesReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetHistories, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Dnc.GrpcService.Protocol.GetHistoriesRsp> GetHistoriesAsync(global::Dnc.GrpcService.Protocol.GetHistoriesReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHistoriesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Dnc.GrpcService.Protocol.GetHistoriesRsp> GetHistoriesAsync(global::Dnc.GrpcService.Protocol.GetHistoriesReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetHistories, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override HistoryServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new HistoryServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(HistoryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetHistories, serviceImpl.GetHistories).Build();
    }

  }
}
#endregion