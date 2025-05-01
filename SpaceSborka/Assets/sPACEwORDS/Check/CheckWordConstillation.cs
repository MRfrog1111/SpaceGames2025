using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordConstillation : MonoBehaviour
{
    string text1 = "�� ������� 3 �����, ������� ������� �� 1 ������. ��� �������!\r\n\r\n\r\n������, � �� �����, ���:\r\n* � ����������� ���������� ���������� 88 ���������. ����� �� ��� ����� ������� ������ �� ��������� ���������(������� ���������, ����� ���������,���������, �����, ������ � ��.), � ����� � �� ������(����� �����, ��������, �������, ��������� � ��.).\r\n* ������, ��������� �������� � ���� ���������, ����� �� ����� ���� ���� ����������� � ������ � ������� �������� ��� ���� �� �����, ���� ������, ������ �����. �� � ����� �������, ��� ��� ��������� �����.\r\n* 48 �� �������������� 88 ��������� ���� ������� ��� ���������, ��������������� ������ � ���������, ������� �������� ���� ����� ��������� ���� ����� 2200 ��� �����.\r\n";
    string text2 = "�� ������� 7 ����, ������� ������� �� 2 ������. ���������� ���!\r\n\r\n\r\n������, � �� �����, ���:\r\n* ������ � ��������� ������ �� ����������, ������� ��������� ���� ���������� �������� � ����������. �� � �������� ����� ���������� ��������� ����� ��� ���������.\r\n* � ����������� �� ������� ���� �� ����� ��������� �� ���� ������ ���������, ��� ��� ����� �������� ������ ������, � �� ����� �� �����.\r\n* ��������� ��������� ������ � ������ ������. ���, � ������ ��������� ������ 19 ���������, � � ������ ������� ��������� � 10.\r\n* � ��������� ������� ������������� ����� �������� �� ��������� ��� �����, ����������� �� ����������� ���������� ���� ����� 2700 ��������. �� ������ �� �������� 900 �������� ���.\r\n";
    string text3 = "�� ������� 10 ����, ������� ������� �� 3 ������. ������� ������ ���������� ������:)\r\n\r\n\r\n������, � �� �����, ���:\r\n* ��������� ��������� ��������� ���, ��� ������ ��������� ��� ������ �������� ������� � 18-� ���� ����� � ������� ��������� ������� ������� ����.\r\n* � ��������� ������� ��������� ������ �� ������ ������. ��� ����� ����� � ��� ������� � ��� ����� ���������, �� ��� ��������� ��� ������ �� ���, ��� �� ������������� ����� ������� �� ��������.\r\n* ������ �������� ��������� ��������� �������, ��� ��� ��������� � ����� �� ������.\r\n* ������� ����� �������� ��������� �������� �����-����.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    ConstillationWords aw;
    public Text checkText;
    GameObject[] bc;
    BtnClick bcNow;

    public Material grey;
    public Material yellow;

    GameObject star1;
    GameObject star2;
    GameObject star3;
    // Start is called before the first frame update
    void Start()
    {
        aw = GameObject.FindGameObjectWithTag("Constillation").GetComponent<ConstillationWords>();
        bc = GameObject.FindGameObjectsWithTag("BtnClick");
        check = this.GetComponent<Button>();
        check.onClick.AddListener(checkWord);

        star1 = GameObject.Find("Star1");
        star2 = GameObject.Find("Star2");
        star3 = GameObject.Find("Star3");
        star1.GetComponent<MeshRenderer>().material = grey;
        star2.GetComponent<MeshRenderer>().material = grey;
        star3.GetComponent<MeshRenderer>().material = grey;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void checkWord()
    {
        word = checkText.text;

        
        for (int i = 0; i < aw.words.Count; i++)
        {

            if (word.ToLower() == aw.words[i])
            {
                aw.words.RemoveAt(i);
                int cnt;
                int.TryParse(count.text, out cnt);
                cnt++;
                count.text = cnt.ToString();
                if (cnt == 3)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 7)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 10)
                {
                    star3.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text3);

                }

                gList.Add(checkText.text);
                guessed.text = "";
                gList.Sort((x, y) => x.Length.CompareTo(y.Length));
                for (int j = 0; j < gList.Count; ++j)
                {
                    Debug.Log(gList[j]);
                    guessed.text += gList[j];
                    if (j != gList.Count - 1)
                    {
                        guessed.text += " ";
                    }
                }
            }   
        }
        checkText.text = "";
        foreach (GameObject butt in bc)
        {
            bcNow = butt.GetComponent<BtnClick>();
            bcNow.btn.interactable = true;
        }
    }
}
