using System.Reflection;

using MondoCore.Collections;

using JTran;
using JTran.Random;

namespace Rota.Transform.Test
{
    internal static class JTranBuilder
    {
        internal static async Task<ITransformer<T>> CreateTransformer<T>(string transformPath, object args)
        {
            var transform = await LoadTransform(transformPath);

            return TransformerBuilder.FromString(transform)
                                     .AddArguments(args.ToReadOnlyDictionary()!)
                                     .AddExtension(new RandomExtensions())
                                     .AddDocumentRepository("docs", new DocumentRepository())
                                     .Build<T>();
        }

        internal static Task<string> LoadTransform(string name)
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("Rota.Transform.Test\\bin\\Debug\\net8.0", "").Replace("Rota.Transform.Test\\bin\\Release\\net8.0", "");
            
            return File.ReadAllTextAsync(Path.Combine(location, "Transforms", name + ".jtran"));
        }    
    }
}
