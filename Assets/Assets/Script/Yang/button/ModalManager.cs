using System;
using UnityEngine;

public class ModalWindow : MonoBehaviour
{
    public static ModalWindow Instance { get; private set; }
    ModalWindow _current;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Register(ModalWindow mw)
    {
        // 关闭之前的
        if (_current != null && _current != mw)
            _current.Close();

        _current = mw;
    }

    private void Close()
    {
        throw new NotImplementedException();
    }

    public void Unregister(ModalWindow mw)
    {
        if (_current == mw)
            _current = null;
    }
}
