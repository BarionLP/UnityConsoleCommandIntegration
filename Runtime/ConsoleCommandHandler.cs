using System;
using Ametrin.Console;
using Ametrin.Command;

namespace Ametrin.ConsoleCommandIntegration{
    #nullable enable
    public sealed class ConsoleCommandHandler : IConsoleHandler {
        public bool PassPrefix => false;

        public void Execute(string input)=> CommandManager.Execute(input);

        public string? GetSyntax(string value){
            var inputParts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if(inputParts.Length == 0) return CommandManager.GetFirstSyntax();
            return CommandManager.GetSyntax(inputParts[0]);
        }

        public string? GetCompletion(string input){
            var inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (inputParts.Length == 0) return null;
            return CommandManager.GetFirstCommand(inputParts[0])?.Remove(0, input.Length) + " ";
        }
    }
}