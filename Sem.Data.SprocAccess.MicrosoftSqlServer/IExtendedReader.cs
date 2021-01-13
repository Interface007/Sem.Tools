// <copyright file="IExtendedReader.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.MicrosoftSqlServer
{
    internal interface IExtendedReader : IReader
    {
        int FieldCount { get; }

        string GetAsString(int index);

        string NameByIndex(int index);
    }
}