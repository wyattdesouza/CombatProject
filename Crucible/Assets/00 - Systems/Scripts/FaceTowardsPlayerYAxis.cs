using UnityEngine;

public class FaceTowardsPlayerYAxis : MonoBehaviour
{
    private Player player;
    void Start()
    {
        //switch this to look at teh camera at some point
        player = Player.Instance;
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        //the above function works except we need to flip the rotation on the y axis
        transform.Rotate(0, 180, 0);
        
    }
}
