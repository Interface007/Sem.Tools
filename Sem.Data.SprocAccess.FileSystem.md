# [Sem.Data.SprocAccess.FileSystem](#Sem.Data.SprocAccess.FileSystem)

## Type: Sem.Data.SprocAccess.FileSystem.TxtDatabase{#Ref60d3389ea6a4d4a39156251ea08e22afb722c84e813d5b2403b491b5bf75069e}

 Simple text file implementation of [Sem.Data.SprocAccess.IDatabase](Sem.Data.SprocAccess.md#Ref3a173008c7c029ceadd480ce5257abcb04f85c10a71936b8a19f0ea7864339e7). Can be used to mock database access easily. Each SPROC gets its own folder and each combination of parameters its own file. 



---
### Method: Sem.Data.SprocAccess.FileTxtDatabase.#ctor(String){#Ref68e4733945ff30ff2f590cb23ee8026077a4c635a9ed286245b65bdda8913137}

 Initializes a new instance of the [Sem.Data.SprocAccess.FileSystem.TxtDatabase](Sem.Data.SprocAccess.FileSystem.md#Refeae4b52b5194bfdf317847ba31d76d2ae4280d83b6db823fcfebe7417be1e8fe) class. 

#### Parameters:
|Name | Description |
|-----|------|
|baseFolder|The base folder for the data files.|


---
### Method: Sem.Data.SprocAccess.FileTxtDatabase.Execute\<T1>(String, Func\<Sem.Data.SprocAccess.IReader, Task\<T1>>, Sem.Tools.Logging.LogScope, KeyValuePair\<String, Object>[]){#Refabdb6d38673f2025c76b8ad850b69318591adb2cae15cf47ba06f64479b48a25}

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
### Method: Sem.Data.SprocAccess.FileTxtDatabase.DisposeAsync{#Ref26b766b275c72c62368883d6cf24953a87aff81fc2225892dfde7603847c057a}

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.


#### Returns:
A task that represents the asynchronous dispose operation.



---
## Type: Sem.Data.SprocAccess.FileSystem.TxtReader{#Refaeb4298b23e7f3ea0f54e92fde33e19b4e9dfdb27985c8b80d1b5030eaee3ec1}

 Reader implementation for a bunch of text files - [Sem.Data.SprocAccess.FileSystem.TxtDatabase](Sem.Data.SprocAccess.FileSystem.md#Refeae4b52b5194bfdf317847ba31d76d2ae4280d83b6db823fcfebe7417be1e8fe). 



---
### Method: Sem.Data.SprocAccess.FileTxtReader.#ctor(String){#Ref9360dbabfe408cd40da20092e5d8ed252455dda22938b4c24ca278afcd9aae5c}

 Initializes a new instance of the [Sem.Data.SprocAccess.FileSystem.TxtReader](Sem.Data.SprocAccess.FileSystem.md#Refb6cea98e7ef30dac565d07a13287340a8b7ed96c037d3f341d4b015210f4df7e) class. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The name of the file containing the data.|


---
### Method: Sem.Data.SprocAccess.FileTxtReader.Read{#Ref9ad4ae127c205153dbd44646cb5fc5fbd4706ff257595b9bf4c5c67ce9a52cb0}

 Increments the line pointer. 


#### Returns:
A value indicating whether there is still data at this line.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Get\<T1>(Int32){#Ref801287467d52cf77b457fae3510056307451c33be700ccee57705218eb5d818b}

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
### Method: Sem.Data.SprocAccess.FileTxtReader.Get(Int32, Type){#Ref9f9ec5aeb2ef2daeb92f59e4956e2274c88fea4fe5bc22bf86e682c1c45ee255}

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.NextResult{#Ref5e8c3c4bb1933803f6bd9031b90f76cb5556e5486cbb6ebebfc4effb22a5c57c}

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Close{#Reff298c91c65490cac3a6ea023996ff72eaacf1d9b5ffb376b332ef6b8d4116980}

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.IndexByName(String){#Ref5899ed7916820c31dc1a1d60e113c1cf7e7b2a1e7b5976146a570d40681b744c}

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---
### Method: Sem.Data.SprocAccess.FileTxtReader.Init{#Ref1c6c2e1b3b495d1afa2d9575e7df524bc012cbe4c94273b277644967985074e7}

 Reads the text file and initializes the line-pointer. 



---


---
