using UnityEngine.Networking;

using Steamy.Editor;

public class ClientLayerController : NetworkBehaviour
{
    [Layer]
    public int LocalPlayerLayer;
    [Layer]
    public int RemotePlayerLayer;

    private void Start()
    {
        var targetLayer = RemotePlayerLayer;
        if (isLocalPlayer)
        {
            targetLayer = LocalPlayerLayer;
        }
        gameObject.layer = targetLayer;
    }
}
