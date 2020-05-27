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
        /////// <summary>
        /////// Initializes a new instance of the <see cref="MenuItem"/> class.
        /////// </summary>
        /////// <param name="displayString">The "label" that should be shown on the screen to describe the functionality.</param>
        /////// <param name="action">The action to perform when the user selects this menu item.</param>
        /////// <param name="suffixForMenu">A suffix for the display string.</param>
        ////public MenuItem(string displayString, Func<Task> action, string suffixForMenu = "")
        ////{
        ////    this.DisplayString = displayString + suffixForMenu;
        ////    this.Action = action;
        ////}

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="displayString">The "label" that should be shown on the screen to describe the functionality.</param>
        /// <param name="action">The action to perform when the user selects this menu item.</param>
        /// <param name="suffixForMenu">A suffix for the display string.</param>
        public MenuItem(string displayString, Func<object[], Task> action, string suffixForMenu = "")
        {
            this.DisplayString = displayString + suffixForMenu;
            this.ActionWithParameters = action;
        }

        /// <summary>
        /// Gets or sets an implementation for console actions. This is helpful for
        /// testing and automating processes that have been created using this library.
        /// </summary>
        public static IConsole Console { get; set; } = new ConsoleWrapper();

        /// <summary>
        /// Gets the "label" that should be shown on the screen to describe the functionality.
        /// </summary>
        public string DisplayString { get; }

        /// <summary>
        /// Gets the action with parameters to perform when the user selects this menu item.
        /// </summary>
        public Func<object[], Task> ActionWithParameters { get; }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is a method that returns a sequence of strings using an
        /// <see cref="IAsyncEnumerable{T}"/> of <see cref="string"/>. Each of the strings will be printed to the console.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<IAsyncEnumerable<string>>> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is a method that returns a sequence of strings using an
        /// <see cref="IEnumerable{T}"/> of <see cref="string"/>. Each of the strings will be printed to the console.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<Task<IEnumerable<string>>>> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is an async method that returns a single string.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Func<Task<string>>> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is a method that returns a single string.
        /// </summary>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(Expression<Action> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return Print(GetDescription(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is a method that returns a single string.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(Action<T1> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            var methodInfo = action.GetMethodInfo();
            return Print(GetDescription(methodInfo) + suffixForMenu, action);
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// This method assumes that <paramref name="action"/> is a method that returns a single string.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(Func<T1, string> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            var methodInfo = action.GetMethodInfo();
            return Print(GetDescription(methodInfo) + suffixForMenu, action);
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(Func<T1, Task<string>> action, string suffixForMenu = "")
        {
            var methodInfo = action.GetMethodInfo();
            return Print(GetDescription(methodInfo) + suffixForMenu, action);
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(Func<T1, Task> action, string suffixForMenu = "")
        {
            var methodInfo = action.GetMethodInfo();
            return Print(GetDescription(methodInfo) + suffixForMenu, action);
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
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                p =>
            {
                action.Invoke();
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(string displayString, Action<T1> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                parameters =>
            {
                var callParams = CallParams(action.GetMethodInfo(), parameters);
                action.Invoke((T1)callParams[0]);
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from a non-async void expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(string displayString, Func<T1, string> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                parameters =>
            {
                var callParams = CallParams(action.GetMethodInfo(), parameters);
                var returnValue = action.Invoke((T1)callParams[0]);
                return Task.FromResult(returnValue);
            });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print(string displayString, Func<Task> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(displayString + suffixForMenu, async p => await action().ConfigureAwait(false));
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(string displayString, Func<T1, Task<string>> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(displayString + suffixForMenu, async (parameters) =>
            {
                var callParams = CallParams(action.GetMethodInfo(), parameters);
                Console.WriteLine("\n" + await action((T1)callParams[0]).ConfigureAwait(false));
            });
        }

        /// <summary>
        /// Creates a <see cref="MenuItem"/> from an expression - is meant to be used with a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <typeparam name="T1">The parameter type of the first method parameter.</typeparam>
        /// <param name="displayString">The explicit "label" to be used for the menu entry.</param>
        /// <param name="action">The expression to create a menu item for.</param>
        /// <param name="suffixForMenu">A suffix for the description of the method (the description will be extracted from the documentation XML file).</param>
        /// <returns>A new menu item.</returns>
        public static MenuItem Print<T1>(string displayString, Func<T1, Task> action, string suffixForMenu = "")
        {
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(displayString + suffixForMenu, async (parameters) =>
            {
                var callParams = CallParams(action.GetMethodInfo(), parameters);
                await action((T1)callParams[0]).ConfigureAwait(false);
            });
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
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                async p =>
                {
                    await foreach (var result in action())
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
            _ = action.MustNotBeNull(nameof(action));
            return new MenuItem(
                displayString + suffixForMenu,
                async p =>
                {
                    foreach (var result in await action().ConfigureAwait(false))
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
        public static MenuItem For<T>(params object[] parameters) =>
            new MenuItem(
                GetDescription(typeof(T)),
                async callParams =>
                {
                    var items = MenuItemsFor<T>(parameters);
                    await items.Show(callParams.Union(parameters).ToArray()).ConfigureAwait(false);
                });

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="action">The action to perform.</param>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem For<T>(Expression<Action> action, params object[] parameters)
        {
            var methodInfo = GetMethod(action.MustNotBeNull(nameof(action)));
            return new MenuItem(GetDescription(methodInfo), p =>
            {
                InvokeAction<T>(methodInfo, parameters.Union(p).ToArray());
                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="method">The action to perform.</param>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem For<T>(Expression<Action<T>> method, params object[] parameters)
        {
            var methodInfo = GetMethod(method.MustNotBeNull(nameof(method)));
            return Print(GetDescription(methodInfo), () => InvokeAction<T>(methodInfo, parameters));
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="method">The action to perform.</param>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem For<T>(Expression<Func<Task>> method, params object[] parameters)
        {
            var methodInfo = GetMethod(method.MustNotBeNull(nameof(method)));
            return new MenuItem(GetDescription(methodInfo), async p => await InvokeActionAsync<T>(methodInfo, parameters.Union(p).ToArray()).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="method">The action to perform.</param>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem For<T>(Expression<Func<T, Task>> method, params object[] parameters)
        {
            var methodInfo = GetMethod(method.MustNotBeNull(nameof(method)));
            return new MenuItem(GetDescription(methodInfo), async p => await InvokeActionAsync<T>(methodInfo, parameters.Union(p).ToArray()).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates menu entries for public methods of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to create entries for.</typeparam>
        /// <param name="parameters">Parameter values for the methods.</param>
        /// <returns>A menu entry with sub menu items.</returns>
        public static MenuItem[] MenuItemsFor<T>(params object[] parameters)
        {
            static bool IsIAsyncEnum(MethodInfo methodInfo) => methodInfo.ReturnType == typeof(IAsyncEnumerable<string>);
            static bool IsTaskString(MethodInfo methodInfo) => methodInfo.ReturnType == typeof(Task<string>);
            static bool IsTaskNoType(MethodInfo methodInfo) => methodInfo.ReturnType == typeof(Task);
            static bool IsVoidMethod(MethodInfo methodInfo) => methodInfo.ReturnType == typeof(void) && !methodInfo.Name.StartsWith("set_", StringComparison.Ordinal);

            var methods = typeof(T).GetMethods();
            var items = methods.Where(IsIAsyncEnum).Select(x => new MenuItem(
                GetDescription(x),
                async p =>
                {
                    await foreach (var result in InvokeAction<IAsyncEnumerable<string>, T>(x, parameters.Union(p).ToArray()))
                    {
                        Console.WriteLine($"\n{result}");
                    }
                }))
                 .Union(methods.Where(IsTaskString).Select(x => new MenuItem(GetDescription(x), p => InvokeAction<Task<string>, T>(x, parameters.Union(p).ToArray()))))
                 .Union(methods.Where(IsTaskNoType).Select(x => new MenuItem(GetDescription(x), p => InvokeAction<Task, T>(x, parameters.Union(p).ToArray()))))
                 .Union(methods.Where(IsVoidMethod).Select(x => new MenuItem(GetDescription(x), p => { InvokeAction<T>(x, parameters.Union(p).ToArray()); return Task.CompletedTask; })))
                 .ToArray();

            return items;
        }

        /// <summary>
        /// Represents the method to call.
        /// </summary>
        /// <returns>The method description.</returns>
        public override string ToString() => this.DisplayString;

        /// <summary>
        /// Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly).
        /// </summary>
        /// <param name="method">The method to get the description for.</param>
        /// <returns>The extracted description.</returns>
        private static string GetDescription(MethodInfo method)
        {
            var declaringType = method.MustNotBeNull(nameof(method)).DeclaringType;

            // ReSharper disable once AssignNullToNotNullAttribute
            var fullName = declaringType.MustNotBeNull(nameof(declaringType)).FullName + "." + method.Name;
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
                description = Regex.Replace(name, "([^a-z])", x => $" {x}").Trim();
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
        /// <param name="action">The expression calling a method.</param>
        /// <returns>The method information from the called method.</returns>
        private static MethodInfo GetMethod(LambdaExpression action)
        {
            if (!(action.Body is MethodCallExpression callExpression))
            {
                throw new ArgumentException("must be an expression with body of type MethodCallExpression", nameof(action));
            }

            return callExpression.Method;
        }

        /// <summary>
        /// Invokes a method with the needed parameters.
        /// </summary>
        /// <typeparam name="TClass">The class type that contains the method.</typeparam>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="parameters">The potential parameters for the method call.</param>
        private static void InvokeAction<TClass>(MethodBase methodInfo, object[] parameters)
        {
            var obj = CreateInstance<TClass>(methodInfo, parameters);
            var callParams = CallParams(methodInfo, parameters);
            _ = methodInfo.Invoke(obj, callParams);
        }

        /// <summary>
        /// Invokes a method with the needed parameters.
        /// </summary>
        /// <typeparam name="TClass">The class type that contains the method.</typeparam>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="parameters">The potential parameters for the method call.</param>
        /// <returns>The call result.</returns>
        private static async Task InvokeActionAsync<TClass>(MethodBase methodInfo, object[] parameters)
        {
            var obj = CreateInstance<TClass>(methodInfo, parameters);
            var callParams = CallParams(methodInfo, parameters);
            await ((Task)methodInfo.Invoke(obj, callParams)).ConfigureAwait(false);
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
            var obj = CreateInstance<TClass>(methodInfo, parameters);
            var callParams = CallParams(methodInfo, parameters);
            return (TResult)methodInfo.Invoke(obj, callParams);
        }

        /// <summary>
        /// Creates an instance of <typeparamref name="TClass"/> using the widest constructor (the one with the most parameters).
        /// </summary>
        /// <typeparam name="TClass">The type of object to be created.</typeparam>
        /// <param name="methodInfo">The method info for the call - if the method is static, NULL will be returned.</param>
        /// <param name="parameters">The parameters that might be used for the CTOR and the method call.</param>
        /// <returns>The result of the method call.</returns>
        private static object CreateInstance<TClass>(MethodBase methodInfo, object[] parameters)
        {
            if (methodInfo.IsStatic)
            {
                return null;
            }

            var ctor = typeof(TClass)
                .GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .First();

            var callParams = CallParams(ctor, parameters);
            var obj = ctor.Invoke(callParams);
            return obj;
        }

        /// <summary>
        /// Determines the parameters that best match the call signature.
        /// </summary>
        /// <param name="methodInfo">The info about the method that should be called.</param>
        /// <param name="parameters">The potential parameters for the call.</param>
        /// <returns>The parameters that match the method signature.</returns>
        private static object[] CallParams(MethodBase methodInfo, object[] parameters)
        {
            var callParams = methodInfo
                .GetParameters()
                .Select(x => LookupParameter(methodInfo, x, parameters))
                .ToArray();
            return callParams;
        }

        /// <summary>
        /// Determines the best match for a method parameter from a set of potential parameters.
        /// </summary>
        /// <param name="methodInfo">The method info for the call to be made.</param>
        /// <param name="parameterInfo">The parameter info from the method <paramref name="methodInfo"/>.</param>
        /// <param name="parameters">The potential parameters to select from.</param>
        /// <returns>The matching parameters.</returns>
        private static object LookupParameter(MemberInfo methodInfo, ParameterInfo parameterInfo, object[] parameters)
        {
            var parameterType = parameterInfo.ParameterType;

            var objects = parameters
                .Where(x => x.GetType().Name.StartsWith("<", StringComparison.Ordinal))
                .ToArray();

            var properties = objects
                .SelectMany(x => x.GetType().GetProperties().Select(p => new { Value = p.GetValue(x), p.Name }))
                .ToArray();

            var value = parameters.FirstOrDefault(x => x.GetType() == parameterType)
                           ?? properties.FirstOrDefault(x => x.Name == parameterInfo.Name && x.Value.GetType() == parameterType)?.Value;

            if (value == null)
            {
                throw new InvalidOperationException($"no value found for the parameter [{parameterInfo.Name}] of method [{methodInfo.Name}] with the type [{parameterType.Name}]");
            }

            return value;
        }
    }
}