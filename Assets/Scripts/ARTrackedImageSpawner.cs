using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedImageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cr7Prefab;
    [SerializeField] private AudioSource siu;
    [SerializeField] private AudioClip audioClip;
    private GameObject cr7;
    private ARTrackedImageManager aRTrackedImageMager;

    void OnEnable()
    {
        aRTrackedImageMager = GetComponent<ARTrackedImageManager>();
        aRTrackedImageMager.trackablesChanged.AddListener(OnImageChanged);
    }
    
    private void OnImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            cr7 = Instantiate(cr7Prefab, newImage.transform);

            cr7.transform.localPosition = new Vector3(0, 0.1f, 0);
            cr7.transform.localRotation = Quaternion.identity;
            siu.PlayOneShot(audioClip);
        }
    }
}
