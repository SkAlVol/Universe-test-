using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public bool IsStarted { get; private set; }

    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private Text resultTxt;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (var btn in buttons)
            btn.interactable = false;
        
        resultTxt.gameObjec.SetActive(false);
    }

    public void StartGame()
    {
        IsStarted = true;

        foreach (var btn in buttons)
            btn.interactable = true;
    }

    public void SendChoose(int choose)
    {
        FirebaseController.Instance.SendChoose(choose);

    }

    public void SetResult(bool win)
    {
        IsStarted = false;
        resultTxt.gameObject.SetActive(true);
        resultTxt = win ? "You won" : "You lost";
    }
}
