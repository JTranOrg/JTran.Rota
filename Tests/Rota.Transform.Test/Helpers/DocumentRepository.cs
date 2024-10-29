using System.Reflection;

using JTran;

namespace Rota.Transform.Test
{
    public class DocumentRepository : IDocumentRepository2
    { 
        private static string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("Rota.Transform.Test\\bin\\Debug\\net8.0", "").Replace("Rota.Transform.Test\\bin\\Release\\net8.0", "")), "Transforms\\Documents");

        public DocumentRepository()
        {
        }

        public string GetDocument(string name)
        {
            return File.ReadAllText(Path.Combine(_path, name + ".json"));
        }

        public Stream GetDocumentStream(string name)
        {
            return File.OpenRead(Path.Combine(_path, name + ".json"));
        }
    }
}
