First of all: this project is just meant to give me a playground for programming. I like to write code and have I fun trying new features 
or some "unusual" way of implementation. You are welcome to use this code (it's all MIT licensed) and you are also welcome to give me a 
hint when something does not work - but still: this code is not tested for production ... before you use it: test it.

[Click here to find the generated documentstion](https://github.com/Interface007/Sem.Tools/blob/master/Documentation.MD)
I'm currently in the process of refactoring the documentation generation - the final version will create a bunch of files (instead of this single one), link them together, generate a TOC file and produce some readable 

# Sem.Tools
A collection of some tools I like to use in my code:
- Extensions.Hash(this string value)
  Produces a hex encoded SHA256 hash from a string.
- Extensions.MustNotBeNull(this T value, string nameOfValue)
  Checks for null (thows an ArgumentNullException when value is null) and includes variable check hints for ReSharper and FXCop
- EncryptionConverter
  A JSON converter encrypting using DPAPI for the local machine and the current user.
- InheritanceConverter
  Serializes inherited objects in properties. Normally, only the properties of the type explicitly
  declared on the property is being serialized - with this attribute the property value is fully serialized
  and restores the original type.
