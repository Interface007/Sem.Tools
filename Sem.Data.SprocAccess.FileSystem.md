# [Sem.Data.SprocAccess.FileSystem](#Sem.Data.SprocAccess.FileSystem)

## Type: Sem.Data.SprocAccess.FileSystem.TxtDatabase

 Simple text file implementation of [Sem.Data.SprocAccess.IDatabase](Sem.Data.SprocAccess.md#semdatasprocaccessidatabase). Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
### Method: Sem.Data.SprocAccess.FileTxtDatabase.#ctor(String)

 Initializes a new instance of the [Sem.Data.SprocAccess.FileSystem.TxtDatabase](Sem.Data.SprocAccess.FileSystem.md#semdatasprocaccessfilesystemtxtdatabase) class. 

#### Parameters:
|Name | Description |
|-----|------|
|baseFolder|The base folder for the data files.|


---
### Method: Sem.Data.SprocAccess.FileTxtDatabase.Execute\<T1>(String, Func\<Sem.Data.SprocAccess.IReader, Task\<T1>>, Sem.Tools.Logging.LogScope, KeyValuePair\<String, Object>[])

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
### Method: Sem.Data.SprocAccess.FileTxtDatabase.DisposeAsync

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.FileSystem.TxtReader

 Reader implementation for a bunch of text files - [Sem.Data.SprocAccess.FileSystem.TxtDatabase](Sem.Data.SprocAccess.FileSystem.md#semdatasprocaccessfilesystemtxtdatabase). 



---
### Method: Sem.Data.SprocAccess.FileTxtReader.#ctor(String)

 Initializes a new instance of the [Sem.Data.SprocAccess.FileSystem.TxtReader](Sem.Data.SprocAccess.FileSystem.md#semdatasprocaccessfilesystemtxtreader) class. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The name of the file containing the data.|


---
### Method: Sem.Data.SprocAccess.FileTxtReader.Read

 Increments the line pointer. 


#### Returns:
A value indicating whether there is still data at this line.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Get\<T1>(Int32)

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
### Method: Sem.Data.SprocAccess.FileTxtReader.Get(Int32, Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.IndexByName(String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Init

 Reads the text file and initializes the line-pointer. 



---


---
