@rem ���ɿͻ��˺ͷ������˴�� 

setlocal 
@rem ���뵱ǰĿ¼ 
cd /d %~dp0 
set path=%~dp0
set PROTOC=tools\protoc.exe
set PLUGIN=tools\grpc_csharp_plugin.exe

@rem tools\protoc.exe --proto_path protos --csharp_out=Interfaces --plugin=protoc-gen-grpc=tools\grpc_csharp_plugin.exe protos/mathservice.proto 
%PROTOC% --proto_path=protos --csharp_out=Interfaces protos\*.proto --grpc_out=Interfaces --plugin=protoc-gen-grpc=%PLUGIN%

endlocal 
timeout 10
