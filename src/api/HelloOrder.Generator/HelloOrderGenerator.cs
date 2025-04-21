using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace HelloOrder.Generator;

[Generator]
public class HelloOrderGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // No setup needed for now
    }

    public void Execute(GeneratorExecutionContext context)
    {
        const string source = @"
namespace Generated
{
    public static class Order
    {
        public static string Hello() => ""Hello from Order!"";
    }
}
";
        context.AddSource("Order.g.cs", SourceText.From(source, Encoding.UTF8));
    }
}
