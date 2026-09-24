using System.Collections;
using Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class PlayerHealthPlayModeTests
    {
        private GameObject _playerObject;
        private PlayerHealth _playerHealth;

        [SetUp]
        public void SetUp()
        {
            _playerObject = new GameObject("Player");
            _playerHealth = _playerObject.AddComponent<PlayerHealth>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_playerObject);
        }

        // Ejemplo 4: test PlayMode sobre un componente real (Awake ya se ejecuto)
        [Test]
        public void TakeDamage_ReducesCurrentHealth()
        {
            _playerHealth.TakeDamage(30);

            Assert.AreEqual(70, _playerHealth.CurrentHealth);
        }

        // Ejemplo 5: UnityTest con corrutina, esperando frames y comprobando un evento
        [UnityTest]
        public IEnumerator TakeDamage_WhenHealthReachesZero_FiresDiedEvent()
        {
            bool diedEventFired = false;
            _playerHealth.Died += () => diedEventFired = true;

            _playerHealth.TakeDamage(100);

            yield return null;

            Assert.IsTrue(_playerHealth.IsDead);
            Assert.IsTrue(diedEventFired);
        }
    }
}
