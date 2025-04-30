namespace Quiron.UploadFile
{
    public class UploadException : Exception
    {
        public UploadException(string message)
            : base(message) { }

        public UploadException(string message, Exception inner)
            : base(message, inner) { }
    }
}