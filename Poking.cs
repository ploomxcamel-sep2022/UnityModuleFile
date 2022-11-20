using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 突っつく様なスクリプトアニメーション<br/>
/// チュートリアルなどで矢印のUIオブジェクトを、ある項目や場所を突っつくようにアニメーションさせたい時などに使う<br/>
/// RectTransformで動かす<br/>
/// 基本的にPokingさせたいオブジェクトにアタッチして設定する
/// </summary>
public class Poking : MonoBehaviour
{
    [Header("Pokingさせるオブジェクト")]
    public RectTransform pokingObjRect;

    [Header("Pokingを有効にしたい場合はTrue")]
    public bool isPoking = true;

    [Header("unscaleDeltaTimeで動かしたい場合はTrue")]
    public bool isUnscaleDeltaTime;

    [Header("突っつく速さ")]
    public float pokingSpeed = 40.0f;

    [Header("突っつく幅、移動幅")]
    public float pokingDistance = 15.0f;

    public enum PokingDirection
    {
        up,
        under,
        right,
        left,
    }
    [Header("動かす方向")]
    public PokingDirection pokingDirection;

    //内部変数
    private float _scaleTime;
    private float _accumulationValue;
    private Vector2 originRectPosition;


    // Start is called before the first frame update
    void Start()
    {
        _accumulationValue = 0.0f;
        originRectPosition = pokingObjRect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUnscaleDeltaTime)
        {
            _scaleTime = Time.unscaledDeltaTime;
        }
        else
        {
            _scaleTime = Time.deltaTime;
        }

        if(isPoking)
        {
            PokingAnimation();
        }
    }

    private void PokingAnimation()
    {
        //１フレームの移動幅を計算
        _accumulationValue += pokingSpeed * _scaleTime;

        //PokingObjRectをDirectionの設定でPokingさせる
        switch((int)pokingDirection)
        {
            case (int)PokingDirection.up:
                pokingObjRect.anchoredPosition += new Vector2(0.0f, _accumulationValue);
                break;

            case (int)PokingDirection.under:
                pokingObjRect.anchoredPosition += new Vector2(0.0f, _accumulationValue * -1.0f);
                break;

            case (int)PokingDirection.right:
                pokingObjRect.anchoredPosition += new Vector2(_accumulationValue, 0.0f);
                break;

            case (int)PokingDirection.left:
                pokingObjRect.anchoredPosition += new Vector2(_accumulationValue * -1.0f, 0.0f);
                break;
        }

        //累積値が移動幅を超えたら原位置に戻す
        if(_accumulationValue >= pokingDistance)
        {
            pokingObjRect.anchoredPosition = originRectPosition;
            _accumulationValue = 0.0f;
        }
    }
}
