using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    
    public bool isOn;
    bool blink = false;
    public float animationLenght = 1.1f;
    float curentTime = 0;
    float blinkdirection = 0.05f;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        TurnOf();
    }
    private void Awake()
    {      
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animationLenght = 1.1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (blink)
        {
            //Debug.Log(m_SpriteRenderer.color.a);
            if (m_SpriteRenderer.color.a >= 1f || m_SpriteRenderer.color.a <= 0.5f)
            {
                blinkdirection *= -1;
            }
            m_SpriteRenderer.color = new Vector4(m_SpriteRenderer.color.r, m_SpriteRenderer.color.g, m_SpriteRenderer.color.b, (m_SpriteRenderer.color.a + blinkdirection));
            if (Time.fixedTime > curentTime + animationLenght)
            {
                StopBlinking();
            }
        }

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
        blink = false;

    }
    public void StopBlinking()
    {
        blink = false;
        TurnOf();
    }
    public void StartBlinking()
    {
        blink = true;
        TurnOn();
        curentTime = Time.fixedTime;
    }
}
