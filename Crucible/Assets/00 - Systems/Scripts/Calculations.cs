using UnityEngine;

public static class Calculations 
{
    public static Vector3 UpAngleForce(Vector3 ForwardReference)
    {
        Vector3 direction = ForwardReference.normalized;
        direction = Quaternion.AngleAxis(45, Vector3.left) * direction;
        return direction;
    }
}
