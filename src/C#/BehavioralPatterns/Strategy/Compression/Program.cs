using System;

namespace Compression
{
    public interface ICompressionStrategy
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    public class RarCompressionStrategy : ICompressionStrategy
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine($"The folder is compressed using the RAR approach: {compressedArchiveFileName}.rar file is created");
        }
    }

    public class ZipCompressionStrategy : ICompressionStrategy
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine($"The folder is compressed using the ZIP approach: {compressedArchiveFileName}.zip file is created");
        }
    }

    public class CompressionContext
    {
        private ICompressionStrategy compressionStrategy;

        public CompressionContext(ICompressionStrategy compressionStrategy)
        {
            this.compressionStrategy = compressionStrategy;
        }

        public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
        {
            this.compressionStrategy = compressionStrategy;
        }

        public void CreateArchive(string compressedArchiveFileName)
        {
            compressionStrategy.CompressFolder(compressedArchiveFileName);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ICompressionStrategy compressionStrategy = new ZipCompressionStrategy();

            CompressionContext compressionContext = new CompressionContext(compressionStrategy);
            compressionContext.CreateArchive("DesignPatterns");

            compressionContext.SetCompressionStrategy(new RarCompressionStrategy());
            compressionContext.CreateArchive("DesignPatterns");
        }
    }
}
