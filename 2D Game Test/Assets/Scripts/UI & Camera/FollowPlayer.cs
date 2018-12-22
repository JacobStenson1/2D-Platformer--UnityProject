using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Makes sure this camera is always at the position of the player,
        //offset so it does not appear at a first person view.
        transform.position = player.position + offset;
    }
}
