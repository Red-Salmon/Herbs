using UnityEngine;

[CreateAssetMenu(fileName = "New Herb", menuName = "Herb")]
public class herbs : ScriptableObject
{

    public string herbName = "New Herb";
    public Sprite icon = null;
    public int waterDelta = 0;
    public int fireDelta = 0;
    public int airDelta = 0;

}
