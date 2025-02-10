using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        /*
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
        */

        //tryGetcomponent : true/false null체크까지 함. //주소값.참조. (초기화 안해도 될때는 out)
        if(other.TryGetComponent<RubyController>(out var controller))
        {
            controller.ChangeHealth(-1);
        }
    }
}
