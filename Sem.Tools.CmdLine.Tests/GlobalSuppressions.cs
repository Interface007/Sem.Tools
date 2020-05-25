// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Tests are structured this way.")] //// , Scope = "assembly", Target = "Sem.Tools.CmdLine.Tests")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Undocumented intentionally to test documentation.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWay~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "for testing purpose", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWay~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "for testing purpose", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.DoItTheRightWayWithDocumentation~System.Collections.Generic.IAsyncEnumerable{System.String}")]
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "Need to use default behaviour.")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Intentionally empty instance method", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.ThisIsAVoidMethod")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Intentionally non-static.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTarget.ThisIsAVoidMethod(System.String,Sem.Tools.CmdLine.Tests.TestMenuTarget)")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Undocumented intentionally to test documentation.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTargetWithCtorParameter.DoIt(Sem.Tools.CmdLine.Tests.TestMenuTargetWithCtorParameter)~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "No localization wanted")]
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "parameters are just to build up different signatures")]
[assembly: SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "parameters are just to build up different signatures")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Undocumented intentionally to test documentation.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTargetWithCtorParameter.DoIt~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Undocumented intentionally to test documentation.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTargetWithCtorParameter.VoidDoIt")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "for testing purpose this is needed")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Specific test case", Scope = "type", Target = "~T:Sem.Tools.CmdLine.Tests.TestMenuTargetForOutput")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "needed to generate specific output", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Tests.TestMenuTargetForOutput.ReadSingleContact(Sem.Tools.CmdLine.Tests.TestMenuTarget,System.Guid)~System.Threading.Tasks.Task{System.String}")]
[assembly: SuppressMessage("Design", "RCS1102:Make class static.", Justification = "Class is used as a generic parameter, which needs this class to be non-static.", Scope = "type", Target = "~T:Sem.Tools.CmdLine.Tests.TestMenuTargetForOutput")]
