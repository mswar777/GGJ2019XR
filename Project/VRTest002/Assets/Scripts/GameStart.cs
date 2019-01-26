using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    //開始時に表示するテキスト
    public Text startText;
    //テキストがフェードして消える時間
    public int fadeTime;
    //アルファ値が下がる量
    private float alpha;
    
    private void Start()
    {
        if (startText == null) Destroy(this);
        alpha = startText.color.a / (fadeTime  * 60);
        StartCoroutine(TextFadeCoroutine());
    }

    /// <summary>
    /// テキストをフェードさせるコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator TextFadeCoroutine()
    {
        while(startText.color.a > 0.0f)
        {
            var color = startText.color;
            color.a -= alpha;
            startText.color = color;
            yield return null;
        }
    }
}
