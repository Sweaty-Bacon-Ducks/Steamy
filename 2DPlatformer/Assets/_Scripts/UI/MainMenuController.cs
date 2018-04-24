using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        List<GameObject> objectsToFadeIn;

        [SerializeField]
        float fadeSpeed;

        void Start()
        {
            foreach (GameObject @object in objectsToFadeIn)
            {
                try
                {
                    StartCoroutine(FadeIn(@object.GetComponentInChildren<TMP_Text>(), fadeSpeed));
                }
                catch (System.NullReferenceException)
                {
                    Debug.Log(@object.name);
                }
            }
        }

        IEnumerator FadeIn(TMP_Text text, float fadeSpeed)
        {
            float targetAlpha = 1;
            float newAlpha = 0;
            while (text.color.a < targetAlpha)
            {
                newAlpha += Time.deltaTime * fadeSpeed;
                text.color = new Color(text.color.r, text.color.g, text.color.b, newAlpha);
                yield return null;
            }
        }
        IEnumerator FadeIn(Button button, float fadeSpeed)
        {
            float targetAlpha = 1;
            float newAlpha = 0;
            while (button.colors.disabledColor.a < targetAlpha)
            {
                newAlpha += Time.deltaTime * fadeSpeed;
                Color color = new Color(button.colors.disabledColor.r, button.colors.disabledColor.g, button.colors.disabledColor.b, newAlpha);
                ColorBlock colorBlock = new ColorBlock
                {
                    colorMultiplier = button.colors.colorMultiplier,
                    fadeDuration = button.colors.fadeDuration,
                    highlightedColor = button.colors.highlightedColor,
                    normalColor = button.colors.normalColor,
                    pressedColor = button.colors.pressedColor,
                    disabledColor = color
                };
                button.colors = colorBlock;
                yield return null;
            }
        }

        public void PlayGame()
        {
            LoadingScreenController.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}