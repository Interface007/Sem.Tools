# 02-upgrade-consumer-and-core-projects-to-net10: upgrade-consumer-and-core-projects-to-net10

Upgrade the primary consumer/application projects and their directly required core libraries to `net10.0`, applying inline fixes for API findings in this wave. Scope includes `Sem.MdDocGenerator`, `Sem.Tools.CmdLine`, `Sem.Tools`, `Sem.Tools.Logging`, `Sem.Tools.TestHelper`, and any directly coupled dependencies needed to keep these projects compiling and functioning.

Assessment context: API compatibility findings include source/binary/behavior changes concentrated around SQL client and crypto/data-protection related APIs; package upgrade recommendations are limited but should be applied where relevant in this wave.

**Done when**: consumer/application and core dependency projects target `net10.0` and compile with required inline compatibility fixes.
