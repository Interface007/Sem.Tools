# [Sem.Tools.CmdLine](#Sem.Tools.CmdLine)

## Type: Sem.Tools.CmdLine.Menu

 Extension methods to handle command line menu definitions. 



---
### Method: Menu.Show(MenuItem[])

 Show the menu items and wait for selection of user. 

#### Parameters:
|Name | Description |
|-----|------|
|items|The items to display.|

#### Returns:
A task to wait for.



---
## Type: Sem.Tools.CmdLine.MenuItem

 Menu item for a command line program. An array of menu items can be displayed using the extension method [Menu.Show(MenuItem[])](Sem.Tools.CmdLine.md#method-menushowmenuitem). 

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
### Method: MenuItem.#ctor(String, Func\<Task>, String)

 Initializes a new instance of the [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) class. 

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
### Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<IAsyncEnumerable\<String>>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<Task\<String>>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(Linq.Expressions.Expression\<Func\<Task\<IEnumerable\<String>>>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|action|The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(String, Func\<Task\<String>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(String, Func\<IAsyncEnumerable\<String>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.Print(String, Func\<Task\<IEnumerable\<String>>>, String)

 Creates a [Sem.Tools.CmdLine.MenuItem](Sem.Tools.CmdLine.md#type-semtoolscmdlinemenuitem) from an expression - is meant to be used with a ```System.Linq.Expressions.MethodCallExpression```. 

#### Parameters:
|Name | Description |
|-----|------|
|displayString|The explicit "label" to be used for the menu entry.|
|action: |The expression to create a menu item for.|
|suffixForMenu: |A suffix for the description of the method (the description will be extracted from the documentation XML file).|

#### Returns:
A new menu item.



---
### Method: MenuItem.For\<T1>(Object[])

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
### Method: MenuItem.GetDescriptionFromXml(Reflection.MemberInfo)

 Extracts the description from the XML documentation of a method (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|method|The method to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetDescriptionFromXml(Type)

 Extracts the description from the XML documentation of a class (the XML file mst be generated while building the assembly). 

#### Parameters:
|Name | Description |
|-----|------|
|type|The class type to get the description for.|

#### Returns:
The extracted description.



---
### Method: MenuItem.GetMethod\<T1>(Linq.Expressions.Expression\<Func\<T1>>)

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
### Method: MenuItem.InvokeAction\<T1,  T2>(Reflection.MethodBase, Object[])

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
