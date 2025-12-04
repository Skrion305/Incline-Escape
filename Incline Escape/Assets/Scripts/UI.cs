using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject xrOrigin;
    [SerializeField] GameObject arSession;
    [SerializeField] MonoBehaviour[] scripts;
    public GameObject menu;
    public GameObject pause;
    public GameObject game;
    public GameObject victory;
    public void SetSystemsActive(bool active)
    {
        foreach (var s in scripts)
        {
            if (s != null)
            {
                s.enabled = active;
            }
        }
        if (xrOrigin != null)
        {
            xrOrigin.SetActive(active);
        }
        if (arSession != null)
        {
            arSession.SetActive(active);
        }
    }
    public void Menu()
    {
        game.SetActive(false);
        pause.SetActive(false);
        victory.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 1f;
        SetSystemsActive(false);
    }
    public void StartGame()
    {
        menu.SetActive(false);
        pause.SetActive(false);
        victory.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1f;
        SetSystemsActive(true);
    }
    public void Pause()
    {
        menu.SetActive(false);
        game.SetActive(false);
        victory.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 0f;
        SetSystemsActive(false);
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        pause.SetActive(false);
        victory.SetActive(false);
        game.SetActive(true);
        Time.timeScale = 1f;
        SetSystemsActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
