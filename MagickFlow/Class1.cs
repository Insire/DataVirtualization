using Cake.Common.Solution;
using Cake.Core;

namespace MagickFlow
{
    public class Class1
    {
        public void Do()
        {
            var platform = new CakePlatform();
            var runtime = new CakeRuntime();
            var log = new Log();
            var environment = new CakeEnvironment(platform, runtime, log);
            var fileSystem = new FileSystem();
            var parser = new SolutionParser(fileSystem, environment);
        }
    }
}
