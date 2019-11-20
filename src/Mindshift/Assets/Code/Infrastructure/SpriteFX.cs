using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Common;
using Assets.Code.Extensions;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class SpriteFX : MonoBehaviour
  {
    public bool Looping;
    public float FPS;
    public float StartDelay = 0;
    public bool PlayOnAwake = false;
    public bool LeaveLastFrame = false;
    public bool IgnorePlayUntilFinished = false;
    public bool LeaveInitialSprite = false;
    public float LastFrameFadeTime = -1;
    public float LastFrameFadeDelay = 0;
    public Sprite[] LoopingSprites;
    public Sprite[] OnSprites;
    public Sprite[] OffSprites;

    private IEnumerator _doPlayOnce;
    private Coroutine _playOnceCoroutine;
    private Coroutine _fadeCoroutine;

    public SpriteRenderer SpriteRenderer;
    public bool Solo;

    private bool _shouldPlayLooping = false;
    private List<SpriteFX> _withChildren;
    private SpriteFX _lastChild;

    public bool IsPlaying { get; private set; }

    public virtual int Order { get => SpriteRenderer.sortingOrder; set => SpriteRenderer.sortingOrder = value; }
    public virtual Color Color { get => SpriteRenderer.color; set => SpriteRenderer.color = value; }

    public void Update() => UpdateLooping();

    protected void Awake()
    {
      if (SpriteRenderer && !PlayOnAwake && !LeaveInitialSprite)
        SpriteRenderer.sprite = null;

      _withChildren = GetComponentsInChildren<SpriteFX>()
        .Where(x => x == this || !x.Solo)
        .ToList();

      _lastChild = _withChildren.LastOrDefault();
    }

    protected void Start()
    {
      //if (PlayOnAwake)
      //  Play(transform.position, true);
    }

    protected void OnEnable()
    {
      if (SpriteRenderer == null)
        SpriteRenderer = GetComponent<SpriteRenderer>();

      if (PlayOnAwake)
        Play(transform.position, true);
    }

    public void PlayWithChildren(Action afterPlayed = null) =>
      PlayWithChildren(transform.position, true, afterPlayed);

    public void PlayWithChildren(Vector2 at, bool isWorldPos, Action afterPlayed = null)
    {
      foreach (SpriteFX child in _withChildren)
      {
        if (child == _lastChild)
          child?.Play(() => afterPlayed?.Invoke());
        else
          child?.Play();
      }
    }

    public void Play(Vector2 position, bool isWorldPos, Action afterPlayed = null)
    {
      if (IgnorePlayUntilFinished && IsPlaying)
        return;

      if (isWorldPos)
        transform.position = position;
      else
        transform.localPosition = position;

      Play(afterPlayed);
    }

    public void Play(Action afterPlayed = null)
    {
      if (IgnorePlayUntilFinished && IsPlaying)
        return;

      Delay.For(StartDelay, this, andThen: () =>
      {
        if (!OnSprites.IsNullOrEmpty())
          StartPlaying(afterPlayed);
        else if (Looping)
          _shouldPlayLooping = true;
      });
    }

    private void StartPlaying(Action afterPlayed)
    {
      _doPlayOnce = DoPlayOnce(OnSprites, () =>
      {
        if (Looping)
          _shouldPlayLooping = true;

        afterPlayed?.Invoke();
      },
        leaveLastFrame: LeaveLastFrame || FollowedByLooping()); // Leave last frame also if OnSprites should be followed by looping sprites.

      _playOnceCoroutine = StartCoroutine(_doPlayOnce);
    }

    private bool FollowedByLooping() =>
      Looping && !LoopingSprites.IsNullOrEmpty();

    public void StopLoopingWithChildren(Action afterPlayed = null)
    {
      foreach (SpriteFX child in _withChildren)
      {
        if (child == _lastChild)
          child?.StopLooping(afterPlayed);
        else
          child?.StopLooping();
      }
    }

    public void Terminate()
    {
      TerminatePlayingOnce();
      TerminateFading();

      _shouldPlayLooping = false;
      SetSprite(null);
    }

    private void StopLooping(Action afterPlayed = null)
    {
      _shouldPlayLooping = false;
      PlayOffSprites(afterPlayed);
    }

    private void TerminateFading()
    {
      if (_fadeCoroutine == null)
        return;

      StopCoroutine(_fadeCoroutine);
      _fadeCoroutine = null;
    }

    private void TerminatePlayingOnce()
    {
      if (_playOnceCoroutine == null)
        return;

      StopCoroutine(_playOnceCoroutine);
      _playOnceCoroutine = null;
      _doPlayOnce = null;
    }

    protected virtual void SetSprite(Sprite sprite) => SpriteRenderer.sprite = sprite;

    private void UpdateLooping()
    {
      if (LoopingSprites.IsNullOrEmpty())
        return;

      if (_shouldPlayLooping)
      {
        var index = (int)(Contexts.sharedInstance.game.Time.InGameTime * FPS);
        index = index % LoopingSprites.Length;
        SetSprite(LoopingSprites[index]);

        IsPlaying = true;
      }
    }

    private void PlayOffSprites(Action afterPlayed = null)
    {
      if (OffSprites.IsNullOrEmpty())
        return;

      StartCoroutine(DoPlayOnce(OffSprites, afterPlayed, leaveLastFrame: LeaveLastFrame));
    }

    private IEnumerator DoPlayOnce(Sprite[] sprites, Action afterPlayed = null, bool leaveLastFrame = false)
    {
      IsPlaying = true;

      foreach (Sprite sprite in sprites)
      {
        SetSprite(sprite);
        yield return new WaitForSeconds(1f / FPS);
      }

      if (!leaveLastFrame)
        SetSprite(null);

      if (LastFrameFadeTime > 0)
        _fadeCoroutine = StartCoroutine(Fade(LastFrameFadeTime));
      else
        IsPlaying = false;

      afterPlayed?.Invoke();
    }

    private IEnumerator Fade(float fadeTime)
    {
      IsPlaying = true;
      yield return new WaitForSeconds(LastFrameFadeDelay);
      while (Color.a > float.Epsilon)
      {
        Color = Color.Alpha(Color.a - 0.01f / fadeTime);
        yield return new WaitForSeconds(0.01f);
      }

      IsPlaying = false;
      SetSprite(null);
      Color = Color.Alpha(1);
    }
  }
}
