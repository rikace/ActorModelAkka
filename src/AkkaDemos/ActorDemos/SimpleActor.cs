using System;
using System.Threading.Tasks;
using Akka.Actor;

namespace AkkaActor.Demos
{
    public class SimpleActor : ReceiveActor
    {
        public SimpleActor()
        {
            Receive<string>(message =>
                Console.WriteLine("{0} got {1}", Self.Path.ToStringWithAddress(), message));

            Receive<SimpleGreet>(message =>
            {
                Console.WriteLine("SimpleGreet: {0} got {1}", Self.Path.ToStringWithAddress(), message.Who);
                var response = new SimpleGreetResponse($"Hello back {message.Who}");
                var sender = Context.Sender;
                sender.Tell(new SimpleGreetResponse($"I am responding"));
            });
        }
        

        protected override void Unhandled(object message)
        {
            Console.WriteLine("Unhandled message {0}", message);
        }


        public static async Task Run()
        {
            using (var system = ActorSystem.Create("Mediator-System"))
            {
                var actor = system.ActorOf<SimpleActor>();

                actor.Tell("Message One");
                actor.Tell(42);

                var resp = await actor.Ask<SimpleGreetResponse>(new SimpleGreet("Ricky"));
                Console.WriteLine(resp.Response);

            }
        }
    }

    public class SimpleGreet
    {
        public string Who { get; private set; }

        public SimpleGreet(string who)
        {
            Who = who;
        }
    }

    public class SimpleGreetResponse
    {
        public string Response { get; private set; }

        public SimpleGreetResponse(string response)
        {
            Response = response;
        }
    }
}