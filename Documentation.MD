# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: TxtDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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


Returns: A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess.FileSystemTests ##

## Type: Sem.Data.SprocAccess.FileSystemTests.ClassMap

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystemTests.Map]]. 



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassMap.To

 Tests the method [[|M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)]]. 



---
### Method: ClassMap.To.MapsSampleType

 Tests default property name mapping to a sample class. 


Returns: A task to wait for.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute

 Tests for the method [[|M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])]]. 



---
### Method: ClassTxtDatabase.Execute.ReadsIntFromCorrectColumn

 Tests whether the [[|T:System.Int32]] column can be mapped correctly. 


Returns: A task to wait for.



---
### Method: ClassTxtDatabase.Execute.ReadsDateTimeFromCorrectColumn

 Tests whether the [[|T:System.DateTime]] column can be mapped correctly. 


Returns: A task to wait for.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.Map

 Helper class that implements a slow, bt generic mapper method. 



---
### Method: Map.To\<T>(Sem.Data.SprocAccess.IReader)

 Mapper method that maps data from an [[|T:Sem.Data.SprocAccess.IReader]] to a POCO object using the names of the properties. The process uses a very simple reflection based approach, that is not really "production ready" - use an explicit and specific implementation in production to prevent the overhead of reflection. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the target POCO objects.|
#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader implementation.|

Returns: The initialized object instance.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.Sample

 Sample class for mapping tests. 



---
### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Id

 Gets or sets the identifier of the row. 



---
### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Date

 Gets or sets the date specified in a row. 



---


# Sem.Data.SprocAccess.IntegrationTests ##

## Type: Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension

 Logging batched items - this is only implemented to test the flexibility of the logging, not to be used in production. The way it is currently implemented does not provide any benefit to the logging process. 



---
### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Queue

 Queue to collect logging items. 



---
### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.QueueLock

 Lock to be able to pull a consistent set of items from the queue without other threads to interfere. 



---
### Method: BatchLogExtension.Batch(System.Action\<Sem.Tools.Logging.LogCategories, Sem.Tools.Logging.LogLevel, Sem.Tools.Logging.LogScope, string>, System.Int32)

 Simply batches the log execution - this has NO real benefit ... for testing purpose only. 

#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The current log method.|
|batchSize: |The count of logs to be collected.|

Returns: A new log method.



---
## Type: Sem.Data.SprocAccess.IntegrationTests.Program

 Simple executable that will read the database named of a local SQL server instance using a trusted connection (current user must be able to execute SPROC [sys].[sp_databases]). 



---
### Method: Program.Main

 Entry point for the integration test program. 


Returns: A task to wait for.



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
### Method: SqlDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get\<T>(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get(System.Int32, System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.IndexByName(string)

 !! UNSUPPORTED: inheritdoc !! 

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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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


# Sem.Tools.Logging.Tests ##

## Type: Sem.Tools.Logging.Tests.ClassLogCategoryExtensions

 Tests for the static helper class [[|T:Sem.Tools.Logging.LogCategoryExtensions]]. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast

 Tests the method [[|M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)]]. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagSingle

 Tests whether the method can detect a single flag being set. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagInCombination

 Tests whether the method can detect a single flag in a variable with multiple flags being set. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagNotSet

 Tests whether the method can detect a single flag not being set. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope

 Tests for the class [[|T:Sem.Tools.Logging.LogScope]]. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor

 Tests the constructor(s) for [[|T:Sem.Tools.Logging.LogScope]]. 



---
### Method: ClassLogScope.LogScopeConstructor.LogsScopeStart

 Tests whether the ctor log line is formatted correctly. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Dispose

 Tests the method for [[|M:Sem.Tools.Logging.LogScope.Dispose]]. 



---
### Method: ClassLogScope.Dispose.LogsScopeEnd

 Tests whether the destructor log line is formatted correctly. 



---
### Method: ClassLogScope.Dispose.LogsScopeStart

 Tests whether the indentation of logs is correct. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Child

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)]]. 



---
### Method: ClassLogScope.Child.StartingChildScopeAddsIdToHierarchy

 Tests whether the ctor log line is formatted correctly. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Log

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]]. 



---
### Method: ClassLogScope.Log.DefaultsToCorrectLevelAndCategory

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs using the correct category and level. 



