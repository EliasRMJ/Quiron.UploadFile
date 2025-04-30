namespace Quiron.UploadFile
{
    public class UploadMaxSizeException : Exception
    {
        public UploadMaxSizeException(string message)
            : base(message) { }

        public UploadMaxSizeException(string message, Exception inner)
            : base(message, inner) { }
    }
}