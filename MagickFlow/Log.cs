using Cake.Core.Diagnostics;

namespace MagickFlow
{
    public class Log : ICakeLog
    {
        public Log()
        {
        }

        public Verbosity Verbosity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override bool Equals(object obj)
        {
            var log = obj as Log;
            return log != null &&
                   Verbosity == log.Verbosity;
        }

        public override int GetHashCode()
        {
            return 588451578 + Verbosity.GetHashCode();
        }

        public void Write(Verbosity verbosity, LogLevel level, string format, params object[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}
