namespace MkBin
{
    public class ArgumentParser
    {
        private readonly string[] _args;

        public ArgumentParser(string[] args)
        {
            _args = args;
        }

        public bool HasArguments =>
            _args != null && _args.Length > 0;

        public string? GetArgumentParameter(string argumentName)
        {
            for (var i = 0; i < _args.Length; i++)
            {
                if (string.Compare(_args[i], argumentName, StringComparison.CurrentCultureIgnoreCase) != 0)
                    continue;

                if (i < _args.Length - 1)
                    return _args[i + 1];
            }
            return null;
        }

        public string? GetArgument(params string[] argumentName) =>
            _args.FirstOrDefault(
                t => argumentName.Any(s => string.Compare(t, s, StringComparison.CurrentCultureIgnoreCase) == 0)
            );

        public bool HasParameter(string argumentName) =>
            _args.Any(a => string.Compare(a, argumentName, StringComparison.CurrentCultureIgnoreCase) == 0);
    }
}