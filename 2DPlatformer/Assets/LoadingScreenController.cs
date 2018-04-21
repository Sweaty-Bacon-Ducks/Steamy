using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class LoadingScreenController : CustomBehaviour.SingletonBehaviour<LoadingScreenController> 
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    int buildIndex;
    [SerializeField]
    float rotationSpeed;

    AsyncOperation async;
    public void LoadLevel(int buildIndex)
    {
        async = SceneManager.LoadSceneAsync(buildIndex);
        StartCoroutine(SmoothRotate(async, text.rectTransform, rotationSpeed));
    }

    public IEnumerator SmoothRotate(AsyncOperation async, RectTransform rectTransform, float rotationSpeed)
    {
        while (!async.isDone)
        {
            rectTransform.rotation = Quaternion.Euler(0, 0, Time.deltaTime * rotationSpeed);
            yield return null;
        }
    }
}
