## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Data.SprocAccess.FileSystem ##

# T:Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

|Name | Description |
|-----|------|
|baseFolder: |The base folder for the data files.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

|Name | Description |
|-----|------|
|fileName: |The name of the file containing the data.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Read

 Increments the line pointer. 

Returns: A value indicating whether there is still data at this line.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


## Sem.Data.SprocAccess.FileSystemTests ##

# T:Sem.Data.SprocAccess.FileSystemTests.ClassMap

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystemTests.Map]]. 



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To

 Tests the method [[|M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)]]. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To.MapsSampleType

 Tests default property name mapping to a sample class. 

Returns: A task to wait for.



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute

 Tests for the method [[|M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])]]. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute.ReadsIntFromCorrectColumn

 Tests whether the [[|T:System.Int32]] column can be mapped correctly. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute.ReadsDateTimeFromCorrectColumn

 Tests whether the [[|T:System.DateTime]] column can be mapped correctly. 

Returns: A task to wait for.



---
# T:Sem.Data.SprocAccess.FileSystemTests.Map

 Helper class that implements a slow, bt generic mapper method. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)

 Mapper method that maps data from an [[|T:Sem.Data.SprocAccess.IReader]] to a POCO object using the names of the properties. The process uses a very simple reflection based approach, that is not really "production ready" - use an explicit and specific implementation in production to prevent the overhead of reflection. 

|Name | Description |
|-----|------|
|T: |The type of the target POCO objects.|
|Name | Description |
|-----|------|
|reader: |The reader implementation.|
Returns: The initialized object instance.



---
# T:Sem.Data.SprocAccess.FileSystemTests.Sample

 Sample class for mapping tests. 



---
##### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Id

 Gets or sets the identifier of the row. 



---
##### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Date

 Gets or sets the date specified in a row. 



---


## Sem.Data.SprocAccess.IntegrationTests ##

# T:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension

 Logging batched items - this is only implemented to test the flexibility of the logging, not to be used in production. The way it is currently implemented does not provide any benefit to the logging process. 



---
##### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Queue

 Queue to collect logging items. 



---
##### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.QueueLock

 Lock to be able to pull a consistent set of items from the queue without other threads to interfere. 



---
##### M:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Batch(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.Int32)

 Simply batches the log execution - this has NO real benefit ... for testing purpose only. 

|Name | Description |
|-----|------|
|currentAction: |The current log method.|
|Name | Description |
|-----|------|
|batchSize: |The count of logs to be collected.|
Returns: A new log method.



---
# T:Sem.Data.SprocAccess.IntegrationTests.Program

 Simple executable that will read the database named of a local SQL server instance using a trusted connection (current user must be able to execute SPROC [sys].[sp_databases]). 



---
##### M:Sem.Data.SprocAccess.IntegrationTests.Program.Main

 Entry point for the integration test program. 

Returns: A task to wait for.



---


## Sem.Data.SprocAccess.SqlServer ##

# T:Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
##### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

|Name | Description |
|-----|------|
|connectionString: |The database connection string to use for this instance.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

