using Assets.Core;
using UnityEngine;

public class EatBehavior : MonoBehaviour
{
    public bool ActiveEatEnemy = false;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Constants.TAG_CROCODILE) && ActiveEatEnemy)
        {
            gameObject.SetActive(false);
        }
    }
}
