// <copyright file="GlobalSuppressions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "No globalization needed.")]
[assembly: SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Structure of tests is this way in my projects.")]
[assembly: SuppressMessage("Usage", "CA1806:Do not ignore method results", Justification = "needed for testing purpose", Scope = "member", Target = "~M:Sem.Tools.TestHelper.Tests.ClassExpectedExceptionMessageAttribute.Ctor.CtorThrowsExpectedExceptionWhenExceptionTypeNotInheritsException")]
[assembly: SuppressMessage("Usage", "CA1806:Do not ignore method results", Justification = "needed for testing purpose", Scope = "member", Target = "~M:Sem.Tools.TestHelper.Tests.ClassExpectedExceptionMessageAttribute.Ctor.CtorThrowsExpectedExceptionWhenTypeIsNull")]