|Name | Description |
|-----|------|
|sqlDataReader: |The data reader to read from.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Read

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get``1(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get(System.Int32,System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.IndexByName(System.String)

 !! UNSUPPORTED: inheritdoc !! 

---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Tools.Logging.Tests ##

# T:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions

 Tests for the static helper class [[|T:Sem.Tools.Logging.LogCategoryExtensions]]. 



---
# T:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast

 Tests the method [[|M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagSingle

 Tests whether the method can detect a single flag being set. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagInCombination

 Tests whether the method can detect a single flag in a variable with multiple flags being set. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagNotSet

 Tests whether the method can detect a single flag not being set. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope

 Tests for the class [[|T:Sem.Tools.Logging.LogScope]]. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor

 Tests the constructor(s) for [[|T:Sem.Tools.Logging.LogScope]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor.LogsScopeStart

 Tests whether the ctor log line is formatted correctly. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Dispose

 Tests the method for [[|M:Sem.Tools.Logging.LogScope.Dispose]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Dispose.LogsScopeEnd

 Tests whether the destructor log line is formatted correctly. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Dispose.LogsScopeStart

 Tests whether the indentation of logs is correct. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Child

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Child.StartingChildScopeAddsIdToHierarchy

 Tests whether the ctor log line is formatted correctly. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Log

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.DefaultsToCorrectLevelAndCategory

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs using the correct category and level. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.LogsOnlySpecifiedCategories

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.LogsOnlyToSpecifiedLevel

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
# T:Sem.Tools.Logging.Tests.LoggerTestBase

 Base class for tests of the logger class. 



---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.#cctor

 Initializes static members of the [[|T:Sem.Tools.Logging.Tests.LoggerTestBase]] class. Initializes the static values of [[|T:Sem.Tools.Logging.LogScope]] to produce deterministic log entries. 



---
##### P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages

 Gets the logged messages. 



---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.LogMethod(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String)

 A log method that adds the log information to [[|P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages]]. 

|Name | Description |
|-----|------|
|category: |The category of the log entry.|
|Name | Description |
|-----|------|
|level: |The log level.|
|Name | Description |
|-----|------|
|scope: |The logging scope that renders the log entry.|
|Name | Description |
|-----|------|
|message: |The log message.|


---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.BasePath(System.String)

 Uses a compile time attribute to determine the source code path of this class. 

|Name | Description |
|-----|------|
|path: |Path of this class will be set at compile time.|
Returns: The source code path of this class.



---


## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Data.SprocAccess.FileSystem ##

# T:Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

|Name | Description |
|-----|------|
|baseFolder: |The base folder for the data files.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

|Name | Description |
|-----|------|
|fileName: |The name of the file containing the data.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Read

 Increments the line pointer. 

Returns: A value indicating whether there is still data at this line.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Data.SprocAccess.FileSystem ##

# T:Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [[|T:Sem.Data.SprocAccess.IDatabase]]. Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtDatabase.baseFolder

 The base folder path. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]] class. 

|Name | Description |
|-----|------|
|baseFolder: |The base folder for the data files.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileName

 The file name of the data file for this result. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.fileLines

 The actual lines of the file. TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-). 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.lineIndex

 The "pointer" to the current row;. 



---
##### F:Sem.Data.SprocAccess.FileSystem.TxtReader.resultIndex

 The index of the current result set - all data files contain a two-digit-index. 



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.FileSystem.TxtReader]] class. 

|Name | Description |
|-----|------|
|fileName: |The name of the file containing the data.|


---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Read

 Increments the line pointer. 

Returns: A value indicating whether there is still data at this line.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---
##### M:Sem.Data.SprocAccess.FileSystem.TxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


## Sem.Data.SprocAccess.FileSystemTests ##

# T:Sem.Data.SprocAccess.FileSystemTests.ClassMap

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystemTests.Map]]. 



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To

 Tests the method [[|M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)]]. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassMap.To.MapsSampleType

 Tests default property name mapping to a sample class. 

Returns: A task to wait for.



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase

 Tests for the class [[|T:Sem.Data.SprocAccess.FileSystem.TxtDatabase]]. 



---
# T:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute

 Tests for the method [[|M:Sem.Data.SprocAccess.FileSystem.TxtDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])]]. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute.ReadsIntFromCorrectColumn

 Tests whether the [[|T:System.Int32]] column can be mapped correctly. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.FileSystemTests.ClassTxtDatabase.Execute.ReadsDateTimeFromCorrectColumn

 Tests whether the [[|T:System.DateTime]] column can be mapped correctly. 

Returns: A task to wait for.



---
# T:Sem.Data.SprocAccess.FileSystemTests.Map

 Helper class that implements a slow, bt generic mapper method. 



---
##### M:Sem.Data.SprocAccess.FileSystemTests.Map.To``1(Sem.Data.SprocAccess.IReader)

 Mapper method that maps data from an [[|T:Sem.Data.SprocAccess.IReader]] to a POCO object using the names of the properties. The process uses a very simple reflection based approach, that is not really "production ready" - use an explicit and specific implementation in production to prevent the overhead of reflection. 

