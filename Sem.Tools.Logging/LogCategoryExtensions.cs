// <copyright file="LogCategoryExtensions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Extension class for the enum type <see cref="LogCategories"/>.
    /// </summary>
    public static class LogCategoryExtensions
    {
        /// <summary>
        /// Tests whether a value has a specific category flag set.
        /// </summary>
        /// <typeparam name="T">The enum type to be tested.</typeparam>
        /// <param name="value">The value to be tested.</param>
        /// <param name="flag">The flag that should be tested.</param>
        /// <returns>A value indicating whether the flag is set.</returns>
        public static bool HasFlag<T>(this T value, T flag)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (Convert.ToInt32(value, CultureInfo.InvariantCulture) & Convert.ToInt32(flag, CultureInfo.InvariantCulture)) != 0;
        }
    }
}