using UnityEngine;

/// <summary>
/// トランスフォームのスケールを増減させてオブジェクトをバウンスアニメーションさせる<br/>
/// 基本的にバウンスさせたいオブジェクトにアタッチして設定する
/// </summary>
public class BounceScale : MonoBehaviour
{
    [Header("バウンスさせたいオブジェクトをセット")]
    public GameObject bounceObj;

    [Header("バウンスの有効・無効")]
    public bool isBounce = true;

    [Header("アンスケールの場合はTrue")]
    public bool isUnScaleDeltaTime = false;

    [Header("初期スケールを最大サイズとして減衰させたい時はチェックを入れる")]
    public bool reverseBounce = false;

    [Header("スケールの初期値、この値から増減させる")]
    public float basicScale = 1.0f;

    [Header("初期スケールからどれくらいの値の間でサイズを増減させるか")]
    public float bounceRange = 0.2f;

    [Header("バウンスする速さ、1.0は増減なし、0.5は2分の1になる")]
    public float bounceSpeed = 0.3f;

    [Header("確認用")]
    public float bounce;

    //内部変数
    private float _deltaTime;


    // Update is called once per frame
    void Update()
    {
        if (isBounce)
        {
            if(isUnScaleDeltaTime)
            {
                _deltaTime += Time.unscaledDeltaTime;
            }
            else
            {
                _deltaTime += Time.deltaTime;
            }

            if (reverseBounce)
            {
                ReverseBounceTransform();
            }
            else
            {
                BounceTransform();
            }
        }
    }

    private void BounceTransform()
    {
        bounce = Mathf.PingPong(_deltaTime * bounceSpeed, bounceRange);
        bounce = bounce + basicScale;
        bounceObj.transform.localScale = new Vector3(bounce, bounce, 1.0f);
    }
    private void ReverseBounceTransform()
    {
        bounce = Mathf.PingPong(_deltaTime * bounceSpeed, bounceRange);
        bounce = basicScale - bounce;
        bounceObj.transform.localScale = new Vector3(bounce, bounce, 1.0f);
    }
}
