using System;
using System.Collections.Generic;
using System.Text;

namespace JukeboxDiscordClient.Api.interfaces
{
    public interface Idnd5eapi
    {
        IList<Result> GetConditions();
        Result GetCondition(string name);
        IList<Result> GetSpellList(string className);
        Result GetSpell(string name);
    }
}
