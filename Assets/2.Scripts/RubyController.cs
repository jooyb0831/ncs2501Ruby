using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    const float SPEED = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;// 초당 프레임 10으로 제한
        */
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        /*GetAxisRaw를 사용하면 -1,0,1값만 넘어옴
        float vertical = Input.GetAxisRaw("Vertical");
        Debug.Log($"h:{horizontal}");
        Debug.Log($"v:{vertical}");
        */
        Vector2 position = transform.position;
        position.x += SPEED * horizontal * Time.deltaTime;
        position.y += SPEED * vertical * Time.deltaTime;
        transform.position = position;
    }
}
