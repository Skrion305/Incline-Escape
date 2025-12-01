using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victory;
    void Update()
    {
        if (victory != null)
        {
            victory = GameObject.FindGameObjectWithTag("Victory");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            victory.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
