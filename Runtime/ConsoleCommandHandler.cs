using System;
using System.Text;
using Ametrin.Command;
using Ametrin.Console;

#nullable enable
namespace Ametrin.ConsoleCommandIntegration
{
    public sealed class ConsoleCommandHandler : IConsoleHandler
    {
        public bool PassPrefix => false;

        public void Handle(ReadOnlySpan<char> input) => CommandManager.Execute(input);

        public string GetHint(ReadOnlySpan<char> input) => CommandManager.Commands.GetSyntax(input, input.Split(' '));

        public string GetAutoCompleted(ReadOnlySpan<char> input)
        {
            var slices = input.Split(' ');
            var endsWithSpace = input.IsEmpty || input[^1] == ' ';
            var nextParam = CommandManager.Commands.CompleteNextParameter(input, slices, endsWithSpace);
            var start = endsWithSpace ? input : input[..slices[^1].Start];
            return new StringBuilder(start.Length + nextParam.Length + 1).Append(start).Append(nextParam).Append(' ').ToString();
        }
    }
}