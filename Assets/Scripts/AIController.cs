using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    //TODO: Add AI logic for medium and hard difficulties
    public int GenerateRandomPosition(int maxButtons)
    {
        return Random.Range(0,maxButtons);
    }
}
