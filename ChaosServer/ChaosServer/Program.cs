using ChaosServerCore.Model;
using System;
using System.ComponentModel;

namespace ChaosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Parameters, string> parametersRepository = new ParametersRepository("");
            var parametersValue = new RandomNumberHandler();
            parametersRepository.AddItem(new Parameters {A=7, B = 9, C0 = 8, Lambda = parametersValue.GenerateLambdaRandomNumber(3.4, 4), T = 9, X = parametersValue.GenerateXRandomNumber(0, 1)});
            parametersRepository.GetAll();            
            try
            {
                parametersRepository.GetItem("2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                parametersRepository.UpdateItem("0", new Parameters {A = 12, B = 10, C0 = 9, Lambda = 5, T = 4, X = 66});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                parametersRepository.DeleteItem("2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            foreach (var item in parametersRepository.GetAll())
            {
                Console.WriteLine(item.Id);
               
            }
        }
    }
}
