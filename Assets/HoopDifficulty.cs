using UnityEngine;
using UnityEngine.UI;

public class HoopDifficulty : MonoBehaviour
{
    public HoopMovement hoopMovement;
    public Transform hoop;
    public Transform net;
    public Slider difficultySlider;

    private float baseSpeed;
    private float baseRange;
    private Vector3 netOffset;

    void Start()
    {
        baseSpeed = hoopMovement.speed;
        baseRange = hoopMovement.range;
        netOffset = net.position - hoop.position;
        difficultySlider.onValueChanged.AddListener(UpdateDifficulty);
        UpdateDifficulty(difficultySlider.value);
    }

    void UpdateDifficulty(float value)
    {
        hoopMovement.speed = baseSpeed * value;
        hoopMovement.range = baseRange * value;
        net.position = hoop.position + netOffset;
    }
}