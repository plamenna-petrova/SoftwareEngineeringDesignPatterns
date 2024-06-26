<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInit07515dbc7fc01e44d8ea7564e420a1cc
{
    public static $prefixLengthsPsr4 = array (
        'B' => 
        array (
            'BehavioralPatterns\\Command\\FastFoodRestaurant\\Models\\' => 53,
            'BehavioralPatterns\\Command\\FastFoodRestaurant\\Commands\\' => 55,
            'BehavioralPatterns\\Command\\FastFoodRestaurant\\' => 46,
        ),
    );

    public static $prefixDirsPsr4 = array (
        'BehavioralPatterns\\Command\\FastFoodRestaurant\\Models\\' => 
        array (
            0 => __DIR__ . '/../..' . '/Models',
        ),
        'BehavioralPatterns\\Command\\FastFoodRestaurant\\Commands\\' => 
        array (
            0 => __DIR__ . '/../..' . '/Commands',
        ),
        'BehavioralPatterns\\Command\\FastFoodRestaurant\\' => 
        array (
            0 => __DIR__ . '/../..' . '/',
        ),
    );

    public static $classMap = array (
        'Composer\\InstalledVersions' => __DIR__ . '/..' . '/composer/InstalledVersions.php',
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->prefixLengthsPsr4 = ComposerStaticInit07515dbc7fc01e44d8ea7564e420a1cc::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInit07515dbc7fc01e44d8ea7564e420a1cc::$prefixDirsPsr4;
            $loader->classMap = ComposerStaticInit07515dbc7fc01e44d8ea7564e420a1cc::$classMap;

        }, null, ClassLoader::class);
    }
}
