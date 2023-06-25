using Assets.Core;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //public SpriteRenderer sr;
    //public CircleCollider2D circle;
    public GameObject collected;
    public int Score;

    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Constants.TAG_PLAYER))
        {
            //Debug.Log($"CollisionEnter2D {collision2D.gameObject.tag}");
            //sr.enabled = false;
            //circle.enabled = false;
            collected.SetActive(true);
            GameController.instance.totalScore += Score;
            GameController.instance.txtCoins.text = GameController.instance.totalScore.ToString();
            Destroy(this.gameObject, 0.25f);
            GetComponent<AudioSource>().Play();
        }
    }
}
