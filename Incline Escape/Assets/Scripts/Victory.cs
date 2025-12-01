using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victory;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            victory.SetActive(true);
        }
    }
}
