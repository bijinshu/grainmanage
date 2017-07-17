/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : grainmanage

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2017-07-17 17:54:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `bm_contact`
-- ----------------------------
DROP TABLE IF EXISTS `bm_contact`;
CREATE TABLE `bm_contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactName` varchar(40) NOT NULL COMMENT '客户名称',
  `Gender` char(1) DEFAULT '' COMMENT '客户性别',
  `BirthDate` date DEFAULT NULL COMMENT '生日',
  `CellPhone` char(11) DEFAULT '' COMMENT '手机',
  `Telephone` varchar(20) DEFAULT '' COMMENT '电话',
  `QQ` varchar(20) DEFAULT '' COMMENT 'QQ',
  `Email` varchar(64) DEFAULT '' COMMENT '邮箱',
  `Area` varchar(60) DEFAULT '' COMMENT '区域',
  `Address` varchar(100) DEFAULT '' COMMENT '地址',
  `Remark` varchar(6000) DEFAULT '' COMMENT '附加描述',
  `Creator` varchar(20) NOT NULL DEFAULT '' COMMENT '创建者',
  `Created` datetime NOT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ContactName` (`ContactName`,`CellPhone`,`Creator`),
  KEY `bm_contact_ibfk_2` (`Creator`),
  CONSTRAINT `bm_contact_ibfk_2` FOREIGN KEY (`Creator`) REFERENCES `rm_users` (`UserName`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_contact
-- ----------------------------
INSERT INTO `bm_contact` VALUES ('1', '张海川', '男', '2016-02-02', '15801992799', '021-6456735', '914023961', 'bijinshu@163.com', '八集', null, null, 'bijinshu', '2016-01-05 18:44:49', '2016-04-05 16:47:13');
INSERT INTO `bm_contact` VALUES ('2', '李玉飞', '女', '1989-06-06', '15801992799', '096-8456735', '914023961', 'bijinshu@163.com', '西王码', '闪电快打', null, 'bijinshu', '2016-01-05 18:44:49', '2016-04-05 16:59:26');
INSERT INTO `bm_contact` VALUES ('3', '王亮亮', '男', '1999-02-02', '15801992799', '032-4456735', '914023961', 'bijinshu@163.com', '李祠堂', '他', null, 'bijinshu', '2016-01-05 18:44:49', '2016-04-05 17:21:16');
INSERT INTO `bm_contact` VALUES ('4', '张思贤', '男', '1988-02-22', '15801992799', '087-5454735', '914023961', 'bijinshu@163.com', '六塘', 'gg', 'df', 'bijinshu', '2016-01-05 18:44:49', '2016-05-17 18:01:29');
INSERT INTO `bm_contact` VALUES ('5', '刘江', '男', '1986-02-09', '15801992799', '028-5455735', '914023961', 'bijinshu@163.com', '泓北', null, null, 'bijinshu', '2016-01-05 18:44:49', '2016-04-05 17:26:43');
INSERT INTO `bm_contact` VALUES ('6', '鲍菲菲', '女', '1980-02-02', '15801992799', '061-8456735', '914023961', 'bijinshu@163.com', '大石渡', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('7', '成杰', '男', '1980-02-02', '15801992799', '045-8456735', '914023961', 'bijinshu@163.com', '芦东', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('8', '陈千业', '男', '1968-02-02', '15801992799', '054-9456735', '914023961', 'bijinshu@163.com', '董荡', null, null, 'bijinshu', '2016-01-05 18:44:49', '2016-04-05 17:28:26');
INSERT INTO `bm_contact` VALUES ('9', '齐昊', '男', '1980-02-02', '15801992799', '065-8459735', '914023961', 'bijinshu@163.com', '朱圩', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('10', '任思', '女', '1980-02-02', '15801992799', '021-6456735', '914023961', 'bijinshu@163.com', '刘庄', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('11', '贾亮', '男', '1980-02-02', '15801992799', '096-8456735', '914023961', 'bijinshu@163.com', '张刘', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('12', '何远', '男', '1980-02-02', '15801992799', '032-4456735', '914023961', 'bijinshu@163.com', '育红', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('13', '文一毫', '男', '1980-02-02', '15801992799', '087-5454735', '914023961', 'bijinshu@163.com', '河东', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('14', '鲁云', '男', '1980-02-02', '15801992799', '028-5455735', '914023961', 'bijinshu@163.com', '桥西', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('15', '毛强国', '男', '1980-02-02', '15801992799', '061-8456735', '914023961', 'bijinshu@163.com', '桥南', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('16', '陈桥锋', '男', '1980-02-02', '15801992799', '045-8456735', '914023961', 'bijinshu@163.com', '合兴', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('17', '秦汉', '男', '1980-02-02', '15801992799', '054-8456735', '914023961', 'bijinshu@163.com', '葛郑', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('18', '李双江', '男', '1980-02-02', '15801992799', '065-8456735', '914023961', 'bijinshu@163.com', '倪荡', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('19', '贝乐石', '男', '1980-02-02', '15801992799', '021-8456735', '914023961', 'bijinshu@163.com', '马洼', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('20', '关楚生', '男', '1980-02-02', '15801992799', '096-8456735', '914023961', 'bijinshu@163.com', '葛荡', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('21', '楚博雄', '男', '1980-02-02', '15801992799', '032-4456735', '914023961', 'bijinshu@163.com', '八集农科', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('22', '张一凡', '男', '1980-02-02', '15801992799', '087-5454735', '914023961', 'bijinshu@163.com', '八集', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('23', '刘玉生', '男', '1980-02-02', '15801992799', '028-5455735', '914023961', 'bijinshu@163.com', '桥西', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('24', '吴雪奇', '女', '1980-02-02', '15801992799', '061-8456735', '914023961', 'bijinshu@163.com', '桥南', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('25', '赵海', '男', '1980-02-02', '15801992799', '045-8456735', '914023961', 'bijinshu@163.com', '合兴', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('26', '江涛', '女', '1980-02-02', '15801992799', '054-8456735', '914023961', 'bijinshu@163.com', '合兴', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('27', '萧见浪', '男', '1980-02-02', '15801992799', '045-8456735', '914023961', 'bijinshu@163.com', '合兴', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('28', '殷了', '女', '1980-02-02', '15801992799', '054-8458736', '914023961', 'bijinshu@163.com', '合兴', '', '', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('29', '薛子琼', '女', '1980-02-02', '15801992799', '065-8456735', '914023961', 'bijinshu@163.com', '桥西', '', '', 'bijinshu', '2016-01-05 18:44:49', null);

-- ----------------------------
-- Table structure for `bm_image`
-- ----------------------------
DROP TABLE IF EXISTS `bm_image`;
CREATE TABLE `bm_image` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ImageName` varchar(64) NOT NULL COMMENT '图片名称',
  `Guid` char(32) NOT NULL COMMENT '编号',
  `Remark` text COMMENT '备注',
  `Creator` varchar(20) DEFAULT '' COMMENT '创建者',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Guid` (`Guid`),
  UNIQUE KEY `ImageName` (`ImageName`,`Creator`),
  KEY `bm_image_ibfk_1` (`Creator`),
  CONSTRAINT `bm_image_ibfk_1` FOREIGN KEY (`Creator`) REFERENCES `rm_users` (`UserName`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_image
-- ----------------------------
INSERT INTO `bm_image` VALUES ('1', 'abacus.ico', '4fb11d10b39911e5adb864006a11eb35', '~/Data/abacus.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('2', 'bamboo.ico', '4fbc7316b39911e5adb864006a11eb35', '~/Data/bamboo.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('3', 'barrel.ico', '4fbc750cb39911e5adb864006a11eb35', '~/Data/barrel.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('4', 'blue and white porcelain.ico', '4fbc7654b39911e5adb864006a11eb35', '~/Data/blue and white porcelain.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('5', 'book.ico', '4fbc7797b39911e5adb864006a11eb35', '~/Data/book.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('6', 'chair.ico', '4fbc78c5b39911e5adb864006a11eb35', '~/Data/chair.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('7', 'chopsticks.ico', '4fbc79f3b39911e5adb864006a11eb35', '~/Data/chopsticks.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('8', 'coin.ico', '4fbc7b1eb39911e5adb864006a11eb35', '~/Data/coin.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('9', 'fan.ico', '4fbc7c3ab39911e5adb864006a11eb35', '~/Data/fan.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('10', 'ink-stone.ico', '4fbc7d60b39911e5adb864006a11eb35', '~/Data/ink-stone.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('11', 'penholder.ico', '4fbc7e7fb39911e5adb864006a11eb35', '~/Data/penholder.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('12', 'plate.ico', '4fbc7f9eb39911e5adb864006a11eb35', '~/Data/plate.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('13', 'scrolls.ico', '4fbc80b8b39911e5adb864006a11eb35', '~/Data/scrolls.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('14', 'sword.ico', '4fbc81d7b39911e5adb864006a11eb35', '~/Data/sword.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('15', 'token.ico', '4fbc82eeb39911e5adb864006a11eb35', '~/Data/token.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('16', 'umbrella.ico', '4fbc840db39911e5adb864006a11eb35', '~/Data/umbrella.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('17', 'vase.ico', '4fbc8533b39911e5adb864006a11eb35', '~/Data/vase.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('18', 'wooden bed.ico', '4fbc865bb39911e5adb864006a11eb35', '~/Data/wooden bed.ico', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('19', 'loading progress.gif', '4fbc8780b39911e5adb864006a11eb35', '~/Data/loading progress.gif', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('20', 'loading Tai Chi.gif', '4fbc8909b39911e5adb864006a11eb35', '~/Data/loading Tai Chi.gif', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('21', 'loading rotation.gif', '4fbc8a3ab39911e5adb864006a11eb35', '~/Data/loading rotation.gif', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('22', 'login_background.jpg', '4fbc8b62b39911e5adb864006a11eb35', '~/Data/login_background.jpg', 'bijinshu', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('23', 'login_title.jpg', '4fbc8c8db39911e5adb864006a11eb35', '~/Data/login_title.jpg', 'bijinshu', '2016-01-05 18:44:49', null);

-- ----------------------------
-- Table structure for `bm_price`
-- ----------------------------
DROP TABLE IF EXISTS `bm_price`;
CREATE TABLE `bm_price` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Grain` varchar(40) NOT NULL DEFAULT '' COMMENT '作物名称',
  `UnitPrice` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '作物价格',
  `PriceType` varchar(20) NOT NULL DEFAULT '' COMMENT '收购、销售',
  `Remark` varchar(200) DEFAULT '' COMMENT '附加描述',
  `Creator` varchar(20) NOT NULL DEFAULT '' COMMENT '创建者',
  `Created` datetime NOT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  KEY `bm_price_ibfk_2` (`Creator`),
  CONSTRAINT `bm_price_ibfk_2` FOREIGN KEY (`Creator`) REFERENCES `rm_users` (`UserName`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_price
-- ----------------------------
INSERT INTO `bm_price` VALUES ('1', '玉米', '2.0100', '销售', '元/千克', 'bijinshu', '2007-10-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('2', '大稻', '2.5200', '收购', '元/千克', 'jack', '2007-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('3', '小稻', '2.3300', '销售', '元/千克', 'bijinshu', '2007-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('4', '小麦', '2.0400', '收购', '元/千克', 'jack', '2007-10-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('5', '菜籽', '3.6500', '销售', '元/千克', 'bijinshu', '2007-10-16 08:40:22', null);
INSERT INTO `bm_price` VALUES ('6', '花生', '3.0600', '收购', '元/千克', 'jack', '2010-10-17 08:40:22', null);
INSERT INTO `bm_price` VALUES ('7', '大稻', '2.5200', '收购', '元/千克', 'bijinshu', '2012-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('8', '玉米', '2.3300', '销售', '元/千克', 'jack', '2012-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('9', '玉米', '2.2900', '销售', '元/千克', 'bijinshu', '2007-10-18 08:40:22', null);
INSERT INTO `bm_price` VALUES ('10', '大稻', '2.6000', '收购', '元/千克', 'jack', '2007-10-19 08:40:22', null);
INSERT INTO `bm_price` VALUES ('11', '小稻', '2.4200', '销售', '元/千克', 'bijinshu', '2007-10-20 08:40:22', null);
INSERT INTO `bm_price` VALUES ('12', '小麦', '2.1300', '收购', '元/千克', 'jack', '2007-10-21 08:40:22', null);
INSERT INTO `bm_price` VALUES ('13', '菜籽', '3.7400', '销售', '元/千克', 'bijinshu', '2007-10-22 08:40:22', null);
INSERT INTO `bm_price` VALUES ('14', '花生', '3.1700', '收购', '元/千克', 'jack', '2010-10-23 08:40:22', null);
INSERT INTO `bm_price` VALUES ('15', '玉米', '2.2200', '收购', '元/千克', 'bijinshu', '2008-12-24 08:40:22', null);
INSERT INTO `bm_price` VALUES ('16', '大稻', '2.7400', '销售', '元/千克', 'jack', '2008-12-25 08:40:22', null);
INSERT INTO `bm_price` VALUES ('17', '小稻', '2.6600', '销售', '元/千克', 'bijinshu', '2008-12-26 08:40:22', null);
INSERT INTO `bm_price` VALUES ('18', '小麦', '2.0800', '收购', '元/千克', 'jack', '2008-12-27 08:40:22', null);
INSERT INTO `bm_price` VALUES ('19', '菜籽', '3.4000', '销售', '元/千克', 'bijinshu', '2008-12-28 08:40:22', null);
INSERT INTO `bm_price` VALUES ('20', '花生', '2.6700', '销售', '元/千克', 'jack', '2008-10-29 08:40:22', null);
INSERT INTO `bm_price` VALUES ('21', '玉米', '2.4100', '收购', '元/千克', 'bijinshu', '2009-02-01 08:40:22', null);
INSERT INTO `bm_price` VALUES ('22', '大稻', '2.8300', '销售', '元/千克', 'jack', '2009-02-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('23', '小稻', '2.4500', '收购', '元/千克', 'bijinshu', '2009-02-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('24', '小麦', '2.0700', '收购', '元/千克', 'jack', '2009-02-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('25', '菜籽', '4.4900', '收购', '元/千克', 'bijinshu', '2009-02-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('26', '花生', '4.8900', '收购', '元/千克', 'jack', '2009-02-16 08:40:22', null);

-- ----------------------------
-- Table structure for `bm_trade`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade`;
CREATE TABLE `bm_trade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactId` int(11) NOT NULL COMMENT '客户Id',
  `Grain` varchar(40) NOT NULL DEFAULT '' COMMENT '作物名称',
  `Price` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '计划价格',
  `Weight` decimal(20,2) DEFAULT '0.00' COMMENT '重量',
  `ActualMoney` decimal(20,2) DEFAULT '0.00' COMMENT '成交价格',
  `TradeType` varchar(20) NOT NULL DEFAULT '' COMMENT '收购、销售',
  `Remark` varchar(6000) DEFAULT '',
  `Creator` varchar(20) DEFAULT '' COMMENT '创建者',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  KEY `ContactID` (`ContactId`),
  KEY `bm_trade_ibfk_3` (`Creator`),
  CONSTRAINT `bm_trade_ibfk_1` FOREIGN KEY (`ContactId`) REFERENCES `bm_contact` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `bm_trade_ibfk_3` FOREIGN KEY (`Creator`) REFERENCES `rm_users` (`UserName`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade
-- ----------------------------
INSERT INTO `bm_trade` VALUES ('1', '1', '玉米', '2.2200', '306.00', '679.32', '收购', '', 'bijinshu', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('2', '2', '大稻', '2.7400', '316.00', '865.84', '收购', '', 'jack', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('3', '3', '小稻', '2.6600', '306.00', '813.96', '销售', '', 'bijinshu', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('4', '4', '小麦', '2.0800', '208.00', '432.64', '收购', '', 'jack', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('5', '5', '菜籽', '3.4000', '306.00', '1040.40', '销售', '', 'bijinshu', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('6', '6', '花生', '2.6700', '306.00', '817.02', '收购', '', 'jack', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('7', '7', '玉米', '2.4100', '306.00', '737.46', '收购', '', 'bijinshu', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('8', '8', '大稻', '2.8300', '306.00', '865.98', '销售', '', 'jack', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('9', '9', '小稻', '2.4500', '306.00', '749.70', '销售', '', 'bijinshu', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('10', '10', '小麦', '2.0700', '306.00', '633.42', '销售', '', 'jack', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('11', '11', '菜籽', '4.4900', '306.00', '1373.94', '销售', '', 'bijinshu', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('12', '12', '花生', '4.8900', '316.00', '1545.24', '收购', '', 'jack', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('13', '13', '玉米', '2.0100', '406.00', '816.06', '收购', '', 'bijinshu', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('14', '14', '大稻', '2.5200', '306.00', '771.12', '销售', '', 'jack', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('15', '15', '小稻', '2.3300', '306.00', '712.98', '收购', '', 'bijinshu', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('16', '16', '小麦', '2.0400', '306.00', '624.24', '销售', '', 'jack', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('17', '17', '菜籽', '3.6500', '306.00', '1116.90', '销售', '', 'bijinshu', '2007-06-01 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('18', '18', '花生', '3.0600', '316.00', '966.96', '收购', '', 'jack', '2006-08-02 14:22:00', null);
INSERT INTO `bm_trade` VALUES ('19', '19', '大稻', '2.5200', '306.00', '771.12', '收购', '', 'bijinshu', '2005-07-02 13:47:03', null);
INSERT INTO `bm_trade` VALUES ('20', '20', '玉米', '2.3300', '406.00', '945.98', '销售', '', 'jack', '2004-09-02 08:47:03', null);
INSERT INTO `bm_trade` VALUES ('21', '21', '玉米', '2.2900', '306.00', '700.74', '收购', '', 'bijinshu', '2004-09-02 08:50:00', null);
INSERT INTO `bm_trade` VALUES ('22', '22', '大稻', '2.6000', '306.00', '795.60', '收购', '', 'jack', '2006-01-02 09:47:56', null);
INSERT INTO `bm_trade` VALUES ('23', '23', '小稻', '2.4200', '306.00', '740.52', '收购', '', 'bijinshu', '2006-01-02 09:50:26', null);
INSERT INTO `bm_trade` VALUES ('24', '24', '小麦', '2.1300', '306.00', '651.78', '收购', '', 'jack', '2010-11-03 10:00:00', null);
INSERT INTO `bm_trade` VALUES ('25', '1', '菜籽', '3.7400', '306.00', '1144.44', '收购', '', 'bijinshu', '2010-08-04 18:45:43', null);
INSERT INTO `bm_trade` VALUES ('26', '1', '花生', '3.1700', '306.00', '970.02', '收购', '', 'jack', '2009-12-06 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('27', '2', '玉米', '2.2200', '306.00', '679.32', '销售', '', 'bijinshu', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('28', '2', '大稻', '2.7400', '316.00', '865.84', '销售', '', 'jack', '2010-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('29', '2', '小稻', '2.6600', '316.00', '840.56', '收购', '', 'bijinshu', '2010-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('30', '20', '小麦', '2.0800', '306.00', '636.48', '销售', '', 'jack', '2010-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('31', '18', '菜籽', '3.4000', '306.00', '1040.40', '销售', '', 'bijinshu', '2010-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('32', '18', '花生', '2.6700', '306.00', '817.02', '收购', '', 'jack', '2010-12-05 16:36:09', null);
INSERT INTO `bm_trade` VALUES ('33', '16', '玉米', '2.4100', '306.00', '737.46', '销售', '', 'bijinshu', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('34', '16', '大稻', '2.8300', '316.00', '894.28', '销售', '', 'jack', '2006-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('35', '7', '小稻', '2.4500', '406.00', '994.70', '收购', '', 'bijinshu', '2005-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('36', '8', '小麦', '2.0700', '306.00', '633.42', '销售', '', 'jack', '2007-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('37', '15', '菜籽', '4.4900', '306.00', '1373.94', '销售', '', 'bijinshu', '2006-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('38', '9', '花生', '4.8900', '306.00', '1496.34', '销售', '', 'jack', '2009-12-05 16:36:09', null);

-- ----------------------------
-- Table structure for `log_action`
-- ----------------------------
DROP TABLE IF EXISTS `log_action`;
CREATE TABLE `log_action` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` varchar(20) NOT NULL DEFAULT '' COMMENT '用户Id',
  `ActionName` varchar(200) NOT NULL COMMENT '动作名称',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '访问端IP',
  `StartTime` datetime NOT NULL COMMENT '调用开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '调用结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=795 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_action
-- ----------------------------
INSERT INTO `log_action` VALUES ('546', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 14:03:16', '2017-07-15 14:03:17', '00:00:01');
INSERT INTO `log_action` VALUES ('547', '', 'Contact.Search', '127.0.0.1', '2017-07-15 14:03:17', '2017-07-15 14:03:17', '00:00:01');
INSERT INTO `log_action` VALUES ('548', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:20:42', '2017-07-15 15:20:42', '00:00:01');
INSERT INTO `log_action` VALUES ('549', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:23:35', '2017-07-15 15:23:35', '00:00:01');
INSERT INTO `log_action` VALUES ('550', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:25:08', '2017-07-15 15:25:09', '00:00:01');
INSERT INTO `log_action` VALUES ('551', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:39:34', '2017-07-15 15:39:34', '00:00:01');
INSERT INTO `log_action` VALUES ('552', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:46:58', '2017-07-15 15:46:58', '00:00:00');
INSERT INTO `log_action` VALUES ('553', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:51:16', '2017-07-15 15:51:16', '00:00:01');
INSERT INTO `log_action` VALUES ('554', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 15:56:30', '2017-07-15 15:56:31', '00:00:01');
INSERT INTO `log_action` VALUES ('555', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:00:55', '2017-07-15 16:00:56', '00:00:01');
INSERT INTO `log_action` VALUES ('556', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:01:00', '2017-07-15 16:01:01', '00:00:01');
INSERT INTO `log_action` VALUES ('557', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:25:27', '2017-07-15 16:25:28', '00:00:01');
INSERT INTO `log_action` VALUES ('558', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:25:28', '2017-07-15 16:25:28', '00:00:02');
INSERT INTO `log_action` VALUES ('559', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:29:28', '2017-07-15 16:29:29', '00:00:01');
INSERT INTO `log_action` VALUES ('560', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:29:29', '2017-07-15 16:29:29', '00:00:01');
INSERT INTO `log_action` VALUES ('561', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:29:57', '2017-07-15 16:29:57', '00:00:01');
INSERT INTO `log_action` VALUES ('562', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:29:57', '2017-07-15 16:29:57', '00:00:00');
INSERT INTO `log_action` VALUES ('563', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:43:40', '2017-07-15 16:43:40', '00:00:01');
INSERT INTO `log_action` VALUES ('564', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:43:40', '2017-07-15 16:43:41', '00:00:01');
INSERT INTO `log_action` VALUES ('565', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 16:48:09', '2017-07-15 16:48:09', '00:00:00');
INSERT INTO `log_action` VALUES ('566', '', 'Contact.Search', '127.0.0.1', '2017-07-15 16:48:09', '2017-07-15 16:48:09', '00:00:00');
INSERT INTO `log_action` VALUES ('567', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 17:18:55', '2017-07-15 17:18:55', '00:00:01');
INSERT INTO `log_action` VALUES ('568', '', 'Contact.Search', '127.0.0.1', '2017-07-15 17:18:59', '2017-07-15 17:18:59', '00:00:01');
INSERT INTO `log_action` VALUES ('569', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 18:37:24', '2017-07-15 18:37:24', '00:00:01');
INSERT INTO `log_action` VALUES ('570', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:37:35', '2017-07-15 18:37:36', '00:00:01');
INSERT INTO `log_action` VALUES ('571', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:37:36', '2017-07-15 18:37:36', '00:00:01');
INSERT INTO `log_action` VALUES ('572', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 18:40:27', '2017-07-15 18:40:27', '00:00:00');
INSERT INTO `log_action` VALUES ('573', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:40:32', '2017-07-15 18:40:32', '00:00:01');
INSERT INTO `log_action` VALUES ('574', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:40:32', '2017-07-15 18:40:32', '00:00:00');
INSERT INTO `log_action` VALUES ('575', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 18:45:40', '2017-07-15 18:45:40', '00:00:01');
INSERT INTO `log_action` VALUES ('576', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:45:41', '2017-07-15 18:45:42', '00:00:01');
INSERT INTO `log_action` VALUES ('577', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:47:15', '2017-07-15 18:47:15', '00:00:00');
INSERT INTO `log_action` VALUES ('578', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:47:46', '2017-07-15 18:47:46', '00:00:01');
INSERT INTO `log_action` VALUES ('579', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:50:40', '2017-07-15 18:50:40', '00:00:01');
INSERT INTO `log_action` VALUES ('580', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:52:45', '2017-07-15 18:52:45', '00:00:01');
INSERT INTO `log_action` VALUES ('581', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:52', '2017-07-15 18:53:52', '00:00:01');
INSERT INTO `log_action` VALUES ('582', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:53', '2017-07-15 18:53:53', '00:00:00');
INSERT INTO `log_action` VALUES ('583', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:54', '2017-07-15 18:53:54', '00:00:01');
INSERT INTO `log_action` VALUES ('584', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:55', '2017-07-15 18:53:55', '00:00:01');
INSERT INTO `log_action` VALUES ('585', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:55', '2017-07-15 18:53:55', '00:00:00');
INSERT INTO `log_action` VALUES ('586', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:56', '2017-07-15 18:53:56', '00:00:01');
INSERT INTO `log_action` VALUES ('587', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:57', '2017-07-15 18:53:57', '00:00:00');
INSERT INTO `log_action` VALUES ('588', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:53:58', '2017-07-15 18:53:58', '00:00:00');
INSERT INTO `log_action` VALUES ('589', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:54:44', '2017-07-15 18:54:44', '00:00:00');
INSERT INTO `log_action` VALUES ('590', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:56:29', '2017-07-15 18:56:29', '00:00:00');
INSERT INTO `log_action` VALUES ('591', '', 'Contact.Search', '127.0.0.1', '2017-07-15 18:57:00', '2017-07-15 18:57:00', '00:00:01');
INSERT INTO `log_action` VALUES ('592', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:00:38', '2017-07-15 19:00:38', '00:00:02');
INSERT INTO `log_action` VALUES ('593', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:00:44', '2017-07-15 19:00:44', '00:00:01');
INSERT INTO `log_action` VALUES ('594', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:00:45', '2017-07-15 19:00:45', '00:00:01');
INSERT INTO `log_action` VALUES ('595', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:00:46', '2017-07-15 19:00:46', '00:00:01');
INSERT INTO `log_action` VALUES ('596', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:01:40', '2017-07-15 19:01:40', '00:00:00');
INSERT INTO `log_action` VALUES ('597', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:02:52', '2017-07-15 19:02:52', '00:00:00');
INSERT INTO `log_action` VALUES ('598', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:24', '2017-07-15 19:03:24', '00:00:01');
INSERT INTO `log_action` VALUES ('599', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:35', '2017-07-15 19:03:36', '00:00:01');
INSERT INTO `log_action` VALUES ('600', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:37', '2017-07-15 19:03:37', '00:00:01');
INSERT INTO `log_action` VALUES ('601', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:38', '2017-07-15 19:03:38', '00:00:01');
INSERT INTO `log_action` VALUES ('602', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:38', '2017-07-15 19:03:39', '00:00:01');
INSERT INTO `log_action` VALUES ('603', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:03:40', '2017-07-15 19:03:40', '00:00:02');
INSERT INTO `log_action` VALUES ('604', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:04:35', '2017-07-15 19:04:35', '00:00:00');
INSERT INTO `log_action` VALUES ('605', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:05:36', '2017-07-15 19:05:37', '00:00:01');
INSERT INTO `log_action` VALUES ('606', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:11:17', '2017-07-15 19:11:18', '00:00:01');
INSERT INTO `log_action` VALUES ('607', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:12:19', '2017-07-15 19:12:19', '00:00:00');
INSERT INTO `log_action` VALUES ('608', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:16:15', '2017-07-15 19:16:15', '00:00:00');
INSERT INTO `log_action` VALUES ('609', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:16:32', '2017-07-15 19:16:32', '00:00:01');
INSERT INTO `log_action` VALUES ('610', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:18:53', '2017-07-15 19:18:53', '00:00:00');
INSERT INTO `log_action` VALUES ('611', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:19:10', '2017-07-15 19:19:10', '00:00:01');
INSERT INTO `log_action` VALUES ('612', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:20:16', '2017-07-15 19:20:16', '00:00:01');
INSERT INTO `log_action` VALUES ('613', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 19:25:45', '2017-07-15 19:25:46', '00:00:01');
INSERT INTO `log_action` VALUES ('614', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:25:46', '2017-07-15 19:25:46', '00:00:00');
INSERT INTO `log_action` VALUES ('615', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:38:52', '2017-07-15 19:38:52', '00:00:01');
INSERT INTO `log_action` VALUES ('616', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:40:45', '2017-07-15 19:40:45', '00:00:01');
INSERT INTO `log_action` VALUES ('617', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:54:26', '2017-07-15 19:54:26', '00:00:01');
INSERT INTO `log_action` VALUES ('618', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:55:50', '2017-07-15 19:55:50', '00:00:00');
INSERT INTO `log_action` VALUES ('619', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:56:02', '2017-07-15 19:56:02', '00:00:00');
INSERT INTO `log_action` VALUES ('620', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:56:17', '2017-07-15 19:56:17', '00:00:00');
INSERT INTO `log_action` VALUES ('621', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:57:05', '2017-07-15 19:57:05', '00:00:01');
INSERT INTO `log_action` VALUES ('622', '', 'Contact.Search', '127.0.0.1', '2017-07-15 19:57:28', '2017-07-15 19:57:28', '00:00:00');
INSERT INTO `log_action` VALUES ('623', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:08:02', '2017-07-15 20:08:02', '00:00:00');
INSERT INTO `log_action` VALUES ('624', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:08:11', '2017-07-15 20:08:11', '00:00:01');
INSERT INTO `log_action` VALUES ('625', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:09:53', '2017-07-15 20:09:53', '00:00:01');
INSERT INTO `log_action` VALUES ('626', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:09:59', '2017-07-15 20:09:59', '00:00:00');
INSERT INTO `log_action` VALUES ('627', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:11:42', '2017-07-15 20:11:42', '00:00:01');
INSERT INTO `log_action` VALUES ('628', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:13:29', '2017-07-15 20:13:29', '00:00:00');
INSERT INTO `log_action` VALUES ('629', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:13:44', '2017-07-15 20:13:44', '00:00:01');
INSERT INTO `log_action` VALUES ('630', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:18:21', '2017-07-15 20:18:21', '00:00:01');
INSERT INTO `log_action` VALUES ('631', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:18:25', '2017-07-15 20:18:25', '00:00:01');
INSERT INTO `log_action` VALUES ('632', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:18:27', '2017-07-15 20:18:27', '00:00:00');
INSERT INTO `log_action` VALUES ('633', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:18:29', '2017-07-15 20:18:29', '00:00:00');
INSERT INTO `log_action` VALUES ('634', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:18:32', '2017-07-15 20:18:32', '00:00:01');
INSERT INTO `log_action` VALUES ('635', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:19:46', '2017-07-15 20:19:46', '00:00:01');
INSERT INTO `log_action` VALUES ('636', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:21:01', '2017-07-15 20:21:02', '00:00:01');
INSERT INTO `log_action` VALUES ('637', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:21:19', '2017-07-15 20:21:19', '00:00:01');
INSERT INTO `log_action` VALUES ('638', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:21:48', '2017-07-15 20:21:48', '00:00:00');
INSERT INTO `log_action` VALUES ('639', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:02', '2017-07-15 20:23:02', '00:00:01');
INSERT INTO `log_action` VALUES ('640', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:08', '2017-07-15 20:23:08', '00:00:01');
INSERT INTO `log_action` VALUES ('641', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:20', '2017-07-15 20:23:20', '00:00:01');
INSERT INTO `log_action` VALUES ('642', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:21', '2017-07-15 20:23:21', '00:00:00');
INSERT INTO `log_action` VALUES ('643', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:23', '2017-07-15 20:23:23', '00:00:01');
INSERT INTO `log_action` VALUES ('644', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:25', '2017-07-15 20:23:25', '00:00:01');
INSERT INTO `log_action` VALUES ('645', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:23:27', '2017-07-15 20:23:27', '00:00:00');
INSERT INTO `log_action` VALUES ('646', '', 'Account.SignIn', '127.0.0.1', '2017-07-15 20:24:42', '2017-07-15 20:24:42', '00:00:01');
INSERT INTO `log_action` VALUES ('647', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:24:42', '2017-07-15 20:24:42', '00:00:00');
INSERT INTO `log_action` VALUES ('648', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:27:00', '2017-07-15 20:27:00', '00:00:00');
INSERT INTO `log_action` VALUES ('649', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:27:05', '2017-07-15 20:27:05', '00:00:00');
INSERT INTO `log_action` VALUES ('650', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:06', '2017-07-15 20:28:06', '00:00:01');
INSERT INTO `log_action` VALUES ('651', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:08', '2017-07-15 20:28:08', '00:00:01');
INSERT INTO `log_action` VALUES ('652', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:10', '2017-07-15 20:28:10', '00:00:00');
INSERT INTO `log_action` VALUES ('653', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:12', '2017-07-15 20:28:12', '00:00:00');
INSERT INTO `log_action` VALUES ('654', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:14', '2017-07-15 20:28:14', '00:00:01');
INSERT INTO `log_action` VALUES ('655', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:15', '2017-07-15 20:28:15', '00:00:00');
INSERT INTO `log_action` VALUES ('656', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:21', '2017-07-15 20:28:22', '00:00:01');
INSERT INTO `log_action` VALUES ('657', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:22', '2017-07-15 20:28:22', '00:00:00');
INSERT INTO `log_action` VALUES ('658', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:23', '2017-07-15 20:28:23', '00:00:01');
INSERT INTO `log_action` VALUES ('659', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:24', '2017-07-15 20:28:24', '00:00:01');
INSERT INTO `log_action` VALUES ('660', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:28:43', '2017-07-15 20:28:44', '00:00:01');
INSERT INTO `log_action` VALUES ('661', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:29:28', '2017-07-15 20:29:28', '00:00:01');
INSERT INTO `log_action` VALUES ('662', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:29:31', '2017-07-15 20:29:31', '00:00:00');
INSERT INTO `log_action` VALUES ('663', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:29:33', '2017-07-15 20:29:34', '00:00:01');
INSERT INTO `log_action` VALUES ('664', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:29:35', '2017-07-15 20:29:35', '00:00:00');
INSERT INTO `log_action` VALUES ('665', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:29:38', '2017-07-15 20:29:38', '00:00:00');
INSERT INTO `log_action` VALUES ('666', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:33:41', '2017-07-15 20:33:41', '00:00:01');
INSERT INTO `log_action` VALUES ('667', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:35:16', '2017-07-15 20:35:16', '00:00:01');
INSERT INTO `log_action` VALUES ('668', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:36:22', '2017-07-15 20:36:22', '00:00:01');
INSERT INTO `log_action` VALUES ('669', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:37:39', '2017-07-15 20:37:39', '00:00:01');
INSERT INTO `log_action` VALUES ('670', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:39:45', '2017-07-15 20:39:45', '00:00:01');
INSERT INTO `log_action` VALUES ('671', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:50:41', '2017-07-15 20:50:41', '00:00:00');
INSERT INTO `log_action` VALUES ('672', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:53:10', '2017-07-15 20:53:10', '00:00:01');
INSERT INTO `log_action` VALUES ('673', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:53:19', '2017-07-15 20:53:19', '00:00:01');
INSERT INTO `log_action` VALUES ('674', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:54:57', '2017-07-15 20:54:57', '00:00:01');
INSERT INTO `log_action` VALUES ('675', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:54:59', '2017-07-15 20:54:59', '00:00:00');
INSERT INTO `log_action` VALUES ('676', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:02', '2017-07-15 20:55:02', '00:00:01');
INSERT INTO `log_action` VALUES ('677', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:03', '2017-07-15 20:55:04', '00:00:01');
INSERT INTO `log_action` VALUES ('678', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:09', '2017-07-15 20:55:09', '00:00:01');
INSERT INTO `log_action` VALUES ('679', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:16', '2017-07-15 20:55:16', '00:00:00');
INSERT INTO `log_action` VALUES ('680', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:19', '2017-07-15 20:55:19', '00:00:00');
INSERT INTO `log_action` VALUES ('681', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:40', '2017-07-15 20:55:40', '00:00:00');
INSERT INTO `log_action` VALUES ('682', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:55:48', '2017-07-15 20:55:48', '00:00:01');
INSERT INTO `log_action` VALUES ('683', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:58:42', '2017-07-15 20:58:42', '00:00:00');
INSERT INTO `log_action` VALUES ('684', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:58:54', '2017-07-15 20:58:54', '00:00:01');
INSERT INTO `log_action` VALUES ('685', '', 'Contact.Search', '127.0.0.1', '2017-07-15 20:59:26', '2017-07-15 20:59:26', '00:00:00');
INSERT INTO `log_action` VALUES ('686', '', 'Contact.Search', '127.0.0.1', '2017-07-15 21:00:10', '2017-07-15 21:00:10', '00:00:00');
INSERT INTO `log_action` VALUES ('687', '', 'Contact.Search', '127.0.0.1', '2017-07-15 21:00:56', '2017-07-15 21:00:56', '00:00:00');
INSERT INTO `log_action` VALUES ('688', '', 'Contact.Search', '127.0.0.1', '2017-07-15 21:01:50', '2017-07-15 21:01:51', '00:00:01');
INSERT INTO `log_action` VALUES ('689', '', 'Account.SignIn', '127.0.0.1', '2017-07-16 13:02:47', '2017-07-16 13:02:47', '00:00:01');
INSERT INTO `log_action` VALUES ('690', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:02:47', '2017-07-16 13:02:47', '00:00:00');
INSERT INTO `log_action` VALUES ('691', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:03:07', '2017-07-16 13:03:07', '00:00:01');
INSERT INTO `log_action` VALUES ('692', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:03:46', '2017-07-16 13:03:46', '00:00:01');
INSERT INTO `log_action` VALUES ('693', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:05:16', '2017-07-16 13:05:17', '00:00:01');
INSERT INTO `log_action` VALUES ('694', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:07:36', '2017-07-16 13:07:36', '00:00:00');
INSERT INTO `log_action` VALUES ('695', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:08:52', '2017-07-16 13:08:52', '00:00:01');
INSERT INTO `log_action` VALUES ('696', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:09:19', '2017-07-16 13:09:19', '00:00:01');
INSERT INTO `log_action` VALUES ('697', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:09:29', '2017-07-16 13:09:29', '00:00:01');
INSERT INTO `log_action` VALUES ('698', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:17:22', '2017-07-16 13:17:22', '00:00:01');
INSERT INTO `log_action` VALUES ('699', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:17:33', '2017-07-16 13:17:33', '00:00:01');
INSERT INTO `log_action` VALUES ('700', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:19:39', '2017-07-16 13:19:39', '00:00:00');
INSERT INTO `log_action` VALUES ('701', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:29:23', '2017-07-16 13:29:23', '00:00:01');
INSERT INTO `log_action` VALUES ('702', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:29:24', '2017-07-16 13:29:24', '00:00:01');
INSERT INTO `log_action` VALUES ('703', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:31:54', '2017-07-16 13:31:54', '00:00:01');
INSERT INTO `log_action` VALUES ('704', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:32:48', '2017-07-16 13:32:48', '00:00:01');
INSERT INTO `log_action` VALUES ('705', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:33:27', '2017-07-16 13:33:27', '00:00:00');
INSERT INTO `log_action` VALUES ('706', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:33:30', '2017-07-16 13:33:30', '00:00:01');
INSERT INTO `log_action` VALUES ('707', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:37:57', '2017-07-16 13:37:57', '00:00:00');
INSERT INTO `log_action` VALUES ('708', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:40:22', '2017-07-16 13:40:22', '00:00:00');
INSERT INTO `log_action` VALUES ('709', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:43:41', '2017-07-16 13:43:41', '00:00:01');
INSERT INTO `log_action` VALUES ('710', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:43:42', '2017-07-16 13:43:42', '00:00:01');
INSERT INTO `log_action` VALUES ('711', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:43:49', '2017-07-16 13:43:49', '00:00:00');
INSERT INTO `log_action` VALUES ('712', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:44:04', '2017-07-16 13:44:04', '00:00:00');
INSERT INTO `log_action` VALUES ('713', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:44:21', '2017-07-16 13:44:21', '00:00:00');
INSERT INTO `log_action` VALUES ('714', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:44:50', '2017-07-16 13:44:51', '00:00:01');
INSERT INTO `log_action` VALUES ('715', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:45:11', '2017-07-16 13:45:11', '00:00:01');
INSERT INTO `log_action` VALUES ('716', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:48:04', '2017-07-16 13:48:04', '00:00:00');
INSERT INTO `log_action` VALUES ('717', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:48:48', '2017-07-16 13:48:48', '00:00:01');
INSERT INTO `log_action` VALUES ('718', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:50:10', '2017-07-16 13:50:10', '00:00:01');
INSERT INTO `log_action` VALUES ('719', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:50:11', '2017-07-16 13:50:12', '00:00:01');
INSERT INTO `log_action` VALUES ('720', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:55:15', '2017-07-16 13:55:16', '00:00:01');
INSERT INTO `log_action` VALUES ('721', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:55:30', '2017-07-16 13:55:30', '00:00:00');
INSERT INTO `log_action` VALUES ('722', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:57:05', '2017-07-16 13:57:06', '00:00:01');
INSERT INTO `log_action` VALUES ('723', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:57:28', '2017-07-16 13:57:28', '00:00:01');
INSERT INTO `log_action` VALUES ('724', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:57:50', '2017-07-16 13:57:50', '00:00:01');
INSERT INTO `log_action` VALUES ('725', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:06', '2017-07-16 13:58:06', '00:00:00');
INSERT INTO `log_action` VALUES ('726', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:10', '2017-07-16 13:58:10', '00:00:00');
INSERT INTO `log_action` VALUES ('727', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:13', '2017-07-16 13:58:13', '00:00:00');
INSERT INTO `log_action` VALUES ('728', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:16', '2017-07-16 13:58:16', '00:00:01');
INSERT INTO `log_action` VALUES ('729', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:18', '2017-07-16 13:58:18', '00:00:01');
INSERT INTO `log_action` VALUES ('730', '', 'Contact.Search', '127.0.0.1', '2017-07-16 13:58:29', '2017-07-16 13:58:29', '00:00:00');
INSERT INTO `log_action` VALUES ('731', '', 'Account.SignIn', '127.0.0.1', '2017-07-16 18:33:13', '2017-07-16 18:33:14', '00:00:01');
INSERT INTO `log_action` VALUES ('732', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:33:15', '2017-07-16 18:33:15', '00:00:01');
INSERT INTO `log_action` VALUES ('733', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:33:30', '2017-07-16 18:33:30', '00:00:00');
INSERT INTO `log_action` VALUES ('734', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:36:22', '2017-07-16 18:36:22', '00:00:00');
INSERT INTO `log_action` VALUES ('735', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:36:27', '2017-07-16 18:36:27', '00:00:00');
INSERT INTO `log_action` VALUES ('736', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:37:59', '2017-07-16 18:37:59', '00:00:00');
INSERT INTO `log_action` VALUES ('737', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:38:04', '2017-07-16 18:38:04', '00:00:01');
INSERT INTO `log_action` VALUES ('738', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:35', '2017-07-16 18:41:35', '00:00:00');
INSERT INTO `log_action` VALUES ('739', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:38', '2017-07-16 18:41:38', '00:00:00');
INSERT INTO `log_action` VALUES ('740', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:41', '2017-07-16 18:41:41', '00:00:00');
INSERT INTO `log_action` VALUES ('741', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:44', '2017-07-16 18:41:44', '00:00:01');
INSERT INTO `log_action` VALUES ('742', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:46', '2017-07-16 18:41:47', '00:00:01');
INSERT INTO `log_action` VALUES ('743', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:41:49', '2017-07-16 18:41:49', '00:00:01');
INSERT INTO `log_action` VALUES ('744', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:45:53', '2017-07-16 18:45:53', '00:00:01');
INSERT INTO `log_action` VALUES ('745', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:46:32', '2017-07-16 18:46:32', '00:00:01');
INSERT INTO `log_action` VALUES ('746', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:50:17', '2017-07-16 18:50:17', '00:00:01');
INSERT INTO `log_action` VALUES ('747', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:50:51', '2017-07-16 18:50:51', '00:00:01');
INSERT INTO `log_action` VALUES ('748', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:51:10', '2017-07-16 18:51:10', '00:00:01');
INSERT INTO `log_action` VALUES ('749', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:51:34', '2017-07-16 18:51:34', '00:00:01');
INSERT INTO `log_action` VALUES ('750', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:51:47', '2017-07-16 18:51:47', '00:00:00');
INSERT INTO `log_action` VALUES ('751', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:52:13', '2017-07-16 18:52:13', '00:00:00');
INSERT INTO `log_action` VALUES ('752', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:52:28', '2017-07-16 18:52:28', '00:00:00');
INSERT INTO `log_action` VALUES ('753', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:53:45', '2017-07-16 18:53:45', '00:00:01');
INSERT INTO `log_action` VALUES ('754', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:57:24', '2017-07-16 18:57:24', '00:00:00');
INSERT INTO `log_action` VALUES ('755', '', 'Contact.Search', '127.0.0.1', '2017-07-16 18:58:07', '2017-07-16 18:58:07', '00:00:01');
INSERT INTO `log_action` VALUES ('756', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:41:06', '2017-07-17 14:41:06', '00:00:01');
INSERT INTO `log_action` VALUES ('757', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:41:45', '2017-07-17 14:41:45', '00:00:00');
INSERT INTO `log_action` VALUES ('758', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:41:49', '2017-07-17 14:41:50', '00:00:02');
INSERT INTO `log_action` VALUES ('759', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:41:50', '2017-07-17 14:41:50', '00:00:00');
INSERT INTO `log_action` VALUES ('760', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:42:21', '2017-07-17 14:42:22', '00:00:01');
INSERT INTO `log_action` VALUES ('761', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:43:54', '2017-07-17 14:43:54', '00:00:01');
INSERT INTO `log_action` VALUES ('762', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:44:37', '2017-07-17 14:44:38', '00:00:01');
INSERT INTO `log_action` VALUES ('763', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:49:38', '2017-07-17 14:49:38', '00:00:01');
INSERT INTO `log_action` VALUES ('764', '', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:49:49', '2017-07-17 14:49:51', '00:00:03');
INSERT INTO `log_action` VALUES ('765', 'bijinshu', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:50:25', '2017-07-17 14:50:25', '00:00:00');
INSERT INTO `log_action` VALUES ('766', 'bijinshu', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:50:34', '2017-07-17 14:50:34', '00:00:01');
INSERT INTO `log_action` VALUES ('767', 'bijinshu', 'Account.SignIn', '127.0.0.1', '2017-07-17 14:50:34', '2017-07-17 14:50:34', '00:00:01');
INSERT INTO `log_action` VALUES ('768', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:04:22', '2017-07-17 16:04:22', '00:00:01');
INSERT INTO `log_action` VALUES ('769', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:04:28', '2017-07-17 16:04:45', '00:00:17');
INSERT INTO `log_action` VALUES ('770', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:06:13', '2017-07-17 16:06:13', '00:00:00');
INSERT INTO `log_action` VALUES ('771', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:06:15', '2017-07-17 16:06:28', '00:00:13');
INSERT INTO `log_action` VALUES ('772', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:10:09', '2017-07-17 16:10:10', '00:00:01');
INSERT INTO `log_action` VALUES ('773', '', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:10:12', '2017-07-17 16:10:14', '00:00:03');
INSERT INTO `log_action` VALUES ('774', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:11:00', '2017-07-17 16:11:00', '00:00:00');
INSERT INTO `log_action` VALUES ('775', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:39:28', '2017-07-17 16:39:28', '00:00:02');
INSERT INTO `log_action` VALUES ('776', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:39:30', '2017-07-17 16:39:44', '00:00:15');
INSERT INTO `log_action` VALUES ('777', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:41:10', '2017-07-17 16:41:10', '00:00:01');
INSERT INTO `log_action` VALUES ('778', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:41:23', '2017-07-17 16:41:23', '00:00:01');
INSERT INTO `log_action` VALUES ('779', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:41:25', '2017-07-17 16:41:29', '00:00:05');
INSERT INTO `log_action` VALUES ('780', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:41:31', '2017-07-17 16:41:31', '00:00:01');
INSERT INTO `log_action` VALUES ('781', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:41:34', '2017-07-17 16:41:55', '00:00:21');
INSERT INTO `log_action` VALUES ('782', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:49:59', '2017-07-17 16:50:00', '00:00:01');
INSERT INTO `log_action` VALUES ('783', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:05', '2017-07-17 16:50:07', '00:00:02');
INSERT INTO `log_action` VALUES ('784', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:07', '2017-07-17 16:50:07', '00:00:00');
INSERT INTO `log_action` VALUES ('785', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:07', '2017-07-17 16:50:07', '00:00:00');
INSERT INTO `log_action` VALUES ('786', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:26', '2017-07-17 16:50:26', '00:00:01');
INSERT INTO `log_action` VALUES ('787', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:27', '2017-07-17 16:50:27', '00:00:01');
INSERT INTO `log_action` VALUES ('788', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:29', '2017-07-17 16:50:29', '00:00:02');
INSERT INTO `log_action` VALUES ('789', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:30', '2017-07-17 16:50:31', '00:00:01');
INSERT INTO `log_action` VALUES ('790', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 16:50:32', '2017-07-17 16:50:32', '00:00:01');
INSERT INTO `log_action` VALUES ('791', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 17:51:17', '2017-07-17 17:51:17', '00:00:01');
INSERT INTO `log_action` VALUES ('792', 'bijinshu', 'Account.SignIn', '10.10.133.209,192.168.86.1', '2017-07-17 17:51:19', '2017-07-17 17:51:20', '00:00:02');
INSERT INTO `log_action` VALUES ('793', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 17:51:20', '2017-07-17 17:51:20', '00:00:00');
INSERT INTO `log_action` VALUES ('794', 'bijinshu', 'Contact.Index', '10.10.133.209,192.168.86.1', '2017-07-17 17:51:21', '2017-07-17 17:51:21', '00:00:01');

-- ----------------------------
-- Table structure for `log_exception`
-- ----------------------------
DROP TABLE IF EXISTS `log_exception`;
CREATE TABLE `log_exception` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Path` varchar(200) NOT NULL COMMENT '调用路径',
  `InputParameter` text NOT NULL COMMENT '输入参数',
  `Message` varchar(600) NOT NULL COMMENT '描述',
  `StackTrace` text COMMENT '堆栈信息',
  `ClientIP` varchar(20) NOT NULL DEFAULT '' COMMENT '客户端调用IP',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_exception
-- ----------------------------

-- ----------------------------
-- Table structure for `log_login`
-- ----------------------------
DROP TABLE IF EXISTS `log_login`;
CREATE TABLE `log_login` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) DEFAULT NULL COMMENT '用户名称',
  `LoginIP` varchar(64) DEFAULT NULL COMMENT '客户端登录IP',
  `Status` varchar(60) NOT NULL COMMENT '登录状态',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`),
  KEY `AccountName` (`UserName`),
  CONSTRAINT `log_login_ibfk_1` FOREIGN KEY (`UserName`) REFERENCES `rm_users` (`UserName`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_login
-- ----------------------------
INSERT INTO `log_login` VALUES ('7', 'bijinshu', '127.0.0.1', '0', '2017-07-14 16:08:23');
INSERT INTO `log_login` VALUES ('8', 'bijinshu', '10.10.133.209,192.168.86.1', '0', '2017-07-14 16:24:11');
INSERT INTO `log_login` VALUES ('9', 'bijinshu', '10.10.133.209,192.168.86.1', '0', '2017-07-14 16:28:12');
INSERT INTO `log_login` VALUES ('10', 'bijinshu', '10.10.133.209,192.168.86.1', '0', '2017-07-14 16:32:19');
INSERT INTO `log_login` VALUES ('11', 'bijinshu', '10.10.133.209,192.168.86.1', '0', '2017-07-14 16:38:04');
INSERT INTO `log_login` VALUES ('12', 'bijinshu', '127.0.0.1', '0', '2017-07-14 16:42:27');
INSERT INTO `log_login` VALUES ('13', 'bijinshu', '10.10.133.209,192.168.86.1', '成功', '2017-07-17 17:51:20');

-- ----------------------------
-- Table structure for `rm_resources`
-- ----------------------------
DROP TABLE IF EXISTS `rm_resources`;
CREATE TABLE `rm_resources` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Url` varchar(600) DEFAULT NULL,
  `Summary` varchar(160) DEFAULT NULL,
  `Method` varchar(8) DEFAULT NULL,
  `Action` varchar(64) DEFAULT NULL,
  `Controller` varchar(255) DEFAULT NULL COMMENT '资源类型',
  `Remark` text,
  `Message` varchar(80) DEFAULT NULL,
  `Disabled` bit(1) NOT NULL COMMENT '是否禁用',
  `IsCommon` bit(1) NOT NULL COMMENT '是否公用',
  `IsAnonymous` bit(1) NOT NULL COMMENT '是否允许匿名访问',
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8 COMMENT='所有API资源';

-- ----------------------------
-- Records of rm_resources
-- ----------------------------
INSERT INTO `rm_resources` VALUES ('1', 'api/Contact/SearchName', '搜寻联系人', 'POST', 'SearchName', 'GrainManage.Server.Controllers.ContactController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('2', 'api/Contact/SearchArea', '搜寻区域', 'POST', 'SearchArea', 'GrainManage.Server.Controllers.ContactController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('3', 'api/Contact/SearchAddress', '搜寻地址', 'POST', 'SearchAddress', 'GrainManage.Server.Controllers.ContactController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('4', 'api/Contact/GetByID', '根据Id获取联系人', 'POST', 'GetByID', 'GrainManage.Server.Controllers.ContactController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('5', 'api/Contact/Search', '搜索联系人', 'POST', 'Search', 'GrainManage.Server.Controllers.ContactController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('6', 'api/Contact/Insert', '添加联系人', 'POST', 'Insert', 'GrainManage.Server.Controllers.ContactController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('7', 'api/Contact/Update', '更新联系人', 'POST', 'Update', 'GrainManage.Server.Controllers.ContactController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('8', 'api/Contact/Delete', '删除联系人', 'POST', 'Delete', 'GrainManage.Server.Controllers.ContactController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('9', 'api/Account/SignIn', '用户登录', 'POST', 'SignIn', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('10', 'api/Account/ResetPassword', '重设密码', 'POST', 'ResetPassword', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('11', 'api/Account/ManageAccount', '管理账号', 'POST', 'ManageAccount', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('12', 'api/Account/Register', '注册', 'POST', 'Register', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('13', 'api/Account/SignOut', '注销', 'POST', 'SignOut', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('14', 'api/Account/GetEncryptKey', '获取加密密钥', 'POST', 'GetEncryptKey', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('15', 'api/Account/ChangePassword', '更改密码', 'POST', 'ChangePassword', 'GrainManage.Server.Controllers.AccountController', null, '新增', '', '', '', '2016-03-15 20:27:34', null);
INSERT INTO `rm_resources` VALUES ('16', 'api/Column/GetHeader', '获取中文列名', 'POST', 'GetHeader', 'GrainManage.Server.Controllers.ColumnController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('17', 'api/Column/GetColumnHeader', '获取英文到中文映射字典', 'POST', 'GetColumnHeader', 'GrainManage.Server.Controllers.ColumnController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('18', 'api/District/GetByID', '根据Id获取地址信息', 'POST', 'GetByID', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('19', 'api/District/Search', '根据名称搜索', 'POST', 'Search', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('20', 'api/District/GetFatherName', '根据Id获取父级地址', 'POST', 'GetFatherName', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('21', 'api/District/GetChildName', '根据Id获取子地址', 'POST', 'GetChildName', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('22', 'api/District/GetUpwardDistrict', '获取父级所有地址，并限制最大搜索级数', 'POST', 'GetUpwardDistrict', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('23', 'api/District/GetChildDistrict', '获取子级所有地址，并限制最大搜索级数', 'POST', 'GetChildDistrict', 'GrainManage.Server.Controllers.DistrictController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:39:06');
INSERT INTO `rm_resources` VALUES ('24', 'api/Common/PublicKey', '以文件方式返回公钥', 'GET', 'PublicKey', 'GrainManage.Server.Controllers.CommonController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('25', 'api/Common/PublicKey', '以文件方式返回公钥', 'POST', 'PublicKey', 'GrainManage.Server.Controllers.CommonController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('26', 'api/Image/GetImages', '获取图片元数据', 'POST', 'GetImages', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('27', 'api/Image/GetImageFile', '获取图片内容', 'POST', 'GetImageFile', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('28', 'api/Image/GetImageUrl', '获取图片Url', 'POST', 'GetImageUrl', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('29', 'api/Image/DownLoad', '下载图片', 'POST', 'DownLoad', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('30', 'api/Image/Insert', '添加图片', 'POST', 'Insert', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('31', 'api/Image/Update', '更新图片信息', 'POST', 'Update', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('32', 'api/Image/Delete', '删除图片', 'POST', 'Delete', 'GrainManage.Server.Controllers.ImageController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('33', 'api/Price/GetByID', '获取单条价格信息', 'POST', 'GetByID', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('34', 'api/Price/GetRecentPriceByGrain', '获取单条最新价格信息', 'POST', 'GetRecentPriceByGrain', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('35', 'api/Price/SearchRecentPrice', '搜索最新价格信息', 'POST', 'SearchRecentPrice', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('36', 'api/Price/SearchPrice', '搜索价格历史信息', 'POST', 'SearchPrice', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('37', 'api/Price/Insert', '添加新价格', 'POST', 'Insert', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('38', 'api/Price/Update', '更改价格', 'POST', 'Update', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('39', 'api/Price/Delete', '删除价格', 'POST', 'Delete', 'GrainManage.Server.Controllers.PriceController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('40', 'api/MetaData/GetNameByCategory', '按类别获取元数据信息', 'POST', 'GetNameByCategory', 'GrainManage.Server.Controllers.MetaDataController', null, '过时', '', '', '', '2016-03-15 20:27:34', '2017-07-13 17:47:56');
INSERT INTO `rm_resources` VALUES ('41', 'api/Trade/GetByID', '获取单条交易信息', 'POST', 'GetByID', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('42', 'api/Trade/GetDetailByContactID', '根据联系人获取交易明细', 'POST', 'GetDetailByContactID', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('43', 'api/Trade/SearchDetail', '搜索交易历史', 'POST', 'SearchDetail', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('44', 'api/Trade/GetTotal', '统计交易情况', 'POST', 'GetTotal', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('45', 'api/Trade/GetTotalByArea', '按地区统计交易情况', 'POST', 'GetTotalByArea', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('46', 'api/Trade/GetTotalByContactArea', '按联系人和地区统计交易情况', 'POST', 'GetTotalByContactArea', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('47', 'api/Trade/Insert', '添加交易记录', 'POST', 'Insert', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('48', 'api/Trade/Update', '更改交易记录', 'POST', 'Update', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('49', 'api/Trade/Delete', '删除交易记录', 'POST', 'Delete', 'GrainManage.Server.Controllers.TradeController', null, '方法描述变更', '', '', '', '2016-03-15 20:27:34', '2016-03-15 20:55:12');
INSERT INTO `rm_resources` VALUES ('50', 'api/Image/GetImageUrl?imageID={imageID}&userName={userName}', null, 'GET', 'GetImageUrl', 'GrainManage.Server.Controllers.ImageController', null, '新增', '', '', '', '2017-07-13 17:47:56', null);
INSERT INTO `rm_resources` VALUES ('51', 'api/MetaData/GetNameByType', '按类别获取元数据信息', 'POST', 'GetNameByType', 'GrainManage.Server.Controllers.MetaDataController', null, '新增', '', '', '', '2017-07-13 17:47:56', null);

-- ----------------------------
-- Table structure for `rm_roles`
-- ----------------------------
DROP TABLE IF EXISTS `rm_roles`;
CREATE TABLE `rm_roles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Remark` varchar(600) DEFAULT NULL,
  `CheckApi` bit(1) NOT NULL COMMENT '是否需要平台加强安全性限制',
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='系统角色，每个子系统都应该建立一个对应角色';

-- ----------------------------
-- Records of rm_roles
-- ----------------------------
INSERT INTO `rm_roles` VALUES ('1', '超级管理员', null, '', '2016-03-05 18:09:24');
INSERT INTO `rm_roles` VALUES ('2', '普通用户', null, '', '2016-03-05 18:09:47');

-- ----------------------------
-- Table structure for `rm_role_resources`
-- ----------------------------
DROP TABLE IF EXISTS `rm_role_resources`;
CREATE TABLE `rm_role_resources` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) NOT NULL,
  `ResourceId` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_roleid_apprightid` (`RoleId`,`ResourceId`),
  KEY `fk_role_api_resource_id` (`ResourceId`),
  CONSTRAINT `fk_role_api_resource_id` FOREIGN KEY (`ResourceId`) REFERENCES `rm_resources` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_role_id` FOREIGN KEY (`RoleId`) REFERENCES `rm_roles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='每个角色拥有的权限';

-- ----------------------------
-- Records of rm_role_resources
-- ----------------------------

-- ----------------------------
-- Table structure for `rm_users`
-- ----------------------------
DROP TABLE IF EXISTS `rm_users`;
CREATE TABLE `rm_users` (
  `UserName` varchar(20) NOT NULL COMMENT '用户名称、登录名称',
  `Pwd` varchar(42) NOT NULL COMMENT '密码',
  `Status` smallint(6) NOT NULL COMMENT '0:未激活 1:启用 2:禁用',
  `RealName` varchar(40) DEFAULT NULL COMMENT '真实姓名',
  `CellPhone` char(11) DEFAULT NULL COMMENT '电话',
  `Email` varchar(64) DEFAULT NULL COMMENT '邮箱',
  `Guid` varchar(36) DEFAULT NULL,
  `EncryptKey` char(8) DEFAULT NULL COMMENT '加密密钥',
  `ResetCount` int(11) DEFAULT '0' COMMENT '密码尝试次数',
  `Remark` varchar(200) DEFAULT NULL COMMENT '附加描述',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `LastActive` datetime DEFAULT NULL COMMENT '上次活动时间',
  PRIMARY KEY (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of rm_users
-- ----------------------------
INSERT INTO `rm_users` VALUES ('bijinshu', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', '1', null, '15801992799', '914023961@qq.com', '4d2b5668-6b3f-46ae-be57-41afc0e7a0e6', 'SZtkxiUt', '0', null, '2016-01-05 18:44:49', '2017-07-17 17:51:20');
INSERT INTO `rm_users` VALUES ('jack', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', '0', null, '15882402032', 'bijinshu@126.com', '4fe87fabb39911e5adb864006a11eb35', 'wRqpkGTm', '0', null, '2016-01-05 18:44:49', '2016-01-05 18:44:49');
INSERT INTO `rm_users` VALUES ('testadmin', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', '0', null, '15801992799', 'bijinshu@163.com', '4fe89ce9b39911e5adb864006a11eb35', 'P4PSU3hj', '0', null, '2016-01-05 18:44:49', '2016-01-05 18:44:49');
INSERT INTO `rm_users` VALUES ('testroot', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', '0', null, '15801992799', 'bijinshu@163.com', '4fe8b78eb39911e5adb864006a11eb35', 'ZYxZuol', '0', null, '2016-01-05 18:44:49', '2016-01-05 18:44:49');

-- ----------------------------
-- Table structure for `rm_user_roles`
-- ----------------------------
DROP TABLE IF EXISTS `rm_user_roles`;
CREATE TABLE `rm_user_roles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_user_role` (`UserName`,`RoleId`),
  KEY `fk_role_id_3` (`RoleId`),
  CONSTRAINT `fk_role_id_3` FOREIGN KEY (`RoleId`) REFERENCES `rm_roles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_user_name` FOREIGN KEY (`UserName`) REFERENCES `rm_users` (`UserName`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户-角色表';

-- ----------------------------
-- Records of rm_user_roles
-- ----------------------------
INSERT INTO `rm_user_roles` VALUES ('1', 'bijinshu', '1');

-- ----------------------------
-- Table structure for `sys_metadata`
-- ----------------------------
DROP TABLE IF EXISTS `sys_metadata`;
CREATE TABLE `sys_metadata` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Content` varchar(60) NOT NULL COMMENT '内容',
  `TypeCode` varchar(20) DEFAULT NULL COMMENT '类型编码',
  `Remark` varchar(60) DEFAULT NULL COMMENT '附件描述',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_metadata
-- ----------------------------
INSERT INTO `sys_metadata` VALUES ('1', '小麦', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('2', '收购', 'TradeType', '交易类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('3', '水稻', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('4', '燕麦', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('5', '玉米', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('6', '花生', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('7', '菜籽', 'GrainType', '作物类型', '2016-01-05 19:16:59');
INSERT INTO `sys_metadata` VALUES ('8', '销售', 'TradeType', '交易类型', '2016-01-05 19:16:59');
