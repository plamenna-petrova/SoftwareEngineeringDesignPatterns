<?php

interface ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName);
}

class RarCompressionStrategy implements ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName): void
    {
        echo "The folder is compressed using the RAR approach: $compressedArchiveFileName.rar file is created\n";
    }
}

class ZipCompressionStrategy implements ICompressionStrategy {
    public function compressFolder($compressedArchiveFileName): void
    {
        echo "The folder is compressed using the ZIP approach: $compressedArchiveFileName.zip file is created\n";
    }
}

class CompressionContext {
    private ICompressionStrategy $compressionStrategy;

    public function __construct(ICompressionStrategy $compressionStrategy) {
        $this->compressionStrategy = $compressionStrategy;
    }

    public function setCompressionStrategy(ICompressionStrategy $compressionStrategy): void
    {
        $this->compressionStrategy = $compressionStrategy;
    }

    public function createArchive($compressedArchiveFileName): void
    {
        $this->compressionStrategy->compressFolder($compressedArchiveFileName);
    }
}

$compressionStrategy = new ZipCompressionStrategy();

$compressionContext = new CompressionContext($compressionStrategy);
$compressionContext->createArchive("DesignPatterns");

$compressionContext->setCompressionStrategy(new RarCompressionStrategy());
$compressionContext->createArchive("DesignPatterns");
