using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    public AudioClip audioCoin;
    private AudioSource MediaPlayerCoin;
    void Start()
    {
        MediaPlayerCoin = gameObject.AddComponent<AudioSource>();
        MediaPlayerCoin.clip = audioCoin;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag.Equals("Player"))
        {
            MediaPlayerCoin.Play();
            ScoreTextScript.coinAmount += 10;
            Destroy(gameObject);
        }
    }
}
