
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public Transform Player;

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + 2.5f, Player.position.z - 8f);
    }
}
