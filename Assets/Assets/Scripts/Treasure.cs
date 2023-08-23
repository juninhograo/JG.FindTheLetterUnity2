using Assets.Core;
using System.Linq;
using UnityEngine;
public class Treasure : MonoBehaviour
{
    public Player player;
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        //Debug.Log("Touch the chest");
        if (collision2D.gameObject.CompareTag(Constants.TAG_PLAYER))
        {

            if (GameController.instance.IsKeyCatched)
            {
                player.GameCore.Finish();
            }
            else
            {
                player.GameCore.FindTheKeyMessage(true);
            }
        }
    }
}
