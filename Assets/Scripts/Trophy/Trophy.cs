﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Import SceneManager

public class Trophy : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Win");
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            StartCoroutine(LoadNextLevelAfterDelay(5f));
        }
    }

    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Kiểm tra nếu còn level tiếp theo thì load, nếu không thì thoát game
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Dừng game trong Unity Editor
#else
            Application.Quit(); // Thoát game khi build
#endif
        }
    }
}
