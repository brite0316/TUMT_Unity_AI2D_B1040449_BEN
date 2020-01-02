using UnityEngine;

public class cammove : MonoBehaviour
{
    public float camspeed = 10;

    public Transform target;


    private void Start()
    {
        target = GameObject.Find("忍者").transform;
    }

    // 延遲更新：在 Update 後更新 - 用於攝影機, 物件追蹤
    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -0.1f, 1);   //數學.夾住(值, 最小, 最大)
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * camspeed);
    }
}
