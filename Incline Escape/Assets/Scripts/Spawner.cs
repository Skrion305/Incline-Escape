using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Spawner : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] InputActionReference tapAction;
    [SerializeField] GameObject maze;
    GameObject spawnedObject;
    [SerializeField] GameObject ballPrefab;
    private void OnEnable()
    {
        tapAction.action.Enable();
        tapAction.action.performed += OnTap;
    }
    private void OnDisable()
    {
        tapAction.action.Disable();
        tapAction.action.performed -= OnTap;
    }
    private void OnTap(InputAction.CallbackContext context)
    {
        Vector2 touchPosition;
        if (context.control is Pointer inputPointer)
        {
            touchPosition = inputPointer.position.ReadValue();
        }
        else if (context.control is TouchControl pointerControl)
        {
            touchPosition = pointerControl.position.ReadValue();
        }
        else
        {
            touchPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        }
        var arRaycastHits = new List<ARRaycastHit>();
        if (!raycastManager.Raycast(touchPosition, arRaycastHits, TrackableType.PlaneWithinPolygon))
        {
            return;
        }
        var hitPose = arRaycastHits[0].pose;
        if (spawnedObject != null)
        {
            Transform anchorTransform = spawnedObject.transform.parent;
            if ((anchorTransform != null) && (anchorTransform.GetComponent<ARAnchor>() != null))
            {
                anchorTransform.position = hitPose.position;
                anchorTransform.rotation = hitPose.rotation;
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
            SpawnBall();
        }
        else
        {
            var anchorObject = new GameObject("MazeAnchor");
            anchorObject.transform.position = hitPose.position + (Vector3.up * 0.0001f);
            anchorObject.transform.rotation = hitPose.rotation;
            var anchor = anchorObject.AddComponent<ARAnchor>();
            spawnedObject = Instantiate(maze, hitPose.position + (Vector3.up * 0.0001f), hitPose.rotation);
            spawnedObject.transform.SetParent(anchorObject.transform);
            SpawnBall();
        }
    }
    void SpawnBall()
    {
        if ((ballPrefab == null) || (spawnedObject == null))
        {
            return;
        }
        Transform oldBall = spawnedObject.transform.Find("Sphere");
        if (oldBall != null)
        {
            Destroy(oldBall.gameObject);
        }
        Vector3 local = new Vector3(0f, 6.47f, -4.02f);
        Vector3 spawn = spawnedObject.transform.TransformPoint(local);
        GameObject ball = Instantiate(ballPrefab, spawn, Quaternion.identity);
    }
}
