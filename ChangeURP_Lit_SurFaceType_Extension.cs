using UnityEngine;

/// <summary>
/// URP/LitマテリアルのサーフェスタイプをTransparentに変更する拡張メソッドのクラス
/// </summary>
public static class ChangeURP_Lit_SurFaceType_Extension
{
    /// <summary>
	/// SkinnedMashRenderer.materials配列に入っているマテリアルのサーフェスタイプをTransparentに変更する拡張メソッド<br/>
	/// URP/Litシェーダーが設定されているマテリアルが変換可能<br/>
	/// ＜使用例＞mSkinnedMashRenderer.materials.toTransparent();
	/// </summary>
	/// <param name="materials"></param>
    public static void toTransparents(this Material[] materials)
	{
        for (int i = 0; i < materials.Length; i++)
        {
            // Alpha Blend
            materials[i].SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            materials[i].SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //playerSkinMeshMat.materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");

            // General Transparent Material Settings
            materials[i].SetFloat("_Surface", 1.0f);   //(float)UnityEditor.BaseShaderGUI.SurfaceType.Transparent　※ビルドエラーになるので数値で記入
            materials[i].SetFloat("_ZWrite", 0.0f);
            materials[i].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            materials[i].renderQueue += materials[i].HasProperty("_QueueOffset") ? (int)materials[i].GetFloat("_QueueOffset") : 0;
            materials[i].SetShaderPassEnabled("ShadowCaster", false); //影を受ける
        }
    }

    /// <summary>
	/// SkinnedMashRenderer.materials配列に入っているマテリアルのサーフェスタイプをOpaqueに変更する拡張メソッド<br/>
	/// URP/Litシェーダーが設定されているマテリアルが変換可能<br/>
	/// ＜使用例＞mSkinnedMashRenderer.materials.toOpaque();
	/// </summary>
	/// <param name="materials"></param>
    public static void toOpaque(this Material[] materials)
	{
        for (int i = 0; i < materials.Length; i++)
        {
            // Alpha Blend
            //materials[i].SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            //materials[i].SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //playerSkinMeshMat.materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");

            // General Transparent Material Settings
            materials[i].SetFloat("_Surface", 0.0f);   //(float)UnityEditor.BaseShaderGUI.SurfaceType.Opaque　※ビルドエラーになるので数値で記入
            materials[i].SetFloat("_ZWrite", 1.0f);
            materials[i].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            //materials[i].renderQueue += materials[i].HasProperty("_QueueOffset") ? (int)materials[i].GetFloat("_QueueOffset") : 0;
            materials[i].SetShaderPassEnabled("ShadowCaster", true); //影を受ける
        }
    }
}
