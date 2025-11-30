using UnityEngine;

public class WatcherSpawner : MonoBehaviour
{
    [SerializeField] AimBehaviour aimBehaviour;
    [SerializeField] GameObject watcherPrefab;
    [SerializeField] float speed = 1.2f;
    WatcherBehavior _watcherBehavior;
    void Update()
    {
        if ((_watcherBehavior == null) && (aimBehaviour.currentPlane != null))
        {
            var instantiate = Instantiate(watcherPrefab, aimBehaviour.transform.position, Quaternion.identity);
            _watcherBehavior = instantiate.GetComponent<WatcherBehavior>();
            _watcherBehavior.SetUp(speed, aimBehaviour);
            aimBehaviour.SetLockedPlane(aimBehaviour.currentPlane);
        }
    }
}
