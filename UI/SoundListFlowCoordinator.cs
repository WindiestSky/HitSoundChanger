﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMUI;
using BeatSaberMarkupLanguage;
namespace HitSoundChanger.UI
{
    class SoundListFlowCoordinator : FlowCoordinator
    {
        private SoundListView _soundListView;
        public void Awake()
        {
            if (_soundListView == null)
            {
                _soundListView = BeatSaberUI.CreateViewController<SoundListView>();

            }
        }
        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {

                    SetTitle("Hit Sounds");
                    showBackButton = true;
                    ProvideInitialViewControllers(_soundListView);
                }
                if (addedToHierarchy)
                {

                }

            }
            catch (Exception ex)
            {
                Utilities.Logging.Log.Error(ex);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            // dismiss ourselves
            var mainFlow = BeatSaberMarkupLanguage.BeatSaberUI.MainFlowCoordinator;
            mainFlow.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
        }
    }
}
