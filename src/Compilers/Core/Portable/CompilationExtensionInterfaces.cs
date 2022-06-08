using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace CompilationExtensionInterfaces
{
    /// <summary>
    /// Implement this and put the resulting dll in the compiler directory with a name "CompilationExtensionYOUR_NAME.dll" to hook into the compilation process.
    /// </summary>
    public abstract class ProcessCompilationBase : ISourceGenerator
    {
        void ISourceGenerator.Initialize(GeneratorInitializationContext context)
        {
            // Empty, because we implement ISourceGenerator for convenience. Roslyn collects all generators for us.
            // Otherwise it would be a huge refactoring to add a new type that foes not extend ISourceGenerator.
        }
        void ISourceGenerator.Execute(GeneratorExecutionContext context) { }
        
        /// <summary>
        /// Untyped, because we can't reference Microsoft.CodeAnalysis due to circular references.
        /// </summary>
        /// <param name="compilation">Microsoft.CodeAnalysis.Compilation</param>
        /// <returns>IEnumerable&lt;Microsoft.CodeAnalysis.Diagnostic&gt;</returns>
        public abstract IEnumerable<Diagnostic> process(
            ref Compilation compilation, string baseDirectory, bool allowFileTransformations
        );
    }
}
