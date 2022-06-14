rm -r build
mkdir build
dotnet build -c Release .\src\Compilers\Server\VBCSCompiler\VBCSCompiler.csproj
dotnet build -c Release .\src\Compilers\CSharp\csc\csc.csproj
Copy-Item artifacts\bin\VBCSCompiler\Release\net6.0 -Destination build -Recurse
Copy-Item artifacts\bin\csc\Release\net6.0 -Destination build -Recurse -Force
Copy-Item artifacts\bin\VBCSCompiler\Release\net5.0 -Destination build -Recurse
Copy-Item artifacts\bin\csc\Release\net5.0 -Destination build -Recurse -Force
Copy-Item artifacts\bin\Microsoft.CodeAnalysis\Release\netstandard2.0 -Destination build -Recurse -Force
Copy-Item artifacts\bin\Microsoft.CodeAnalysis.CSharp\Release\netstandard2.0 -Destination build -Recurse -Force