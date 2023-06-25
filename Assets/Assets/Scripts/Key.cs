using Assets.Core;
using UnityEngine;
public class Key : MonoBehaviour
{
    public Player player;
    private AudioSource audioKeyUI;

    private void Start()
    {
        audioKeyUI = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Constants.TAG_PLAYER))
        {
            gameObject.SetActive(false);
            player.Items.Add(gameObject);
            GameController.instance.IsKeyCatched = true;
            GameController.instance.ShowKeyUI(gameObject);
        }
    }
}