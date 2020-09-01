package com.etf.systemevents;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
        value = "by gRPC proto compiler (version 1.15.0)",
        comments = "Source: petFriend.proto")
public final class SystemEventsGrpc {

  private SystemEventsGrpc() {}

  public static final String SERVICE_NAME = "SystemEvents";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<com.etf.systemevents.PetFriend.Request,
          com.etf.systemevents.PetFriend.Response> getLogActionMethod;

  @io.grpc.stub.annotations.RpcMethod(
          fullMethodName = SERVICE_NAME + '/' + "logAction",
          requestType = com.etf.systemevents.PetFriend.Request.class,
          responseType = com.etf.systemevents.PetFriend.Response.class,
          methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.etf.systemevents.PetFriend.Request,
          com.etf.systemevents.PetFriend.Response> getLogActionMethod() {
    io.grpc.MethodDescriptor<com.etf.systemevents.PetFriend.Request, com.etf.systemevents.PetFriend.Response> getLogActionMethod;
    if ((getLogActionMethod = SystemEventsGrpc.getLogActionMethod) == null) {
      synchronized (SystemEventsGrpc.class) {
        if ((getLogActionMethod = SystemEventsGrpc.getLogActionMethod) == null) {
          SystemEventsGrpc.getLogActionMethod = getLogActionMethod =
                  io.grpc.MethodDescriptor.<com.etf.systemevents.PetFriend.Request, com.etf.systemevents.PetFriend.Response>newBuilder()
                          .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
                          .setFullMethodName(generateFullMethodName(
                                  "SystemEvents", "logAction"))
                          .setSampledToLocalTracing(true)
                          .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  com.etf.systemevents.PetFriend.Request.getDefaultInstance()))
                          .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  com.etf.systemevents.PetFriend.Response.getDefaultInstance()))
                          .setSchemaDescriptor(new SystemEventsMethodDescriptorSupplier("logAction"))
                          .build();
        }
      }
    }
    return getLogActionMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static SystemEventsStub newStub(io.grpc.Channel channel) {
    return new SystemEventsStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static SystemEventsBlockingStub newBlockingStub(
          io.grpc.Channel channel) {
    return new SystemEventsBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static SystemEventsFutureStub newFutureStub(
          io.grpc.Channel channel) {
    return new SystemEventsFutureStub(channel);
  }

  /**
   */
  public static abstract class SystemEventsImplBase implements io.grpc.BindableService {

    /**
     */
    public void logAction(com.etf.systemevents.PetFriend.Request request,
                          io.grpc.stub.StreamObserver<com.etf.systemevents.PetFriend.Response> responseObserver) {
      asyncUnimplementedUnaryCall(getLogActionMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
              .addMethod(
                      getLogActionMethod(),
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.etf.systemevents.PetFriend.Request,
                                      com.etf.systemevents.PetFriend.Response>(
                                      this, METHODID_LOG_ACTION)))
              .build();
    }
  }

  /**
   */
  public static final class SystemEventsStub extends io.grpc.stub.AbstractStub<SystemEventsStub> {
    private SystemEventsStub(io.grpc.Channel channel) {
      super(channel);
    }

    private SystemEventsStub(io.grpc.Channel channel,
                             io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected SystemEventsStub build(io.grpc.Channel channel,
                                     io.grpc.CallOptions callOptions) {
      return new SystemEventsStub(channel, callOptions);
    }

    /**
     */
    public void logAction(com.etf.systemevents.PetFriend.Request request,
                          io.grpc.stub.StreamObserver<com.etf.systemevents.PetFriend.Response> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(getLogActionMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class SystemEventsBlockingStub extends io.grpc.stub.AbstractStub<SystemEventsBlockingStub> {
    private SystemEventsBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private SystemEventsBlockingStub(io.grpc.Channel channel,
                                     io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected SystemEventsBlockingStub build(io.grpc.Channel channel,
                                             io.grpc.CallOptions callOptions) {
      return new SystemEventsBlockingStub(channel, callOptions);
    }

    /**
     */
    public com.etf.systemevents.PetFriend.Response logAction(com.etf.systemevents.PetFriend.Request request) {
      return blockingUnaryCall(
              getChannel(), getLogActionMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class SystemEventsFutureStub extends io.grpc.stub.AbstractStub<SystemEventsFutureStub> {
    private SystemEventsFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private SystemEventsFutureStub(io.grpc.Channel channel,
                                   io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected SystemEventsFutureStub build(io.grpc.Channel channel,
                                           io.grpc.CallOptions callOptions) {
      return new SystemEventsFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.etf.systemevents.PetFriend.Response> logAction(
            com.etf.systemevents.PetFriend.Request request) {
      return futureUnaryCall(
              getChannel().newCall(getLogActionMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_LOG_ACTION = 0;

  private static final class MethodHandlers<Req, Resp> implements
          io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final SystemEventsImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(SystemEventsImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_LOG_ACTION:
          serviceImpl.logAction((com.etf.systemevents.PetFriend.Request) request,
                  (io.grpc.stub.StreamObserver<com.etf.systemevents.PetFriend.Response>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
            io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class SystemEventsBaseDescriptorSupplier
          implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    SystemEventsBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return com.etf.systemevents.PetFriend.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("SystemEvents");
    }
  }

  private static final class SystemEventsFileDescriptorSupplier
          extends SystemEventsBaseDescriptorSupplier {
    SystemEventsFileDescriptorSupplier() {}
  }

  private static final class SystemEventsMethodDescriptorSupplier
          extends SystemEventsBaseDescriptorSupplier
          implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    SystemEventsMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (SystemEventsGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
                  .setSchemaDescriptor(new SystemEventsFileDescriptorSupplier())
                  .addMethod(getLogActionMethod())
                  .build();
        }
      }
    }
    return result;
  }
}