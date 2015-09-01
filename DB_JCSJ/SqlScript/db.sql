USE [master]
/****** Object:  Database [@DBName]    Script Date: 08/23/2015 20:37:50 ******/
CREATE DATABASE [@DBName] ON  PRIMARY 
( NAME = '@DBName', FILENAME = N'@DBPath@DBName.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = '@DBName_log', FILENAME = N'@DBPath@DBName_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)