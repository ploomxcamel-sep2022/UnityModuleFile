using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// 指定したオブジェクトのColorをハイライトカラー設定の間でハイライトさせる<br/>
/// 基本的にハイライトさせたいオブジェクトにアタッチして設定する
/// </summary>
public class HighLightColor : MonoBehaviour
{
    //ハイライト
    public bool isHighLight = true;

    [Header("ハイライトする間隔、数値を下げると速くなる")]
    public float duration = 0.5f;

    [Header("ハイライトさせたいオブジェクト")]
    public Image highLightImage;
    public MeshRenderer highLightMat;

    public bool isMaterial;

    [Header("ハイライトカラー設定")]
    public Color lowLightColl;
    public Color highLightCol;

    [Header("必要なければ設定しなくて良い")]
    public Color defaultCol;


	// Update is called once per frame
	void Update()
    {
        if (isHighLight)
        {
            if (isMaterial)
            {
                HighLight_MaterialColor();
            }
            else
			{
                HighLight_ImageColor();
            }
        }
    }

    /// <summary>
    /// ImageColorをハイライトさせる<br/>
    /// </summary>
    private void HighLight_ImageColor()
    {
        float lerp = Mathf.PingPong(Time.unscaledTime, duration) / duration;

        highLightImage.color = Color.Lerp(lowLightColl, highLightCol, lerp);
    }

	/// <summary>
	/// MaterialColorをハイライトさせる<br/>
	/// </summary>
	private void HighLight_MaterialColor()
	{
		float lerp = Mathf.PingPong(Time.unscaledTime, duration) / duration;

		highLightMat.material.color = Color.Lerp(lowLightColl, highLightCol, lerp);
	}

	/// <summary>
	/// ハイライトの有効・無効<br/>
	/// Trueだとハイライトする
	/// </summary>
	public void setHighLight(bool _highLight)
    {
        isHighLight = _highLight;
    }

    /// <summary>
    /// デフォルトカラーに設定<br/>
    /// ハイライトを止めた時などにデフォルトカラーに設定したい場合など
    /// </summary>
    public void setDefaultColor()
    {
        if (isMaterial)
        {
            highLightMat.material.color = defaultCol;
        }
        else
		{
            highLightImage.color = defaultCol;
        }
    }
}
