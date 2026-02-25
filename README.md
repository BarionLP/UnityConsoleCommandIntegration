## Helpers to integrate my UnityConsole with my Command system
call the following methods once
```csharp
ConsoleManager.RegisterHandler('/', new ConsoleCommandHandler());
CommandManager.SetLogger(new ConsoleCommandLogger());
```