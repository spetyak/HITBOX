using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box2Health : MonoBehaviour
{

    public TextMeshProUGUI boxHealth;
    public BoxMove2 box;

    // Update is called once per frame
    void Update()
    {
        boxHealth.text = "Player2: " + box.health.ToString();
    }
}
