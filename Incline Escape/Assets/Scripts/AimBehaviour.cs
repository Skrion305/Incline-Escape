using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;

public class AimBehaviour : MonoBehaviour
{
    public GameObject target;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] ARPlaneManager planeManager;
    public ARPlane currentPlane;
    Camera _mainCamera;
    ARPlane _lockedPlane;
    void Start()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        var screenCenter = _mainCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);
        currentPlane = null;
        ARRaycastHit? hit = hits[0];
        if (hits.Count > 0)
        {
            var lockedPlane = _lockedPlane;
            hit = lockedPlane == null ? hits[0] : hits.SingleOrDefault(x => x.trackableId == lockedPlane.trackableId);
        }
        if (hit.HasValue)
        {
            currentPlane = planeManager.GetPlane(hit.Value.trackableId);
            transform.position = hit.Value.pose.position;
        }
        target.SetActive(currentPlane != null);
    }
    public void SetLockedPlane(ARPlane keepPlane)
    {
        _lockedPlane = keepPlane;
    }
}
