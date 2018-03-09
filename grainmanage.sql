/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : grainmanage

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2018-03-09 14:45:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `bm_company`
-- ----------------------------
DROP TABLE IF EXISTS `bm_company`;
CREATE TABLE `bm_company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '公司编号',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `Name` varchar(60) NOT NULL DEFAULT '' COMMENT '公司名称',
  `Address` varchar(200) NOT NULL DEFAULT '' COMMENT '公司地址',
  `ImgName` varchar(60) NOT NULL DEFAULT '' COMMENT '图片名称',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_userid` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_company
-- ----------------------------
INSERT INTO `bm_company` VALUES ('1', '1', '八集粮食收购', '八集街', 'c7aaa3434441933a0965123b37d0407f.jpg', '2018-03-06 15:05:35', '2018-03-06 18:22:20');
INSERT INTO `bm_company` VALUES ('6', '2', '泗阳粮食收购总代理', '泗阳农场90号', 'a081c5bccc318b3c1e41891274563af5.jpg', '2018-03-06 16:23:10', null);

-- ----------------------------
-- Table structure for `bm_contact`
-- ----------------------------
DROP TABLE IF EXISTS `bm_contact`;
CREATE TABLE `bm_contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompId` smallint(6) NOT NULL DEFAULT '0' COMMENT '公司编号',
  `ContactName` varchar(40) NOT NULL COMMENT '客户名称',
  `Mobile` char(11) NOT NULL DEFAULT '' COMMENT '手机',
  `Weixin` varchar(60) NOT NULL DEFAULT '' COMMENT '微信号',
  `QQ` varchar(20) NOT NULL DEFAULT '' COMMENT 'QQ',
  `Email` varchar(64) NOT NULL DEFAULT '' COMMENT '邮箱',
  `Address` varchar(100) NOT NULL DEFAULT '' COMMENT '地址',
  `ImgName` varchar(60) NOT NULL DEFAULT '' COMMENT '图片名称',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '附加描述',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ContactName` (`ContactName`,`Mobile`,`CompId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_contact
