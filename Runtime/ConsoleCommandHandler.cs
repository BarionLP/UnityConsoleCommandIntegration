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

        public ReadOnlySpan<char> GetSyntax(ReadOnlySpan<char> input) => CommandManager.Commands.GetSyntax(input, input.Split(' '));

        public string GetAutoCompleted(ReadOnlySpan<char> input){
            var slices = input.Split(' ');
            var endsWithSpace = input[^1] == ' ';
            var nextParam = CommandManager.Commands.CompleteNextParameter(input, slices, endsWithSpace);
            var start = endsWithSpace ? input : input[..slices[^1].Start];
            return new StringBuilder(start.Length + nextParam.Length).Append(start).Append(nextParam).ToString();
        }
    }
}