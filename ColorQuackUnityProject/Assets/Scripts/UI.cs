using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject uiTitle;
    public GameObject uiGameOver;
    public bool IsReady { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiGameOver.SetActive(false);
        uiTitle.SetActive(true);
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        uiGameOver.SetActive(true);
        SpaceShooterInput.Instance.DisableInput();
        IsReady = false;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SpaceShooterInput.Instance.EnableInput();
        IsReady = true;
        uiTitle.SetActive(false);
    }
}
