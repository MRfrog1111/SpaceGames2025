using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DialogueSystem : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource; // Выберите контроллер, с которым хотите взаимодействовать
    public SteamVR_Action_Boolean selectAction; // Входной сигнал для выбора в диалоговой системе

    private void Update()
    {
        if (selectAction[inputSource].stateDown)
        {
            // Обработка выбора в диалоговой системе
            // Например, можно активировать выбранный ответ или продолжить диалог в зависимости от выбора игрока
            Debug.Log("Выбор сделан!");
        }
    }
}