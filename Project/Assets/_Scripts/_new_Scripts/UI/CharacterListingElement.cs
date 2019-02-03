using Steamy.Player;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Steamy.UI
{
	public class CharacterListingElement : MonoBehaviour
	{
		private TextMeshProUGUI textField;
		private Image imageField; 

		private void Awake()
		{
			textField = GetComponentInChildren<TextMeshProUGUI>();
			imageField = GetComponentInChildren<Image>();
		}

		public void PresentCharacterData(CharacterModel characterModel)
		{
			textField.text = characterModel.Name;
		}
	}
}

