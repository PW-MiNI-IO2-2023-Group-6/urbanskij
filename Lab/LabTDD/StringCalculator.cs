namespace LabTDD
{
    public static class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            var nums = str.StartsWith("//")
                ? str.Substring(3).Split(',', '\n', str[2])
                : str.Split(',', '\n');

            var sum = 0;
            foreach (var numb in nums)
            {
                var n = int.Parse(numb);
                if (n <= 1000)
                {
                    sum += n;
                }
            }
            return sum;
        }
    }
}
