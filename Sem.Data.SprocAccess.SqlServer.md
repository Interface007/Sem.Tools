# Sem.Data.SprocAccess.SqlServer (#Sem.Data.SprocAccess.SqlServer)

## [Type: Sem.Data.SprocAccess.SqlServer.SqlDatabase](#Ref862f04d9094f826c09b6d57fec638e30608146d06092e855c1dd1c9ae39db1a0)

 An implementation of [Sem.Data.SprocAccess.IDatabase](T:Sem.Data.SprocAccess.md#Ref3a173008c7c029ceadd480ce5257abcb04f85c10a71936b8a19f0ea7864339e7) using SQL server as a backend. 



---
### [Method: SqlDatabase.#ctor(String)](#Ref2083d2cfd7763d4363b8b4efa4d1b99f5b08329dcf826dc15b4f4145994436ed)

 Initializes a new instance of the [Sem.Data.SprocAccess.SqlServer.SqlDatabase](T:Sem.Data.SprocAccess.SqlServer.md#Ref4e2a2c293efa5dee5b8ab120fbc8a5ed02c590709dba4d848bee55b8403083b2) class. 

#### Parameters:
|Name | Description |
|-----|------|
|connectionString|The database connection string to use for this instance.|


---
### [Method: SqlDatabase.Execute\<T1>(String, Func\<Sem.Data.SprocAccess.IReader, Threading.Tasks.Task\<T1>>, Sem.Tools.Logging.LogScope, Collections.Generic.KeyValuePair\<String, Object>[])](#Ref8c3a2f50bf1a2c05594683d2ee1f7e335f0a8e26f46f051ea22d4740dcdd475a)

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
### [Method: SqlDatabase.DisposeAsync](#Ref9789e28cb032339f45b7a323ce6c1dd7dfc3648ad60d3f54694c2a04a23e6e7c)

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## [Type: Sem.Data.SprocAccess.SqlServer.SqlReader](#Refd1e06ca741158a28eb700dad8623a0005f6669f9ebdc7e2533c2e8f8467466bf)

 SQL serer implementation of the reader interface [Sem.Data.SprocAccess.IReader](T:Sem.Data.SprocAccess.md#Ref7175fc1b731107cbcf955298e1403907c77383c1244ac47d016ae74986287022). 



---
### [Method: SqlReader.#ctor(Data.SqlClient.SqlDataReader)](#Ref383c4cd66d58ffca3e9218e83257a35caa8f1e679ad089b36b3192623548d4a5)

 Initializes a new instance of the [Sem.Data.SprocAccess.SqlServer.SqlReader](T:Sem.Data.SprocAccess.SqlServer.md#Ref7aacb36611ee20435711da42eac1374c7e76107755b1a9ed58881d2d3df2812b) class. 

#### Parameters:
|Name | Description |
|-----|------|
|sqlDataReader|The data reader to read from.|


---
### [Method: SqlReader.Read](#Ref576924b077dc965dd00249028a394251e14471e250bb2149775d3b1686183e0c)

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### [Method: SqlReader.Get\<T1>(Int32)](#Refa5ca722363ebb70a1eb7029c7728f7b686538d88ab5c4da0a12ef234c2846a89)

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
### [Method: SqlReader.Get(Int32, Type)](#Refd3430e6294813c3db1bc08d424111fa569c300d22c434f4c847671593add6b38)

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### [Method: SqlReader.NextResult](#Ref2f2ee26c59354a8dee0236333cc33d279a76e19434290d797729f4e939101deb)

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### [Method: SqlReader.Close](#Refff7b060a5e8f60d671d1f1940d187a299b96369621ab16418bd7deb86545e9be)

 Closes the reader. 


#### Returns:
A task to wait for.



---
### [Method: SqlReader.IndexByName(String)](#Ref455540362db3827653df14df0e99a09740f375d39bab7b86369dafb337fc271a)

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


---
