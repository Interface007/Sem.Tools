# [Sem.Data.SprocAccess](#Sem.Data.SprocAccess)

## Type: Sem.Data.SprocAccess.IDatabase{#Ref6f3296162599fba927f62939bb8c3b7b397ab65f3e3b6c16e99bef0493fa365a}

 Very simple and small interface to interact with databases. 



---
### Method: IDatabase.Execute\<T1>(String, Func\<IReader, Task\<T1>>, Sem.Tools.Logging.LogScope, KeyValuePair\<String, Object>[]){#Ref3c1ea8c0790167a1c9da869adc9a182ba55e5b382171fedd71d8bb62c136fd83}

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
## Type: Sem.Data.SprocAccess.IReader{#Refd4ea26ed6963c7d7d862c5d038a3dfe5e8c6fad98ad0756308237234eb54ed5f}

 Simple data reader interface with only the needed methods to provide an interface that can easily be implemented. 



---
### Method: IReader.Read{#Ref6140e5d80d31c8a065579879011d2b8429d7332edb91e6f6d277da0df00e1ee3}

 Advances to the next record. 


#### Returns:
A value indicating whether there is still data to be read.



---
### Method: IReader.Get\<T1>(Int32){#Ref0e911013013473e24b451a38e21edd26440ac35d631e788fbc22a0d0c965003f}

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
### Method: IReader.Get(Int32, Type){#Ref4679f191d96203bac4e9cef80c5e8650d2d19f9f91dff9ec382a8149c581bdd1}

 Reads the value of a column by its index. 

#### Parameters:
|Name | Description |
|-----|------|
|index|The column index.|
|type: |The type of the result.|

#### Returns:
The value of the column in the current row.



---
### Method: IReader.NextResult{#Refddffcd4eaf86045a859c21351302f738eb98e725c97eafa50dd8becc6ab4c2dc}

 Advances to the next result set. 


#### Returns:
A task to wait for.



---
### Method: IReader.Close{#Refa664070908c4c587e509fb9289015c76c80a5c382be8e00a90951aeb26fa5cc1}

 Closes the reader. 


#### Returns:
A task to wait for.



---
### Method: IReader.IndexByName(String){#Ref48a0b89351ffc712b194b78d6f8a412b9573a72de1cc2cef0bfd29d1e8ec3b35}

 Gets the index of a column by its name (case-insensitive). When there are two columns with the same name, the first index will be returned. 

#### Parameters:
|Name | Description |
|-----|------|
|columnName|The name of the column to search.|

#### Returns:
The index of the column.



---


---
