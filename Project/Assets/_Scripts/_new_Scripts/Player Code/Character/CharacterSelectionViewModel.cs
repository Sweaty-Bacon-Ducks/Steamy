using System.Collections.Generic;
using UnityEngine;

namespace Steamy.Player
{
    public class CharacterSelectionViewModel : MonoBehaviour
    {
        [SerializeField]
        private CharacterSelectionPresenter presenter;
        public CharacterSelectionPresenter Presenter
        {
            get => presenter;
            set => presenter = value;
        }

        [SerializeField]
        private List<GameObject> availableCharacters;
        public List<GameObject> AvailableCharacters
        {
            get => availableCharacters;
            set => availableCharacters = value;
        }

        public string SceneCameraTag;
        private GameObject sceneCamera;

        private void Start()
        {
            sceneCamera = GameObject.FindGameObjectWithTag(SceneCameraTag);

            if(Presenter)
                Presenter.Transform(AvailableCharacters);
        }

        private void OnDisable()
        {
        }
    }
}

