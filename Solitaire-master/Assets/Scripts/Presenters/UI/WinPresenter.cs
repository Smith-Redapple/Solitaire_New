using DG.Tweening;
using Solitaire.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class WinPresenter : OrientationAwarePresenter
    {
        [Inject] readonly Game _game;
        [Inject] readonly GamePopup _gamePopup;
        [Inject] readonly GameState _gameState;

        protected override void OnOrientationChanged(bool isLandscape)
        {

        }

        protected override void Start()
        {
            base.Start();
            _gameState.State.Where(state => state == Game.State.Win).Subscribe(_ =>
                OnPopupShow()).AddTo(this);
        }

        private void OnPopupShow()
        {
            if (_game.gameMode == Game.GameMode.SinglePlayer)
            {
                Debug.Log("Single Player Score");
            }
            else Debug.Log("Tournament Score");
        }
    }
}