using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pieceType
{
    Normal = 0,
    Gun = 1,
    Other = 2,
    Otherr = 3,
}

public class playerMana : MonoBehaviour
{
    public int team;
    public int currentX;
    public int currentY;
    public pieceType type;

    private Vector3 desiredPosition;
    // private Vector3 desiredScale:
}
