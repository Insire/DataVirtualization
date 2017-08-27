using Cake.Core.IO;

namespace MagickFlow
{
    public class FileSystem : IFileSystem
    {
        public FileSystem()
        {
        }

        public IDirectory GetDirectory(DirectoryPath path)
        {
            throw new System.NotImplementedException();
        }

        public IFile GetFile(FilePath path)
        {
            throw new System.NotImplementedException();
        }
    }
}
