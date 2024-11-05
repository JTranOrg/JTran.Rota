using System.Reflection;

using MondoCore.Collections;

using JTran;
using JTran.Random;

namespace Rota.Transform.Test
{
    internal static class JTranBuilder
    {
        internal static async Task<ITransformer<T>> CreateTransformer<T>(string transformPath, object args, string? docName = null, string? docContent = null)
        {
            var transform = await LoadTransform(transformPath);

            return TransformerBuilder.FromString(transform)
                                     .AddArguments(args.ToReadOnlyDictionary()!)
                                     .AddExtension(new RandomExtensions())
                                     .AddExtension(new Extensions())
                                     .AddDocumentRepository("docs", new DocumentRepository(docName, docContent))
                                     .Build<T>();
        }

        internal static Task<string> LoadTransform(string name)
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("Rota.Transform.Test\\bin\\Debug\\net8.0", "").Replace("Rota.Transform.Test\\bin\\Release\\net8.0", "");
            
            return File.ReadAllTextAsync(Path.Combine(location, "Transforms", name + ".jtran"));
        }    
    }

    public class Extensions
    {
        public string replaced(string str1, string str2, string str3)
        {
            var result = str1.Replace(str2, str3);

            return result;
        }
    }
}
