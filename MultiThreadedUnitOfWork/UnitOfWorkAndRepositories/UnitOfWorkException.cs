﻿using System;
using System.Runtime.Serialization;

namespace AsynchronousSessionManagement.UnitOfWorkAndRepositories
{
    [Serializable]
    public class UnitOfWorkException : Exception
    {
        protected UnitOfWorkException(SerializationInfo serializationInfo, StreamingContext streamingContest) : base(serializationInfo, streamingContest)
        {
        }
        
        public UnitOfWorkException(string message) : base(message)
        {
        }
    }
}