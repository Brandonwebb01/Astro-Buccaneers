using UnityEngine;
using UnityEngine.SceneManagement;

namespace SolarSystemScripts
{
    public class BattleShipMode : MonoBehaviour
    {
        public string sceneName;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
