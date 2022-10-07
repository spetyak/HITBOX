using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box1Health : MonoBehaviour
{

    public TextMeshProUGUI boxHealth;
    public BoxMove1 box;

    // Update is called once per frame
    void Update()
    {
        boxHealth.text = "Player1: " + box.health.ToString();
    }
}
