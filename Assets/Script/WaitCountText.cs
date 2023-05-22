using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitCountText : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void UpdateWaitText(int value)
    {
        text.text = "Wait: " + value + " second";
    }

    public void UpdateCountdownText(int value)
    {
        text.text = "Game dimulai dalam: " + value + " second";
    }
}
