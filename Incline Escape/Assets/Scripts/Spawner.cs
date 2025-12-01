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
            spawnedObject.transform.position = hitPose.position;
            spawnedObject.transform.rotation = hitPose.rotation;
            SpawnBall();
        }
        else
        {
            spawnedObject = Instantiate(maze, hitPose.position, hitPose.rotation);
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
