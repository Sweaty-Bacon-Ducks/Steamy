using System;

namespace Steamy.Player
{
    [Serializable]
    public struct CharacterNetworkData
    {
        public double Health;

        public CharacterNetworkData(CharacterModel characterModel)
        {
            Health = characterModel.Health.Value;
        }
    }
}
