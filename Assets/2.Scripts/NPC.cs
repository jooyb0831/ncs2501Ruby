using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    [SerializeField] TMP_Text questText;
    [SerializeField] TMP_Text shdText;
    float timerDisplay;
    private int cntRbLeft;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        GameObject[] obj = GameObject.FindGameObjectsWithTag("ENEMY");
        cntRbLeft = obj.Length;
        SetDisplayTxt();
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay>=0)
        {
            timerDisplay-=Time.deltaTime;
            if(timerDisplay<0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public bool NoticeRbFixed()
    {
        cntRbLeft--;
        bool isCompleted = (cntRbLeft <= 0) ? true : false;
        SetDisplayTxt(isCompleted);
        return isCompleted;
    }

    void SetDisplayTxt(bool isDone = false)
    {
        if(isDone)
        {
            questText.text = $"Thank You!!";
        }
        else
        {
            questText.text = $"Help me fix the Robot!\nRobot Left : {cntRbLeft}";
        }
        
        shdText.text = questText.text;
    }
}
