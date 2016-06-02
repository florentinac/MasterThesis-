using ChaosServerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosServerCore.Controller
{
    public class RequestParameters
    {
        private IRepository<Request, string> repository;

        public RequestParameters()
        {
            repository = new RepositoryBase<Request>("repository", "request");
        }

        public bool VerifyIfHaveARequest(string email)
        {
            return repository.GetAll().Select(r => r.Id.Equals(email)).Single();
        }
        public List<string> VerifyIfHaveRequest(string email)
        {
            var result = new List<string>();
            if (VerifyIfHaveARequest(email))
            {
                //result.Add(request.Id);
                //result.Add(request.Image);
                //result.Add(XmlHelper.Serialize<Parameters>(request.Parameters));
            }
            return result;
        }
    }
}
