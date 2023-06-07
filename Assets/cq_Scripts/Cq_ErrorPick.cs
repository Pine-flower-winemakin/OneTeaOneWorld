using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Cq_ErrorPick : MonoBehaviour
{
    private Material material;

    public GameObject warning;

    // 碰撞开始
    private void OnTriggerEnter(Collider collider)
    {
        warning.SetActive(true);
        // warning.GetComponent<Cq_Warning>().appear();
        print("错误采茶：" + this.name);
        StartCoroutine(PlayMusicAfterDelay(3f));
    }
    // 使用OnPointerClick注意：需要为物体添加一个Event Trigger组件 注意还需要继承IPointerClickHandler
    //    public  void OnPointerClick(PointerEventData eventData)
    //{
    //    warning.GetComponent<Cq_Warning>().appear();
    //    print("错误采茶：" + this.name);
    //}

    private IEnumerator PlayMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warning.SetActive(false);
        
    }
}
