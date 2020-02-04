First of all: this project is just meant to give me a playground for programming. I like to write code and have I fun trying new features 
or some "unusual" way of implementation. You are welcome to use this code (it's all MIT licensed) and you are also welcome to give me a 
hint when something does not work - but still: this code is not tested for production ... before you use it: test it.


# Sem.Data.SprocAccess[Sem.Data.SprocAccess](Sem.Data.SprocAccess.md)
Very simple ORM for accessing named result sets / SPROCs - see Sem.Data.SprocAccess.SqlServer 
      or Sem.Data.SprocAccess.FileSystem. The interface IDatabase implements a single method that executes a 
      SPROC and returns an IAsyncEnumerable by mapping each row into a plain old C# object (POCO).
# Sem.Data.SprocAccess.FileSystem[Sem.Data.SprocAccess.FileSystem](Sem.Data.SprocAccess.FileSystem.md)
Implementation of IDatabase.Execute using static text-files. This implementation can be used to easily 
      mock database access. Each SPROC gets its own folder and each combination of parameters its own file.
# Sem.Data.SprocAccess.SqlServer[Sem.Data.SprocAccess.SqlServer](Sem.Data.SprocAccess.SqlServer.md)
Implementation of IDatabase.Execute using SQL server SPROCs.
# Sem.Tools[Sem.Tools](Sem.Tools.md)
Some generic tools.
# Sem.Tools.CmdLine[Sem.Tools.CmdLine](Sem.Tools.CmdLine.md)
Command line tools.
# Sem.Tools.Logging[Sem.Tools.Logging](Sem.Tools.Logging.md)
Simple scoped logging.