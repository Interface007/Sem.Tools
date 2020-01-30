// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive for await using var", Scope = "member", Target = "~M:Sem.Data.SprocAccess.IntegrationTests.Program.Main~System.Threading.Tasks.Task")]