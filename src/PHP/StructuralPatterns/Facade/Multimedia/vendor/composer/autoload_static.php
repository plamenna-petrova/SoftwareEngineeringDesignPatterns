<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInitbbdb68685960557c2448a288d9653811
{
    public static $prefixLengthsPsr4 = array (
        'S' => 
        array (
            'StructuralPatterns\\Facade\\Multimedia\\SubSystems\\' => 48,
            'StructuralPatterns\\Facade\\Multimedia\\Facade\\' => 44,
        ),
    );

    public static $prefixDirsPsr4 = array (
        'StructuralPatterns\\Facade\\Multimedia\\SubSystems\\' => 
        array (
            0 => __DIR__ . '/../..' . '/SubSystems',
        ),
        'StructuralPatterns\\Facade\\Multimedia\\Facade\\' => 
        array (
            0 => __DIR__ . '/../..' . '/Facade',
        ),
    );

    public static $classMap = array (
        'Composer\\InstalledVersions' => __DIR__ . '/..' . '/composer/InstalledVersions.php',
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->prefixLengthsPsr4 = ComposerStaticInitbbdb68685960557c2448a288d9653811::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInitbbdb68685960557c2448a288d9653811::$prefixDirsPsr4;
            $loader->classMap = ComposerStaticInitbbdb68685960557c2448a288d9653811::$classMap;

        }, null, ClassLoader::class);
    }
}
