using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class item_collector : MonoBehaviour
{
    int strawberry = GameManager.Instance.score;

    [SerializeField] private Text strawberryText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            strawberry++;
            strawberryText.text = "Strawberry:" + strawberry;

            GameManager.Instance.score = strawberry;

        }
    }
}