---
### Method: ClassLogScope.Log.LogsOnlySpecifiedCategories

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
### Method: ClassLogScope.Log.LogsOnlyToSpecifiedLevel

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
## Type: Sem.Tools.Logging.Tests.LoggerTestBase

 Base class for tests of the logger class. 



---
### Method: LoggerTestBase.#cctor

 Initializes static members of the [[|T:Sem.Tools.Logging.Tests.LoggerTestBase]] class. Initializes the static values of [[|T:Sem.Tools.Logging.LogScope]] to produce deterministic log entries. 



---
### P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages

 Gets the logged messages. 



---
### Method: LoggerTestBase.LogMethod(Sem.Tools.Logging.LogCategories, Sem.Tools.Logging.LogLevel, Sem.Tools.Logging.LogScope, string)

 A log method that adds the log information to [[|P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages]]. 

#### Parameters:
|Name | Description |
|-----|------|
|category|The category of the log entry.|
|level: |The log level.|
|scope: |The logging scope that renders the log entry.|
|message: |The log message.|


---
### Method: LoggerTestBase.BasePath(string)

 Uses a compile time attribute to determine the source code path of this class. 

#### Parameters:
|Name | Description |
|-----|------|
|path|Path of this class will be set at compile time.|

Returns: The source code path of this class.



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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
### Method: TxtDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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


Returns: A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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
### Method: TxtDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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


Returns: A value indicating whether there is still data at this line.



---
### Method: TxtReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: TxtReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: TxtReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: TxtReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



---
### Method: TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


# Sem.Data.SprocAccess.FileSystemTests ##

## Type: Sem.Data.SprocAccess.FileSystemTests.ClassMap

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystemTests.Map]]. 



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassMap.To

 Tests the method [[|M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)]]. 



---
### Method: ClassMap.To.MapsSampleType

 Tests default property name mapping to a sample class. 


Returns: A task to wait for.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
## Type: Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute

 Tests for the method [[|M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])]]. 



---
### Method: ClassTxtDatabase.Execute.ReadsIntFromCorrectColumn

 Tests whether the [[|T:System.Int32]] column can be mapped correctly. 


Returns: A task to wait for.



---
### Method: ClassTxtDatabase.Execute.ReadsDateTimeFromCorrectColumn

 Tests whether the [[|T:System.DateTime]] column can be mapped correctly. 


Returns: A task to wait for.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.Map

 Helper class that implements a slow, bt generic mapper method. 



---
### Method: Map.To\<T>(Sem.Data.SprocAccess.IReader)

 Mapper method that maps data from an [[|T:Sem.Data.SprocAccess.IReader]] to a POCO object using the names of the properties. The process uses a very simple reflection based approach, that is not really "production ready" - use an explicit and specific implementation in production to prevent the overhead of reflection. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the target POCO objects.|
#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader implementation.|

Returns: The initialized object instance.



---
## Type: Sem.Data.SprocAccess.FileSystemTests.Sample

 Sample class for mapping tests. 



---
### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Id

 Gets or sets the identifier of the row. 



---
### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Date

 Gets or sets the date specified in a row. 



---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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


# Sem.Data.SprocAccess.IntegrationTests ##

## Type: Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension

 Logging batched items - this is only implemented to test the flexibility of the logging, not to be used in production. The way it is currently implemented does not provide any benefit to the logging process. 



---
### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Queue

 Queue to collect logging items. 



---
### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.QueueLock

 Lock to be able to pull a consistent set of items from the queue without other threads to interfere. 



---
### Method: BatchLogExtension.Batch(System.Action\<Sem.Tools.Logging.LogCategories, Sem.Tools.Logging.LogLevel, Sem.Tools.Logging.LogScope, string>, System.Int32)

 Simply batches the log execution - this has NO real benefit ... for testing purpose only. 

#### Parameters:
|Name | Description |
|-----|------|
|currentAction|The current log method.|
|batchSize: |The count of logs to be collected.|

Returns: A new log method.



---
## Type: Sem.Data.SprocAccess.IntegrationTests.Program

 Simple executable that will read the database named of a local SQL server instance using a trusted connection (current user must be able to execute SPROC [sys].[sp_databases]). 



---
### Method: Program.Main

 Entry point for the integration test program. 


Returns: A task to wait for.



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
### Method: SqlDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get\<T>(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get(System.Int32, System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.IndexByName(string)

 !! UNSUPPORTED: inheritdoc !! 

