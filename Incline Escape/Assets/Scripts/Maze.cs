using UnityEngine;

public class Maze : MonoBehaviour
{
    float currentTiltX = 0f;
    float currentTiltZ = 0f;
    Transform mazeTransform;
    Quaternion initialRotation;
    void Start()
    {
        FindMaze();
        if (mazeTransform != null)
        {
            initialRotation = mazeTransform.rotation;
        }
    }
    void Update()
    {
        if (mazeTransform == null)
        {
            FindMaze();
            return;
        }
        Quaternion targetRotation = initialRotation * Quaternion.Euler(currentTiltX, 0f, currentTiltZ);
        mazeTransform.rotation = Quaternion.Slerp(mazeTransform.rotation, targetRotation, 10f * Time.deltaTime);
    }
    void FindMaze()
    {
        GameObject maze = GameObject.FindGameObjectWithTag("Maze");
        if (maze != null)
        {
            mazeTransform = maze.transform;
            initialRotation = mazeTransform.rotation;
        }
    }
    public void TiltUp()
    {
        currentTiltX = Mathf.Clamp(currentTiltX + 15f, -15f, 15f);
    }
    public void TiltDown()
    {
        currentTiltX = Mathf.Clamp(currentTiltX - 15f, -15f, 15f);
    }
    public void TiltLeft()
    {
        currentTiltZ = Mathf.Clamp(currentTiltZ + 15f, -15f, 15f);
    }
    public void TiltRight()
    {
        currentTiltZ = Mathf.Clamp(currentTiltZ - 15f, -15f, 15f);
    }
}
