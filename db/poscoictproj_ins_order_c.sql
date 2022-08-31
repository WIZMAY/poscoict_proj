-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: poscoictproj
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ins_order_c`
--

DROP TABLE IF EXISTS `ins_order_c`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ins_order_c` (
  `ins_num` varchar(20) NOT NULL,
  `hw_code` varchar(45) NOT NULL,
  `num` int NOT NULL,
  `mat_code` varchar(45) NOT NULL,
  `mat_name` varchar(45) NOT NULL,
  `insert_wgt` float NOT NULL,
  `avl_wgt` float DEFAULT NULL,
  `state` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ins_order_c`
--

LOCK TABLES `ins_order_c` WRITE;
/*!40000 ALTER TABLE `ins_order_c` DISABLE KEYS */;
INSERT INTO `ins_order_c` VALUES ('4000328560','E000404',1,'TLIOH_B','수산화리튬(대립자)',750,0,'진행중'),('4000328560','E000404',2,'1002195','수산화알루미늄 Al(OH)3_KH-101LC(연구용)',26.31,0,'진행중'),('4000328560','E000404',3,'TZRO2','산화지르코늄',5.7,0,'진행중'),('4000328560','E000404',4,'1002376','전구체',1560.6,0,'진행중'),('4000328561','E000404',1,'TLIOH_B','수산화리튬(대립자)',750,0,'진행중'),('4000328561','E000404',2,'1002195','수산화알루미늄 Al(OH)3_KH-101LC(연구용)',26.31,0,'진행중'),('4000328561','E000404',3,'TZRO2','산화지르코늄',5.7,0,'진행중'),('4000328561','E000404',4,'1002376','전구체',1560.6,0,'진행중'),('4000328562','E000404',1,'TLIOH_B','수산화리튬(대립자)',750,0,'진행중'),('4000328562','E000404',2,'1002195','수산화알루미늄 Al(OH)3_KH-101LC(연구용)',26.31,0,'진행중'),('4000328562','E000404',3,'TZRO2','산화지르코늄',5.7,0,'진행중'),('4000328562','E000404',4,'1002376','전구체',1560.6,0,'진행중'),('4000328563','E000404',1,'TLIOH_B','수산화리튬(대립자)',750,0,'진행중'),('4000328563','E000404',2,'1002195','수산화알루미늄 Al(OH)3_KH-101LC(연구용)',26.31,0,'진행중'),('4000328563','E000404',3,'TZRO2','산화지르코늄',5.7,0,'진행중'),('4000328563','E000404',4,'1002376','전구체',1560.6,0,'진행중');
/*!40000 ALTER TABLE `ins_order_c` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-08-31 14:25:35
