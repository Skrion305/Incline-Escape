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
        transform.rotation = Quaternion.RotateTowards(mazeTransform.rotation, targetRotation, 50f * Time.deltaTime);
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
        currentTiltZ = Mathf.Clamp(currentTiltZ + 20f, -20f, 20f);
    }
    public void TiltDown()
    {
        currentTiltZ = Mathf.Clamp(currentTiltZ - 20f, -20f, 20f);
    }
    public void TiltLeft()
    {
        currentTiltX = Mathf.Clamp(currentTiltX + 20f, -20f, 20f);
    }
    public void TiltRight()
    {
        currentTiltX = Mathf.Clamp(currentTiltX - 20f, -20f, 20f);
    }
}
