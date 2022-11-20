using UnityEngine.UI;

/// <summary>
/// ImageのFillAmountへの塗りつぶしを行う<br/>
/// オブジェクトへのアタッチではなく、このクラスをインスタンス化して使う<br/>
/// </summary>
public class FillAmountToImage
{
    /// <summary>
    /// 最大値に対して現在値の割合を算出して塗りつぶす（計算式：currentValue ÷ maxValue）<br/>
    /// </summary>
    public void rateFillAmount(Image fillImage, float currentValue, float maxValue)
    {
        drawFillAmount(fillImage, currentValue / maxValue);
    }

    /// <summary>
    /// 引数の値で塗りつぶす、amount（0.0f〜1.0f）<br/>
    /// </summary>
    public void drawFillAmount(Image fillImage, float amount)
    {
        fillImage.fillAmount = amount;
    }
}