|Name | Description |
|-----|------|
|T: |The type of the target POCO objects.|
|Name | Description |
|-----|------|
|reader: |The reader implementation.|
Returns: The initialized object instance.



---
# T:Sem.Data.SprocAccess.FileSystemTests.Sample

 Sample class for mapping tests. 



---
##### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Id

 Gets or sets the identifier of the row. 



---
##### P:Sem.Data.SprocAccess.FileSystemTests.Sample.Date

 Gets or sets the date specified in a row. 



---


## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Data.SprocAccess.IntegrationTests ##

# T:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension

 Logging batched items - this is only implemented to test the flexibility of the logging, not to be used in production. The way it is currently implemented does not provide any benefit to the logging process. 



---
##### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Queue

 Queue to collect logging items. 



---
##### F:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.QueueLock

 Lock to be able to pull a consistent set of items from the queue without other threads to interfere. 



---
##### M:Sem.Data.SprocAccess.IntegrationTests.BatchLogExtension.Batch(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.Int32)

 Simply batches the log execution - this has NO real benefit ... for testing purpose only. 

|Name | Description |
|-----|------|
|currentAction: |The current log method.|
|Name | Description |
|-----|------|
|batchSize: |The count of logs to be collected.|
Returns: A new log method.



---
# T:Sem.Data.SprocAccess.IntegrationTests.Program

 Simple executable that will read the database named of a local SQL server instance using a trusted connection (current user must be able to execute SPROC [sys].[sp_databases]). 



---
##### M:Sem.Data.SprocAccess.IntegrationTests.Program.Main

 Entry point for the integration test program. 

Returns: A task to wait for.



---


## Sem.Data.SprocAccess.SqlServer ##

# T:Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
##### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

|Name | Description |
|-----|------|
|connectionString: |The database connection string to use for this instance.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

