using UnityEditor;
using UnityEngine;

public class Victory : MonoBehaviour
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
    void Update()
    {
        if (victory != null)
        {
            menu = GameObject.FindGameObjectWithTag("Menu");
            game = GameObject.FindGameObjectWithTag("Game");
            pause = GameObject.FindGameObjectWithTag("Pause");
            victory = GameObject.FindGameObjectWithTag("Victory");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            menu.SetActive(false);
            game.SetActive(false);
            pause.SetActive(false);
            victory.SetActive(true);
            Time.timeScale = 0f;
            SetSystemsActive(false);
        }
    }
}
