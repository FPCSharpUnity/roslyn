using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace CompilationExtension;

/// <summary>
/// To hook into the compilation process: <br/>
/// 1. Extend this class. <br/>
/// 2. Add <see cref="GeneratorAttribute"/> attribute to that class. <br/>
/// 3. Compile the dll.<br/>
/// 4. Reference that dll as an `analyzer` in the project that needs this compiler extension
/// (https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview).
/// </summary>
public abstract class ProcessCompilationBase : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context)
    {
        // Empty, because we implement ISourceGenerator for convenience. Roslyn collects all ISourceGenerator's for us.
        // Otherwise it would require a huge refactoring to add a new type that foes not extend ISourceGenerator.
    }
    void ISourceGenerator.Execute(GeneratorExecutionContext context) { }
        
    /// <summary>
    /// Process compiler extension.
    /// </summary>
    public abstract (IEnumerable<Diagnostic> diagnostics, Compilation newCompilation) process(
        Compilation compilation,
        ImmutableArray<ISourceGenerator> generators,
        string baseDirectory,
        bool allowFileTransformations
    );
}
