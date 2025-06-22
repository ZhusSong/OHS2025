using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeControl : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public int maxWordsPerLine = 15;
    public float wordWidthEstimate = 50f; 
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        int wordCount = textMeshPro.text.Length;

        float targetWidth = Mathf.Min(maxWordsPerLine, wordCount) * wordWidthEstimate;
        RectTransform rt = textMeshPro.GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
    }
    //private int maxWordsPerLine = 8;
    //void Start()
    //{
    //    textMeshPro=this.GetComponent<TextMeshProUGUI>();
    //}
    //void Update()
    //{
    //    RectTransform rt = textMeshPro.GetComponent<RectTransform>();
    //    int wordCount = textMeshPro.text.Length;
    //    rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, wordCount * 50f);

    //    if (wordCount > maxWordsPerLine)
    //    {
    //        float scaleFactor = (float)maxWordsPerLine / wordCount;
    //        textMeshPro.fontSize = Mathf.Clamp(36f * scaleFactor, 12f, 36f); // adjust max/min as needed
    //    }
    //    else
    //    {
    //        textMeshPro.fontSize = 36f; // reset to default
    //    }
    //}
}
