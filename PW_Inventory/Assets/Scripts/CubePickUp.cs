using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePickUp : MonoBehaviour
{
    public Item[] items;
    Renderer cubeRenderer;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] List<string> names = new List<string>();
    [SerializeField] int minItemWeight;
    [SerializeField] int maxItemWeight;

    private void Awake()
    {
        cubeRenderer = GetComponent<Renderer>();
        SetUp();
    }

    private void SetUp()
    {
        SetColor();
        SetItemDetails();
    }

    private void SetColor()
    {
        cubeRenderer.material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
    }

    private void SetItemDetails()
    {
        var randomSpriteIndex = Random.Range(0, sprites.Count);
        var randomNameIndex = Random.Range(0, names.Count);
        var randomWeight = Random.Range(minItemWeight, maxItemWeight);

        for (int i = 0; i < items.Length; i++)
        {
            items[i].itemImage = sprites[randomSpriteIndex];
            items[i].name = names[randomNameIndex];
            items[i].weight = randomWeight;
        }
    }
}
