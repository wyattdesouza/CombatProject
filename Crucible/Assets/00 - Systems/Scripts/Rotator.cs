using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool rotateZ;
    public float rotationSpeed = 10f;
    
    void Update()
    {
        if (rotateZ)
        {
            //rotate around z axis by rotationSpeed times by time.deltatime
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
