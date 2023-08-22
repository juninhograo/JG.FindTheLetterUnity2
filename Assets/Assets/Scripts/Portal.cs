using Assets.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject ExitPortal;
    public Player Player;
    public bool IsInversedPortal = false;
    public int Position = 7;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D element)
    {
        //control the jump
        if (element.gameObject.CompareTag(Constants.TAG_PLAYER) && ExitPortal != null)
        {
            var position = Position;

            if (IsInversedPortal)
            {
                position *= -1;
            }
            Console.WriteLine(Player.transform.position.ToString());
            Player.transform.position = new Vector3(ExitPortal.transform.position.x + position, ExitPortal.transform.position.y, ExitPortal.transform.position.z);
            Console.WriteLine(Player.transform.position.ToString());
        }
    }
}
