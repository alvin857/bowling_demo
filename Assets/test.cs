using UnityEngine;

public class test : MonoBehaviour {
    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * 5f * Time.deltaTime);
    }
}
