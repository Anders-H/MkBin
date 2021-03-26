using System.Text;

namespace MkBin
{
    public class TextGenerator
    {
        private readonly byte[] _bytes;

        public TextGenerator(byte[] bytes)
        {
            _bytes = bytes;
        }

        public override string ToString()
        {
            if (_bytes == null || _bytes.Length <= 0)
                return "";

            var s = new StringBuilder();
            var count = 0;
            var sameCount = 0;
            var lastByte = _bytes[0];
            foreach (var b in _bytes)
            {
                if (lastByte == b)
                {
                    sameCount++;
                    continue;
                }

                var expression = sameCount < 2
                    ? $"{lastByte}"
                    : $"{lastByte}*{sameCount}";

                sameCount = 1;
                lastByte = b;

                if (count % 8 == 7)
                    s.AppendLine(expression);
                else
                    s.Append($"{expression} ");
                count++;
            }

            s.AppendLine(
                sameCount > 1
                    ? $"{lastByte}*{sameCount}"
                    : $"{lastByte}"
            );

            return s.ToString().Trim();
        }
    }
}