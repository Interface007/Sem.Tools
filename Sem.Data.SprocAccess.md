# [Sem.Data.SprocAccess](#Sem.Data.SprocAccess)

---
## Type: Sem.Data.SprocAccess.IDatabase

 Very simple and small interface to interact with databases. 



### Method: IDatabase.Execute\<T1>(string, Func\<IReader, Task\<T1>>, Sem.Tools.Logging.LogScope, KeyValuePair\<string, object>[])

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



### Method: IReader.Read

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.


### Method: IReader.Get\<T1>(int)

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


### Method: IReader.Get(int, Type)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.


### Method: IReader.NextResult

 Advances to the next result set. 


#### Returns:
A task to wait for.


### Method: IReader.Close

 Closes the reader. 


#### Returns:
A task to wait for.


### Method: IReader.IndexByName(string)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.




---
