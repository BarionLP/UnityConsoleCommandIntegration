using System;
using Ametrin.Console;
using Ametrin.Command;
using Ametrin.Utils;
using System.Text;

namespace Ametrin.ConsoleCommandIntegration{
#nullable enable
    public sealed class ConsoleCommandHandler : IConsoleHandler {
        public bool PassPrefix => false;

        public void Execute(ReadOnlySpan<char> input)=> CommandManager.Execute(input);

        public ReadOnlySpan<char> GetSyntax(ReadOnlySpan<char> input){
            var slices = input.Split(' ');
            if(slices.Count == 0) return CommandManager.GetFirstSyntax();
            return CommandManager.GetSyntax(input[slices[0]]);
        }

        public string GetAutoCompleted(ReadOnlySpan<char> input){
            var slices = input.Split(' ');
            if(slices.Count == 0) return CommandManager.GetFirstCommand();
            var key = input[slices[0]];
            var blank = input[^1] == ' ';
            if(slices.Count == 1 && !blank) return CommandManager.GetFirstCommand(key);

            if (!CommandManager.GetCommand(key).TryResolve(out var command)) return string.Empty;
            slices.RemoveAt(0);
            var nextParam = command.CompleteNextParameter(input, slices, blank);
            var start = blank ? input : input[..slices[^1].Start];
            return new StringBuilder(start.Length + nextParam.Length).Append(start).Append(nextParam).ToString();
        }
    }
}