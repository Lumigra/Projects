using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OnTimerUp : UnityEvent { }
public class CountdownScript : MonoBehaviour
{
    public OnTimerUp timerUp = new OnTimerUp();

    public static CountdownScript Timer;

    public Text TimerText;
    public float countdownTime = 600;
    private bool Active = true;

    private void Awake()
    {
        if (Timer != null)
            Destroy(gameObject);
        Timer = this;
    }

    void Start()
    {
        //SingletonManager.Manager.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Active)
        {
            countdownTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(countdownTime / 60F);
            int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            TimerText.text = niceTime;

            if (countdownTime <= 0)
            {
                Active = false;
                countdownTime = 0;
                minutes = 0;
                seconds = 0;
                Time.timeScale = 0;

                timerUp.Invoke();
            }
           
        }
    }
}
