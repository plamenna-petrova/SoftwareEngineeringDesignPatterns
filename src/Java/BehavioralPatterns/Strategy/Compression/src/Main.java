interface ICompressionStrategy {
    void compressFolder(String compressedArchiveFileName);
}

class RarCompressionStrategy implements ICompressionStrategy {
    @Override
    public void compressFolder(String compressedArchiveFileName) {
        System.out.println("The folder is compressed using the RAR approach: " + compressedArchiveFileName + ".rar file is created");
    }
}

class ZipCompressionStrategy implements ICompressionStrategy {
    @Override
    public void compressFolder(String compressedArchiveFileName) {
        System.out.println("The folder is compressed using the ZIP approach: " + compressedArchiveFileName + ".zip file is created");
    }
}

class CompressionContext {
    private ICompressionStrategy compressionStrategy;

    public CompressionContext(ICompressionStrategy compressionStrategy) {
        this.compressionStrategy = compressionStrategy;
    }

    public void setCompressionStrategy(ICompressionStrategy compressionStrategy) {
        this.compressionStrategy = compressionStrategy;
    }

    public void createArchive(String compressedArchiveFileName) {
        compressionStrategy.compressFolder(compressedArchiveFileName);
    }
}

public class Main {
    public static void main(String[] args) {
        ICompressionStrategy compressionStrategy = new ZipCompressionStrategy();

        CompressionContext compressionContext = new CompressionContext(compressionStrategy);
        compressionContext.createArchive("DesignPatterns");

        compressionContext.setCompressionStrategy(new RarCompressionStrategy());
        compressionContext.createArchive("DesignPatterns");
    }
}