# [Sem.Data.SprocAccess.SqlServer](#Sem.Data.SprocAccess.SqlServer)

## Type: Sem.Data.SprocAccess.SqlServer.SqlDatabase

 An implementation of [Sem.Data.SprocAccess.IDatabase](Sem.Data.SprocAccess.md#type-semdatasprocaccessidatabase) using SQL server as a backend. 



---
### Method: SqlDatabase.#ctor(String)

 Initializes a new instance of the [Sem.Data.SprocAccess.SqlServer.SqlDatabase](Sem.Data.SprocAccess.SqlServer.md#type-semdatasprocaccesssqlserversqldatabase) class. 

#### Parameters:
|Name | Description |
|-----|------|
|connectionString|The database connection string to use for this instance.|


---
### Method: SqlDatabase.Execute\<T1>(String, Func\<Sem.Data.SprocAccess.IReader, Task\<T1>>, Sem.Tools.Logging.LogScope, KeyValuePair\<String, Object>[])

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

 SQL serer implementation of the reader interface [Sem.Data.SprocAccess.IReader](Sem.Data.SprocAccess.md#type-semdatasprocaccessireader). 



---
### Method: SqlReader.#ctor(Data.SqlClient.SqlDataReader)

 Initializes a new instance of the [Sem.Data.SprocAccess.SqlServer.SqlReader](Sem.Data.SprocAccess.SqlServer.md#type-semdatasprocaccesssqlserversqlreader) class. 

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
### Method: SqlReader.Get\<T1>(Int32)

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
### Method: SqlReader.Get(Int32, Type)

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
### Method: SqlReader.IndexByName(String)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


---
