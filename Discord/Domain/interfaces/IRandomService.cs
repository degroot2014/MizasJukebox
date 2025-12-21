using System;
using System.Collections.Generic;
using System.Text;

namespace JukeboxDiscordClient.Domain.interfaces
{
    public interface IRandomService
    {
        int RandomNumber(int min, int max);
    }
}
