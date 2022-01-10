using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject loadingBar;
    private Slider _loadingBarSlider;

    [CanBeNull] private AsyncOperation _currentLoadingScene;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _loadingBarSlider = loadingBar.GetComponentInChildren<Slider>();
        loadingBar.SetActive(false);
    }

    private void Update()
    {
        if (_currentLoadingScene != null)
            _loadingBarSlider.value = _currentLoadingScene.progress;
        else
            _loadingBarSlider.value = 0;
    }

    private void LoadScene(string sceneName)
    {
        _currentLoadingScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        loadingBar.SetActive(true);
        buttons.SetActive(false);
    }
    
    public void OnExitButtonClicked() => Application.Quit();

    public void OnHouseButtonClicked() => LoadScene("Scenes/HouseScene");
    public void OnForestButtonClicked() => LoadScene("Scenes/ForestScene");
}