---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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
### Method: SqlDatabase.Execute\<T>(string, Func\<Sem.Data.SprocAccess.IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

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

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get\<T>(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Get(System.Int32, System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
### Method: SqlReader.IndexByName(string)

 !! UNSUPPORTED: inheritdoc !! 

---


# Sem.Data.SprocAccess ##

## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T>(string, Func\<IReader, Task\<T>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, Object>[])

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

Returns: A series of POCO instances.



---
## Type: Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read

 Advances to the next record. 


Returns: A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T>(System.Int32)

 Reads the value of a column by its index. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type of the result.|
#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|

Returns: The value of the column in the current row.



---
### Method: IReader.Get(System.Int32, System.Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

Returns: The value of the column in the current row.



---
### Method: IReader.NextResult

 Advances to the next result set. 


Returns: A task to wait for.



---
### Method: IReader.Close

 Closes the reader. 


Returns: A task to wait for.



---
### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

Returns: The index of the column.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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


# Sem.Tools.Logging.Tests ##

## Type: Sem.Tools.Logging.Tests.ClassLogCategoryExtensions

 Tests for the static helper class [[|T:Sem.Tools.Logging.LogCategoryExtensions]]. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast

 Tests the method [[|M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)]]. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagSingle

 Tests whether the method can detect a single flag being set. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagInCombination

 Tests whether the method can detect a single flag in a variable with multiple flags being set. 



---
### Method: ClassLogCategoryExtensions.HasFlagFast.DetectsFlagNotSet

 Tests whether the method can detect a single flag not being set. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope

 Tests for the class [[|T:Sem.Tools.Logging.LogScope]]. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor

 Tests the constructor(s) for [[|T:Sem.Tools.Logging.LogScope]]. 



---
### Method: ClassLogScope.LogScopeConstructor.LogsScopeStart

 Tests whether the ctor log line is formatted correctly. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Dispose

 Tests the method for [[|M:Sem.Tools.Logging.LogScope.Dispose]]. 



---
### Method: ClassLogScope.Dispose.LogsScopeEnd

 Tests whether the destructor log line is formatted correctly. 



---
### Method: ClassLogScope.Dispose.LogsScopeStart

 Tests whether the indentation of logs is correct. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Child

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)]]. 



---
### Method: ClassLogScope.Child.StartingChildScopeAddsIdToHierarchy

 Tests whether the ctor log line is formatted correctly. 



---
## Type: Sem.Tools.Logging.Tests.ClassLogScope.Log

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]]. 



---
### Method: ClassLogScope.Log.DefaultsToCorrectLevelAndCategory

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs using the correct category and level. 



---
### Method: ClassLogScope.Log.LogsOnlySpecifiedCategories

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
### Method: ClassLogScope.Log.LogsOnlyToSpecifiedLevel

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
## Type: Sem.Tools.Logging.Tests.LoggerTestBase

 Base class for tests of the logger class. 



---
### Method: LoggerTestBase.#cctor

 Initializes static members of the [[|T:Sem.Tools.Logging.Tests.LoggerTestBase]] class. Initializes the static values of [[|T:Sem.Tools.Logging.LogScope]] to produce deterministic log entries. 



---
### P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages

 Gets the logged messages. 



---
### Method: LoggerTestBase.LogMethod(Sem.Tools.Logging.LogCategories, Sem.Tools.Logging.LogLevel, Sem.Tools.Logging.LogScope, string)

 A log method that adds the log information to [[|P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages]]. 

#### Parameters:
|Name | Description |
|-----|------|
|category|The category of the log entry.|
|level: |The log level.|
|scope: |The logging scope that renders the log entry.|
|message: |The log message.|


---
### Method: LoggerTestBase.BasePath(string)

 Uses a compile time attribute to determine the source code path of this class. 

#### Parameters:
|Name | Description |
|-----|------|
|path|Path of this class will be set at compile time.|

Returns: The source code path of this class.



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
### Method: LogCategoryExtensions.HasFlag\<T>(``0, ``0)

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

Returns: A value indicating whether the flag is set.



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

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
### Method: LogExtension.AddConsole(System.Action\<LogCategories, LogLevel, LogScope, string>)

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



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

Returns: A new logging scope.



---
### Method: LogScope.MethodStart(Object, string, string)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

Returns: A new scope.



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

Returns: A new scope.



---
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


Returns: A task to wait for.



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


