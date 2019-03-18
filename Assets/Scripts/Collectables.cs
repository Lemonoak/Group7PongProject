using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public bool isOn;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        TurnOf();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOn()
    {
        m_SpriteRenderer.color = Color.white;
        isOn = true;
    }
    public void TurnOf()
    {
        m_SpriteRenderer.color = Color.grey;
        isOn = false;
    }
}
