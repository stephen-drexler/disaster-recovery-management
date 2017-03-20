using System;
using System.Collections.Generic;

namespace VM.DisasterRecovery.Common.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public ICollection<string> Messages { get; private set; }

        public Exception Exception { get; set; }

        private OperationResult(bool success)
        {
            Success = success;
            Messages = new List<string>();
        }

        public static OperationResult Initialize(bool success = true)
        {
            return new OperationResult(success);
        }
        
        public static OperationResult Initialize(bool success, string message, Exception exception = null)
        {
            OperationResult result = new OperationResult(success);
            result.Add(message);
            result.Exception = exception;

            return result;
        }

        public static OperationResult Initialize(bool success, ICollection<string> messages, Exception exception = null)
        {
            OperationResult result = new OperationResult(success);
            result.Add(messages);
            result.Exception = exception;

            return result;
        }

        public void Add(IEnumerable<string> messages)
        {
            if (null != messages)
            {
                foreach (var message in messages)
                {
                    Add(message);
                }
            }
        }

        public void Add(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Messages.Add(message);
            }
        }
    }
}
