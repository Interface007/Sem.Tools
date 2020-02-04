# [Sem.Tools.CmdLine](#Sem.Tools.CmdLine)

## [Type: Sem.Tools.CmdLine.Menu](#Refa1302f7223c42fc5705da7510cc8304b5ba40c68775225017fef47cd8de2a5c7)

 Extension methods to handle command line menu definitions. 



---
### [Method: Menu.Show(MenuItem[])](#Ref0b9b5dc5828c7be85a50bfafe8e0608e187b450af2f62219b70698a07d97c828)

 Show the menu items and wait for selection of user. 

#### Parameters:
|Name | Description |
|-----|------|
|items|The items to display.|

#### Returns:
A task to wait for.



---
## [Type: Sem.Tools.CmdLine.MenuItem](#Ref93d0f209626767d5f15e59c29371660df6e41395cbe8a34b67557e8de1045cd2)

 Menu item for a command line program. An array of menu items can be displayed using the extension method [Menu.Show(MenuItem[])](Sem.Tools.CmdLine.md#Ref0b9b5dc5828c7be85a50bfafe8e0608e187b450af2f62219b70698a07d97c828). 

_C# code_

```c#
    await new[]
    {
        MenuItem.For<AzureToLocalFolderBackupActions>(),
        MenuItem.For<EmailToLocalFolderBackupActions>(),
        MenuItem.For<EmailToAzureBackupActions>(),
        MenuItem.For<FolderToFolderBackupActions>(),
        MenuItem.For<FolderToAzureBackupActions>(),
        MenuItem.For<IntegrationTests>(),
    }.Show();
    
```



---
### [Method: MenuItem.#ctor(String, Func\<Task>, String)](#Ref84ac5dc0758afd06c663f6dfbf0d606fc0cc757b6e3aee62f1644d148d254fda)

 Initializes a new instance of the [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) class. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The "label" that should be shown on the screen to describe the functionality.|
|action: |The action to perform when the user selects this menu item.|
|suffixForMenu: |A suffix for the display string.|


---
### P:Sem.Tools.CmdLine.MenuItem.DisplayString (#P:Sem.Tools.CmdLine.MenuItem.DisplayString)

 Gets the "label" that should be shown on the screen to describe the functionality. 



---
### P:Sem.Tools.CmdLine.MenuItem.Action (#P:Sem.Tools.CmdLine.MenuItem.Action)

 Gets the action to perform when the user selects this menu item. 



---
### [Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<IAsyncEnumerable\<String>>>, String)](#Ref1c2b57f60e75e47d3259dc9ed5dbda90815f5be4cc3b695103ae33a5e7957804)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<Task\<String>>>, String)](#Reff82dfd3db3da1e6aeab353df2ee1cb6abb321b0390f6696d89633e7e19a16ba7)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<Task\<IEnumerable\<String>>>>, String)](#Reff59fa3b3e18297e5810a6d92a2fd1f231d467542221859b370dab9f81c7e3562)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.Print(String, Func\<Task\<String>>, String)](#Ref917ce73d655a2d8a75519e4765642bc03296500f4f7d52bf896860563e0edcc0)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.Print(String, Func\<IAsyncEnumerable\<String>>, String)](#Ref6c51d61921268a7b46769a86f653955ba37c5018ece106f041fee1c05c6df8c6)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.Print(String, Func\<Task\<IEnumerable\<String>>>, String)](#Ref5ef08991eb1f50d33775ed11cd39835b0c66a38562f0170d272a3452f378c781)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#Ref278f9b03a9b148a7ca4c4932290efd512cc2fd21f596aed7bd05c6a26e572220) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### [Method: MenuItem.For\<T1>(Object[])](#Refe542887979abf7e43edf0e5a57f583e9233488d29b3ee397bdc15d28977e2f6f)

 Creates menu entries for public methods of  T . 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The type to create entries for.|
#### Parameters:
|Name | Description |
|-----|------|
|parameters|Parameter values for the methods.|

#### Returns:
A menu entry with sub menu items.



---
### [Method: MenuItem.GetDescriptionFromXml(Reflection.MemberInfo)](#Ref88ee8ddc5d0ece8b2f76d95f7fcfb898b3462ba3e877db659bea400afafe1d0d)

 Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|method|The method to get the description for.|

#### Returns:
The extracted description.



---
### [Method: MenuItem.GetDescriptionFromXml(Type)](#Ref805d8da8a168f36f86589390447cd34858ac02fcebb918c2105ce519fe632e0b)

 Extracts the description from the XML documentation of a class (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|type|The class type to get the description for.|

#### Returns:
The extracted description.



---
### [Method: MenuItem.GetMethod\<T1>(Linq.Expressions.Expression\<Func\<T1>>)](#Ref37ed54755349f12abd26e96e2a4df08ddafe52347e9def60fb149389dda6b062)

 Gets the method information from a ```System.Linq.Expressions.MethodCallExpression```. 

#### Type parameters:
|Name | Description |
|-----|------|
|T|The return type of the method.|
#### Parameters:
|Name | Description |
|-----|------|
|action|The expression calling a method.|

#### Returns:
The method information from the called method.



---
### [Method: MenuItem.InvokeAction\<T1,  T2>(Reflection.MethodBase, Object[])](#Ref78ceaa619cd780add7eeb388242c1aba5bcbfcdb221c72b0e5002f81d261c548)

 Invokes a method with the needed parameters. 

#### Type parameters:
|Name | Description |
|-----|------|
|TResult|The result type of the method.|
|TClass: |The class type that contains the method.|
#### Parameters:
|Name | Description |
|-----|------|
|methodInfo|The method information.|
|parameters: |The potential parameters for the method call.|

#### Returns:
The call result.



---


---
