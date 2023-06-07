using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Cq_ErrorPick : MonoBehaviour
{
    private Material material;

    public GameObject warning;

    // ��ײ��ʼ
    private void OnTriggerEnter(Collider collider)
    {
        warning.SetActive(true);
        // warning.GetComponent<Cq_Warning>().appear();
        print("����ɲ裺" + this.name);
        StartCoroutine(PlayMusicAfterDelay(3f));
    }
    // ʹ��OnPointerClickע�⣺��ҪΪ�������һ��Event Trigger��� ע�⻹��Ҫ�̳�IPointerClickHandler
    //    public  void OnPointerClick(PointerEventData eventData)
    //{
    //    warning.GetComponent<Cq_Warning>().appear();
    //    print("����ɲ裺" + this.name);
    //}

    private IEnumerator PlayMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warning.SetActive(false);
        
    }
}
