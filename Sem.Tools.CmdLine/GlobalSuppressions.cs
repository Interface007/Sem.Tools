// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catching all exceptions on this level is exactly what we want here.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Menu.Show(Sem.Tools.CmdLine.MenuItem[])~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "localization is not needed here")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catching all exceptions on this level is exactly what we want here.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Menu.Show(Sem.Tools.CmdLine.MenuItem[],Sem.Tools.IConsole)~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1107:Code should not contain multiple statements on one line", Justification = "Because of formatting into one line, we can better compare the lines.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.MenuItem.MenuItemsFor``1(System.Object[])~Sem.Tools.CmdLine.MenuItem[]")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Catching all exceptions on this level is exactly what we want here.", Scope = "member", Target = "~M:Sem.Tools.CmdLine.Menu.ShowInternal(Sem.Tools.CmdLine.MenuItem[],System.Object[])~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Performance", "RCS1077:Optimize LINQ method call.", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.CmdLine.MenuItem.LookupParameter(System.Reflection.MemberInfo,System.Reflection.ParameterInfo,System.Object[])~System.Object")]
