// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Exceptions.cs" company="Lan ETS">
//   Touts droits réservés
// </copyright>
// <summary>
//   Defines the BusinessLogicException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Exceptions
{
    using System.Runtime.Serialization;
    using System;

    [Serializable]
    public class BusinessLogicException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public BusinessLogicException()
        {
        }

        public BusinessLogicException(string message)
            : base(message)
        {
        }

        public BusinessLogicException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected BusinessLogicException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
