using System;

using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            State = State.Finished; 
        }

        private State TryParseState(string stateStr)
        {
            State state;

            bool stated = Enum.TryParse<State>(stateStr, out state);

            if (!stated)
            {
                throw new InvalidMissionStateException();
            }

            return state;
        }
    }
}
