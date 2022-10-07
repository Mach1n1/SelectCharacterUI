using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _AnimationPrefab;
    [SerializeField] private List<string> _characterName;
    [SerializeField] private List<GameObject> _CheckIcon;
    private GameObject _OldAnimation;
    [SerializeField] private Transform _CanvasParent;
    [SerializeField] private TextMeshProUGUI _CharacterNameUI;
    private static int index;
    private int currentIndex;

    private void Start()
    {
        Instantiate(_AnimationPrefab[0], _CanvasParent);
        _CharacterNameUI.text = _characterName[0];
    }

    public void StartCharacterAnimation(int number)
    {
        //it's not the best search, but that's the only way I can
        _OldAnimation = GameObject.FindGameObjectWithTag("DestroyCharacter");
        if (_OldAnimation != null) Destroy(_OldAnimation);
        Instantiate(_AnimationPrefab[number], _CanvasParent);
        _CharacterNameUI.text = _characterName[number];
        index = number;
    }

    public void StartStandAnimation(int number)
    {
        _OldAnimation = GameObject.FindGameObjectWithTag("DestroyStand");
        if (_OldAnimation != null) Destroy(_OldAnimation);
        index = number;
        Instantiate(_AnimationPrefab[number], _CanvasParent);
    }

    public void CheckIconActive()
    {
        _CheckIcon[index].SetActive(true);
        if(index != currentIndex)
            _CheckIcon[currentIndex].SetActive(false);
        currentIndex = index;
    }
}