# [Sem.Tools.Logging](#Sem.Tools.Logging)

---
## Type: Sem.Tools.Logging.LogCategories

 The logging category distinguishes between technical and business information. 



---
## Type: Sem.Tools.Logging.LogCategoryExtensions

 Extension class for the enum type [Sem.Tools.Logging.LogCategories](Sem.Tools.Logging.md#type-semtoolslogginglogcategories). 



### Method: LogCategoryExtensions.HasFlag\<T1>(``0, ``0)

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
---
## Type: Sem.Tools.Logging.LogExtension

 Extension class providing some standard logging methods. 



### Method: LogExtension.AddDebug(Action\<LogCategories, LogLevel, LogScope, String>)

 Simple output using ```Diagnostics.Debug.WriteLine(Object)```. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to ```System.Diagnostics.Debug```.



---
### Method: LogExtension.AddConsole(Action\<LogCategories, LogLevel, LogScope, String>)

 Simple output using ```Console.WriteLine(Object)```. 

#### Parameters:
|Name | Description |
|-----|------|
|logMethod|The original log method, this method should be added to.|

#### Returns:
A new method that is the combination of  logMethod  and an output to ```System.Console```.



---
---
## Type: Sem.Tools.Logging.LogLevel

 The "chattiness" level. 



---
## Type: Sem.Tools.Logging.LogScope

 Simple hierarchical logging scope. 



### Property: Sem.Tools.Logging.LogScope.DefaultLevel

 Gets or sets the level of "chattiness". 


### Property: Sem.Tools.Logging.LogScope.DefaultCategory

 Gets or sets the type of logs to be written. 


### Property: Sem.Tools.Logging.LogScope.LogMethod

 Gets or sets the method that will write the log information. 


### Property: Sem.Tools.Logging.LogScope.IdFactory

 Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used. 


### Property: Sem.Tools.Logging.LogScope.BasePath

 Gets or sets a path to be removed in logs. 


### Property: Sem.Tools.Logging.LogScope.Category

 Gets or sets the type of logs to be written. 


### Property: Sem.Tools.Logging.LogScope.Level

 Gets or sets the level of "chattiness". 


### Property: Sem.Tools.Logging.LogScope.Id

 Gets the hierarchical ID of the scope. 


### Method: LogScope.Create(String, Action\<LogCategories, LogLevel, LogScope, String>, String, String)

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
### Method: LogScope.MethodStart(Object, String, String)

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
### Method: LogScope.Child(String, Object, String, String)

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
### Method: LogScope.DisposeAsync

 Async implementation of the dispose pattern. 


#### Returns:
A task to wait for.



---
### Method: LogScope.Dispose

 Logs the end of the scope. 



---
### Method: LogScope.Log(String, Object)

 Logs a message. 

#### Parameters:
|Name | Description |
|-----|------|
|message|The message to be logged.|
|value: |A value that should be included into the message as addition data.|


---
### Method: LogScope.Log(LogCategories, LogLevel, String, Object)

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
