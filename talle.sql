-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         5.7.32-log - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para taller
CREATE DATABASE IF NOT EXISTS `taller` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `taller`;

-- Volcando estructura para tabla taller.categorias
CREATE TABLE IF NOT EXISTS `categorias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.categorias: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` (`id`, `nombre`) VALUES
	(1, 'Coche'),
	(2, 'Motocicleta'),
	(3, 'Ciclomotor'),
	(4, 'hola');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;

-- Volcando estructura para tabla taller.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` tinytext NOT NULL,
  `apellidos` tinytext NOT NULL,
  `dni` tinytext NOT NULL,
  `direccion` tinytext NOT NULL,
  `telefono` varchar(12) NOT NULL DEFAULT '0',
  `email` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.clientes: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` (`id`, `nombre`, `apellidos`, `dni`, `direccion`, `telefono`, `email`) VALUES
	(1, 'Aitor', 'Tilla Rica', '14256398E', 'C/ Aitor, 10', '0', 'a.tillarica@mail.es'),
	(2, 'Armando', 'Bronca Segura', '65847921G', 'C/ Armando, 15', '664875879', 'a.broncasegura@email.es'),
	(3, 'Elena', 'Conejo Pelado', '45658510T', 'C/ Elena, 40', '661203569', 'e.conejopelado@mailing.es'),
	(4, 'Alvaro', 'Lara Cazorla', '12548765J', 'C/ Alvaro el cariñoso, 20', '745215489', 'a.laracazorla@terra.es'),
	(5, 'Antonio', 'Molina', '51458741K', 'C/ Falsa, 123', '665874125', 'a@molina.es'),
	(6, 'Roberto', 'Carlos', '1254598H', 'c/ falsa', '666555888', 'r@carlos.es');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- Volcando estructura para tabla taller.concesionarios
CREATE TABLE IF NOT EXISTS `concesionarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.concesionarios: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `concesionarios` DISABLE KEYS */;
INSERT INTO `concesionarios` (`id`, `nombre`) VALUES
	(1, 'Cumaca Motor'),
	(2, 'Autos Cormosa'),
	(3, 'Ford Garum Motor'),
	(4, 'Automóviles Bolívar');
/*!40000 ALTER TABLE `concesionarios` ENABLE KEYS */;

-- Volcando estructura para tabla taller.mecanicos_categorias
CREATE TABLE IF NOT EXISTS `mecanicos_categorias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria_id` int(11) NOT NULL,
  `mecanico_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categoria_id` (`categoria_id`),
  KEY `mecanico_id` (`mecanico_id`),
  CONSTRAINT `FK_mecanicos_categorias_categorias` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`),
  CONSTRAINT `FK_mecanicos_categorias_usuarios` FOREIGN KEY (`mecanico_id`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.mecanicos_categorias: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `mecanicos_categorias` DISABLE KEYS */;
INSERT INTO `mecanicos_categorias` (`id`, `categoria_id`, `mecanico_id`) VALUES
	(1, 1, 4),
	(2, 2, 4),
	(3, 3, 10);
/*!40000 ALTER TABLE `mecanicos_categorias` ENABLE KEYS */;

-- Volcando estructura para tabla taller.propuestas
CREATE TABLE IF NOT EXISTS `propuestas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vehiculo_id` int(11) NOT NULL,
  `validez` date NOT NULL,
  `observaciones` text,
  `precio` int(11) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `vehiculo_id` (`vehiculo_id`),
  KEY `cliente_id` (`cliente_id`),
  KEY `usuario_id` (`usuario_id`),
  CONSTRAINT `FK_propuestas_vehiculos` FOREIGN KEY (`vehiculo_id`) REFERENCES `vehiculos` (`id`),
  CONSTRAINT `propuestas_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`id`),
  CONSTRAINT `propuestas_ibfk_2` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.propuestas: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `propuestas` DISABLE KEYS */;
INSERT INTO `propuestas` (`id`, `vehiculo_id`, `validez`, `observaciones`, `precio`, `cliente_id`, `usuario_id`) VALUES
	(2, 1, '2020-11-16', '', 1500, 5, 2),
	(4, 4, '2020-11-12', '', 5000, 4, 2);
/*!40000 ALTER TABLE `propuestas` ENABLE KEYS */;

-- Volcando estructura para tabla taller.reparaciones
CREATE TABLE IF NOT EXISTS `reparaciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) NOT NULL,
  `vehiculo_id` int(11) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `estado` enum('Finalizada','En proceso','Por atender') DEFAULT 'Por atender',
  `observaciones` text,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `vehiculo_id` (`vehiculo_id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `FK_reparacion_usuarios` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`),
  CONSTRAINT `FK_reparacion_vehiculos` FOREIGN KEY (`vehiculo_id`) REFERENCES `vehiculos` (`id`),
  CONSTRAINT `reparaciones_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.reparaciones: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `reparaciones` DISABLE KEYS */;
INSERT INTO `reparaciones` (`id`, `usuario_id`, `vehiculo_id`, `cliente_id`, `fecha`, `estado`, `observaciones`) VALUES
	(3, 4, 1, 1, '2020-10-30', 'Finalizada', 'Es un coche muy bonito');
/*!40000 ALTER TABLE `reparaciones` ENABLE KEYS */;

-- Volcando estructura para tabla taller.repuestos
CREATE TABLE IF NOT EXISTS `repuestos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` text NOT NULL,
  `referencia` varchar(50) NOT NULL,
  `precio` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.repuestos: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `repuestos` DISABLE KEYS */;
INSERT INTO `repuestos` (`id`, `nombre`, `referencia`, `precio`) VALUES
	(1, 'Tornillo m4', 'JGU54PO', 1),
	(2, 'Tuerca M4', 'JGU53PO', 1);
/*!40000 ALTER TABLE `repuestos` ENABLE KEYS */;

-- Volcando estructura para tabla taller.repuestos_reparacion
CREATE TABLE IF NOT EXISTS `repuestos_reparacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `repuesto_id` int(11) NOT NULL,
  `reparacion_id` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `repuesto_id` (`repuesto_id`),
  KEY `concesionario_id` (`reparacion_id`),
  CONSTRAINT `FK_repuestos_reparacion_repuestos` FOREIGN KEY (`repuesto_id`) REFERENCES `repuestos` (`id`),
  CONSTRAINT `repuestos_reparacion_ibfk_1` FOREIGN KEY (`reparacion_id`) REFERENCES `reparaciones` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.repuestos_reparacion: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `repuestos_reparacion` DISABLE KEYS */;
