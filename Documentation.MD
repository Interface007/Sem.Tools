# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Data.SprocAccess.FileSystem ##

## Type: Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
### Method: TxtDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|baseFolder|The base folder for the data files.|


---
### Method: TxtDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: TxtDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
### Method: TxtReader.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The name of the file containing the data.|


---
### Method: TxtReader.Read

 Increments the line pointer. 


#### Returns:
A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess.SqlServer ##

## Type: Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
### Method: SqlDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|connectionString|The database connection string to use for this instance.|


---
### Method: SqlDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: SqlDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
### Method: SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|sqlDataReader|The data reader to read from.|


---
### Method: SqlReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: SqlReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools.CmdLine ##

## Type: Sem.Tools.CmdLine.Menu

 Extension methods to handle command line menu definitions. 



---
### Method: Menu.Show(MenuItem[])

 Show the menu items and wait for selection of user. 

#### Parameters:
|Name | Description |
|-----|------|
|items|The items to display.|

#### Returns:
A task to wait for.



---
## Type: Sem.Tools.CmdLine.MenuItem

 Menu item for a command line program. An array of menu items can be displayed using the extension method [[|M:Sem.Tools.CmdLine.Menu.Show(Sem.Tools.CmdLine.MenuItem[])]]. 

_C# code_

```c#
    await new[]
    {
        MenuItem.For<AzureToLocalFolderBackupActions>(),
        MenuItem.For<EmailToLocalFolderBackupActions>(),
        MenuItem.For<EmailToAzureBackupActions>(),
        MenuItem.For<FolderToFolderBackupActions>(),
        MenuItem.For<FolderToAzureBackupActions>(),
        MenuItem.For<IntegrationTests>(),
    }.Show();
    
```



