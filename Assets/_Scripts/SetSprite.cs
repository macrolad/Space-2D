using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSprite : MonoBehaviour
{
    public SpriteRenderer MyImage;
    public Sprite[] Sprites;

    private void Start()
    {
        int i = Random.Range(0, Sprites.Length);
        MyImage.sprite = Sprites[i];

        GetComponent<CircleCollider2D>().radius = Vector3.Magnitude(MyImage.sprite.bounds.extents) * 0.6f;
    }
}
