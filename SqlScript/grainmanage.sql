/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : grainmanage

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2017-07-26 18:39:00
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
  `QQ` varchar(20) DEFAULT '' COMMENT 'QQ',
  `Weixin` varchar(60) DEFAULT NULL,
  `Email` varchar(64) DEFAULT '' COMMENT '邮箱',
  `Address` varchar(100) DEFAULT '' COMMENT '地址',
  `Remark` varchar(600) DEFAULT '' COMMENT '附加描述',
  `Creator` varchar(32) NOT NULL DEFAULT '' COMMENT '创建者',
  `Created` datetime NOT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ContactName` (`ContactName`,`CellPhone`,`Creator`),
  KEY `bm_contact_ibfk_2` (`Creator`),
  CONSTRAINT `bm_contact_ibfk_2` FOREIGN KEY (`Creator`) REFERENCES `rm_user` (`Guid`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_contact
-- ----------------------------
INSERT INTO `bm_contact` VALUES ('1', '张海川', '男', '2016-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '八集', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2016-04-05 16:47:13');
INSERT INTO `bm_contact` VALUES ('2', '李玉飞', '女', '1989-06-06', '15801992799', '914023961', null, 'bijinshu@163.com', '西王码', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2016-04-05 16:59:26');
INSERT INTO `bm_contact` VALUES ('3', '王亮亮', '男', '2017-07-20', '15801992799', '914023961', null, 'bijinshu@163.com', '李祠堂', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2017-07-21 17:07:42');
INSERT INTO `bm_contact` VALUES ('4', '张思贤', '男', '1988-02-22', '15801992799', '914023961', null, 'bijinshu@163.com', '六塘', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2016-05-17 18:01:29');
INSERT INTO `bm_contact` VALUES ('5', '刘江', '男', '1986-02-09', '15801992799', '914023961', null, 'bijinshu@163.com', '泓北', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2017-07-21 16:36:18');
INSERT INTO `bm_contact` VALUES ('6', '鲍菲菲', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '大石渡', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('7', '成杰', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '芦东', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2017-07-21 16:59:38');
INSERT INTO `bm_contact` VALUES ('8', '陈千业', '男', '1968-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '董荡', null, '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', '2016-04-05 17:28:26');
INSERT INTO `bm_contact` VALUES ('9', '齐昊', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '朱圩', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('10', '任思', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '刘庄', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('11', '贾亮', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '张刘', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('12', '何远', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '育红', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('13', '文一毫', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '河东', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('14', '鲁云', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '桥西', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('15', '毛强国', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '桥南', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('16', '陈桥锋', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '合兴', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('17', '秦汉', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '葛郑', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('18', '李双江', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '倪荡', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('19', '贝乐石', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '马洼', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('20', '关楚生', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '葛荡', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('21', '楚博雄', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '八集农科', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('22', '张一凡', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '八集', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('23', '刘玉生', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '桥西', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('24', '吴雪奇', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '桥南', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('25', '赵海', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '合兴', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('26', '江涛', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '合兴', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('27', '萧见浪', '男', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '合兴', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('28', '殷了', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '合兴', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('29', '薛子琼', '女', '1980-02-02', '15801992799', '914023961', null, 'bijinshu@163.com', '桥西', '', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('30', '圣诞快乐', '女', '2017-07-21', '15825789546', null, null, null, 'sddfs', null, '16ddd97b6c4611e7bd7764006a11eb35', '2017-07-20 18:40:40', '2017-07-21 18:46:14');

-- ----------------------------
-- Table structure for `bm_image`
-- ----------------------------
DROP TABLE IF EXISTS `bm_image`;
CREATE TABLE `bm_image` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ImageName` varchar(64) NOT NULL COMMENT '图片名称',
  `Guid` char(32) NOT NULL COMMENT '编号',
  `Remark` text COMMENT '备注',
  `Creator` varchar(32) DEFAULT '' COMMENT '创建者',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Guid` (`Guid`),
  UNIQUE KEY `ImageName` (`ImageName`,`Creator`),
  KEY `bm_image_ibfk_1` (`Creator`),
  CONSTRAINT `bm_image_ibfk_1` FOREIGN KEY (`Creator`) REFERENCES `rm_user` (`Guid`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_image
-- ----------------------------
INSERT INTO `bm_image` VALUES ('1', 'abacus.ico', '4fb11d10b39911e5adb864006a11eb35', '~/Data/abacus.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('2', 'bamboo.ico', '4fbc7316b39911e5adb864006a11eb35', '~/Data/bamboo.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('3', 'barrel.ico', '4fbc750cb39911e5adb864006a11eb35', '~/Data/barrel.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('4', 'blue and white porcelain.ico', '4fbc7654b39911e5adb864006a11eb35', '~/Data/blue and white porcelain.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('5', 'book.ico', '4fbc7797b39911e5adb864006a11eb35', '~/Data/book.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('6', 'chair.ico', '4fbc78c5b39911e5adb864006a11eb35', '~/Data/chair.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('7', 'chopsticks.ico', '4fbc79f3b39911e5adb864006a11eb35', '~/Data/chopsticks.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('8', 'coin.ico', '4fbc7b1eb39911e5adb864006a11eb35', '~/Data/coin.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('9', 'fan.ico', '4fbc7c3ab39911e5adb864006a11eb35', '~/Data/fan.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('10', 'ink-stone.ico', '4fbc7d60b39911e5adb864006a11eb35', '~/Data/ink-stone.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('11', 'penholder.ico', '4fbc7e7fb39911e5adb864006a11eb35', '~/Data/penholder.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('12', 'plate.ico', '4fbc7f9eb39911e5adb864006a11eb35', '~/Data/plate.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('13', 'scrolls.ico', '4fbc80b8b39911e5adb864006a11eb35', '~/Data/scrolls.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('14', 'sword.ico', '4fbc81d7b39911e5adb864006a11eb35', '~/Data/sword.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('15', 'token.ico', '4fbc82eeb39911e5adb864006a11eb35', '~/Data/token.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('16', 'umbrella.ico', '4fbc840db39911e5adb864006a11eb35', '~/Data/umbrella.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('17', 'vase.ico', '4fbc8533b39911e5adb864006a11eb35', '~/Data/vase.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('18', 'wooden bed.ico', '4fbc865bb39911e5adb864006a11eb35', '~/Data/wooden bed.ico', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('19', 'loading progress.gif', '4fbc8780b39911e5adb864006a11eb35', '~/Data/loading progress.gif', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('20', 'loading Tai Chi.gif', '4fbc8909b39911e5adb864006a11eb35', '~/Data/loading Tai Chi.gif', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('21', 'loading rotation.gif', '4fbc8a3ab39911e5adb864006a11eb35', '~/Data/loading rotation.gif', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('22', 'login_background.jpg', '4fbc8b62b39911e5adb864006a11eb35', '~/Data/login_background.jpg', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);
INSERT INTO `bm_image` VALUES ('23', 'login_title.jpg', '4fbc8c8db39911e5adb864006a11eb35', '~/Data/login_title.jpg', '16ddd97b6c4611e7bd7764006a11eb35', '2016-01-05 18:44:49', null);

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
  `Creator` varchar(32) NOT NULL DEFAULT '' COMMENT '创建者',
  `Created` datetime NOT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  KEY `bm_price_ibfk_2` (`Creator`),
  CONSTRAINT `bm_price_ibfk_2` FOREIGN KEY (`Creator`) REFERENCES `rm_user` (`Guid`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_price
-- ----------------------------
INSERT INTO `bm_price` VALUES ('1', '玉米', '2.0100', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('2', '大稻', '2.5200', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2007-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('3', '小稻', '2.3300', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('4', '小麦', '2.0400', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2007-10-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('5', '菜籽', '3.6500', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-16 08:40:22', null);
INSERT INTO `bm_price` VALUES ('6', '花生', '3.0600', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2010-10-17 08:40:22', null);
INSERT INTO `bm_price` VALUES ('7', '大稻', '2.5200', '收购', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2012-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('8', '玉米', '2.3300', '销售', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2012-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('9', '玉米', '2.2900', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-18 08:40:22', null);
INSERT INTO `bm_price` VALUES ('10', '大稻', '2.6000', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2007-10-19 08:40:22', null);
INSERT INTO `bm_price` VALUES ('11', '小稻', '2.4200', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-20 08:40:22', null);
INSERT INTO `bm_price` VALUES ('12', '小麦', '2.1300', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2007-10-21 08:40:22', null);
INSERT INTO `bm_price` VALUES ('13', '菜籽', '3.7400', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2007-10-22 08:40:22', null);
INSERT INTO `bm_price` VALUES ('14', '花生', '3.1700', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2010-10-23 08:40:22', null);
INSERT INTO `bm_price` VALUES ('15', '玉米', '2.2200', '收购', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2008-12-24 08:40:22', null);
INSERT INTO `bm_price` VALUES ('16', '大稻', '2.7400', '销售', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2008-12-25 08:40:22', null);
INSERT INTO `bm_price` VALUES ('17', '小稻', '2.6600', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2008-12-26 08:40:22', null);
INSERT INTO `bm_price` VALUES ('18', '小麦', '2.0800', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2008-12-27 08:40:22', null);
INSERT INTO `bm_price` VALUES ('19', '菜籽', '3.4000', '销售', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2008-12-28 08:40:22', null);
INSERT INTO `bm_price` VALUES ('20', '花生', '2.6700', '销售', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2008-10-29 08:40:22', null);
INSERT INTO `bm_price` VALUES ('21', '玉米', '2.4100', '收购', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2009-02-01 08:40:22', null);
INSERT INTO `bm_price` VALUES ('22', '大稻', '2.8300', '销售', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2009-02-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('23', '小稻', '2.4500', '收购', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2009-02-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('24', '小麦', '2.0700', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2009-02-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('25', '菜籽', '4.4900', '收购', '元/千克', '16ddd97b6c4611e7bd7764006a11eb35', '2009-02-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('26', '花生', '4.8900', '收购', '元/千克', '16dddcff6c4611e7bd7764006a11eb35', '2009-02-16 08:40:22', null);

-- ----------------------------
-- Table structure for `bm_trade`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade`;
CREATE TABLE `bm_trade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactId` int(11) DEFAULT NULL COMMENT '客户Id',
  `Grain` varchar(40) NOT NULL DEFAULT '' COMMENT '作物名称',
  `Price` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '计划价格',
  `Weight` decimal(20,2) DEFAULT '0.00' COMMENT '重量',
  `ActualMoney` decimal(20,2) DEFAULT '0.00' COMMENT '成交价格',
  `TradeType` varchar(20) NOT NULL DEFAULT '' COMMENT '收购、销售',
  `Position` varchar(60) DEFAULT NULL,
  `PositionDesc` varchar(80) DEFAULT NULL,
  `Remark` varchar(6000) DEFAULT '',
  `Creator` varchar(32) DEFAULT '' COMMENT '创建者',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `Modified` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  KEY `bm_trade_ibfk_3` (`Creator`),
  CONSTRAINT `bm_trade_ibfk_3` FOREIGN KEY (`Creator`) REFERENCES `rm_user` (`Guid`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade
-- ----------------------------
INSERT INTO `bm_trade` VALUES ('1', '1', '玉米', '2.2200', '306.00', '679.32', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('2', '2', '大稻', '2.7400', '316.00', '865.84', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('3', '3', '小稻', '2.6600', '306.00', '813.96', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('4', '4', '小麦', '2.0800', '208.00', '432.64', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('5', '5', '菜籽', '3.4000', '306.00', '1040.40', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('6', '6', '花生', '2.6700', '306.00', '817.02', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('7', '7', '玉米', '2.4100', '306.00', '737.46', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('8', '8', '大稻', '2.8300', '306.00', '865.98', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('9', '9', '小稻', '2.4500', '306.00', '749.70', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('10', '10', '小麦', '2.0700', '306.00', '633.42', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('11', '11', '菜籽', '4.4900', '306.00', '1373.94', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('12', '12', '花生', '4.8900', '316.00', '1545.24', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('13', '13', '玉米', '2.0100', '406.00', '816.06', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('14', '14', '大稻', '2.5200', '306.00', '771.12', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('15', '15', '小稻', '2.3300', '306.00', '712.98', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('16', '16', '小麦', '2.0400', '306.00', '624.24', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('17', '17', '菜籽', '3.6500', '306.00', '1116.90', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-06-01 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('18', '18', '花生', '3.0600', '316.00', '966.96', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2006-08-02 14:22:00', null);
INSERT INTO `bm_trade` VALUES ('19', '19', '大稻', '2.5200', '306.00', '771.12', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2005-07-02 13:47:03', null);
INSERT INTO `bm_trade` VALUES ('20', '20', '玉米', '2.3300', '406.00', '945.98', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2004-09-02 08:47:03', null);
INSERT INTO `bm_trade` VALUES ('21', '21', '玉米', '2.2900', '306.00', '700.74', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2004-09-02 08:50:00', null);
INSERT INTO `bm_trade` VALUES ('22', '22', '大稻', '2.6000', '306.00', '795.60', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2006-01-02 09:47:56', null);
INSERT INTO `bm_trade` VALUES ('23', '23', '小稻', '2.4200', '306.00', '740.52', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2006-01-02 09:50:26', null);
INSERT INTO `bm_trade` VALUES ('24', '24', '小麦', '2.1300', '306.00', '651.78', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2010-11-03 10:00:00', null);
INSERT INTO `bm_trade` VALUES ('25', '1', '菜籽', '3.7400', '306.00', '1144.44', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2010-08-04 18:45:43', null);
INSERT INTO `bm_trade` VALUES ('26', '1', '花生', '3.1700', '306.00', '970.02', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2009-12-06 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('27', '2', '玉米', '2.2200', '306.00', '679.32', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('28', '2', '大稻', '2.7400', '316.00', '865.84', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2010-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('29', '2', '小稻', '2.6600', '316.00', '840.56', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2010-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('30', '20', '小麦', '2.0800', '306.00', '636.48', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2010-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('31', '18', '菜籽', '3.4000', '306.00', '1040.40', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2010-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('32', '18', '花生', '2.6700', '306.00', '817.02', '收购', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2010-12-05 16:36:09', null);
INSERT INTO `bm_trade` VALUES ('33', '16', '玉米', '2.4100', '306.00', '737.46', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('34', '16', '大稻', '2.8300', '316.00', '894.28', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2006-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('35', '7', '小稻', '2.4500', '406.00', '994.70', '收购', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2005-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('36', '8', '小麦', '2.0700', '306.00', '633.42', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2007-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('37', '15', '菜籽', '4.4900', '306.00', '1373.94', '销售', null, null, '', '16ddd97b6c4611e7bd7764006a11eb35', '2006-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('38', '9', '花生', '4.8900', '306.00', '1496.34', '销售', null, null, '', '16dddcff6c4611e7bd7764006a11eb35', '2009-12-05 16:36:09', null);

-- ----------------------------
-- Table structure for `log_action`
-- ----------------------------
DROP TABLE IF EXISTS `log_action`;
CREATE TABLE `log_action` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户Id',
  `Path` varchar(200) NOT NULL COMMENT '动作名称',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '访问端IP',
  `Method` varchar(6) NOT NULL DEFAULT '',
  `Status` varchar(60) NOT NULL DEFAULT '',
  `StartTime` datetime NOT NULL COMMENT '调用开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '调用结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_action
-- ----------------------------

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
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '客户端调用IP',
  `Created` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_login
-- ----------------------------

-- ----------------------------
-- Table structure for `rm_role`
-- ----------------------------
DROP TABLE IF EXISTS `rm_role`;
CREATE TABLE `rm_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Remark` varchar(600) DEFAULT NULL,
  `Auths` varchar(600) NOT NULL DEFAULT '',
  `CheckApi` bit(1) NOT NULL COMMENT '是否需要平台加强安全性限制',
  `Created` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='系统角色，每个子系统都应该建立一个对应角色';

-- ----------------------------
-- Records of rm_role
-- ----------------------------
INSERT INTO `rm_role` VALUES ('1', '超级管理员', null, '', '', '2016-03-05 18:09:24');
INSERT INTO `rm_role` VALUES ('2', '普通用户', null, '', '', '2016-03-05 18:09:47');
INSERT INTO `rm_role` VALUES ('3', '粮食商贩', null, '', '', '2017-07-19 18:27:34');

-- ----------------------------
-- Table structure for `rm_user`
-- ----------------------------
DROP TABLE IF EXISTS `rm_user`;
CREATE TABLE `rm_user` (
  `Guid` varchar(32) NOT NULL COMMENT '全局唯一编号',
  `UserName` varchar(20) NOT NULL COMMENT '用户名称、登录名称',
  `Pwd` varchar(42) NOT NULL COMMENT '密码',
  `Gender` char(1) DEFAULT NULL COMMENT '性别',
  `Status` smallint(6) NOT NULL COMMENT '0:未激活 1:启用 2:禁用',
  `NickName` varchar(20) DEFAULT NULL COMMENT '昵称',
  `CellPhone` char(11) DEFAULT NULL COMMENT '电话',
  `Email` varchar(64) DEFAULT NULL COMMENT '邮箱',
  `QQ` varchar(20) DEFAULT NULL,
  `Weixin` varchar(20) DEFAULT NULL,
  `Remark` varchar(200) DEFAULT NULL COMMENT '附加描述',
  `Created` datetime DEFAULT NULL COMMENT '创建时间',
  `LastActive` datetime DEFAULT NULL COMMENT '上次活动时间',
  `Roles` varchar(200) NOT NULL DEFAULT '',
  PRIMARY KEY (`Guid`),
  KEY `uq_user_name` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of rm_user
-- ----------------------------
INSERT INTO `rm_user` VALUES ('16ddd97b6c4611e7bd7764006a11eb35', 'bijinshu', '9adcb29710e807607b683f62e555c22dc5659713', '男', '1', null, '15801992799', '914023961@qq.com', '0', null, 'bijinshu', '2016-01-05 18:44:49', '2017-07-25 16:11:56', '');
INSERT INTO `rm_user` VALUES ('16dddca46c4611e7bd7764006a11eb35', 'testadmin', '9adcb29710e807607b683f62e555c22dc5659713', '男', '0', null, '15801992799', 'bijinshu@163.com', '0', null, 'testadmin', '2016-01-05 18:44:49', '2016-01-05 18:44:49', '');
INSERT INTO `rm_user` VALUES ('16dddcd66c4611e7bd7764006a11eb35', 'testroot', '9adcb29710e807607b683f62e555c22dc5659713', '男', '0', null, '15801992799', 'bijinshu@163.com', '0', null, 'testroot', '2016-01-05 18:44:49', '2016-01-05 18:44:49', '');
INSERT INTO `rm_user` VALUES ('16dddcff6c4611e7bd7764006a11eb35', '毕金书', '9adcb29710e807607b683f62e555c22dc5659713', '男', '1', null, '15882402032', 'bijinshu@126.com', '0', null, '毕金书', '2016-01-05 18:44:49', '2017-07-18 09:46:06', '');
INSERT INTO `rm_user` VALUES ('f7b362daf90347b4835831a820cfecde', 'test', '9adcb29710e807607b683f62e555c22dc5659713', '女', '0', '都是', '15801992799', 'bijs@axon.com.cn', '98455469', null, '谁看', '2017-07-20 15:23:29', '2017-07-20 15:23:29', '');

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

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
INSERT INTO `sys_metadata` VALUES ('9', '零售', 'TradeType', '交易类型', '2017-07-18 15:14:26');
