using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public static int Lives;
    public int StartMoney = 500;
    public int StartLives = 20;
    public static int rounds;

    void Start()
    {
        Money = StartMoney;
        Lives = StartLives;
        rounds = 0;
    }
}
