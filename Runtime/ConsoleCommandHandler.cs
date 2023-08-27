using System;
using Ametrin.Console;
using Ametrin.Command;
using Ametrin.Utils;

namespace Ametrin.ConsoleCommandIntegration{
    #nullable enable
    public sealed class ConsoleCommandHandler : IConsoleHandler {
        public bool PassPrefix => false;

        public void Execute(ReadOnlySpan<char> input)=> CommandManager.Execute(input);

        public ReadOnlySpan<char> GetSyntax(ReadOnlySpan<char> input){
            var inputParts = input.Split(' ');
            if(inputParts.Count == 0) return CommandManager.GetFirstSyntax();
            return CommandManager.GetSyntax(input[inputParts[0]]);
        }

        public ReadOnlySpan<char> GetAutoCompleted(ReadOnlySpan<char> input){
            var inputParts = input.Split(' ');
            if (inputParts.Count != 1) return ReadOnlySpan<char>.Empty;
            return CommandManager.GetFirstCommand(input[inputParts[0]]) + " ";
        }
    }
}