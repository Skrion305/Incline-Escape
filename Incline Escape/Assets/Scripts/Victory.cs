using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] UI ui;
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            ui.menu.SetActive(false);
            ui.game.SetActive(false);
            ui.pause.SetActive(false);
            ui.victory.SetActive(true);
            Time.timeScale = 0f;
            ui.SetSystemsActive(false);
        }
    }
}
