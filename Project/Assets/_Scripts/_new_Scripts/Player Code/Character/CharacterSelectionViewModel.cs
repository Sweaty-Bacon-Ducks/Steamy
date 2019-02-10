using System.Collections.Generic;
using UnityEngine;

using Steamy.Player;

namespace Steamy.UI
{
    public class CharacterSelectionViewModel : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> availableCharacters;
        public List<GameObject> AvailableCharacters
        {
            get => availableCharacters;
            set => availableCharacters = value;
        }

		public Transform ListingContent;
		public GameObject ListingElementPrefab;

        public string SceneCameraTag;
        private GameObject sceneCamera;

        private void Start()
        {
            sceneCamera = GameObject.FindGameObjectWithTag(SceneCameraTag);

			foreach (var charater in AvailableCharacters)
			{
				var listingElement = Instantiate(ListingElementPrefab, ListingContent).
					GetComponent<CharacterListingElement>();

				var characterViewModel = charater.GetComponent<CharacterViewModel>();
				listingElement.PresentCharacterData(characterViewModel.Model);
			}

        }
    }
}

