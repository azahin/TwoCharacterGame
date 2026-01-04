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

    [SerializeField] private int set = 0;

    [SerializeField] private ResourceManager manager;

    private Sprite barImage;
    private void Start()
    {
        barImage = GetComponent<Sprite>();
        UpdateImage();
    }

    private void Awake()
    {
        UpdateImage();
    }


    private void OnEnable()
    {
        manager.movementValueChanged += UpdateImage;
    }

    private void OnDisable()
    {
        manager.movementValueChanged -= UpdateImage;

    }

    private void UpdateImage()
    {
        switch (manager.GetValue()%6)
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
            case 5:
                barImage = I5;
                break;
        }

        gameObject.GetComponent<Image>().sprite = barImage;
           
    }

}
