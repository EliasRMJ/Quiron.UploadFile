namespace Quiron.UploadFile
{
    public static class Extensions
    {
        public static string PathCombane(this string[]? list)
        {
            string _result = string.Empty;
            if (list is null || list.Length.Equals(0))
                return _result;

            _result = list[0];
            for (int i = 1; i < list.Length; i++)
                _result = Path.Combine(_result, list[i]);

            return _result;
        }
    }
}
