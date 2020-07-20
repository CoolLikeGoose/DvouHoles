using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickButton : MonoBehaviour
{
    public void ColorPicking()
    {
        KraskaManager.PickedColor = int.Parse(this.tag);

        
    }
}
