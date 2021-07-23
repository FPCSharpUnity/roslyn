using System.Collections.Generic;

namespace CompilationExtensionInterfaces
{
    /// <summary>
    /// Implement this and put the resulting dll in the compiler directory with a name "CompilationExtensionYOUR_NAME.dll" to hook into the compilation process.
    /// </summary>
    public interface IProcessCompilation
    {
        /// <summary>
        /// Untyped, because we can't reference Microsoft.CodeAnalysis due to circular references.
        /// </summary>
        /// <param name="compilation">Microsoft.CodeAnalysis.Compilation</param>
        /// <returns>IEnumerable&lt;Microsoft.CodeAnalysis.Diagnostic&gt;</returns>
        IEnumerable<object> process(ref object compilation, string baseDirectory, bool allowFileTransformations);
    }
}
