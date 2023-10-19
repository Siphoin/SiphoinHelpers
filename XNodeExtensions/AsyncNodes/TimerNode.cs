using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.AsyncNodes
{
    [NodeTint("#5c2b3f")]
    public class TimerNode : AsyncNodeWithSeconds
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private bool _tickOnStart = true;

        [SerializeField] private TimerType _type;

        [Output, SerializeField] private TimerNode _someTimer;

        public override object GetValue(NodePort port)
        {
            return this;
        }

        public override void Execute()
        {
            bool tickOnStart = _tickOnStart;

            var inputTickOnStart = GetInputPort(nameof(_tickOnStart));

            if (inputTickOnStart.Connection != null)
            {
                tickOnStart = GetDataFromPort<bool>(nameof(_tickOnStart));
            }

            if (tickOnStart)
            {
                Start();
            }
        }

        private async UniTask TimeOut (float seconds)
        {
            if (_type == TimerType.One)
            {
                await Delay(seconds);

                ExecuteInTimer();

                Stop();
            }

            else if (_type == TimerType.Repeat)
            {
                while (true)
                {
                    await Delay(seconds);

                    ExecuteInTimer();
                }
            }
        }

        private void ExecuteInTimer()
        {
            foreach (var item in GetExitPort().GetConnections())
            {
                ExecuteNodesFromPort(item);
            }
        }

        public void Stop ()
        {
            StopTask();
        }

        public void Start ()
        {
            Stop();

            base.Execute();

            float seconds = GetSeconds();

            TimeOut(seconds).Forget();
        }

        private async UniTask Delay (float seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

            await UniTask.Delay(timeSpan, cancellationToken: TokenSource.Token);
        }
    }
}
