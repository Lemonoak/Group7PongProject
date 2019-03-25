using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Round : MonoBehaviour
{
    TextMeshProUGUI textPro;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        textPro = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void setRoundNum(int round)
    {
        textPro.text = round.ToString();
    }
}
