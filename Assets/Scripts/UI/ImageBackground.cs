using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class ImageBackground : MonoBehaviour
{
    [SerializeField] private Image _imageBackground;
    [SerializeField] private float _maxScaleValue;
    [SerializeField] private float _scaleDuration;
    private Vector3 _startScaleImage;

    private void Start()
    {
        _startScaleImage = _imageBackground.transform.localScale;
        RotateImage();
        ScaleImage();

    }

    private TweenerCore<Quaternion, Vector3, QuaternionOptions> RotateImage()
    {
        return _imageBackground.transform.DORotate(GetRotateValue(), _scaleDuration, RotateMode.FastBeyond360)
                               .SetRelative()
                              .SetLoops(2,LoopType.Yoyo)
                               .SetEase(Ease.Linear)
                               .SetRecyclable()
                               .SetAutoKill()
                               .OnComplete(()=>
                               {
                                   RotateImage();
                               });
    }

    private Vector3 GetRotateValue()
    {
        return new Vector3(0, 0, Random.Range(180, 360f));
    }

    private TweenerCore<Vector3, Vector3, VectorOptions> ScaleImage()
    {
        return _imageBackground.transform.DOScale(GetScaleValue(), _scaleDuration)
                               .SetLoops(2, LoopType.Yoyo)
                               .SetEase(Ease.Linear).SetRecyclable()
                               .SetAutoKill()
                               .OnComplete(()=>
                               {
                                   ScaleImage();
                               });
    }

    private Vector3 GetScaleValue()
    {
        var _rndX = _startScaleImage.x + Random.Range(-_maxScaleValue, _maxScaleValue);
        var _rndY = _startScaleImage.y + Random.Range(-_maxScaleValue, _maxScaleValue);
        var _rndZ = _startScaleImage.z + Random.Range(-_maxScaleValue, _maxScaleValue);
        return new Vector3(_rndX, _rndY, _rndZ);
    }
}