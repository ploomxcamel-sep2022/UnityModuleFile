using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// このスクリプトをアタッチしたオブジェクトをシーンをまたいで生存させる
/// </summary>
public class KeepObjects : MonoBehaviour
{
    public static KeepObjects Instance
    {
        get; private set;
    }

    void Awake()
    {
        //シーンを行き来する事で同じオブジェクトが重複する事の対策
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
