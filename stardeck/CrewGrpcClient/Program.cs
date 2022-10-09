using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5151");
var client = new Crew.Crew.CrewClient(channel);
var response = client.ReadLogbook(new Empty());


await foreach (var crew in response.ResponseStream.ReadAllAsync()) {
    Console.WriteLine(crew);
}