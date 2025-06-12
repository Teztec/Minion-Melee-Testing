using UnityEngine;

public class Buffs : MonoBehaviour
{
    public BuffType type;
    public int amount;
    public Timing timing;
    public int duration;

}
public enum BuffType
{
    attackChange,
    armor,
    speedChange,
    heal
}
public enum Timing
{
    immediate,
    nextRound,
    delayed
}
