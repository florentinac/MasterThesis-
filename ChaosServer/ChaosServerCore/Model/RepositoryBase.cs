using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChaosServerCore.Model
{
    /// <summary>
    /// Base repository.
    /// Please note that this class must handle all file/directory exceptions. (I was too lazy, sue me).
    /// </summary>
    /// <typeparam name="T">The type that will be stored in the repository.</typeparam>
    public class RepositoryBase<T> : IRepository<T, string> where T : IIndexable
    {
        protected string baseDirectory;
        protected string repositoryName;

        protected string fullPath;

       public RepositoryBase(string baseDirectory, string repositoryName)
        {
            this.baseDirectory = baseDirectory;
            this.repositoryName = repositoryName;

            this.InitializeRepository();
        }
        
        public bool AddItem(T item)
        {
            var result = false;

            var key = this.GenerateKey(item);
            if (this.CheckIfKeyAlreadyExists(key))
            {
                return result;
            }

            item.Id = key;

            using (var fileStream = File.Create(Path.Combine(this.fullPath, key)))
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
            var items = new DirectoryInfo(this.fullPath).GetFiles();
            foreach(var fileInfo in items)
            {
                result.Add(this.GetItem(fileInfo.Name));
            }

            return result;
        }

        public T GetItem(string key)
        {
            T item;

            if (!this.CheckIfKeyAlreadyExists(key))
            {
                throw new Exception("The key does not exists in the repository!!!");
            }

            using (var fileStream = File.OpenRead(Path.Combine(this.fullPath, key)))
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

            using (var writer = new StreamWriter(Path.Combine(fullPath, key)))
            {
                var serializedObject = XmlHelper.Serialize(item);
                writer.Write(serializedObject);
                result = true;
            }
            return result;
        }

        protected virtual string GenerateKey(T item)
        {
            var maxKey = 0;

            var numbarOfFiles = new DirectoryInfo(this.fullPath).GetFiles();

            if (numbarOfFiles.Length != 0)
            {
                maxKey = numbarOfFiles.Select(p => int.Parse(p.Name)).Max();
                maxKey++;
            }

            return maxKey.ToString();
        }

        protected bool CheckIfKeyAlreadyExists(string key)
        {
            return new DirectoryInfo(this.fullPath).GetFiles().Any(k => k.Name == key);
        }

        private void InitializeRepository()
        {
            this.fullPath = Path.Combine(this.baseDirectory, this.repositoryName);
            Directory.CreateDirectory(this.fullPath);
        }
    }
}
