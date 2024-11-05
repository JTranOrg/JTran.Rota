using System.Reflection;
using System.Text;

using JTran;

namespace Rota.Transform.Test
{
    public class DocumentRepository : IDocumentRepository2
    { 
        private static string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("Rota.Transform.Test\\bin\\Debug\\net8.0", "").Replace("Rota.Transform.Test\\bin\\Release\\net8.0", "")), "Transforms\\Documents");
        private Dictionary<string, string> _docs = new();

        public DocumentRepository(string? name, string? document)
        {
            if(name != null)
                _docs.Add(name!, document!);
        }

        public string GetDocument(string name)
        {
            if(_docs.ContainsKey(name))
                return _docs[name];

            return File.ReadAllText(Path.Combine(_path, name + ".json"));
        }

        public Stream GetDocumentStream(string name)
        {
            if(_docs.ContainsKey(name))
                return new MemoryStream(UTF8Encoding.Default.GetBytes(_docs[name]));

            return File.OpenRead(Path.Combine(_path, name + ".json"));
        }
    }
}
