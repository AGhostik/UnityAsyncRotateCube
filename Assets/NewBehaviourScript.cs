using System.Threading.Tasks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Transform cubeTransform;

    private Quaternion _rotation;

    private void Awake()
    {
        _rotation = Quaternion.Euler(0, 0.3f, 0);
    }

    public async void Fun()
    {
        var delayMilliseconds = 3000f;
        Debug.Log("START!!!");

        var time = Time.time;

        while (delayMilliseconds > 0)
        {
            cubeTransform.rotation *= _rotation;
            var deltatime = await WaitForFrame();
            delayMilliseconds -= deltatime;
        }
        
        Debug.Log($"END!!! time elapsed - {Time.time - time}");
    }

    private static async Task<float> WaitForFrame()
    {
        var frames = Time.frameCount;
        
        while (Time.frameCount == frames)
            await Task.Yield();

        return Time.deltaTime * 1000;
    }
}
