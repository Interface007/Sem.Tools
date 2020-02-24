// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Readability is more important here.", Scope = "type", Target = "~T:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Exception for structuring test classes.", Scope = "type", Target = "~T:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Exception for structuring test classes.", Scope = "type", Target = "~T:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute.LogsCorrectly~System.Threading.Tasks.Task")]