---
### Method: MenuItem.#ctor(string, Func\<Task>, string)

 Initializes a new instance of the [[|T:Sem.Tools.CmdLine.MenuItem]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The "label" that should be shown on the screen to describe the functionality.|
|action: |The action to perform when the user selects this menu item.|
|suffixForMenu: |A suffix for the display string.|


---
### P:Sem.Tools.CmdLine.MenuItem.DisplayString

 Gets the "label" that should be shown on the screen to describe the functionality. 



---
### P:Sem.Tools.CmdLine.MenuItem.Action

 Gets the action to perform when the user selects this menu item. 



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<System.Collections.Generic.IAsyncEnumerable\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<Task\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<Task\<System.Collections.Generic.IEnumerable\<string>>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<Task\<string>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<System.Collections.Generic.IAsyncEnumerable\<string>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<Task\<System.Collections.Generic.IEnumerable\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.For\<T1>(Object[])

 Creates menu entries for public methods of  !! UNSUPPORTED: typeparamref !! . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type to create entries for.|
#### Parameters:
|Name | Description |
|-----|------|
|parameters|Parameter values for the methods.|

#### Returns:
A menu entry with sub menu items.



---
### Method: MenuItem.GetDescriptionFromXml(System.Reflection.MemberInfo)

 Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|method|The method to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetDescriptionFromXml(System.Type)

 Extracts the description from the XML documentation of a class (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|type|The class type to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetMethod\<T1>(System.Linq.Expressions.Expression\<Func\<T>>)

 Gets the method information from a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The return type of the method.|
#### Parameters:
|Name | Description |
|-----|------|
|action|The expression calling a method.|

#### Returns:
The method information from the called method.



---
### Method: MenuItem.InvokeAction\<T1,  T2>(System.Reflection.MethodBase, Object[])

 Invokes a method with the needed parameters. 

#### Type parameters:
|Name | Description |
|-----|------|
|TResult|The result type of the method.|
|TClass: |The class type that contains the method.|
#### Parameters:
|Name | Description |
|-----|------|
|methodInfo|The method information.|
|parameters: |The potential parameters for the method call.|

#### Returns:
The call result.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Data.SprocAccess.FileSystem ##

## Type: Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
### Method: TxtDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|baseFolder|The base folder for the data files.|


---
### Method: TxtDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: TxtDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
### Method: TxtReader.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The name of the file containing the data.|


---
### Method: TxtReader.Read

 Increments the line pointer. 


#### Returns:
A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Data.SprocAccess.FileSystem ##

## Type: Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
### Method: TxtDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|baseFolder|The base folder for the data files.|


---
### Method: TxtDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: TxtDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
### Method: TxtReader.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The name of the file containing the data.|


---
### Method: TxtReader.Read

 Increments the line pointer. 


#### Returns:
A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Data.SprocAccess.SqlServer ##

## Type: Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
### Method: SqlDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|connectionString|The database connection string to use for this instance.|


---
### Method: SqlDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: SqlDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
### Method: SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|sqlDataReader|The data reader to read from.|


---
### Method: SqlReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: SqlReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Data.SprocAccess.SqlServer ##

## Type: Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
### Method: SqlDatabase.#ctor(string)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|connectionString|The database connection string to use for this instance.|


---
### Method: SqlDatabase.Execute\<T1>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
### Method: SqlDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
### Method: SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|sqlDataReader|The data reader to read from.|


---
### Method: SqlReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: SqlReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: SqlReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: SqlReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The POCO type to map the result to.|
#### Parameters:
|Name | Description |
|-----|------|
|sproc|The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|readerToObject: |A function that maps a single result into a POCO instance.|
|logger: |Optional logger.|
|parameters: |The named parameters for the SPROC.|

#### Returns:
A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools.CmdLine ##

## Type: Sem.Tools.CmdLine.Menu

 Extension methods to handle command line menu definitions. 



---
### Method: Menu.Show(MenuItem[])

 Show the menu items and wait for selection of user. 

#### Parameters:
|Name | Description |
|-----|------|
|items|The items to display.|

#### Returns:
A task to wait for.



---
## Type: Sem.Tools.CmdLine.MenuItem

 Menu item for a command line program. An array of menu items can be displayed using the extension method [[|M:Sem.Tools.CmdLine.Menu.Show(Sem.Tools.CmdLine.MenuItem[])]]. 

_C# code_

```c#
    await new[]
    {
        MenuItem.For<AzureToLocalFolderBackupActions>(),
        MenuItem.For<EmailToLocalFolderBackupActions>(),
        MenuItem.For<EmailToAzureBackupActions>(),
        MenuItem.For<FolderToFolderBackupActions>(),
        MenuItem.For<FolderToAzureBackupActions>(),
        MenuItem.For<IntegrationTests>(),
    }.Show();
    
```



---
### Method: MenuItem.#ctor(string, Func\<Task>, string)

 Initializes a new instance of the [[|T:Sem.Tools.CmdLine.MenuItem]] class. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The "label" that should be shown on the screen to describe the functionality.|
|action: |The action to perform when the user selects this menu item.|
|suffixForMenu: |A suffix for the display string.|


---
### P:Sem.Tools.CmdLine.MenuItem.DisplayString

 Gets the "label" that should be shown on the screen to describe the functionality. 



---
### P:Sem.Tools.CmdLine.MenuItem.Action

 Gets the action to perform when the user selects this menu item. 



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<System.Collections.Generic.IAsyncEnumerable\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<Task\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(System.Linq.Expressions.Expression\<Func\<Task\<System.Collections.Generic.IEnumerable\<string>>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<Task\<string>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<System.Collections.Generic.IAsyncEnumerable\<string>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(string, Func\<Task\<System.Collections.Generic.IEnumerable\<string>>>, string)

 Creates a [[|T:Sem.Tools.CmdLine.MenuItem]] from an expression - is meant to be used with a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.For\<T1>(Object[])

 Creates menu entries for public methods of  !! UNSUPPORTED: typeparamref !! . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type to create entries for.|
#### Parameters:
|Name | Description |
|-----|------|
|parameters|Parameter values for the methods.|

#### Returns:
A menu entry with sub menu items.



---
### Method: MenuItem.GetDescriptionFromXml(System.Reflection.MemberInfo)

 Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|method|The method to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetDescriptionFromXml(System.Type)

 Extracts the description from the XML documentation of a class (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|type|The class type to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetMethod\<T1>(System.Linq.Expressions.Expression\<Func\<T>>)

 Gets the method information from a [[|T:System.Linq.Expressions.MethodCallExpression]]. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The return type of the method.|
#### Parameters:
|Name | Description |
|-----|------|
|action|The expression calling a method.|

#### Returns:
The method information from the called method.



---
### Method: MenuItem.InvokeAction\<T1,  T2>(System.Reflection.MethodBase, Object[])

 Invokes a method with the needed parameters. 

#### Type parameters:
|Name | Description |
|-----|------|
|TResult|The result type of the method.|
|TClass: |The class type that contains the method.|
#### Parameters:
|Name | Description |
|-----|------|
|methodInfo|The method information.|
|parameters: |The potential parameters for the method call.|

#### Returns:
The call result.



---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools.Logging ##

## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

 Tests whether a value has a specific category flag set. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The enum type to be tested.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be tested.|
|flag: |The flag that should be tested.|

#### Returns:
A value indicating whether the flag is set.



---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
### Method: LogExtension.AddDebug(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to [[|T:System.Console]].



---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
### Method: LogScope.Create(string, System.Action\<LogCategories, LogLevel, LogScope, string>, string, string)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.Child(string, Object, string, string)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, string, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


# Sem.Tools ##

## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### Method: ActionExtension.Append\<T1>(System.Action\<T>, System.Action\<T>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2>(System.Action\<``0, \<T1>>, System.Action\<``0, \<T1>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3>(System.Action\<``0, \<T1>, \<T1,  T2>>, System.Action\<``0, \<T1>, \<T1,  T2>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>, System.Action\<``0, \<T1>, \<T1,  T2>, \<T1,  T2,  T3>>)

 Extension to combine two logging methods into a new one. 

#### Type parameters:
|Name | Description |
|-----|------|
|T1|The type of the first parameter of the methods to concatenate.|
|T2: |The type of the second parameter of the methods to concatenate.|
|T3: |The type of the third parameter of the methods to concatenate.|
|T4: |The type of the fourth parameter of the methods to concatenate.|
#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The logging method that should be executed first.|
|actionToAdd: |The logging method to be executed after  currentAction .|

#### Returns:
A new method combining both methods specified in the parameters.



---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### Method: EncryptionConverter.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type string.

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: EncryptionConverter.Write(System.Text.Json.Utf8JsonWriter, string, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



---
### Method: Extensions.Hash(string)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(string, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, string)

 Throws an [[|T:System.ArgumentNullException]] when passing NULL values to  value . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the parameter.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.ToJson\<T1>(``0)

 Extends all objects to have a simple JsonSerialization method. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the object to be serialized.|
#### Parameters:
|Name | Description |
|-----|------|
|value|The value to be serialized.|

#### Returns:
A JSON string.



---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



---
### F:Sem.Tools.FileSystemTools.Sanitizer

 A Regex to replace illegal characters from file names. 



---
### Method: FileSystemTools.SanitizeFileName(string)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### Method: InheritanceConverter`1.Read(System.Text.Json.Utf8JsonReader@, System.Type, System.Text.Json.JsonSerializerOptions)

Reads and converts the JSON to type  !! UNSUPPORTED: typeparamref !! .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### Method: InheritanceConverter`1.Write(System.Text.Json.Utf8JsonWriter, `0, System.Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


