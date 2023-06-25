using Assets.Core;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject collected;
    public int Score;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Constants.TAG_PLAYER))
        {
            collected.SetActive(true);
            GameController.instance.totalScore += Score;
            GameController.instance.txtCoins.text = GameController.instance.totalScore.ToString();
            Destroy(this.gameObject, 0.25f);
            GetComponent<AudioSource>().Play();
        }
    }
}
