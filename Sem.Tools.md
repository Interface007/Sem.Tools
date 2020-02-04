# [Sem.Tools](#Sem.Tools)

## [Type: Sem.Tools.ActionExtension](#Reff7b0fe1eda427b6b8760c80d089deaa1288df920584a35b07efb71c237d1f2a6)

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



---
### [Method: ActionExtension.Append\<T1>(Action\<T1>, Action\<T1>)](#Ref5729fd564aeccc28557ca1defad86886d9a75474f602e053f5514ddecf74316c)

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
### [Method: ActionExtension.Append\<T1,  T2>(Action\<T1,  T2>, Action\<T1,  T2>)](#Ref236ddda323a7d2adc28cc36f3484e3f9136b786f261f4fcbe97c4dcb9b98b359)

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
### [Method: ActionExtension.Append\<T1,  T2,  T3>(Action\<T1,  T2,  T3>, Action\<T1,  T2,  T3>)](#Ref6625ee12e2311a0f65fffcab09609cfd9806a07e93512c05102e4b5b372dc751)

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
### [Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(Action\<T1,  T2,  T3,  T4>, Action\<T1,  T2,  T3,  T4>)](#Reff91259c21aa1bd5d71bd11526efd42faccbc4d4185d45597966a16df21ff4b89)

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
## [Type: Sem.Tools.EncryptionConverter](#Refe2f69d12bb044c722fe60813686c682e28d89e3b5cb890aa4190645bb59b5d0f)

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



---
### [Method: EncryptionConverter.Read(Text.Json.Utf8JsonReader@, Type, Text.Json.JsonSerializerOptions)](#Ref59089d1745716be1e31faa64879b2b36a053f67685b8161dc470f967c21eb6ac)

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
### [Method: EncryptionConverter.Write(Text.Json.Utf8JsonWriter, String, Text.Json.JsonSerializerOptions)](#Ref2553777c3feba51fe6a69aaaa5c09e7e23dab2fa32a686a5aeb96c3a2e2b7c70)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
## [Type: Sem.Tools.Extensions](#Refbd5f19f88e3ea7b016bb915668ad8067c708d885b55bf4a3dc7100114510e8ee)

 Very basic extension methods. 



---
### [Method: Extensions.Hash(String)](#Refa6a941bbac72424b599fd6747bf46fe953075143bd035419f725d35db9386cb1)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### [Method: Extensions.MustNotBeNullOrEmpty(String, String)](#Ref48966661ee8513e88e591b03acf9f2bb14ed267f4e9b15552a43d04fc0248516)

 Throws an ```System.ArgumentNullException``` when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### [Method: Extensions.MustNotBeNull\<T1>(``0, String)](#Ref0a37c78ef77ccb8040d5da511476d9f706139e8ca1d868e61993231d1e398570)

 Throws an ```System.ArgumentNullException``` when passing NULL values to  value . 

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
### [Method: Extensions.ToJson\<T1>(``0)](#Refded7ff9afafe81511c88087041c474ddc7d03eadc7d0b409d866629dc3e2660c)

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
## [Type: Sem.Tools.FileSystemTools](#Ref4d30129baa27569bdcb3a44fab6a841a0501d74a1890390ab93daf51f3f0521d)

 Tools for file system interaction. 



---
### [Method: FileSystemTools.SanitizeFileName(String)](#Ref3ee0039b2ca1d0e0fe2df4e985d3c298615183d239e03b5dd135fdbfe1e602a6)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
## [Type: Sem.Tools.InheritanceConverter`1](#Ref28f369d7a15aae7a73a239910c26174bc01c6ea3b329900ea1ee5c37fbefd3fa)

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


---
### [Method: InheritanceConverter`1.Read(Text.Json.Utf8JsonReader@, Type, Text.Json.JsonSerializerOptions)](#Ref68f1697561e19f54749f0fd45d51bb4985ff6d621d3dc723d8ac9d8c1cfb978a)

Reads and converts the JSON to type  TType .

#### Parameters:
|Name | Description |
|-----|------|
|reader|The reader.|
|typeToConvert: |The type to convert.|
|options: |An object that specifies serialization options to use.|

#### Returns:
The converted value.



---
### [Method: InheritanceConverter`1.Write(Text.Json.Utf8JsonWriter, `0, Text.Json.JsonSerializerOptions)](#Ref71ef3a69d22d77997930c95f46c9635e33a3d92756b5fee3bc330362195e1ca5)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


---
