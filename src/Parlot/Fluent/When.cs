﻿using System;

namespace Parlot.Fluent
{
    /// <summary>
    /// Ensure the given parser is valid based on a condition
    /// </summary>
    /// <typeparam name="T">The output parser type.</typeparam>
    public sealed class When<T> : Parser<T>
    {
        private readonly Func<T, bool> _action;
        private readonly IParser<T> _parser;

        public When(IParser<T> parser, Func<T, bool> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public override bool Parse(Scanner scanner, ref ParseResult<T> result)
        {
            return _parser.Parse(scanner, ref result) && _action(result.Value);
        }
    }
}