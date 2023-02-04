using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorsButton : MonoBehaviour
{
    [SerializeField] private Color _color;

    public void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = _color;
    }
}
