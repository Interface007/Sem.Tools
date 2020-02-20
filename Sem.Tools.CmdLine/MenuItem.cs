// <copyright file="MenuItem.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

// ReSharper disable MemberCanBePrivate.Global
namespace Sem.Tools.CmdLine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml;

    using Sem.Tools;

    /// <summary>
    /// Menu item for a command line program. An array of menu items can be displayed using the extension method
    /// <see cref="Menu.Show(Sem.Tools.CmdLine.MenuItem[])"/>.
    /// </summary>
    /// <example>
    /// <code>
    /// await new[]
    /// {
    ///     MenuItem.For&lt;AzureToLocalFolderBackupActions&gt;(),
    ///     MenuItem.For&lt;EmailToLocalFolderBackupActions&gt;(),
    ///     MenuItem.For&lt;EmailToAzureBackupActions&gt;(),
    ///     MenuItem.For&lt;FolderToFolderBackupActions&gt;(),
    ///     MenuItem.For&lt;FolderToAzureBackupActions&gt;(),
    ///     MenuItem.For&lt;IntegrationTests&gt;(),
    /// }.Show();
    /// </code>
    /// </example>
    public class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="displayString">The "label" that should be shown on the screen to describe the functionality.</param>
        /// <param name="action">The action to perform when the user selects this menu item.</param>
        /// <param name="suffixForMenu">A suffix for the display string.</param>
        public MenuItem(string displayString, Func<Task> action, string suffixForMenu = "")
        {
            this.DisplayString = displayString + suffixForMenu;
            this.Action = action;
        }

        /// <summary>
        /// Gets or sets an implementation for console actions.
        /// </summary>
        public static IConsole Console { get; set; } = new ConsoleWrapper();

        /// <summary>
        /// Gets the "label" that should be shown on the screen to describe the functionality.
        /// </summary>
        public string DisplayString { get; }

        /// <summary>
        /// Gets the action to perform when the user selects this menu item.
        /// </summary>
        public Func<Task> Action { get; }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<IAsyncEnumerable<string>>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<Task<string>>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<Task<IEnumerable<string>>>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Action> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(string displayString, Action action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                () =>
            {
                action.Invoke();
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(string displayString, Func<Task<string>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return new MenuItem(displayString + suffixForMenu, async () => Console.WriteLine("\n" + await action().ConfigureAwait(false)));
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(string displayString, Func<IAsyncEnumerable<string>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                async () =>
                {
                    await foreach (var result in action.Invoke())
                    {
                        Console.WriteLine($"\n{result}");
                    }
                });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(string displayString, Func<Task<IEnumerable<string>>> action, string suffixForMenu = "")
        {
            action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                async () =>
                {
                    foreach (var result in await action.Invoke().ConfigureAwait(false))
                    {
                        Console.WriteLine($"\n{result}");
                    }
                });
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem For<T>(params object[] parameters)
        {
            return new MenuItem(
                GetDescription(typeof(T)),
                async () =>
                {
                    var items = MenuItemsFor<T>(parameters);
                    await items.Show().ConfigureAwait(false);
                });
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem[] MenuItemsFor<T>(params object[] parameters)
        {
            var methods = typeof(T).GetMethods();
            var items = methods.Where(x => x.ReturnType == typeof(IAsyncEnumerable<string>)).Select(x => Print(GetDescription(x), () => InvokeAction<IAsyncEnumerable<string>, T>(x, parameters)))
                 .Union(methods.Where(x => x.ReturnType == typeof(Task<string>)).Select(x => Print(GetDescription(x), () => InvokeAction<Task<string>, T>(x, parameters))))
                 .Union(methods.Where(x => x.ReturnType == typeof(void) && !x.Name.StartsWith("set_", StringComparison.Ordinal)).Select(x => Print(GetDescription(x), () => InvokeAction<Task, T>(x, parameters))))
                 .ToArray();
            return items;
        }

        /// <summary>
        /// Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly).
        /// </summary>
        /// <param name="method">The method to get the description for.</param>
        /// <returns>The extracted description.</returns>
        private static string GetDescription(MethodInfo method)
        {
            var declaringType = method.DeclaringType;
            declaringType.MustNotBeNull(nameof(declaringType));

            var fullName = declaringType.FullName + "." + method.Name;
            var xPath = method.GetParameters().Length > 0
                ? $"//member[starts-with(@name, 'M:{fullName}(')]/summary"
                : $"//member[@name = 'M:{fullName}']/summary";

            return GetDocumentationFromXml(declaringType, xPath, method.Name);
        }

        /// <summary>
        /// Extracts the description from the XML documentation of a class (the XML file mst be generated while building the assembly).
        /// </summary>
        /// <param name="type">The class type to get the description for.</param>
        /// <returns>The extracted description.</returns>
        private static string GetDescription(Type type)
        {
            var xPath = $"//member[@name = 'T:{type.FullName}']/summary";

            return GetDocumentationFromXml(type, xPath, type.Name);
        }

        /// <summary>
        /// Extracts the documentation from the XML file of the assembly.
        /// </summary>
        /// <param name="declaringType">The declaring type to find the assembly.</param>
        /// <param name="xPath">The XPath expression to find the correct element.</param>
        /// <param name="name">The name of the element to compensate a missing file or XML comment.</param>
        /// <returns>A documentation read from the file or generated from the name.</returns>
        private static string GetDocumentationFromXml(Type declaringType, string xPath, string name)
        {
            var assemblyFolder = declaringType.Assembly.CodeBase.Replace("file:///", string.Empty, StringComparison.Ordinal);
            var documentationXml = Path.ChangeExtension(Path.GetFullPath(assemblyFolder), ".XML");

            var description = string.Empty;
            if (File.Exists(documentationXml))
            {
                var document = new XmlDocument();
                document.Load(documentationXml);

                var documentationNode = document.SelectSingleNode(xPath);
                description = documentationNode?.InnerText.Trim();
            }

            if (string.IsNullOrEmpty(description))
            {
                description = Regex.Replace(name, "([^a-z])", x => " " + x).Trim();
            }

            while (description.Contains("  ", StringComparison.Ordinal))
            {
                description = description.Replace("  ", " ", StringComparison.Ordinal);
            }

            return description
                .Replace("\r", string.Empty, StringComparison.Ordinal)
                .Replace("\n", string.Empty, StringComparison.Ordinal)
                .Trim();
        }

        /// <summary>
        /// Gets the method information from a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="action">The expression calling a method.</param>
        /// <returns>The method information from the called method.</returns>
        private static MethodInfo GetMethod<T>(Expression<Func<T>> action)
        {
            return ((MethodCallExpression)action.Body).Method;
        }

        /// <summary>
        /// Gets the method information from a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="action">The expression calling a method.</param>
        /// <returns>The method information from the called method.</returns>
        private static MethodInfo GetMethod(Expression<Action> action)
        {
            return ((MethodCallExpression)action.Body).Method;
        }

        /// <summary>
        /// Invokes a method with the needed parameters.
        /// </summary>
        /// <typeparam name="TResult">The result type of the method.</typeparam>
        /// <typeparam name="TClass">The class type that contains the method.</typeparam>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="parameters">The potential parameters for the method call.</param>
        /// <returns>The call result.</returns>
        private static TResult InvokeAction<TResult, TClass>(MethodBase methodInfo, object[] parameters)
        {
            object LookupParameter(ParameterInfo parameterInfo)
            {
                var parameterType = parameterInfo.ParameterType;

                var value = parameters.FirstOrDefault(x => x.GetType() == parameterType)
                            ?? parameters
                                .Where(x => x.GetType().Name.StartsWith("<", StringComparison.Ordinal))
                                .SelectMany(x => x.GetType().GetProperties().Select(p => new { Value = p.GetValue(x), p.Name }))
                                .FirstOrDefault(x => x.Name == parameterInfo.Name && x.Value.GetType() == parameterType)?.Value;

                if (value == null)
                {
                    throw new InvalidOperationException($"no value found for the parameter [{parameterInfo.Name}] of method [{methodInfo.Name}] with the type [{parameterType.Name}]");
                }

                return value;
            }

            var callParams = methodInfo
                .GetParameters()
                .Select(LookupParameter)
                .ToArray();

            var obj = methodInfo.IsStatic ? null : typeof(TClass).GetConstructor(Array.Empty<Type>())?.Invoke(Array.Empty<object>());

            return (TResult)methodInfo.Invoke(obj, callParams);
        }
    }
}