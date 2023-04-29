using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarSystemBtnClick : MonoBehaviour
{
    // The name of the scene to load
    public string sceneName;

    // Called when the object is clicked
    private void OnMouseDown()
    {
        // Load the scene with the specified name
        SceneManager.LoadScene(sceneName);
    }
}
