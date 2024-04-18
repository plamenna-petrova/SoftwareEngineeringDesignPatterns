<?php

interface ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName);
}

class RarCompressionStrategy implements ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName) {
        echo "The folder is compressed using the RAR approach: $compressedArchiveFileName.rar file is created\n";
    }
}

class ZipCompressionStrategy implements ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName) {
        echo "The folder is compressed using the ZIP approach: $compressedArchiveFileName.zip file is created\n";
    }
}

class CompressionContext {
    private $compressionStrategy;

    public function __construct(ICompressionStrategy $compressionStrategy) {
        $this->compressionStrategy = $compressionStrategy;
    }

    public function setCompressionStrategy(ICompressionStrategy $compressionStrategy) {
        $this->compressionStrategy = $compressionStrategy;
    }

    public function createArchive($compressedArchiveFileName) {
        $this->compressionStrategy->compressFolder($compressedArchiveFileName);
    }
}

$compressionStrategy = new ZipCompressionStrategy();

$compressionContext = new CompressionContext($compressionStrategy);
$compressionContext->createArchive("DesignPatterns");

$compressionContext->setCompressionStrategy(new RarCompressionStrategy());
$compressionContext->createArchive("DesignPatterns");
