using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SwitchButton[] switchButtons;

    private bool isPlayerTurn = true;
    private AIController ai;

    private void Start()
    {
        ai = gameObject.AddComponent<AIController>();
        for (int i = 0; i < switchButtons.Length; i++)
        {
            int buttonIndex = i;
            switchButtons[i].button.onClick.AddListener(() => HandleButtonClick(buttonIndex));
        }
    }

    private void HandleButtonClick(int buttonIndex)
    {
        if (isPlayerTurn)
        {
            if (switchButtons[buttonIndex] != null)
            {
                switchButtons[buttonIndex].Switch(isPlayerTurn);

                if (CheckForWin(switchButtons[buttonIndex].GetCurrentSprite()))
                {
                    Debug.Log(switchButtons[buttonIndex].GetCurrentSprite().name + " wins!");
                }
                else if (IsBoardFull())
                {
                    Debug.Log("It's a draw!");
                }
                else
                {
                    isPlayerTurn = false;
                    Debug.Log("AI turn");
                    Invoke(nameof(HandleAITurn), 2f);
                }
            }
        }
    }

    private void HandleAITurn()
    {
        var randButton = ai.GenerateRandomPosition(switchButtons.Length);
        if (switchButtons[randButton] != null && switchButtons[randButton].GetCurrentSprite() != null && switchButtons[randButton].GetCurrentSprite().name == "X")
        {
            HandleAITurn();
        }
        else
        {
            switchButtons[randButton].Switch(isPlayerTurn);
            if (CheckForWin(switchButtons[randButton].GetCurrentSprite()))
            {
                Debug.Log(switchButtons[randButton].GetCurrentSprite().name + " wins!");
            }
            else if (IsBoardFull())
            {
                Debug.Log("It's a draw!");
            }
            Debug.Log("Player turn");
            isPlayerTurn = true;
        }
    }

    private bool CheckForWin(Sprite markerSprite)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (switchButtons[i * 3].GetCurrentSprite() == markerSprite &&
                switchButtons[i * 3 + 1].GetCurrentSprite() == markerSprite &&
                switchButtons[i * 3 + 2].GetCurrentSprite() == markerSprite)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (switchButtons[i].GetCurrentSprite() == markerSprite &&
                switchButtons[i + 3].GetCurrentSprite() == markerSprite &&
                switchButtons[i + 6].GetCurrentSprite() == markerSprite)
            {
                return true;
            }
        }

        // Check diagonals
        if (switchButtons[0].GetCurrentSprite() == markerSprite &&
            switchButtons[4].GetCurrentSprite() == markerSprite &&
            switchButtons[8].GetCurrentSprite() == markerSprite)
        {
            return true;
        }

        if (switchButtons[2].GetCurrentSprite() == markerSprite &&
            switchButtons[4].GetCurrentSprite() == markerSprite &&
            switchButtons[6].GetCurrentSprite() == markerSprite)
        {
            return true;
        }

        return false;
    }

    private bool IsBoardFull()
    {
        foreach (SwitchButton button in switchButtons)
        {
            if (button.GetCurrentSprite() == null)
            {
                return false;
            }
        }
        return true;
    }

    private void WinEnd(string winName)
    {
        new NotImplementedException();
    }
}
