using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _imageManager;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _videoScreenPrefab;

    private GameObject _videoScreenInstance;

    private void Awake()
    {
        _imageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (trackedImage.referenceImage.name == "YourImageName")
            {
                PlayVideo(trackedImage);
            }
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            if (_videoScreenInstance != null)
            {
                _videoScreenInstance.SetActive(false);
            }
        }
    }

    private void PlayVideo(ARTrackedImage trackedImage)
    {
        _videoScreenInstance = Instantiate(_videoScreenPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        _videoScreenInstance.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);
        _videoScreenInstance.transform.parent = trackedImage.transform;

        _videoPlayer.Play();
    }
}
