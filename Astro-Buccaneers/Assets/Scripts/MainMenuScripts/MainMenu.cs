using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuScripts
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame() {
            SceneManager.LoadScene("Navigation");
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}
