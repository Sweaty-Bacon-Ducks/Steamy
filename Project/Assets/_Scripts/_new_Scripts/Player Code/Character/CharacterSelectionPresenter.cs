using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Player
{ 
    public abstract class CharacterSelectionPresenter : ScriptableObject
    {
        public abstract void Transform(List<GameObject> characters);
    }
}
