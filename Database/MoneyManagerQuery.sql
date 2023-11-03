
CREATE DATABASE [MoneyManager]
 ON  PRIMARY 
( NAME = N'MoneyManager', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoneyManager_log', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
	