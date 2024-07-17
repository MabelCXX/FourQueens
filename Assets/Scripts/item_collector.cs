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

    private void Start()
    {
        // 初始化草莓数量
        strawberry = GameManager.Instance.score;
        // 更新UI显示
        UpdateStrawberryText();
    }

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

    public void UpdateStrawberryText()
    {
        strawberryText.text = "Strawberry: " + GameManager.Instance.score;
    }
}
