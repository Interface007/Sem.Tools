namespace Sem.Tools.Logging
{
    using System;

    /// <summary>
    /// Extension class for the enum type <see cref="LogCategory"/>.
    /// </summary>
    public static class LogCategoryExtensions
    {
        /// <summary>
        /// Tests whether a value has a specific category flag set.
        /// </summary>
        /// <param name="value">The value to be tested.</param>
        /// <param name="flag">The flag that should be tested.</param>
        /// <returns>A value indicating whether the flag is set.</returns>
        public static bool HasFlagFast<T>(this T value, T flag)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (Convert.ToInt32(value) & Convert.ToInt32(flag)) != 0;
        }
    }
}