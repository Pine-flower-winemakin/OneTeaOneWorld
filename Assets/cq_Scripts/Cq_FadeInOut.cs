using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Cq_FadeInOut : MonoBehaviour
{
    private List<Material> materials = new List<Material>();

    private void Start()
    {
        //获取材质
        GetMeterials();
    }
    private void GetMeterials()
    {
        Material[] materals;
        MeshRenderer[] meshRendererer = this.GetComponentsInChildren<MeshRenderer>();
        foreach (var item in meshRendererer)
        {
            materals = item.materials;
            foreach (Material m in materals)
            {
                if (!materials.Contains(m))
                {
                    materials.Add(m);
                }
            }
        }
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
        }
    }
    // 如果是private的话我在另一个脚本就调用不了这个函数了
   public void FadeOut()
    {
        GetMeterials();
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            Color color = m.color;
            m.DOColor(new Color(color.r, color.g, color.b, 0), 3f);
        }
    }

    public void FadeIn()
    {
        GetMeterials();
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            Color color = m.color;
            m.DOColor(new Color(color.r, color.g, color.b, 1), 3f);
        }
    }
}
