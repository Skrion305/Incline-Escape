using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject xrOrigin;
    [SerializeField] GameObject arSession;
    [SerializeField] MonoBehaviour[] scripts;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject game;
    [SerializeField] GameObject victory;
    void SetSystemsActive(bool active)
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
        menu.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        victory.SetActive(false);
        Time.timeScale = 1f;
        SetSystemsActive(false);
    }
    public void StartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        victory.SetActive(false);
        Time.timeScale = 1f;
        SetSystemsActive(true);
    }
    public void Pause()
    {
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(true);
        victory.SetActive(false);
        Time.timeScale = 0f;
        SetSystemsActive(false);
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        victory.SetActive(false);
        Time.timeScale = 1f;
        SetSystemsActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
