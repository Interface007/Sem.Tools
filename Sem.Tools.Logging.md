# [Sem.Tools.Logging](#Sem.Tools.Logging)

## [Type: Sem.Tools.Logging.LogCategories](#Refa16e2fdadea687a1ee6ac9fb756c3cf75ff65d4fbe6ab945dfff0b40e77aac19)

 The logging category distinguishes between technical and business information. 



---
## [Type: Sem.Tools.Logging.LogCategoryExtensions](#Ref685440658934ab8a95ee9c968b061604c8be263e3a6cf1b6e5310a48ff9d562b)

 Extension class for the enum type [Sem.Tools.Logging.LogCategories](Sem.Tools.Logging.md#Ref5b7412e7cdc9dfe6d0dfc0f11eaa5071e22fa8e163edbd04d4325f1389d5e0e5). 



---
### [Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)](#Ref10f94274ab54368ee9c31c23983017ce3cb56e3fc922cb910ba565ea92db6741)

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

#### Returns:
A value indicating whether the flag is set.



---
## [Type: Sem.Tools.Logging.LogExtension](#Ref51cc90791b69dd809363b975c0b9af4198811575385c61bd9f105263bfd7870d)

 Extension class providing some standard logging methods. 



---
### [Method: LogExtension.AddDebug(Action\<LogCategories, LogLevel, LogScope, String>)](#Refd8d6d4518115b920e7b656ba0709e08c6a4734a5327c55f8f9130acaec3f4a33)

 Simple output using ```Diagnostics.Debug.WriteLine(Object)```. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to ```System.Diagnostics.Debug```.



---
### [Method: LogExtension.AddConsole(Action\<LogCategories, LogLevel, LogScope, String>)](#Refc7c426b970c3271913aa56b33807400ce35f06d0d2ea3b9b9dd72448de3edf8d)

 Simple output using ```Console.WriteLine(Object)```. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to ```System.Console```.



---
## [Type: Sem.Tools.Logging.LogLevel](#Ref1157ded0d2f15c3f77c6e021b200ab818e04298304d54391856634172a3d634e)

 The "chattiness" level. 



---
## [Type: Sem.Tools.Logging.LogScope](#Refbce3a4dadf1550714214912ff328feccb6d954fd7192dda154b67018f3bb1f96)

 Simple hierarchical logging scope. 



---
### P:Sem.Tools.Logging.LogScope.DefaultLevel (#P:Sem.Tools.Logging.LogScope.DefaultLevel)

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.DefaultCategory (#P:Sem.Tools.Logging.LogScope.DefaultCategory)

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.LogMethod (#P:Sem.Tools.Logging.LogScope.LogMethod)

 Gets or sets the method that will write the log information. 



---
### P:Sem.Tools.Logging.LogScope.IdFactory (#P:Sem.Tools.Logging.LogScope.IdFactory)

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 



---
### P:Sem.Tools.Logging.LogScope.BasePath (#P:Sem.Tools.Logging.LogScope.BasePath)

 Gets or sets a path to be removed in logs. 



---
### P:Sem.Tools.Logging.LogScope.Category (#P:Sem.Tools.Logging.LogScope.Category)

 Gets or sets the type of logs to be written. 



---
### P:Sem.Tools.Logging.LogScope.Level (#P:Sem.Tools.Logging.LogScope.Level)

 Gets or sets the level of "chattiness". 



---
### P:Sem.Tools.Logging.LogScope.Id (#P:Sem.Tools.Logging.LogScope.Id)

 Gets the hierarchical ID of the scope. 



---
### [Method: LogScope.Create(String, Action\<LogCategories, LogLevel, LogScope, String>, String, String)](#Ref9283e4920364a7aaa3adb536c569b96ac9a70888e75d32de2e7e834d70ae4353)

 Create a new scope instance. 

#### Parameters:
|Name | Description |
|-----|------|
|scopeName|Name of the scope.|
|logMethod: |Method that renders the log entry.|
|member: |The member (method) that creates the instance.|
|path: |The path to the class file.|

#### Returns:
A new logging scope.



---
### [Method: LogScope.MethodStart(Object, String, String)](#Ref9a09e8e3443ce30823d78c1f11a6c4b04b76eb9dcb290f902dfac839fcea4410)

 Call this to indicate a method start. 

#### Parameters:
|Name | Description |
|-----|------|
|value|A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### [Method: LogScope.Child(String, Object, String, String)](#Ref0c69bf33b7c8590d40d296db3cd4d0aa23a7fd7f0c495b95a5cef1d99cdf8aff)

 Creates a new child scope. 

#### Parameters:
|Name | Description |
|-----|------|
|childName| The name of the scope. |
|value: |A value that should be logged as part of the creation.|
|member: |The name of the method.|
|path: |The path of the source file.|

#### Returns:
A new scope.



---
### [Method: LogScope.DisposeAsync](#Reff10ed0110eff68ab1b5200ffde4de0a2b1b0be28e55ebe4323ed41fe85cde3c7)

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### [Method: LogScope.Dispose](#Refbcf58b6a033a503cfa393595f11ba32fe6f3c17e5e0ebf0a3d1fc930e2e7f3bb)

 Logs the end of the scope. 



---
### [Method: LogScope.Log(String, Object)](#Ref33309f16daccac8e98f915e8645e73e589c3ecf4692d106b028ce9a2aedad0bd)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### [Method: LogScope.Log(LogCategories, LogLevel, String, Object)](#Ref10bf97d09a5b085fbccaacca413a30046916c4f3851973c4a7da634992a1f3f3)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|logCategory|The category of this message (Is it technical information of business process information?).|
|logLevel: |The log level of this message (How important is this message?).|
|message: |The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---


---