|Name | Description |
|-----|------|
|sqlDataReader: |The data reader to read from.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Read

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get``1(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get(System.Int32,System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.IndexByName(System.String)

 !! UNSUPPORTED: inheritdoc !! 

---


## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Data.SprocAccess.SqlServer ##

# T:Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [[|T:Sem.Data.SprocAccess.IDatabase]] using SQL server as a backend. 



---
##### F:Sem.Data.SprocAccess.SqlServer.SqlDatabase.connectionString

 The connection string for the database. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.#ctor(System.String)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlDatabase]] class. 

|Name | Description |
|-----|------|
|connectionString: |The database connection string to use for this instance.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlDatabase.DisposeAsync

 !! UNSUPPORTED: inheritdoc !! 

---
# T:Sem.Data.SprocAccess.SqlServer.SqlReader

 SQL serer implementation of the reader interface [[|T:Sem.Data.SprocAccess.IReader]]. 



---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.#ctor(System.Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [[|T:Sem.Data.SprocAccess.SqlServer.SqlReader]] class. 

|Name | Description |
|-----|------|
|sqlDataReader: |The data reader to read from.|


---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Read

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get``1(System.Int32)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Get(System.Int32,System.Type)

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.NextResult

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.Close

 !! UNSUPPORTED: inheritdoc !! 

---
##### M:Sem.Data.SprocAccess.SqlServer.SqlReader.IndexByName(System.String)

 !! UNSUPPORTED: inheritdoc !! 

---


## Sem.Data.SprocAccess ##

# T:Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



---
##### M:Sem.Data.SprocAccess.IDatabase.Execute``1(System.String,System.Func{Sem.Data.SprocAccess.IReader,System.Threading.Tasks.Task{``0}},Sem.Tools.Logging.LogScope,System.Collections.Generic.KeyValuePair{System.String,System.Object}[])

 Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs. 

|Name | Description |
|-----|------|
|T: |The POCO type to map the result to.|
|Name | Description |
|-----|------|
|sproc: |The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").|
|Name | Description |
|-----|------|
|readerToObject: |A function that maps a single result into a POCO instance.|
|Name | Description |
|-----|------|
|logger: |Optional logger.|
|Name | Description |
|-----|------|
|parameters: |The named parameters for the SPROC.|
Returns: A series of POCO instances.



---
# T:Sem.Data.SprocAccess.IReader

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
##### M:Sem.Data.SprocAccess.IReader.Read

 Advances to the next record. 

Returns: A value indicating whether there is still data to be read.



---
##### M:Sem.Data.SprocAccess.IReader.Get``1(System.Int32)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|T: |The type of the result.|
|Name | Description |
|-----|------|
|index: |The column index.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.Get(System.Int32,System.Type)

 Reads the value of a column by its index. 

|Name | Description |
|-----|------|
|index: |The column index.|
|Name | Description |
|-----|------|
|type: |The type of the result.|
Returns: The value of the column in the current row.



---
##### M:Sem.Data.SprocAccess.IReader.NextResult

 Advances to the next result set. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.Close

 Closes the reader. 

Returns: A task to wait for.



---
##### M:Sem.Data.SprocAccess.IReader.IndexByName(System.String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

|Name | Description |
|-----|------|
|columnName: |The name of the column to search.|
Returns: The index of the column.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


## Sem.Tools.Logging.Tests ##

# T:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions

 Tests for the static helper class [[|T:Sem.Tools.Logging.LogCategoryExtensions]]. 



---
# T:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast

 Tests the method [[|M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagSingle

 Tests whether the method can detect a single flag being set. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagInCombination

 Tests whether the method can detect a single flag in a variable with multiple flags being set. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogCategoryExtensions.HasFlagFast.DetectsFlagNotSet

 Tests whether the method can detect a single flag not being set. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope

 Tests for the class [[|T:Sem.Tools.Logging.LogScope]]. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor

 Tests the constructor(s) for [[|T:Sem.Tools.Logging.LogScope]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.LogScopeConstructor.LogsScopeStart

 Tests whether the ctor log line is formatted correctly. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Dispose

 Tests the method for [[|M:Sem.Tools.Logging.LogScope.Dispose]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Dispose.LogsScopeEnd

 Tests whether the destructor log line is formatted correctly. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Dispose.LogsScopeStart

 Tests whether the indentation of logs is correct. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Child

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Child.StartingChildScopeAddsIdToHierarchy

 Tests whether the ctor log line is formatted correctly. 



---
# T:Sem.Tools.Logging.Tests.ClassLogScope.Log

 Tests the method [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]]. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.DefaultsToCorrectLevelAndCategory

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs using the correct category and level. 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.LogsOnlySpecifiedCategories

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
##### M:Sem.Tools.Logging.Tests.ClassLogScope.Log.LogsOnlyToSpecifiedLevel

 Tests whether [[|M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)]] logs only the specified level(s). 



---
# T:Sem.Tools.Logging.Tests.LoggerTestBase

 Base class for tests of the logger class. 



---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.#cctor

 Initializes static members of the [[|T:Sem.Tools.Logging.Tests.LoggerTestBase]] class. Initializes the static values of [[|T:Sem.Tools.Logging.LogScope]] to produce deterministic log entries. 



---
##### P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages

 Gets the logged messages. 



---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.LogMethod(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String)

 A log method that adds the log information to [[|P:Sem.Tools.Logging.Tests.LoggerTestBase.LogMessages]]. 

|Name | Description |
|-----|------|
|category: |The category of the log entry.|
|Name | Description |
|-----|------|
|level: |The log level.|
|Name | Description |
|-----|------|
|scope: |The logging scope that renders the log entry.|
|Name | Description |
|-----|------|
|message: |The log message.|


---
##### M:Sem.Tools.Logging.Tests.LoggerTestBase.BasePath(System.String)

 Uses a compile time attribute to determine the source code path of this class. 

|Name | Description |
|-----|------|
|path: |Path of this class will be set at compile time.|
Returns: The source code path of this class.



---


## Sem.Tools.Logging ##

# T:Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
##### F:Sem.Tools.Logging.LogCategories.None

 The context is not determined. 



---
##### F:Sem.Tools.Logging.LogCategories.Technical

 The log information is pure technical. 



---
##### F:Sem.Tools.Logging.LogCategories.Business

 The log information is pure business. 



---
# T:Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [[|T:Sem.Tools.Logging.LogCategories]]. 



---
##### M:Sem.Tools.Logging.LogCategoryExtensions.HasFlag``1(``0,``0)

 Tests whether a value has a specific category flag set. 

|Name | Description |
|-----|------|
|T: |The enum type to be tested.|
|Name | Description |
|-----|------|
|value: |The value to be tested.|
|Name | Description |
|-----|------|
|flag: |The flag that should be tested.|
Returns: A value indicating whether the flag is set.



---
# T:Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



---
##### M:Sem.Tools.Logging.LogExtension.AddDebug(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Diagnostics.Debug.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Diagnostics.Debug]].



---
##### M:Sem.Tools.Logging.LogExtension.AddConsole(System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String})

 Simple output using [[|M:System.Console.WriteLine(System.Object)]]. 

|Name | Description |
|-----|------|
|logMethod: |The original log method, this method should be added to.|
Returns: A new method that is the combination of  !! UNSUPPORTED: paramref !!  and an output to [[|T:System.Console]].



---
# T:Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
##### F:Sem.Tools.Logging.LogLevel.None

 Log never. 



---
##### F:Sem.Tools.Logging.LogLevel.Exception

 When writing logs: Specifies that this entry is an exception. When configuring logger: will only allow exceptions to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Warning

 When writing logs: Specifies that this entry is a warning (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]]). When configuring logger: will only allow exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Information

 When writing logs: Specifies that this entry is a information (less important than an [[|F:Sem.Tools.Logging.LogLevel.Exception]] or a [[|F:Sem.Tools.Logging.LogLevel.Warning]]). When configuring logger: will only allow information, exceptions and warnings to be logged. 



---
##### F:Sem.Tools.Logging.LogLevel.Trace

 When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging). When configuring logger: will only allow any message to be logged. 



---
# T:Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



---
##### F:Sem.Tools.Logging.LogScope.idStack

 Gets the structure handling the hierarchy. 



---
##### P:Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 



---
##### P:Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
##### P:Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 



---
##### P:Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 



---
##### P:Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 



---
##### P:Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Create(System.String,System.Action{Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,Sem.Tools.Logging.LogScope,System.String},System.String,System.String)

 Create a new scope instance. 

|Name | Description |
|-----|------|
|scopeName: |Name of the scope.|
|Name | Description |
|-----|------|
|logMethod: |Method that renders the log entry.|
|Name | Description |
|-----|------|
|member: |The member (method) that creates the instance.|
|Name | Description |
|-----|------|
|path: |The path to the class file.|
Returns: A new logging scope.



---
##### M:Sem.Tools.Logging.LogScope.MethodStart(System.Object,System.String,System.String)

 Call this to indicate a method start. 

|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.Child(System.String,System.Object,System.String,System.String)

 Creates a new child scope. 

|Name | Description |
|-----|------|
|childName: | The name of the scope. |
|Name | Description |
|-----|------|
|value: |A value that should be logged as part of the creation.|
|Name | Description |
|-----|------|
|member: |The name of the method.|
|Name | Description |
|-----|------|
|path: |The path of the source file.|
Returns: A new scope.



---
##### M:Sem.Tools.Logging.LogScope.DisposeAsync

 Async implementation of the dispose pattern. 

Returns: A task to wait for.



---
##### M:Sem.Tools.Logging.LogScope.Dispose

 Logs the end of the scope. 



---
##### M:Sem.Tools.Logging.LogScope.Log(System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---
##### M:Sem.Tools.Logging.LogScope.Log(Sem.Tools.Logging.LogCategories,Sem.Tools.Logging.LogLevel,System.String,System.Object)

 Logs a message. 

|Name | Description |
|-----|------|
|logCategory: |The category of this message (Is it technical information of business process information?).|
|Name | Description |
|-----|------|
|logLevel: |The log level of this message (How important is this message?).|
|Name | Description |
|-----|------|
|message: |The message to be logged.|
|Name | Description |
|-----|------|
|value: |A value that should be included into the message as addition data.|


---


