using System.IO;
using System.Linq;

namespace ChaosServerCore.Model
{
    public class ParametersRepository : RepositoryBase<Parameters>
    {
        public ParametersRepository(string baseDirectory) : base(baseDirectory, "Parameters")
        {
        }

        protected override string GenerateKey(Parameters item)
        {
            var maxKey = 0;

            var numbarOfFiles = new DirectoryInfo(base.fullPath).GetFiles();

            if (numbarOfFiles.Length != 0)
            {
                maxKey = numbarOfFiles.Select(p => int.Parse(p.Name)).Max();
                maxKey++;
            }

            return maxKey.ToString();
        }
    }
}
