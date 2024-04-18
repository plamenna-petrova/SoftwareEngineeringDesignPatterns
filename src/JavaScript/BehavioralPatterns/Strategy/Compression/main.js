
// Define ICompressionStrategy interface
class CompressionStrategy {
    compressFolder(compressedArchiveFileName) {}
}

class RarCompressionStrategy extends CompressionStrategy {
    compressFolder(compressedArchiveFileName) {
        console.log(`The folder is compressed using the RAR approach: ${compressedArchiveFileName}.rar file is created`);
    }
}

class ZipCompressionStrategy extends CompressionStrategy {
    compressFolder(compressedArchiveFileName) {
        console.log(`The folder is compressed using the ZIP approach: ${compressedArchiveFileName}.zip file is created`);
    }
}

class CompressionContext {
    constructor(compressionStrategy) {
        this.compressionStrategy = compressionStrategy;
    }

    setCompressionStrategy(compressionStrategy) {
        this.compressionStrategy = compressionStrategy;
    }

    createArchive(compressedArchiveFileName) {
        this.compressionStrategy.compressFolder(compressedArchiveFileName);
    }
}

const compressionStrategy = new ZipCompressionStrategy();
const compressionContext = new CompressionContext(compressionStrategy);
compressionContext.createArchive("DesignPatterns");

compressionContext.setCompressionStrategy(new RarCompressionStrategy());
compressionContext.createArchive("DesignPatterns");