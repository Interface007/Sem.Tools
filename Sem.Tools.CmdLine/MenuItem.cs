namespace Sem.Tools.CmdLine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Menu item for a command line program. An array of menu items can be displayed using the extension method
    /// <see cref="Menu.Show"/>.
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
        public MenuItem(string displayString, Func<Task> action, string suffixForMenu = "")
        {
            this.DisplayString = displayString + suffixForMenu;
            this.Action = action;
        }

        public string DisplayString { get; }

        public Func<Task> Action { get; }

        public static MenuItem Print(Expression<Func<IAsyncEnumerable<string>>> action, string suffixForMenu = "")
        {
            return Print(GetDescriptionFromXml(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        public static MenuItem Print(Expression<Func<Task<string>>> action, string suffixForMenu = "")
        {
            return Print(GetDescriptionFromXml(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        public static MenuItem Print(Expression<Func<Task<IEnumerable<string>>>> action, string suffixForMenu = "")
        {
            return Print(GetDescriptionFromXml(GetMethod(action)) + suffixForMenu, action.Compile());
        }

        public static MenuItem Print(string displayString, Func<Task<string>> action, string suffixForMenu = "")
        {
            return new MenuItem(displayString + suffixForMenu, async () => System.Console.WriteLine("\n" + await action.Invoke()));
        }

        public static MenuItem Print(string displayString, Func<IAsyncEnumerable<string>> action, string suffixForMenu = "")
        {
            return new MenuItem(
                displayString + suffixForMenu,
                async () =>
                {
                    await foreach (var result in action.Invoke())
                    {
                        System.Console.WriteLine($"\n{result}");
                    }
                });
        }

        public static MenuItem Print(string displayString, Func<Task<IEnumerable<string>>> action, string suffixForMenu = "")
        {
            return new MenuItem(
                displayString + suffixForMenu,
                async () =>
                {
                    foreach (var result in await action.Invoke().ConfigureAwait(false))
                    {
                        System.Console.WriteLine($"\n{result}");
                    }
                });
        }

        public static MenuItem For<T>(params object[] parameters)
        {
            var methods = typeof(T).GetMethods();
            return new MenuItem(
                GetDescriptionFromXml(typeof(T)),
                async () =>
                {
                    await methods.Where(x => x.ReturnType == typeof(IAsyncEnumerable<string>)).Select(x => Print(GetDescriptionFromXml(x), () => GetAction<IAsyncEnumerable<string>, T>(x, parameters)))
                        .Union(methods.Where(x => x.ReturnType == typeof(Task<string>)).Select(x => Print(GetDescriptionFromXml(x), () => GetAction<Task<string>, T>(x, parameters))))
                        .ToArray()
                        .Show()
                        .ConfigureAwait(false);
                });
        }

        private static string GetDescriptionFromXml(MemberInfo method)
        {
            var assemblyFolder = method.DeclaringType?.Assembly.CodeBase.Replace("file:///", string.Empty, StringComparison.Ordinal) ?? ".";
            var documentationXml = Path.ChangeExtension(Path.GetFullPath(assemblyFolder), ".XML");

            string documentation = null;

            if (File.Exists(documentationXml))
            {
                var document = new XmlDocument();
                document.Load(documentationXml);

                var path = "M:" + method.DeclaringType?.FullName + "." + method.Name;

                var methodDocumentation = document.SelectSingleNode("//member[starts-with(@name, '" + path + "')]/summary");
                documentation = methodDocumentation?
                    .InnerText
                    .Replace("\r", string.Empty, StringComparison.Ordinal)
                    .Replace("\n", string.Empty, StringComparison.Ordinal)
                    .Trim();
            }

            return documentation ?? $"[no description found for {method.Name}]";
        }

        private static string GetDescriptionFromXml(Type type)
        {
            var assemblyFolder = type.Assembly.CodeBase.Replace("file:///", string.Empty, StringComparison.Ordinal) ?? ".";
            var documentationXml = Path.ChangeExtension(Path.GetFullPath(assemblyFolder), ".XML");

            string documentation = null;

            if (File.Exists(documentationXml))
            {
                var document = new XmlDocument();
                document.Load(documentationXml);

                var path = "T:" + type.FullName;

                var methodDocumentation = document.SelectSingleNode("//member[starts-with(@name, '" + path + "')]/summary");
                documentation = methodDocumentation?
                    .InnerText
                    .Replace("\r", string.Empty, StringComparison.Ordinal)
                    .Replace("\n", string.Empty, StringComparison.Ordinal)
                    .Trim();
            }

            return documentation ?? $"[no description found for {type.Name}]";
        }

        private static MethodInfo GetMethod<T>(Expression<Func<T>> action)
        {
            return ((MethodCallExpression)action.Body).Method;
        }

        private static TResult GetAction<TResult, TClass>(MethodBase methodInfo, object[] parameters)
        {
            object LookupParameter(ParameterInfo parameterInfo)
            {
                var parameterType = parameterInfo.ParameterType;

                var value = parameters.FirstOrDefault(x => x.GetType() == parameterType)
                            ?? parameters
                                .Where(x => x.GetType().Name.StartsWith("<", StringComparison.Ordinal))
                                .SelectMany(x => x.GetType().GetProperties().Select(p => new { Value = p.GetValue(x), Name = p.Name }))
                                .FirstOrDefault(x => x.Name == parameterInfo.Name && x.Value.GetType() == parameterType)?.Value;

                if (value == null)
                {
                    throw new InvalidOperationException($"no value found for the parameter [{parameterInfo.Name}] of method [{methodInfo.Name}] with the type [{parameterType.Name}]");
                }

                return value;
            }

            var callParams = methodInfo
                .GetParameters()
                .Select(parameterInfo => LookupParameter(parameterInfo))
                .ToArray();

            var obj = methodInfo.IsStatic ? null : typeof(TClass).GetConstructor(new Type[0]).Invoke(new object[0]);

            return (TResult)methodInfo.Invoke(obj, callParams);
        }
    }
}