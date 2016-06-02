using ChaosServerCore;
using ChaosServerCore.Model;
using System;

namespace ChaosServer
{
    class Program
    {
        static void Main(string[] args)
        {

            var request = new Request
            {
                Id = "1",
                Image = "Blabla",
                Parameters = new Parameters(),
                Sender = new Sender { Id = "1", Name = "Maria" },
                Receiver = new Receiver { Id = "1", Name = "Maria" }
            };

            IRepository<Request, string> repository = new RepositoryBase<Request>("repository", "Parameters");
            repository.AddItem(request);
            var requestdes = repository.GetAll();
        }
    }
}
