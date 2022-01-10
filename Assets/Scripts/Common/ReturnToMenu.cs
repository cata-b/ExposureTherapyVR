using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ReturnToMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                SceneManager.LoadScene("Scenes/MainMenuScene", LoadSceneMode.Single);
        }
    }
}