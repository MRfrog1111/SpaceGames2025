using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShip_UI : MonoBehaviour
{
    public MC_InGameInformation inf;
    public Text score;
    public Text time;
    private int minutes = 0, secs = 0;
    void Start()
    {
        StartCoroutine(GameTimeCounter());
    }
    public void OK(GameObject messege) {
        messege.SetActive(!messege.activeSelf);
    }

    void FixedUpdate()
    {
        score.text = "Кораблей собрано: " + inf.shipsCreated;
    }

    private IEnumerator GameTimeCounter()
    {
        while (true){ 
        yield return new WaitForSecondsRealtime(1);
        secs++;
        minutes += secs/60;
            secs = secs % 60;
            time.text = "Время: " + minutes + "."+secs.ToString("00");
        
            }
    }
}
