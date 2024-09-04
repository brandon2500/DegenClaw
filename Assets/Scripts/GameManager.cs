using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public SpriteRenderer spriteRenderer;

    public float moveDistance = 0.1f;
    public float leftBound = -5f;
    public float rightBound = 5f;
    public float lowerSpeed = 2f;
    public float initialY;
    public float lowerDistance = 0.1f;
    public float totalLowerDistance = 3f;
    public float totalRaiseDistance = 3f;
    public float curLowerDistance = 0f;
    public float curRaiseDistance = 0f;
    public float raiseDistance = 0.1f;
    public float tolerance = 0.001f;


    public bool isMovingRight = true;
    public bool isStopped = false;
    public bool isLowering = false;
    public bool isRaising = false;

    public Button dropButton;

    public Sprite openClawSprite;
    public Sprite[] closedClawSprites;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
    }

    void FixedUpdate()
    {
        if (!isStopped && !isLowering)
        {
            MoveClaw();
        }
        else if (isLowering)
        {
            LowerClaw();
        }
        else if (isRaising)
        {
            RaiseClaw();
        }

    }

    public void MoveClaw()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * moveDistance);
            if (transform.position.x >= rightBound)
            {
                isMovingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveDistance);
            if (transform.position.x <= leftBound)
            {
                isMovingRight = true;
            }
        }
    }

    public void StopClaw()
    {
        isStopped = true;
        isLowering = true;
        LowerClaw();
    }

    public void LowerClaw()
    {
        if((curLowerDistance - totalLowerDistance) < tolerance)
        {
            transform.Translate(Vector2.down * lowerDistance);
            curLowerDistance += lowerDistance;
        }
        else
        {
            isLowering = false;
            curLowerDistance = 0f;
        }
    }

    public void ChangeToClosedClaw()
    {
        if (spriteRenderer != null && closedClawSprites != null && closedClawSprites.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, closedClawSprites.Length);
            spriteRenderer.sprite = closedClawSprites[randomIndex];
        }
        
    }

    public void RaiseClaw()
    {
        isLowering = false;
        isRaising = true;

        if ((curRaiseDistance - totalRaiseDistance) < tolerance)
        {
            transform.Translate(Vector2.up * raiseDistance);
            curRaiseDistance += raiseDistance;
        }
        else
        {
            isRaising = false;
            curRaiseDistance = 0f;
        }
        StartCoroutine(MoveClawAgain());
    }

    public void ResetClaw()
    {
        spriteRenderer.sprite = openClawSprite;
        RaiseClaw();
    }

    public void EmptyClaw()
    {
        spriteRenderer.sprite = openClawSprite;
    }

    public void ResetBools()
    {
        isStopped = false;
    }

    public async void BuyPack()
    {
        await BlockchainManager.Instance.BuyPack();
    }

    public async void OpenPack()
    {
        await BlockchainManager.Instance.OpenPack();
    }


    IEnumerator MoveClawAgain()
    {
        yield return new WaitForSeconds(5);
        ResetBools();
    }
}
