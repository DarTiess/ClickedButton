using System;
using UnityEngine;
using YG;

namespace LeaderBoard
{
    public class LeaderBoardView : MonoBehaviour
    {
        [SerializeField]private LeaderboardYG _leaderboardYg;

        private void Start()
        {
            UpdateLb();
        }

        public void UpdateLb()
        {
            _leaderboardYg.UpdateLB();
        }
    }
}