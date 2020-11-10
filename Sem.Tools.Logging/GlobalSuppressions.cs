// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "localization is not needed here", Scope = "member", Target = "~M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)~Sem.Tools.Logging.LogScope")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "localization is not needed here", Scope = "member", Target = "~M:Sem.Tools.Logging.LogScope.Dispose")]// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "need to suppress everything here - there is no way to handle specific errors", Scope = "member", Target = "~M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)")]
