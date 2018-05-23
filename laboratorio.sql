-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 23-05-2018 a las 01:26:48
-- Versión del servidor: 5.7.21
-- Versión de PHP: 7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `laboratorio`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `laboratorio`
--

DROP TABLE IF EXISTS `laboratorio`;
CREATE TABLE IF NOT EXISTS `laboratorio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(23) NOT NULL,
  `name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `encrypted_password` varchar(80) NOT NULL,
  `salt` varchar(10) NOT NULL,
  `mensaje` varchar(200) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `fotografia_direccion` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=75 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `laboratorio`
--

INSERT INTO `laboratorio` (`id`, `unique_id`, `name`, `email`, `encrypted_password`, `salt`, `mensaje`, `created_at`, `updated_at`, `fotografia_direccion`) VALUES
(55, '5afb2715494e61.34164909', 'Brandon Rivera Godines', 'branricona@hotmail.com', 'owVy5jvooRFe5og7Aud2ZK6u4As2NTM1MjAzMTk5', '6535203199', '', '2018-05-15 13:29:41', NULL, NULL),
(56, '5afce9885a2b58.30475777', 'Edith', 'edith@gmail.com', '0LFkIn5E2zNs1LSIDP+/VJ0DiZRmYmYwYjQxM2Fm', 'fbf0b413af', '', '2018-05-16 21:31:36', NULL, NULL),
(57, '5afcea416d2d98.70049006', 'Edith IÃ±iguez Gonzalez', 'inigueze53@gmail.com', '19N/LWbsshz+ME5utu1sZZl2TYtjNWMxOTVmZjgy', 'c5c195ff82', '', '2018-05-16 21:34:41', NULL, NULL),
(58, '5afe3d4793aa44.39808886', 'pancho', 'pancho@gmail.com', 'uWH0KZcTF2usgAQTBgtB8hTFVNk1MWU1N2M5NGJm', '51e57c94bf', 'mouse', '2018-05-17 21:41:11', NULL, 'http://192.168.0.5/laboratorio/products/uploads/73.png'),
(59, '5afe48f1b4b421.04825766', 'gonzalo', 'gonzalo@gmail.com', 'tKpymn2njIvimrtQM4xmNo9QoGozYjU2NjQ1YmQ5', '3b56645bd9', '', '2018-05-17 22:30:57', NULL, NULL),
(60, '5afe49483c2649.82615969', 'perla', 'perla@gmail.com', '/c4SKg/afEEtC9vAoal7b01QEDk4ZmU4MWJmMDY2', '8fe81bf066', '', '2018-05-17 22:32:24', NULL, NULL),
(61, '5afe4b097597a8.22185549', 'lelo', 'lelo@gmail.com', 'NYs0fhm+6E2t0Xr8QEOYhjrdOIEwOGE1YmQzZGYx', '08a5bd3df1', '', '2018-05-17 22:39:53', NULL, NULL),
(62, '5afe4b40f08696.46510528', 'lulu', 'lulu@gmail.com', 'vhYLvD6RpkOSnBOGddBvwoJ2EWpmMzQyZWVmYjli', 'f342eefb9b', '', '2018-05-17 22:40:48', NULL, NULL),
(63, '5b00845b6a13c4.67391273', 'bebe', 'bebe@gmail.com', 'uSM/a2A3N8CxmGhWVEz/z7AfC31lMmQzYzNmMjZh', 'e2d3c3f26a', 'prueba', '2018-05-19 15:08:59', NULL, 'http://192.168.0.5/laboratorio/products/uploads/73.png'),
(64, '5b009497a13e98.72140297', 'bobo', 'bobo@gmail.com', 'GiK2calKQgyhVDXWH42GpLE+hjQ1MGYwNzZlOTYx', '50f076e961', '', '2018-05-19 16:18:15', NULL, NULL),
(65, '5b0097fbba0f68.55380894', 'bibi', 'bibi@gmail.com', 'PLarDFlKgNxmUFY7sdjK9EDlUhU0NzQ1YmYwZjU1', '4745bf0f55', '', '2018-05-19 16:32:43', NULL, NULL),
(66, '5b009840cd0993.33871887', 'baba', 'baba@gmail.com', '5pj0neW0ZtpC5JegfxYrLGksLbYyMzg0ZTc1MjIz', '2384e75223', 'Envio de prueba', '2018-05-19 16:33:52', NULL, 'http://192.168.0.5/laboratorio/products/uploads/73.png'),
(67, '5b0098d5c15ee3.38275257', 'bubu', 'bubu@gmail.com', 'KgbbtGqYYtWqkQHxcjYKfJhQnbMwNzQ1ZjkyYzJj', '0745f92c2c', '', '2018-05-19 16:36:21', NULL, NULL),
(68, '5b009994c8a232.52632657', 'lala', 'lala@gmail.com', '7P5YBPeICp+VM+naZx+airE6eQtjZWU3NjAxZGMw', 'cee7601dc0', '', '2018-05-19 16:39:32', NULL, NULL),
(69, '5b009d41f2c7e5.90159557', 'lele', 'lele@gmail.com', 'EWZ3KJNQt00WQnwBeKuX4HwSYVhjNDI1YzY3MDI0', 'c425c67024', '', '2018-05-19 16:55:13', NULL, NULL),
(70, '5b009e1f5e8aa3.46793855', 'lolo', 'lolo@gmai.com', 'IYZ242lE55taZxVqEjfgEUbtT1AzYjdlM2Y0MmJh', '3b7e3f42ba', '', '2018-05-19 16:58:55', NULL, NULL),
(71, '5b009e70ab21d8.51895566', 'lili', 'lil@gmai.com', 'wjbYtKVIpM9KGDsri+okis9Wf1w3ZWUzMzg1MTFi', '7ee338511b', '', '2018-05-19 17:00:16', NULL, NULL),
(72, '5b009eaaa79d65.34231424', 'nana', 'nana@gmail.com', '3lSXN94PX+9FQTsa0yOdCoM0qWc0M2E4NjFkYjU1', '43a861db55', '', '2018-05-19 17:01:14', NULL, NULL),
(73, '5b021ca99e1bd5.54287270', 'nene', 'nene@gmail.com', 'CpCOY5L3wHvC/qBVgxf10ch11ytlYmM3OTFkMmQ3', 'ebc791d2d7', 'mouse del nene ', '2018-05-20 20:11:05', NULL, 'http://192.168.0.5/laboratorio/products/uploads/73.png'),
(74, '5b03a7ac992995.18456458', 'nini', 'nini@gmail.com', 'nmvLsOmoi8p0WT61fgorFGfbGS4zZDY4OTlhZWE2', '3d6899aea6', 'botella de agua del nini', '2018-05-22 00:16:28', NULL, 'http://192.168.0.5/laboratorio/products/uploads/74.png');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
