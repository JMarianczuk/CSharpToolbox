using System;

namespace CSharpToolbox.ControlFlow
{
    public class Flag
    {
        public bool State { get; private set; }

        private Flag(bool state)
        {
            State = state;
        }

        public IDisposable Toggle()
        {
            return new FlagToggle(this);
        }

        public static implicit operator bool(Flag flag) => flag.State;
        public static implicit operator Flag(bool value) => new Flag(value);

        private class FlagToggle : IDisposable
        {
            private Flag _flag;

            public FlagToggle(Flag flag)
            {
                _flag = flag;
                _flag.State = !_flag.State;
            }

            public void Dispose()
            {
                if (_flag != null)
                {
                    _flag.State = !_flag.State;
                    _flag = null;
                }
            }
        }
    }
}