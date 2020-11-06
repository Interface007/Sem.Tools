// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Exception for structuring test classes.")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "localization is not needed here")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.AsyncDispose.AsyncDisposeCorrectlyLogsEndOfScope~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.MethodStart.ParametersAreCorrectlyLogged~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.DefaultCategory.OnlyMatchingLogMessagesAreLogged~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positive", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.DefaultLevel.OnlyMatchingLogMessagesAreLogged~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = "here we need exactly this", Scope = "member", Target = "~M:Sem.Tools.Logging.Tests.ClassLogScope.LogMethod.Log1(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String)")]
