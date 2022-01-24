using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFollow : MonoBehaviour
{
    [SerializeField] GameObject player;

    private bool followPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -.3f);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
        }
            
    }

    public void SetFollowPlayer(bool _followPlayer)
    {
        followPlayer = _followPlayer;
    }

    public bool IsFollowing()
    {
        return followPlayer;
    }
}
