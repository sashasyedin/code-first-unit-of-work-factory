using System;
using System.Linq;
using System.Reflection;

namespace Quizmaster.Common.Extensions
{
    /// <summary>
    /// Extensions to Enumerations.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the custom attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>
        /// The custom attribute.
        /// </returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
