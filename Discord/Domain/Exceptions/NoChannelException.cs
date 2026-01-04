using System;
using System.Collections.Generic;
using System.Text;

namespace JukeboxDiscordClient.Domain.Exceptions
{
    public class NoChannelException : Exception
    {
        public NoChannelException() : base("No channel selected")
        {
        }
    }
}
