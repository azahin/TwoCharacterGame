using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIBar : MonoBehaviour
{
    [SerializeField] private Sprite I0;
    [SerializeField] private Sprite I1;
    [SerializeField] private Sprite I2;
    [SerializeField] private Sprite I3;
    [SerializeField] private Sprite I4;
    [SerializeField] private Sprite I5;


    
    private void Start()
    {
        ResourceManager.Instance.movementValueChanged += UpdateImage;
        UpdateImage();
    }

    private void UpdateImage()
    {
        Sprite barImage = I0;
        int barValue = ResourceManager.Instance.GetValue();
        
        int fillBar = 0;

        while (fillBar < barValue / 5)
        {
            transform.GetChild(fillBar).GetComponent<Image>().sprite = I5;
            fillBar++;
        }

        switch (barValue % 5)
        {
            case 0:
                barImage = I0;
                break;
            case 1:
                barImage = I1;
                break;
            case 2:
                barImage = I2;
                break;
            case 3:
                barImage = I3;
                break;
            case 4:
                barImage = I4;
                break;
        }
       
        transform.GetChild(fillBar).GetComponent<Image>().sprite = barImage;
           
    }

}
