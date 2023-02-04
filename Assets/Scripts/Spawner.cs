using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _rndXMinPosition;
    [SerializeField] private float _rndXMaxPosition;

    private WaitForSeconds _waitForSeconds;
    private Coin _spawnedCoin;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            _spawnedCoin = Instantiate(_coin, new Vector2(Random.Range(_rndXMinPosition, _rndXMaxPosition), transform.position.y), Quaternion.identity);

            yield return _waitForSeconds;
        }
    }
}