-- ----------------------------
INSERT INTO `bm_contact` VALUES ('1', '1', '张海川', '15801992799', '', '914023961', 'bijinshu@163.com', '江苏省南京市雨花台区花神大道', '', '', '1', '2016-01-05 18:44:49', '2018-03-02 10:10:42');
INSERT INTO `bm_contact` VALUES ('2', '1', '李玉飞', '15801992799', '', '914023961', 'bijinshu@163.com', '江苏省南京市雨花台区软件大道119号', '', '', '1', '2016-01-05 18:44:49', '2018-01-04 20:10:47');
INSERT INTO `bm_contact` VALUES ('3', '1', '王亮亮', '15801992799', '', '914023961', 'bijinshu@163.com', '李祠堂', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 17:07:42');
INSERT INTO `bm_contact` VALUES ('4', '1', '张思贤', '15801992799', '', '914023961', 'bijinshu@163.com', '六塘', '', '', '1', '2016-01-05 18:44:49', '2016-05-17 18:01:29');
INSERT INTO `bm_contact` VALUES ('5', '1', '刘江', '15801992799', '', '914023961', 'bijinshu@163.com', '泓北', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 16:36:18');
INSERT INTO `bm_contact` VALUES ('6', '1', '鲍菲菲', '15801992799', '', '914023961', 'bijinshu@163.com', '大石渡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('7', '1', '成杰', '15801992799', '', '914023961', 'bijinshu@163.com', '芦东', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 16:59:38');
INSERT INTO `bm_contact` VALUES ('8', '1', '陈千业', '15801992799', '', '914023961', 'bijinshu@163.com', '董荡', '', '', '1', '2016-01-05 18:44:49', '2016-04-05 17:28:26');
INSERT INTO `bm_contact` VALUES ('9', '1', '齐昊', '15801992799', '', '914023961', 'bijinshu@163.com', '朱圩', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('10', '1', '任思', '15801992799', '', '914023961', 'bijinshu@163.com', '刘庄', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('11', '1', '贾亮', '15801992799', '', '914023961', 'bijinshu@163.com', '张刘', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('12', '1', '何远', '15801992799', '', '914023961', 'bijinshu@163.com', '育红', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('13', '1', '文一毫', '15801992799', '', '914023961', 'bijinshu@163.com', '河东', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('14', '1', '鲁云', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('15', '1', '毛强国', '15801992799', '', '914023961', 'bijinshu@163.com', '桥南', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('16', '1', '陈桥锋', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('17', '1', '秦汉', '15801992799', '', '914023961', 'bijinshu@163.com', '葛郑', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('18', '1', '李双江', '15801992799', '', '914023961', 'bijinshu@163.com', '倪荡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('19', '1', '贝乐石', '15801992799', '', '914023961', 'bijinshu@163.com', '马洼', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('20', '1', '关楚生', '15801992799', '', '914023961', 'bijinshu@163.com', '葛荡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('21', '1', '楚博雄', '15801992799', '', '914023961', 'bijinshu@163.com', '八集农科', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('22', '1', '张一凡', '15801992799', '', '914023961', 'bijinshu@163.com', '八集', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('23', '1', '刘玉生', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('24', '1', '吴雪奇', '15801992799', '', '914023961', 'bijinshu@163.com', '桥南', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('25', '1', '赵海', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('26', '1', '江涛', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('27', '1', '萧见浪', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('28', '1', '殷了', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('29', '1', '薛子琼', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);

-- ----------------------------
-- Table structure for `bm_order`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order`;
CREATE TABLE `bm_order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Mobile` varchar(11) NOT NULL COMMENT '手机号码',
  `Address` varchar(200) NOT NULL DEFAULT '' COMMENT '地址',
  `UserId` int(11) NOT NULL DEFAULT '0' COMMENT '用户编号',
  `CompId` int(11) NOT NULL DEFAULT '0' COMMENT '店铺编号',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:待发送 1:待接单 2:已接单 3:交易成功 4:交易失败',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `AcceptedAt` datetime DEFAULT NULL COMMENT '接单时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order
-- ----------------------------

-- ----------------------------
-- Table structure for `bm_order_detail`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order_detail`;
CREATE TABLE `bm_order_detail` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OrderId` int(10) unsigned NOT NULL COMMENT '订单编号',
  `ProductId` int(11) NOT NULL COMMENT '产品编号',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `Num` decimal(20,2) NOT NULL COMMENT '数量',
  `TotalMoney` decimal(20,2) NOT NULL COMMENT '总价',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order_detail
-- ----------------------------

-- ----------------------------
-- Table structure for `bm_product`
-- ----------------------------
DROP TABLE IF EXISTS `bm_product`;
CREATE TABLE `bm_product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompId` int(11) NOT NULL COMMENT '店铺Id',
  `Name` varchar(20) NOT NULL COMMENT '产品名称',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：离线 1：在线',
  `Source` smallint(6) NOT NULL COMMENT '来源/归属( 0：店铺产品 1：系统产品)',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  `ModifiedBy` int(11) DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_name` (`Name`,`CompId`,`Source`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_product
-- ----------------------------
INSERT INTO `bm_product` VALUES ('1', '0', '小麦', '1.0400', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('2', '0', '黄豆', '1.3000', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('3', '0', '大稻', '1.2600', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('4', '0', '燕麦', '1.3000', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('5', '0', '玉米', '1.2050', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('6', '0', '花生', '2.4450', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('7', '0', '菜籽', '2.2450', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('8', '0', '小稻', '1.2250', '', '1', '1', '2018-02-13 15:17:04', '1', '2018-03-01 17:27:25', '1');
INSERT INTO `bm_product` VALUES ('9', '1', '小麦', '1.0400', '', '1', '0', '2018-03-07 13:07:13', '1', '2018-03-07 14:36:24', '1');
INSERT INTO `bm_product` VALUES ('21', '1', '大稻', '1.2600', '', '1', '0', '2018-03-07 14:47:51', '1', '2018-03-07 14:48:24', '1');
INSERT INTO `bm_product` VALUES ('22', '1', '小稻', '1.2250', '', '1', '0', '2018-03-07 14:48:01', '1', null, null);
INSERT INTO `bm_product` VALUES ('23', '6', '玉米', '1.2050', '', '1', '0', '2018-03-07 14:48:47', '1', null, null);

-- ----------------------------
-- Table structure for `bm_trade`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade`;
CREATE TABLE `bm_trade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompId` int(11) NOT NULL COMMENT '店铺Id',
  `ContactId` int(11) NOT NULL COMMENT '客户Id',
  `ContactName` varchar(20) NOT NULL DEFAULT '' COMMENT '联系人名称',
  `ProductId` int(11) NOT NULL COMMENT '作物名称',
  `ProductName` varchar(20) NOT NULL DEFAULT '' COMMENT '产品名称',
  `Price` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '计划价格',
  `Weight` decimal(20,2) NOT NULL DEFAULT '0.00' COMMENT '重量',
  `ActualMoney` decimal(20,2) NOT NULL DEFAULT '0.00' COMMENT '成交价格',
  `TradeType` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：收购: 1：出售',
  `Position` varchar(60) NOT NULL DEFAULT '',
  `PositionDesc` varchar(80) NOT NULL DEFAULT '',
  `Remark` varchar(6000) NOT NULL DEFAULT '',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade
-- ----------------------------
INSERT INTO `bm_trade` VALUES ('1', '1', '1', '张海川', '3', '大稻', '1.2600', '612.00', '679.32', '0', '', '', '', '1', '2007-11-02 14:47:03', '2018-02-28 18:06:50');
INSERT INTO `bm_trade` VALUES ('3', '1', '3', '王亮亮', '8', '小稻', '1.3300', '612.00', '813.96', '1', '', '', '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('5', '1', '5', '刘江', '7', '菜籽', '1.7000', '612.00', '1040.40', '1', '', '', '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('7', '1', '7', '成杰', '5', '玉米', '1.2050', '612.00', '737.46', '0', '', '', '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('9', '1', '9', '齐昊', '8', '小稻', '1.2250', '612.00', '749.70', '1', '', '', '', '1', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('11', '1', '11', '贾亮', '7', '菜籽', '2.2450', '612.00', '1373.94', '1', '', '', '', '1', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('13', '1', '13', '文一毫', '5', '玉米', '1.0050', '812.00', '816.06', '0', '', '', '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('15', '1', '15', '毛强国', '8', '小稻', '1.1650', '612.00', '712.98', '0', '', '', '', '1', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('17', '1', '17', '秦汉', '7', '菜籽', '1.8250', '612.00', '1116.90', '1', '', '', '', '1', '2007-06-01 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('19', '1', '19', '贝乐石', '3', '大稻', '1.2600', '612.00', '771.12', '0', '', '', '', '1', '2005-07-02 13:47:03', null);
INSERT INTO `bm_trade` VALUES ('21', '1', '21', '楚博雄', '5', '玉米', '1.1450', '612.00', '700.74', '0', '', '', '', '1', '2004-09-02 08:50:00', null);
INSERT INTO `bm_trade` VALUES ('23', '1', '23', '刘玉生', '8', '小稻', '1.2100', '612.00', '740.52', '0', '', '', '', '1', '2006-01-02 09:50:26', null);
INSERT INTO `bm_trade` VALUES ('25', '1', '1', '张海川', '7', '菜籽', '1.8700', '612.00', '1144.44', '0', '', '', '', '1', '2010-08-04 18:45:43', null);
INSERT INTO `bm_trade` VALUES ('27', '1', '2', '李玉飞', '5', '玉米', '1.1100', '612.00', '679.32', '1', '', '', '', '1', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('29', '1', '2', '李玉飞', '8', '小稻', '1.3300', '632.00', '840.56', '0', '', '', '', '1', '2010-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('31', '1', '18', '李双江', '7', '菜籽', '1.7000', '612.00', '1040.40', '1', '', '', '', '1', '2010-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('33', '1', '16', '陈桥锋', '5', '玉米', '1.2050', '612.00', '737.46', '1', '', '', '', '1', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('35', '1', '7', '成杰', '8', '小稻', '1.2250', '812.00', '994.70', '0', '', '', '', '1', '2005-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('37', '1', '15', '毛强国', '7', '菜籽', '2.2450', '612.00', '1373.94', '1', '', '', '', '1', '2006-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('39', '1', '4', '张思贤', '1', '小麦', '1.6000', '560.00', '582.40', '1', '', '', '', '1', '2018-02-28 14:41:18', '2018-02-28 20:26:46');
INSERT INTO `bm_trade` VALUES ('40', '1', '1', '张海川', '1', '小麦', '1.0400', '50.00', '52.00', '0', '', '', '', '1', '2018-02-28 15:07:01', '2018-03-06 10:14:53');
INSERT INTO `bm_trade` VALUES ('46', '1', '1', '张海川', '1', '小麦', '1.0460', '555.00', '580.53', '0', '', '', '', '1', '2018-02-28 19:38:31', null);
INSERT INTO `bm_trade` VALUES ('47', '1', '1', '张海川', '3', '大稻', '1.2600', '655.00', '825.30', '0', '', '', '', '1', '2018-03-01 17:36:26', null);
INSERT INTO `bm_trade` VALUES ('48', '1', '1', '张海川', '5', '玉米', '1.2050', '600.00', '723.00', '0', '', '', '', '1', '2018-03-02 10:12:34', '2018-03-02 14:39:40');
INSERT INTO `bm_trade` VALUES ('49', '1', '1', '张海川', '2', '黄豆', '1.3000', '100.00', '130.00', '0', '', '', '', '1', '2018-03-02 11:59:27', '2018-03-02 14:35:50');
INSERT INTO `bm_trade` VALUES ('50', '1', '3', '王亮亮', '7', '菜籽', '2.2450', '500.00', '1122.50', '0', '', '', '', '1', '2018-03-02 12:05:03', '2018-03-02 14:31:40');
INSERT INTO `bm_trade` VALUES ('51', '1', '6', '鲍菲菲', '3', '大稻', '1.2600', '900.00', '1134.00', '0', '', '', '', '1', '2018-03-02 12:08:51', null);
INSERT INTO `bm_trade` VALUES ('52', '1', '7', '成杰', '2', '黄豆', '1.3000', '700.00', '910.00', '0', '', '', '', '1', '2018-03-02 12:08:51', null);
INSERT INTO `bm_trade` VALUES ('53', '1', '3', '王亮亮', '1', '小麦', '1.0400', '900.00', '936.00', '0', '', '', '', '1', '2018-03-02 16:16:35', null);
INSERT INTO `bm_trade` VALUES ('54', '1', '6', '鲍菲菲', '22', '小稻', '2.6000', '600.00', '1560.00', '0', '', '', '', '1', '2018-03-07 15:07:22', '2018-03-07 19:26:29');
INSERT INTO `bm_trade` VALUES ('55', '1', '13', '文一毫', '23', '玉米', '1.2050', '367.00', '442.24', '0', '', '', '', '1', '2018-03-07 15:08:45', null);
INSERT INTO `bm_trade` VALUES ('56', '1', '15', '毛强国', '9', '小麦', '1.0400', '600.00', '624.00', '0', '', '', '', '1', '2018-03-07 15:09:06', null);
INSERT INTO `bm_trade` VALUES ('57', '1', '1', '张海川', '9', '小麦', '1.0400', '900.00', '936.00', '0', '', '', '', '1', '2018-03-08 10:10:36', '2018-03-08 11:58:02');
INSERT INTO `bm_trade` VALUES ('60', '1', '0', '毕建昌', '9', '小麦', '1.5000', '900.00', '939.00', '0', '', '', '', '1', '2018-03-08 12:01:48', '2018-03-08 17:43:56');

-- ----------------------------
-- Table structure for `log_action`
-- ----------------------------
DROP TABLE IF EXISTS `log_action`;
CREATE TABLE `log_action` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(11) unsigned NOT NULL COMMENT '用户Id',
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户名称',
  `Path` varchar(200) NOT NULL DEFAULT '' COMMENT '动作名称',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '访问端IP',
  `Method` varchar(6) NOT NULL DEFAULT '' COMMENT '请求方法',
  `Status` varchar(60) NOT NULL DEFAULT '' COMMENT '状态',
  `Para` varchar(1200) NOT NULL DEFAULT '' COMMENT '请求参数',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `StartTime` datetime NOT NULL COMMENT '调用开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '调用结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=439 DEFAULT CHARSET=utf8 COMMENT='访问日志';

-- ----------------------------
-- Records of log_action
-- ----------------------------

-- ----------------------------
-- Table structure for `log_exception`
-- ----------------------------
DROP TABLE IF EXISTS `log_exception`;
CREATE TABLE `log_exception` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Path` varchar(200) NOT NULL DEFAULT '' COMMENT '调用路径',
  `Para` text NOT NULL COMMENT '请求参数',
  `Message` varchar(600) NOT NULL DEFAULT '' COMMENT '描述',
  `StackTrace` text COMMENT '堆栈信息',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '客户端调用IP',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_exception
-- ----------------------------
INSERT INTO `log_exception` VALUES ('34', '/Contact/Edit', '{\"Name\":\"八集粮食收购\",\"Address\":\"八集街\"}', 'Sequence contains no elements\r\n', '   at System.Linq.Enumerable.First[TSource](IEnumerable`1 source)\r\n   at lambda_method(Closure , QueryContext )\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass17_1`1.<CompileQueryCore>b__0(QueryContext qc)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.Execute[TResult](Expression query)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.Execute[TResult](Expression expression)\r\n   at System.Linq.Queryable.First[TSource](IQueryable`1 source)\r\n   at GrainManage.Web.Controllers.ContactController.Edit(ContactDto input) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Controllers\\ContactController.cs:line 103\r\n   at lambda_method(Closure , Object , Object[] )\r\n   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()', '10.10.133.108', '2018-03-06 17:31:26');
INSERT INTO `log_exception` VALUES ('35', '/Trade/Edit', '{\"Id\":\"0\",\"ContactId\":\"3\",\"ContactName\":\"王亮亮\",\"ProductId\":\"21\",\"ProductName\":\"大稻\",\"Price\":\"1.26\",\"Weight\":\"900\",\"TradeType\":\"0\",\"ActualMoney\":\"1134.00\",\"Remark\":\"\"}', 'Object reference not set to an instance of an object.\r\n', '   at GrainManage.Web.Controllers.TradeController.Edit(TradeDto input) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Controllers\\TradeController.cs:line 103\r\n   at lambda_method(Closure , Object , Object[] )\r\n   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()', '10.10.133.108', '2018-03-08 10:05:08');

-- ----------------------------
-- Table structure for `log_job`
-- ----------------------------
DROP TABLE IF EXISTS `log_job`;
CREATE TABLE `log_job` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `JobName` varchar(20) NOT NULL COMMENT '任务名称',
  `Status` varchar(20) DEFAULT NULL COMMENT '状态',
  `Remark` varchar(600) DEFAULT NULL COMMENT '说明',
  `StartTime` datetime NOT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_job
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
  `Level` smallint(6) NOT NULL COMMENT '级别-只有超过该级别的用户才可查看该条记录',
  `TypeId` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：后台登录 1：微信端登录',
  `CreatedAt` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=117 DEFAULT CHARSET=utf8 COMMENT='后台登录日志';

-- ----------------------------
-- Records of log_login
-- ----------------------------
INSERT INTO `log_login` VALUES ('104', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-02 14:23:34');
INSERT INTO `log_login` VALUES ('105', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-02 16:15:59');
INSERT INTO `log_login` VALUES ('106', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-05 14:10:24');
INSERT INTO `log_login` VALUES ('107', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-06 10:01:07');
INSERT INTO `log_login` VALUES ('108', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-06 14:51:15');
INSERT INTO `log_login` VALUES ('109', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-06 16:03:45');
INSERT INTO `log_login` VALUES ('110', 'testadmin', '10.10.133.108', '成功', '80', '0', '2018-03-06 16:05:14');
INSERT INTO `log_login` VALUES ('111', 'testadmin', '10.10.133.108', '成功', '80', '0', '2018-03-06 16:06:28');
INSERT INTO `log_login` VALUES ('112', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-06 17:23:03');
INSERT INTO `log_login` VALUES ('113', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-07 11:03:58');
INSERT INTO `log_login` VALUES ('114', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-08 09:30:13');
INSERT INTO `log_login` VALUES ('115', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-09 14:28:15');
INSERT INTO `log_login` VALUES ('116', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-03-09 14:39:08');

-- ----------------------------
-- Table structure for `rm_address`
-- ----------------------------
DROP TABLE IF EXISTS `rm_address`;
CREATE TABLE `rm_address` (
  `Url` varchar(255) NOT NULL DEFAULT '' COMMENT '地址',
  `IsWatching` tinyint(6) NOT NULL COMMENT '0:不监控 1:监控 ',
  `IsValid` tinyint(6) NOT NULL COMMENT '0:无效地址 1:有效地址',
  `TypeId` smallint(6) NOT NULL COMMENT '0:一般地址 1:公共地址（免权限验证）',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '说明',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Url`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地址监控配置表';

-- ----------------------------
-- Records of rm_address
-- ----------------------------
INSERT INTO `rm_address` VALUES ('/Contact/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Home/Index', '0', '1', '1', '', '2018-02-11 16:43:23', null);
INSERT INTO `rm_address` VALUES ('/Role/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/ChangePwd', '1', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Info', '0', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Register', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/ResetPwd', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/SignIn', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/SignOut', '1', '1', '1', '', '2018-02-11 16:43:27', null);

-- ----------------------------
-- Table structure for `rm_role`
-- ----------------------------
DROP TABLE IF EXISTS `rm_role`;
CREATE TABLE `rm_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL COMMENT '角色名称',
  `Auths` varchar(1600) NOT NULL DEFAULT '' COMMENT '权限列表',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='系统角色，每个子系统都应该建立一个对应角色';

-- ----------------------------
-- Records of rm_role
-- ----------------------------
INSERT INTO `rm_role` VALUES ('1', '超级管理员', '', '100', '开发者专用用户', '2016-03-05 18:09:24');
INSERT INTO `rm_role` VALUES ('2', '普通用户', '', '80', '普通注册用户或关注公众号的用户', '2016-03-05 18:09:47');
INSERT INTO `rm_role` VALUES ('3', '店铺管理员', 'contact.add,contact,contact.view', '80', '管理店铺下的员工', '2017-07-19 18:27:34');
INSERT INTO `rm_role` VALUES ('4', '系统管理员', 'contact,contact.add,contact.delete,contact.edit,contact.trade,contact.view,employee,employee.add,employee.delete,employee.edit,employee.view,home,home.edit,log,log.action,log.action.view,log.exception,log.exception.delete,log.exception.view,log.job,log.job.view,log.login,log.login.view,order,order.add,order.delete,order.edit,order.view,product,product.add,product.delete,product.edit,product.view,system,system.role,system.role.add,system.role.delete,system.role.edit,system.role.view,system.user,system.user.add,system.user.delete,system.user.edit,system.user.view,trade,trade.add,trade.delete,trade.edit,trade.view', '90', '管理系统用户', '2017-08-29 15:07:11');
INSERT INTO `rm_role` VALUES ('5', '店铺员工', '', '30', '店铺的员工，协助店铺管理员工作', '2018-02-26 11:31:05');

-- ----------------------------
-- Table structure for `rm_user`
-- ----------------------------
DROP TABLE IF EXISTS `rm_user`;
CREATE TABLE `rm_user` (
  `Id` int(32) NOT NULL AUTO_INCREMENT COMMENT '全局唯一编号',
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户名称、登录名称',
  `CompId` int(11) NOT NULL COMMENT '公司编号',
  `Pwd` varchar(42) NOT NULL DEFAULT '' COMMENT '密码',
  `Gender` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:男 1:女',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:禁用 1:启用',
  `RealName` varchar(20) NOT NULL DEFAULT '' COMMENT '真实姓名',
  `Mobile` char(11) NOT NULL DEFAULT '' COMMENT '手机号码',
  `Email` varchar(64) NOT NULL DEFAULT '' COMMENT '邮箱',
  `QQ` varchar(20) NOT NULL DEFAULT '' COMMENT 'QQ',
  `Weixin` varchar(20) NOT NULL DEFAULT '' COMMENT '微信',
  `Roles` varchar(200) NOT NULL DEFAULT '' COMMENT '角色',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者： -1:系统注册 >0 表内其它用户',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '上次活动时间',
  PRIMARY KEY (`Id`),
  KEY `uq_user_name` (`UserName`),
  KEY `index_mobile` (`Mobile`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of rm_user
-- ----------------------------
INSERT INTO `rm_user` VALUES ('1', 'bijinshu', '1', '9adcb29710e807607b683f62e555c22dc5659713', '0', '1', '毕金书', '15801992799', '914023961@qq.com', '914023961', 'bijinshu', '1', 'bijinshu', '2016-01-05 18:44:49', '0', '2018-03-06 16:05:06');
INSERT INTO `rm_user` VALUES ('2', 'testadmin', '6', '9adcb29710e807607b683f62e555c22dc5659713', '0', '1', '管理员', '15801992799', 'bijinshu@163.com', '12863589', 'bijinshu', '3', '555', '2016-01-05 18:44:49', '1', '2018-03-06 17:21:23');
INSERT INTO `rm_user` VALUES ('3', 'testroot', '0', '9adcb29710e807607b683f62e555c22dc5659713', '1', '1', '管理员', '15801992799', 'bijinshu@163.com', '96584258', '', '2', 'testroot', '2016-01-05 18:44:49', '1', '2018-02-11 10:33:42');
INSERT INTO `rm_user` VALUES ('15', 'test', '1', '9adcb29710e807607b683f62e555c22dc5659713', '0', '1', '松岛枫', '15657476162', 'sdfd@xon.com', '95481563', 'bijinshusdlf', '5', '', '2018-03-02 10:12:34', '1', '2018-03-02 10:15:00');

-- ----------------------------
-- Table structure for `rm_white_ip`
-- ----------------------------
DROP TABLE IF EXISTS `rm_white_ip`;
CREATE TABLE `rm_white_ip` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IP` varchar(16) NOT NULL DEFAULT '' COMMENT 'IP',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='ip白名单';

-- ----------------------------
-- Records of rm_white_ip
-- ----------------------------
INSERT INTO `rm_white_ip` VALUES ('1', '10.10.133.108', '2018-02-11 16:42:31');
