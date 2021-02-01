using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSound : NonPersistentSingleton<RewardSound> {
  [Header("Configuration")]
  public int bufferSize = 10;
  public Vector2 volumeRange = new Vector2(0.7f, 1);

  [Header("Information")]
  public int[] buffer;
  public int current;

  [Header("Initialization")]
  public AudioClip[] clips;
  public AudioSource speaker;

  void Start () {
    buffer = new int[bufferSize];
  }

  public void Play () {
    int infinityGuard = 100;
    bool found = false;
    int b = 0;
    while (infinityGuard > 0 && !found) {
      infinityGuard--;
      b = Random.Range(0, clips.Length);
      found = true;
      for (int i=0; i<bufferSize; i++) {
        if (b == buffer[i]) {
          found = false;
        }
      }
    }
    current = (current + 1) % bufferSize;
    buffer[current] = b;
    speaker.volume = Random.Range(volumeRange.x, volumeRange.y);
    speaker.PlayOneShot(clips[b]);
  }
}
