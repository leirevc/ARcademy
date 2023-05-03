using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ImageTrackerManager : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    private VideoPlayer videoPlayer;
    private bool isImageTrackable; //para indicar si imagen esta rastreada

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    
    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventData)
    {
        //Detectar imagen y reproducir el video
        foreach ( var trackedImage in eventData.added)
        {
            videoPlayer = trackedImage.GetComponentInChildren<VideoPlayer>();
            videoPlayer.Play();
        }
        //Detectar cuando la imagen sale de camara
        foreach ( var trackedImage in eventData.updated)
        {
            //Evento llamado para cada frame del video
            if (trackedImage.trackingState == TrackingState.Tracking) //imagen rastreada
            {
                if (!isImageTrackable) //si no estaba rastreada, comienza el video
                {
                    isImageTrackable = true;
                    videoPlayer.gameObject.SetActive(true);
                    videoPlayer.Play();
                }
            }
            else if (trackedImage.trackingState == TrackingState.Limited) //imagen no rastreada
            {
                if (!isImageTrackable) //desactivar video cuando deja de rastrearse
                {
                    isImageTrackable = false;
                    videoPlayer.gameObject.SetActive(false);
                    videoPlayer.Pause();
                }
            }
        }

    }

    //volvemos al menu
    public void Return()
    {
        //a que escena se accede segun su index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
