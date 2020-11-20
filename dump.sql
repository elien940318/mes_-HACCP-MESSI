-- MySQL dump 10.17  Distrib 10.3.25-MariaDB, for debian-linux-gnueabihf (armv7l)
--
-- Host: localhost    Database: mes
-- ------------------------------------------------------
-- Server version	10.3.25-MariaDB-0+deb10u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `info_bom`
--

DROP TABLE IF EXISTS `info_bom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `info_bom` (
  `bom_no` int(11) NOT NULL COMMENT '제품코드',
  `bom_parent_no` int(11) NOT NULL COMMENT '제품의 부모코드',
  `bom_count` double DEFAULT NULL,
  PRIMARY KEY (`bom_no`,`bom_parent_no`),
  KEY `bom_parent_no` (`bom_parent_no`),
  CONSTRAINT `info_bom_ibfk_1` FOREIGN KEY (`bom_no`) REFERENCES `info_material` (`mat_no`) ON DELETE CASCADE,
  CONSTRAINT `info_bom_ibfk_2` FOREIGN KEY (`bom_parent_no`) REFERENCES `info_material` (`mat_no`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='BOM정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info_bom`
--

LOCK TABLES `info_bom` WRITE;
/*!40000 ALTER TABLE `info_bom` DISABLE KEYS */;
INSERT INTO `info_bom` VALUES (30001,30005,0.01),(30001,30006,0.01),(30001,30007,0.01),(30002,30005,0.01),(30003,30006,0.01),(30004,30007,0.01),(30005,30005,1),(30005,30010,20),(30006,30006,1),(30006,30011,20),(30007,30007,1),(30007,30012,20),(30010,30010,1),(30011,30011,1),(30012,30012,1),(30013,30013,1);
/*!40000 ALTER TABLE `info_bom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `info_company`
--

DROP TABLE IF EXISTS `info_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `info_company` (
  `com_no` int(11) NOT NULL AUTO_INCREMENT COMMENT '10000번대 시작',
  `com_type` varchar(10) NOT NULL COMMENT '거래처유형(매입,매출)',
  `com_name` varchar(20) NOT NULL COMMENT '거래처명',
  `com_licenseno` varchar(20) DEFAULT NULL COMMENT '사업자번호',
  `com_phoneno` varchar(20) DEFAULT NULL COMMENT '전화번호',
  `com_rep_name` varchar(20) DEFAULT NULL COMMENT '대표자',
  PRIMARY KEY (`com_no`)
) ENGINE=InnoDB AUTO_INCREMENT=10030 DEFAULT CHARSET=utf8mb4 COMMENT='거래처정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info_company`
--

LOCK TABLES `info_company` WRITE;
/*!40000 ALTER TABLE `info_company` DISABLE KEYS */;
INSERT INTO `info_company` VALUES (10002,'입고','이버푸드','220-81-62517','010-0011-1512','이동국'),(10003,'입고','돈슨','621-81-41812','055-380-6666','안선'),(10004,'출고','오카카','120-81-47521','02-6718-1082','여민수'),(10010,'입고','비이버','154-81-45321','052-456-8475','강창기'),(10011,'출고','NPN','774-45-48123','010-2245-6482','조영현'),(10012,'출고','래이엇','451-81-65427','055-665-4455','강챙이'),(10013,'출고','고글','889-81-46123','010-1122-4615','김문혁'),(10014,'출고','skp','415-55-15132','02-543-4499','박근도'),(10029,'입고','테스트','123','123','강창기');
/*!40000 ALTER TABLE `info_company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `info_material`
--

DROP TABLE IF EXISTS `info_material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `info_material` (
  `mat_no` int(11) NOT NULL AUTO_INCREMENT COMMENT '30000번대 시작',
  `mat_name` varchar(30) NOT NULL COMMENT '품목명',
  `mat_type` varchar(20) NOT NULL COMMENT '제품,반제품,',
  `mat_spec` varchar(20) DEFAULT NULL COMMENT 'kg,L 등등',
  `mat_price` int(11) DEFAULT NULL,
  `mat_etc` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`mat_no`)
) ENGINE=InnoDB AUTO_INCREMENT=40017 DEFAULT CHARSET=utf8mb4 COMMENT='품목정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info_material`
--

LOCK TABLES `info_material` WRITE;
/*!40000 ALTER TABLE `info_material` DISABLE KEYS */;
INSERT INTO `info_material` VALUES (30001,'임금님표 쌀','원재료','10 kg',28000,''),(30002,'멸치맛 분말','부재료','1 Kg',15000,NULL),(30003,'김치맛 분말','부재료','1 Kg',15000,'수정'),(30004,'소고기맛 분말','부재료','1 Kg',15000,NULL),(30005,'멸치국수','제품','1 EA',1500,''),(30006,'김치국수','제품','1 EA',1500,NULL),(30007,'소고기국수','제품','1 EA',1500,NULL),(30009,'김국수','제품','1 EA',1500,'테스트용'),(30010,'멸치국수 Box','제품','20 EA / Box',30000,'멸치국수 Box포장'),(30011,'김치국수 Box','제품','20 EA / Box',30000,'김치국수 Box포장'),(30012,'소고기국수 Box','제품','20 EA / Box',30000,'소고기국수 Box포장'),(30013,'김국수 Box','제품','20 EA / Box',30000,'김국수 Box포장'),(40015,'고시히카리 쌀','원재료','20kg ',35000,'품목 추가 테스트.');
/*!40000 ALTER TABLE `info_material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `info_user`
--

DROP TABLE IF EXISTS `info_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `info_user` (
  `user_id` varchar(20) NOT NULL COMMENT '아이디',
  `user_pw` varchar(20) NOT NULL COMMENT '패스워드',
  `user_name` varchar(10) DEFAULT NULL COMMENT '유저이름',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='회원정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info_user`
--

LOCK TABLES `info_user` WRITE;
/*!40000 ALTER TABLE `info_user` DISABLE KEYS */;
INSERT INTO `info_user` VALUES ('admin','admin','관리자'),('elien940318','1234','강창기'),('JYH','wow','영현'),('kdwkim','123qwe','동욱김');
/*!40000 ALTER TABLE `info_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `info_warehouse`
--

DROP TABLE IF EXISTS `info_warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `info_warehouse` (
  `ware_no` int(11) NOT NULL AUTO_INCREMENT COMMENT '20000번대 시작',
  `ware_name` varchar(20) NOT NULL COMMENT '창고명',
  `ware_type` varchar(20) NOT NULL COMMENT '입고,출고,자재 등...',
  `ware_use` varchar(10) DEFAULT NULL COMMENT '사용,미사용',
  `ware_etc` varchar(50) DEFAULT NULL COMMENT '비고',
  PRIMARY KEY (`ware_no`)
) ENGINE=InnoDB AUTO_INCREMENT=20016 DEFAULT CHARSET=utf8mb4 COMMENT='창고';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info_warehouse`
--

LOCK TABLES `info_warehouse` WRITE;
/*!40000 ALTER TABLE `info_warehouse` DISABLE KEYS */;
INSERT INTO `info_warehouse` VALUES (20000,'원재료창고','입고','사용','쌀과 같은 원재료가 보관됨'),(20001,'부재료창고','입고','사용','스프와 같은 부재료가 보관됨'),(20002,'창고','입고','미사용','미사용 창고'),(20003,'제품창고','출고','사용','국수와 같은 포장전 제품이 보관됨'),(20004,'출고대기창고','출고','사용','출고대기중인 포장된 제품이 보관됨'),(20005,'검사대기창고','검수','사용','작업 지시 후 불량 체크전 임시창고');
/*!40000 ALTER TABLE `info_warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manage_curmat`
--

DROP TABLE IF EXISTS `manage_curmat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manage_curmat` (
  `ware_no` int(11) NOT NULL COMMENT '어느 창고에',
  `mat_no` int(11) NOT NULL COMMENT '어느 품목이',
  `curmat_count` int(11) NOT NULL COMMENT '얼마나 많이',
  PRIMARY KEY (`ware_no`,`mat_no`),
  KEY `FK_manage_curmat_mat_no_info_material_mat_no` (`mat_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='현재 창고에 어떤 제품이 얼마나 있는지. ..';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manage_curmat`
--

LOCK TABLES `manage_curmat` WRITE;
/*!40000 ALTER TABLE `manage_curmat` DISABLE KEYS */;
INSERT INTO `manage_curmat` VALUES (20000,30001,599),(20001,30002,198),(20001,30003,100),(20001,30004,215),(20003,30005,0),(20003,30006,3),(20003,30007,0),(20004,30010,152),(20004,30011,167),(20004,30012,150),(20004,30013,78),(20005,30005,0),(20005,30006,0),(20005,30007,0),(20005,30009,0);
/*!40000 ALTER TABLE `manage_curmat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manage_input`
--

DROP TABLE IF EXISTS `manage_input`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manage_input` (
  `input_idx` int(11) NOT NULL AUTO_INCREMENT COMMENT '입고인덱스',
  `input_date` datetime NOT NULL COMMENT '언제 입고할것인지',
  `mat_no` int(11) NOT NULL COMMENT '어떤제품?',
  `input_count` int(11) NOT NULL COMMENT '입고할 수량',
  `input_admin` varchar(20) NOT NULL COMMENT '입고신청한 사람명',
  `input_inspec` varchar(20) NOT NULL COMMENT '개별,샘플링,체크',
  `ware_no` int(11) NOT NULL COMMENT '입고할 창고 코드',
  `input_etc` varchar(100) DEFAULT NULL,
  `com_no` int(11) DEFAULT NULL,
  PRIMARY KEY (`input_idx`),
  KEY `FK_manage_input_mat_no_info_material_mat_no` (`mat_no`),
  KEY `FK_manage_input_ware_no_info_warehouse_ware_no` (`ware_no`),
  KEY `fk_input_com` (`com_no`)
) ENGINE=InnoDB AUTO_INCREMENT=110029 DEFAULT CHARSET=utf8mb4 COMMENT='원자재, 반제품 등 입고 관리';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manage_input`
--

LOCK TABLES `manage_input` WRITE;
/*!40000 ALTER TABLE `manage_input` DISABLE KEYS */;
INSERT INTO `manage_input` VALUES (110001,'2020-10-23 14:35:35',30001,5,'강창기','샘플링체크',20000,'',10002),(110004,'2020-11-03 23:34:32',30003,10,'강창기','샘플링체크',20000,'입고테스트2',10003),(110006,'2020-11-08 18:01:00',30002,24,'귀찮아','전수검사',20000,'',10003),(110007,'2020-11-08 18:01:00',30001,10,'테스형','전수검사',20001,'테스트',10002),(110008,'2020-11-11 15:07:59',30003,10,'강창기','전수검사',20000,'날짜테스트용',10003),(110009,'2020-11-11 16:22:15',30001,7,'창기','샘플링검사',20000,'입고수량 반영 테스트',10002),(110011,'2020-11-14 13:11:01',30002,5,'뿡뿡','마검사',20001,'',10003),(110013,'2020-11-16 17:27:51',30004,10,'16일창기','전수검사',20001,'테스트',10003),(110015,'2020-11-18 20:30:01',30003,10,'창기','전수조사',20000,'테스트',10004),(110017,'2020-11-18 21:05:28',30004,100,'강창기','전수검사',20000,'수량증가',10011),(110018,'2020-11-18 21:08:34',30001,500,'창기','샘플링검사',20000,'test',10010),(110020,'2020-11-18 21:49:58',30001,50,'임원','',20000,'',10010),(110021,'2020-11-18 21:51:06',30002,100,'임원','',20001,'',10002),(110022,'2020-11-18 21:51:41',30003,100,'김부장','',20001,'',10003),(110023,'2020-11-18 21:52:17',30004,100,'김그래','',20001,'',10003),(110024,'2020-11-19 16:01:30',30002,10,'강창기','전수 검사',20001,'관리자 테스트',10002),(110025,'2020-11-19 16:22:58',30002,30,'동욱김','',20001,'',10010),(110026,'2020-11-19 17:41:27',30004,120,'관리자','샘플링 검사',20001,'재고 부족으로 인한 입고',10002),(110027,'2020-11-19 17:41:28',30002,10,'관리자','전수 검사',20001,'멸치가 맛있대서',10003);
/*!40000 ALTER TABLE `manage_input` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manage_output`
--

DROP TABLE IF EXISTS `manage_output`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manage_output` (
  `output_idx` int(11) NOT NULL AUTO_INCREMENT COMMENT '출고인덱스',
  `output_date` datetime DEFAULT current_timestamp(),
  `mat_no` int(11) NOT NULL COMMENT '출고할 제품코드',
  `output_count` int(11) NOT NULL COMMENT '출고할 수량',
  `ware_no` int(11) NOT NULL COMMENT '제품을 출고할 창고코드',
  `output_admin` varchar(20) DEFAULT NULL COMMENT '출고신청한 사람명',
  `com_no` int(11) DEFAULT NULL COMMENT '어느 거래처로 출고할건가.',
  `output_etc` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`output_idx`),
  KEY `FK_manage_output_com_no_info_company_com_no` (`com_no`),
  KEY `FK_manage_output_mat_no_info_material_mat_no` (`mat_no`),
  KEY `FK_manage_output_ware_no_info_warehouse_ware_no` (`ware_no`)
) ENGINE=InnoDB AUTO_INCREMENT=210016 DEFAULT CHARSET=utf8mb4 COMMENT='제품을 어느 회사로 얼마나 출고할것인지...';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manage_output`
--

LOCK TABLES `manage_output` WRITE;
/*!40000 ALTER TABLE `manage_output` DISABLE KEYS */;
INSERT INTO `manage_output` VALUES (210010,'2020-11-18 23:33:45',30010,20,20004,'강창기',10012,''),(210011,'2020-11-18 23:33:45',30013,22,20004,'강창기',10011,''),(210012,'2020-11-18 23:34:03',30011,13,20004,'강창기',10013,''),(210013,'2020-11-18 23:34:31',30012,35,20004,'강창기',10014,''),(210014,'2020-11-19 16:06:09',30011,5,20004,'강창기',10012,'출고테스트'),(210015,'2020-11-19 17:45:35',30011,20,20004,'관리자',10011,'');
/*!40000 ALTER TABLE `manage_output` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manage_realstocktake`
--

DROP TABLE IF EXISTS `manage_realstocktake`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manage_realstocktake` (
  `stocktake_no` int(11) NOT NULL AUTO_INCREMENT COMMENT '재고실사 인덱스',
  `ware_no` int(11) NOT NULL COMMENT '창고코드',
  `mat_no` int(11) NOT NULL COMMENT '품목코드',
  `stocktake_type` varchar(10) NOT NULL COMMENT '추가/차감',
  `stocktake_beforecount` int(11) NOT NULL COMMENT '기존수량',
  `stocktake_changecount` int(11) NOT NULL COMMENT '변경수량',
  `user_id` varchar(20) DEFAULT NULL COMMENT '관리자 아이디',
  `stocktake_date` datetime NOT NULL COMMENT '실사관리날짜',
  `memo` varchar(100) DEFAULT NULL COMMENT '메모',
  PRIMARY KEY (`stocktake_no`),
  KEY `FK_manage_realstocktake_mat_no_info_material_mat_no` (`mat_no`),
  KEY `FK_manage_realstocktake_ware_no_info_warehouse_ware_no` (`ware_no`),
  KEY `FK_manage_realstocktake_user_id_info_user_user_id` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COMMENT='재고 실사';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manage_realstocktake`
--

LOCK TABLES `manage_realstocktake` WRITE;
/*!40000 ALTER TABLE `manage_realstocktake` DISABLE KEYS */;
INSERT INTO `manage_realstocktake` VALUES (1,20000,30001,'차감',9,1,'admin','2020-11-15 23:35:41','test'),(2,20001,30002,'차감',45,3,'admin','2020-11-17 23:58:56',''),(3,20003,30006,'추가',33,2,'admin','2020-11-18 00:03:36','갯수 파악'),(5,20005,30006,'차감',20,5,'admin','2020-11-18 18:01:52',''),(6,20005,30006,'추가',15,10,'admin','2020-11-18 18:02:10',''),(7,20005,30006,'추가',25,10,'admin','2020-11-18 20:27:35',''),(8,20004,30010,'추가',0,100,'admin','2020-11-18 22:19:16','test'),(9,20004,30011,'추가',0,100,'admin','2020-11-18 22:22:02','test'),(10,20004,30011,'추가',0,100,'admin','2020-11-18 22:22:12','test'),(11,20004,30012,'추가',0,100,'admin','2020-11-18 22:22:22','test'),(12,20004,30013,'추가',0,100,'admin','2020-11-18 22:22:36','test'),(13,20004,30011,'차감',200,100,'admin','2020-11-18 22:22:54','test'),(14,20005,30005,'차감',215,90,'admin','2020-11-19 17:47:18','실사 테스트'),(15,20001,30002,'차감',214,14,'admin','2020-11-20 11:28:20','실사 테스트'),(16,20000,30001,'차감',672,72,'admin','2020-11-20 13:13:05','실사 테스트');
/*!40000 ALTER TABLE `manage_realstocktake` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`messi`@`%`*/ /*!50003 TRIGGER `trig_INSERT_real_stock_taking` AFTER INSERT ON `manage_realstocktake` FOR EACH ROW BEGIN
IF NEW.stocktake_type = '추가' THEN BEGIN
UPDATE manage_curmat SET curmat_count = curmat_count + NEW.stocktake_changecount WHERE ware_no = NEW.ware_no AND mat_no = NEW.mat_no;
END; END IF;
IF NEW.stocktake_type = '차감' THEN BEGIN
UPDATE manage_curmat SET curmat_count = curmat_count - NEW.stocktake_changecount WHERE ware_no = NEW.ware_no AND mat_no = NEW.mat_no;
END; END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `production_mngodr`
--

DROP TABLE IF EXISTS `production_mngodr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `production_mngodr` (
  `mngodr_no` int(11) NOT NULL AUTO_INCREMENT COMMENT '작업지시코드',
  `mngodr_date` datetime DEFAULT current_timestamp(),
  `mat_no` int(11) NOT NULL COMMENT '만들 제품명(bom에서 하위재료 프로시저처리)',
  `mngodr_count` int(11) NOT NULL COMMENT '작업지시내링 수량',
  `user_id` varchar(20) NOT NULL COMMENT '아이디',
  `ware_no` int(11) DEFAULT NULL,
  PRIMARY KEY (`mngodr_no`),
  KEY `FK_production_mngodr_mat_no_info_material_mat_no` (`mat_no`),
  KEY `FK_production_mngodr_user_id_info_user_user_id` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=50067 DEFAULT CHARSET=utf8mb4 COMMENT='작업지시관리(manageorder)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_mngodr`
--

LOCK TABLES `production_mngodr` WRITE;
/*!40000 ALTER TABLE `production_mngodr` DISABLE KEYS */;
INSERT INTO `production_mngodr` VALUES (50030,'2020-11-02 00:00:00',30005,100,'강창기',20005),(50031,'2020-11-02 00:00:00',30006,200,'김문혁',20005),(50032,'2020-11-03 00:00:00',30005,100,'김동욱',20005),(50033,'2020-11-03 00:00:00',30007,100,'박근도',20005),(50034,'2020-11-04 00:00:00',30006,300,'조영현',20005),(50035,'2020-11-04 00:00:00',30005,100,'강창기',20005),(50036,'2020-11-05 00:00:00',30006,200,'김문혁',20005),(50037,'2020-11-05 00:00:00',30007,100,'김동욱',20005),(50038,'2020-11-06 00:00:00',30005,100,'박근도',20005),(50039,'2020-11-06 00:00:00',30006,200,'조영현',20005),(50040,'2020-11-09 00:00:00',30007,100,'강창기',20005),(50041,'2020-11-09 00:00:00',30006,100,'김문혁',20005),(50042,'2020-11-10 00:00:00',30007,100,'김동욱',20005),(50043,'2020-11-10 00:00:00',30006,100,'박근도',20005),(50044,'2020-11-11 00:00:00',30005,100,'김문혁',20005),(50045,'2020-11-11 00:00:00',30006,200,'김문혁',20005),(50046,'2020-11-12 00:00:00',30006,200,'박근도',20005),(50047,'2020-11-12 00:00:00',30007,100,'박근도',20005),(50048,'2020-11-13 00:00:00',30005,200,'조영현',20005),(50049,'2020-11-13 00:00:00',30007,300,'조영현',20005),(50050,'2020-11-14 00:00:00',30006,100,'강창기',20005),(50051,'2020-11-14 00:00:00',30007,100,'강창기',20005),(50052,'2020-11-15 00:00:00',30005,100,'김동욱',20005),(50053,'2020-11-15 00:00:00',30005,200,'김동욱',20005),(50054,'2020-11-16 00:00:00',30005,100,'김문혁',20005),(50055,'2020-11-16 00:00:00',30006,300,'김문혁',20005),(50056,'2020-11-17 00:00:00',30005,100,'박근도',20005),(50057,'2020-11-17 00:00:00',30007,200,'박근도',20005),(50058,'2020-11-18 00:00:00',30007,200,'조영현',20005),(50059,'2020-11-18 00:00:00',30007,200,'조영현',20005),(50060,'2020-11-19 00:00:00',30006,100,'강창기',20005),(50061,'2020-11-19 00:00:00',30005,100,'강창기',20005),(50064,'2020-11-20 00:00:00',30006,100,'박근도',20005),(50065,'2020-11-20 00:00:00',30005,100,'영현님',20005),(50066,'2020-11-20 00:00:00',30005,100,'관리자',20005);
/*!40000 ALTER TABLE `production_mngodr` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = euckr */ ;
/*!50003 SET character_set_results = euckr */ ;
/*!50003 SET collation_connection  = euckr_korean_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`messi`@`%`*/ /*!50003 TRIGGER trig_INSERT_production_mngodr
AFTER INSERT ON production_mngodr
FOR EACH ROW
BEGIN

    
    
    

    UPDATE manage_curmat ,
        (SELECT bom_no as mat_no, bom_count * NEW.mngodr_count as curmat_count 
         FROM info_bom 
         WHERE bom_parent_no=NEW.mat_no AND bom_no != NEW.mat_no) as temp
    SET manage_curmat.curmat_count = manage_curmat.curmat_count - temp.curmat_count
    WHERE manage_curmat.mat_no = temp.mat_no 
    AND (manage_curmat.ware_no=20000 OR manage_curmat.ware_no=20001);


  
    
    
    
    INSERT INTO manage_curmat(ware_no, mat_no, curmat_count) 
    VALUES(NEW.ware_no, NEW.mat_no, NEW.mngodr_count)
    ON DUPLICATE KEY UPDATE curmat_count = curmat_count + NEW.mngodr_count;
        

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `production_prodrecod`
--

DROP TABLE IF EXISTS `production_prodrecod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `production_prodrecod` (
  `prodrecod_no` int(11) NOT NULL AUTO_INCREMENT,
  `mngodr_no` int(11) NOT NULL,
  `prodrecod_date` datetime DEFAULT current_timestamp(),
  `prodrecod_good` int(11) NOT NULL DEFAULT 0,
  `prodrecod_err` int(11) NOT NULL DEFAULT 0,
  `ware_no` int(11) NOT NULL,
  PRIMARY KEY (`prodrecod_no`),
  UNIQUE KEY `mngodr_no` (`mngodr_no`),
  KEY `production_mngodr_ware_no_fk` (`ware_no`),
  CONSTRAINT `production_mngodr_no_fk` FOREIGN KEY (`mngodr_no`) REFERENCES `production_mngodr` (`mngodr_no`) ON DELETE CASCADE,
  CONSTRAINT `production_mngodr_ware_no_fk` FOREIGN KEY (`ware_no`) REFERENCES `info_warehouse` (`ware_no`)
) ENGINE=InnoDB AUTO_INCREMENT=60068 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_prodrecod`
--

LOCK TABLES `production_prodrecod` WRITE;
/*!40000 ALTER TABLE `production_prodrecod` DISABLE KEYS */;
INSERT INTO `production_prodrecod` VALUES (60033,50030,'2020-11-03 00:00:00',96,4,20003),(60034,50031,'2020-11-03 00:00:00',190,10,20003),(60035,50032,'2020-11-04 00:00:00',90,10,20003),(60036,50033,'2020-11-04 00:00:00',95,5,20003),(60037,50034,'2020-11-05 00:00:00',280,20,20003),(60038,50035,'2020-11-05 00:00:00',95,5,20003),(60039,50036,'2020-11-06 00:00:00',185,15,20003),(60040,50037,'2020-11-06 00:00:00',98,2,20003),(60041,50038,'2020-11-09 00:00:00',96,4,20003),(60042,50039,'2020-11-09 00:00:00',192,8,20003),(60043,50040,'2020-11-10 00:00:00',97,3,20003),(60044,50041,'2020-11-10 00:00:00',98,2,20003),(60045,50042,'2020-11-11 00:00:00',95,5,20003),(60046,50043,'2020-11-11 00:00:00',90,10,20003),(60047,50044,'2020-11-12 00:00:00',96,4,20003),(60048,50045,'2020-11-12 00:00:00',180,20,20003),(60049,50046,'2020-11-13 00:00:00',190,10,20003),(60050,50047,'2020-11-13 00:00:00',90,10,20003),(60051,50048,'2020-11-14 00:00:00',192,8,20003),(60052,50049,'2020-11-14 00:00:00',295,5,20003),(60053,50050,'2020-11-15 00:00:00',95,5,20003),(60054,50051,'2020-11-15 00:00:00',96,4,20003),(60055,50052,'2020-11-16 00:00:00',92,8,20003),(60056,50053,'2020-11-16 00:00:00',198,2,20003),(60057,50054,'2020-11-17 00:00:00',95,5,20003),(60058,50055,'2020-11-17 00:00:00',289,11,20003),(60059,50056,'2020-11-18 00:00:00',95,5,20003),(60060,50057,'2020-11-18 00:00:00',190,10,20003),(60061,50058,'2020-11-19 00:00:00',185,15,20003),(60062,50059,'2020-11-19 00:00:00',190,10,20003),(60063,50060,'2020-11-20 00:00:00',93,7,20003),(60064,50061,'2020-11-20 00:00:00',89,11,20003),(60065,50064,'2020-11-20 00:00:00',92,8,20003),(60066,50065,'2020-11-20 00:00:00',99,1,20003),(60067,50066,'2020-11-20 00:00:00',98,2,20003);
/*!40000 ALTER TABLE `production_prodrecod` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = euckr */ ;
/*!50003 SET character_set_results = euckr */ ;
/*!50003 SET collation_connection  = euckr_korean_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`messi`@`%`*/ /*!50003 TRIGGER boxing_insert AFTER INSERT ON production_prodrecod FOR EACH ROW
BEGIN
declare _total int default 0;
set _total = (SELECT curmat_count FROM manage_curmat WHERE ware_no = NEW.ware_no AND mat_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no)) + NEW.prodrecod_good;
UPDATE manage_curmat SET curmat_count = _total WHERE ware_no = NEW.ware_no AND mat_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);
UPDATE manage_curmat SET curmat_count = (SELECT curmat_count FROM manage_curmat WHERE ware_no in (SELECT ware_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) AND mat_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no)) - (SELECT mngodr_count FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) WHERE ware_no in (SELECT ware_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) AND mat_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);
IF NEW.ware_no = 20003 AND _total > 19
THEN
BEGIN
UPDATE manage_curmat SET curmat_count = curmat_count + _total div 20 WHERE ware_no = 20004 AND mat_no in (SELECT bom_parent_no FROM info_bom WHERE bom_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no) AND bom_count = 20);
UPDATE manage_curmat SET curmat_count = (_total % 20) WHERE ware_no = 20003 AND mat_no in (SELECT mat_no FROM production_mngodr WHERE mngodr_no = NEW.mngodr_no);
END;
END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `temp`
--

DROP TABLE IF EXISTS `temp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temp` (
  `prodrecod_no` int(11) NOT NULL AUTO_INCREMENT,
  `mngodr_no` int(11) DEFAULT NULL,
  `prodrecod_date` datetime DEFAULT NULL,
  `prodrecod_good` int(11) DEFAULT NULL,
  `prodrecod_err` int(11) DEFAULT NULL,
  `ware_no` int(11) DEFAULT NULL,
  PRIMARY KEY (`prodrecod_no`)
) ENGINE=InnoDB AUTO_INCREMENT=60042 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp`
--

LOCK TABLES `temp` WRITE;
/*!40000 ALTER TABLE `temp` DISABLE KEYS */;
INSERT INTO `temp` VALUES (60007,50008,'2020-10-19 22:33:37',79,2,20003),(60008,50010,'2020-10-20 22:33:48',93,4,20003),(60009,50011,'2020-10-21 22:33:55',84,2,20003),(60010,50012,'2020-10-22 22:34:05',78,1,20003),(60011,50013,'2020-10-23 22:34:11',98,5,20003),(60012,50014,'2020-10-24 22:34:17',69,2,20003),(60013,50015,'2020-10-25 22:34:48',93,2,20003),(60014,50020,'2020-10-26 23:50:21',95,5,20003),(60015,50021,'2020-10-27 00:07:48',98,2,20003),(60016,50022,'2020-10-28 00:13:07',92,8,20003),(60017,50023,'2020-10-29 00:18:08',95,5,20003),(60018,50024,'2020-10-30 00:30:34',92,8,20003),(60019,50025,'2020-10-31 01:06:17',98,2,20003),(60020,50026,'2020-11-01 01:10:58',92,8,20003);
/*!40000 ALTER TABLE `temp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-20 18:29:00
