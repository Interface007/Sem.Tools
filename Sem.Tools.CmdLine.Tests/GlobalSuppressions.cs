// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Tests are structured this way.")] //// , Scope = "assembly", Target = "Sem.Tools.CmdLine.Tests")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Undocumented intentionally to test documentation.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWay~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "for testing purpose", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWay~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "for testing purpose", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWayWithDocumentation~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "Need to use default behaviour.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Intentionally empty instance method", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.ThisIsAVoidMethod")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Intentionally non-static.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.ThisIsAVoidMethod(System.String,Sem.Tools.CmdLine.Tests.TestMenuTarget)")]
