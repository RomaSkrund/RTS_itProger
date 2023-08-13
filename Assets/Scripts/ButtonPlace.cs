using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlace : MonoBehaviour
{
    public GameObject building;

    public void PlaceBuild()
    {
        Instantiate(building);
    }
}
