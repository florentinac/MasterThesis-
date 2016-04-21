using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChaosServerCore.Model
{
    public abstract class RepositoryBase<T> : IRepository<T, string> where T : IIndexable
    {
        protected string baseDirectory;
        protected string repositoryName;

        protected string fullPath;

        internal RepositoryBase(string baseDirectory, string repositoryName)
        {
            this.baseDirectory = baseDirectory;
            this.repositoryName = repositoryName;

            this.InitializeRepository();
        }
        
        public bool AddItem(T item)
        {
            var result = false;

            var key = GenerateKey(item);
            if (CheckIfKeyAlreadyExists(key))
            {
                return result;                
            }

            item.Id = key;

            using (var fileStream = File.Create(Path.Combine(fullPath, key)))
            using (var writer = new StreamWriter(fileStream))
            {
                var serializedObject = XmlHelper.Serialize(item);
                writer.Write(serializedObject);
                result = true;
            }

            return result;
        }       

        public bool DeleteItem(string key)
        {
            var result = false;

            if (!CheckIfKeyAlreadyExists(key))
            {
                throw new Exception("The key does not exists in the repository!!!");
            }

            File.Delete(Path.Combine(fullPath, key));
            result = true;

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            var items = new DirectoryInfo(fullPath).GetFiles();

            foreach(var fileInfo in items)
            {
                result.Add(GetItem(fileInfo.Name));
            }

            return result;
        }

        public T GetItem(string key)
        {
            T item;

            if (!CheckIfKeyAlreadyExists(key))
            {
                throw new Exception("The key does not exists in the repository!!!");
            }

            using (var fileStream = File.OpenRead(Path.Combine(fullPath, key)))
            using (var reader = new StreamReader(fileStream))
            {
                var serializedObject = reader.ReadToEnd();

                item = XmlHelper.Deserialize<T>(serializedObject);
                item.Id = key;
            }

            return item;
        }

        public bool UpdateItem(string key, T item)
        {
            var result = false;

            if (!CheckIfKeyAlreadyExists(key))
            {
                throw new Exception("The key does not exists in the repository!!!");
            }
           
            using (var writer = new StreamWriter(Path.Combine(fullPath,key))) 
            {
                var serializedObject = XmlHelper.Serialize(item);
                writer.Write(serializedObject);
                result = true;
            }

            return result;
        }

        protected abstract string GenerateKey(T item);
   
        private bool CheckIfKeyAlreadyExists(string key)
        {
            return new DirectoryInfo(fullPath).GetFiles().Any(k => k.Name == key);
        }

        private void InitializeRepository()
        {
            fullPath = Path.Combine(baseDirectory, repositoryName);
            Directory.CreateDirectory(fullPath);
        }
    }
}
