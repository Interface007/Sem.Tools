// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Exception for structuring test classes.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "localization is not needed here")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.AsyncDispose.AsyncDisposeCorrectlyLogsEndOfScope~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.MethodStart.ParametersAreCorrectlyLogged~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.DefaultCategory.OnlyMatchingLogMessagesAreLogged~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.DefaultLevel.OnlyMatchingLogMessagesAreLogged~System.Threading.Tasks.Task")]