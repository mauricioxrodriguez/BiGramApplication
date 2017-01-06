using System;

namespace BiGramApplication
{
    public class InvalidFileTypeException : System.IO.IOException
    {
        #region properties
        public string _Message { get; set; }
        #endregion properties

        #region public methods
        public InvalidFileTypeException(string path, string acceptedType)
        {
            _Message = string.Format("Invalid file type: '{0}' Valid file type is: '{1}'", path, acceptedType);
            throw new Exception(_Message);
        }
        #endregion public methods
    }
}
