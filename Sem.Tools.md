# [Sem.Tools](#Sem.Tools)

---
## Type: Sem.Tools.ActionExtension

 Implements extension methods to handle some "magic" with actions (like concatenating two calls to two methods with the same signature to one method). 



### Method: ActionExtension.Append\<T1>(Action\<T1>, Action\<T1>)

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
### Method: ActionExtension.Append\<T1,  T2>(Action\<T1,  T2>, Action\<T1,  T2>)

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
### Method: ActionExtension.Append\<T1,  T2,  T3>(Action\<T1,  T2,  T3>, Action\<T1,  T2,  T3>)

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
### Method: ActionExtension.Append\<T1,  T2,  T3,  T4>(Action\<T1,  T2,  T3,  T4>, Action\<T1,  T2,  T3,  T4>)

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
---
## Type: Sem.Tools.EncryptionConverter

 A JSON converter encrypting using DPAPI for the local machine and the current user. 



### Method: EncryptionConverter.Read(Text.Json.Utf8JsonReader@, Type, Text.Json.JsonSerializerOptions)

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
### Method: EncryptionConverter.Write(Text.Json.Utf8JsonWriter, String, Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---
---
## Type: Sem.Tools.Extensions

 Very basic extension methods. 



### Method: Extensions.Hash(String)

 Calculates a simple SHA256 hash from a string. 

#### Parameters:
|Name | Description |
|-----|------|
|value|The string to be hashed.|

#### Returns:
The has as HEX encoded data.



---
### Method: Extensions.MustNotBeNullOrEmpty(String, String)

 Throws an ```System.ArgumentNullException``` when passing NULL or an empty string to  value . 

#### Parameters:
|Name | Description |
|-----|------|
|value|The value that must not be null or en empty string.|
|nameOfValue: |The name of the value (usually the name of the parameter).|

#### Returns:
 The original value of  value . 



---
### Method: Extensions.MustNotBeNull\<T1>(``0, String)

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
---
## Type: Sem.Tools.FileSystemTools

 Tools for file system interaction. 



### Method: FileSystemTools.SanitizeFileName(String)

 Removes illegal characters from file names. 

#### Parameters:
|Name | Description |
|-----|------|
|fileName|The file name to sanitize.|

#### Returns:
The file name without illegal characters.



---
---
## Type: Sem.Tools.InheritanceConverter`1

 Serializes inherited objects in properties. Normally, only the properties of the type explicitly declared on the property is being serialized - with this attribute the property value is fully serialized. 

#### Type parameters:
|Name | Description |
|-----|------|
|TType|The type to handle with this converter.|


### Method: InheritanceConverter`1.Read(Text.Json.Utf8JsonReader@, Type, Text.Json.JsonSerializerOptions)

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
### Method: InheritanceConverter`1.Write(Text.Json.Utf8JsonWriter, `0, Text.Json.JsonSerializerOptions)

Writes a specified value as JSON.

#### Parameters:
|Name | Description |
|-----|------|
|writer|The writer to write to.|
|value: |The value to convert to JSON.|
|options: |An object that specifies serialization options to use.|


---


---
