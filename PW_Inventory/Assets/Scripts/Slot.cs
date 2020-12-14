using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Slot : MonoBehaviour
{
    public Image image;
    public string itemName;
    public Item item;
    [SerializeField] Image toolTipImage;
    [SerializeField] Text toolTipText;

    public void DisplayToolTip(bool shouldDisplay)
    {
        if (itemName == String.Empty)
        {
            return;
        } 
        else if (toolTipText.text != itemName ) 
        {
            toolTipText.text = itemName;
        }

        toolTipImage.gameObject.SetActive(shouldDisplay);
    }
}
