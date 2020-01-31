// <copyright file="ActionExtension.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools
{
    using System;

    /// <summary>
    /// Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method).
    /// </summary>
    public static class ActionExtension
    {
        /// <summary>
        /// Extension to combine two logging methods into a new one.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the methods to concatenate.</typeparam>
        /// <param name="currentAction">The logging method that should be executed first.</param>
        /// <param name="actionToAdd">The logging method to be executed after <paramref name="currentAction"/>.</param>
        /// <returns>A new method combining both methods specified in the parameters.</returns>
        public static Action<T1> Append<T1>(this Action<T1> currentAction, Action<T1> actionToAdd)
        {
            if (currentAction == null)
            {
                return actionToAdd;
            }

            return arg1 =>
            {
                currentAction(arg1);
                actionToAdd(arg1);
            };
        }

        /// <summary>
        /// Extension to combine two logging methods into a new one.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the methods to concatenate.</typeparam>
        /// <param name="currentAction">The logging method that should be executed first.</param>
        /// <param name="actionToAdd">The logging method to be executed after <paramref name="currentAction"/>.</param>
        /// <returns>A new method combining both methods specified in the parameters.</returns>
        public static Action<T1, T2> Append<T1, T2>(this Action<T1, T2> currentAction, Action<T1, T2> actionToAdd)
        {
            if (currentAction == null)
            {
                return actionToAdd;
            }

            return (arg1, arg2) =>
            {
                currentAction(arg1, arg2);
                actionToAdd(arg1, arg2);
            };
        }

        /// <summary>
        /// Extension to combine two logging methods into a new one.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the methods to concatenate.</typeparam>
        /// <param name="currentAction">The logging method that should be executed first.</param>
        /// <param name="actionToAdd">The logging method to be executed after <paramref name="currentAction"/>.</param>
        /// <returns>A new method combining both methods specified in the parameters.</returns>
        public static Action<T1, T2, T3> Append<T1, T2, T3>(this Action<T1, T2, T3> currentAction, Action<T1, T2, T3> actionToAdd)
        {
            if (currentAction == null)
            {
                return actionToAdd;
            }

            return (arg1, arg2, arg3) =>
            {
                currentAction(arg1, arg2, arg3);
                actionToAdd(arg1, arg2, arg3);
            };
        }

        /// <summary>
        /// Extension to combine two logging methods into a new one.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the methods to concatenate.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the methods to concatenate.</typeparam>
        /// <param name="currentAction">The logging method that should be executed first.</param>
        /// <param name="actionToAdd">The logging method to be executed after <paramref name="currentAction"/>.</param>
        /// <returns>A new method combining both methods specified in the parameters.</returns>
        public static Action<T1, T2, T3, T4> Append<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> currentAction, Action<T1, T2, T3, T4> actionToAdd)
        {
            if (currentAction == null)
            {
                return actionToAdd;
            }

            return (arg1, arg2, arg3, arg4) =>
            {
                currentAction(arg1, arg2, arg3, arg4);
                actionToAdd(arg1, arg2, arg3, arg4);
            };
        }
    }
}
