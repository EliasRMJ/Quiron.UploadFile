namespace Quiron.UploadFile
{
    public class UploadTypeException : Exception
    {
        public UploadTypeException(string message)
            : base(message) { }

        public UploadTypeException(string message, Exception inner)
            : base(message, inner) { }
    }
}