INSERT INTO `repuestos_reparacion` (`id`, `repuesto_id`, `reparacion_id`, `cantidad`) VALUES
	(14, 1, 3, 150);
/*!40000 ALTER TABLE `repuestos_reparacion` ENABLE KEYS */;

-- Volcando estructura para tabla taller.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(20) NOT NULL DEFAULT '',
  `password` varchar(32) NOT NULL DEFAULT '',
  `tipo` enum('jefe','mecanico_jefe','mecanico','ventas') NOT NULL DEFAULT 'ventas',
  `concesionario_id` int(11) NOT NULL,
  `nombre` text,
  `apellidos` text,
  `email` text,
  PRIMARY KEY (`id`),
  KEY `concesionario_id` (`concesionario_id`),
  CONSTRAINT `usuarios_ibfk_2` FOREIGN KEY (`concesionario_id`) REFERENCES `concesionarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.usuarios: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`id`, `login`, `password`, `tipo`, `concesionario_id`, `nombre`, `apellidos`, `email`) VALUES
	(2, 'ventas', '81dc9bdb52d04dc20036dbd8313ed055', 'ventas', 1, 'Julian', 'PErez', 'asas@adsd-co,'),
	(4, 'mecanico', '81dc9bdb52d04dc20036dbd8313ed055', 'mecanico', 1, 'Antonio', 'Ramirez', 'asda@asda.com'),
	(5, 'jefe', '81dc9bdb52d04dc20036dbd8313ed055', 'jefe', 1, 'Alvaro', 'Lara', 'asda@sdgh9o.com,'),
	(7, 'mecanico_jefe', '81dc9bdb52d04dc20036dbd8313ed055', 'mecanico_jefe', 1, 'Dani', 'Delgado', 'asda@sdfs-com'),
	(10, 'mecanico_ciclomotor', '81dc9bdb52d04dc20036dbd8313ed055', 'mecanico', 1, 'Jose', 'PP', 'asd@asdf.es');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

-- Volcando estructura para tabla taller.vehiculos
CREATE TABLE IF NOT EXISTS `vehiculos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria_id` int(11) NOT NULL,
  `concesionario_id` int(11) NOT NULL,
  `marca` varchar(50) NOT NULL,
  `modelo` varchar(50) NOT NULL,
  `color` tinytext NOT NULL,
  `matricula` varchar(50) NOT NULL,
  `fecha_registro` date NOT NULL,
  `vendido` tinyint(1) NOT NULL DEFAULT '0',
  `combustible` enum('Diésel','Gasolina','Híbrido','Eléctrico') NOT NULL DEFAULT 'Gasolina',
  `km` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `concesionario_id` (`concesionario_id`),
  KEY `categoria_id` (`categoria_id`),
  CONSTRAINT `vehiculos_ibfk_1` FOREIGN KEY (`concesionario_id`) REFERENCES `concesionarios` (`id`),
  CONSTRAINT `vehiculos_ibfk_2` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.vehiculos: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `vehiculos` DISABLE KEYS */;
INSERT INTO `vehiculos` (`id`, `categoria_id`, `concesionario_id`, `marca`, `modelo`, `color`, `matricula`, `fecha_registro`, `vendido`, `combustible`, `km`) VALUES
	(1, 1, 1, 'Toyota', 'Auris', 'Blanco', '1452HKL', '2020-10-27', 0, 'Híbrido', 0),
	(2, 2, 2, 'Kawasaki', 'Versys', 'Verde', '8849CM', '2020-09-15', 0, 'Gasolina', 1000),
	(3, 3, 3, 'Piaggio', 'Zip', 'Negro', '1234DAM', '2020-11-25', 0, 'Gasolina', 10000),
	(4, 1, 4, 'Seat', 'Ibiza', 'Azul', '5487KJH', '2020-10-31', 0, 'Diésel', 25000),
	(6, 1, 2, 'Fiat', '500', 'Rojo', '654sd', '2020-11-06', 0, 'Gasolina', 200000);
/*!40000 ALTER TABLE `vehiculos` ENABLE KEYS */;

-- Volcando estructura para tabla taller.ventas
CREATE TABLE IF NOT EXISTS `ventas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `vehiculo_id` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `importe` int(11) NOT NULL DEFAULT '0',
  `fecha_limite` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `cliente_id` (`cliente_id`),
  KEY `vehiculo_id` (`vehiculo_id`),
  CONSTRAINT `FK_ventas_clientes` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`id`),
  CONSTRAINT `FK_ventas_usuarios` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`),
  CONSTRAINT `FK_ventas_vehiculos` FOREIGN KEY (`vehiculo_id`) REFERENCES `vehiculos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla taller.ventas: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` (`id`, `usuario_id`, `cliente_id`, `vehiculo_id`, `fecha`, `importe`, `fecha_limite`) VALUES
	(1, 2, 2, 2, '2020-11-16', 7300, '2020-11-15');
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
