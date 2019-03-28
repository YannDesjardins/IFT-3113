﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Thalass
{
    public class BatteryManager : MonoBehaviour, IObserver<Entities.Element.Values>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        private void GoToUpgradeSubmarineScene()
        {
            SceneManager.LoadScene("Upgrade_Submarine", LoadSceneMode.Additive);
        }

        public void OnNext(Entities.Element.Values value)
        {
            if (value.Current <= 0)
            {
                Debug.Log("Battery empty: Emergency exit");
                Invoke("GoToUpgradeSubmarineScene", 4.0f);
            }
        }
    }

}