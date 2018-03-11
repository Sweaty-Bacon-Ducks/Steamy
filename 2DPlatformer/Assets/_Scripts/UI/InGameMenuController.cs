using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuController : MonoBehaviour
{
    [SerializeField]
    private Scene DisconnectScene;
    public void DisconnectFromHost()
    {
        SceneManager.LoadScene(DisconnectScene.buildIndex);
    }
}
